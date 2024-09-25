using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Infrastructure.Database
{
    public class TopicDbContext : DbContext, IUnitOfWork, IDisposable, IAsyncDisposable
    {
        public DbSet<TopicEntity> Topics { get; set; } = null!;

        private readonly IMediator _mediator;
        private IDbContextTransaction? _transaction;

        public bool HasTransaction => _transaction != null;

        public TopicDbContext(DbContextOptions<TopicDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("topics");

            base.OnModelCreating(modelBuilder);
        }

        public async Task<Guid> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
            {
                return _transaction.TransactionId;
            }

            _transaction = await Database.BeginTransactionAsync(cancellationToken);

            return _transaction.TransactionId;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) throw new ArgumentNullException(nameof(_transaction));

            try
            {
                await SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) return;

            try
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                DisposeTransaction();
            }
        }


        public override void Dispose()
        {
            DisposeTransaction();
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            DisposeTransaction();
            return base.DisposeAsync();
        }

        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
