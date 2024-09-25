using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Services;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Application.Commands
{
    public class AddTopicCommandHandler : IRequestHandler<AddTopicCommand, Unit>
    {
        private readonly IRepository<TopicEntity> _topicRepository;
        private readonly ITopicService _topicService;

        public AddTopicCommandHandler(IRepository<TopicEntity> topicRepository,
            ITopicService topicService)
        {
            _topicRepository = topicRepository;
            _topicService = topicService;
        }

        public async Task<Unit> Handle(AddTopicCommand request, CancellationToken cancellationToken)
        {
            TopicEntity entity = _topicService.Create(request.Topic);
            await _topicRepository.AddAsync(entity, cancellationToken);

            await _topicRepository
                .UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
