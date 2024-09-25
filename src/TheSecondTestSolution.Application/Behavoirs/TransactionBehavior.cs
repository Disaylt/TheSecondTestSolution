using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Commands;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Application.Behavoirs
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork, ILogger<TransactionBehavior<TRequest, TResponse>> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Guid? transactionId = null;

            try
            {
                if (_unitOfWork.HasTransaction)
                {
                    return await next();
                }

                transactionId = await _unitOfWork.BeginTransactionAsync(cancellationToken);

                _logger.LogInformation("Create transaction id - {0}.", transactionId);

                TResponse response = await next();

                await _unitOfWork.CommitAsync(cancellationToken);

                _logger.LogInformation("Transaction id - {0} commited.", transactionId);

                return response;
            }
            catch (Exception ex)
            {
                if (transactionId != null)
                {
                    await _unitOfWork.RollbackAsync(cancellationToken);
                    _logger.LogError(ex, "Error handling transaction id - {0}", transactionId.Value);
                }

                throw;
            }
        }
    }
}
