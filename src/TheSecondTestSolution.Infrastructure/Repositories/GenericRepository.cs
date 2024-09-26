using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Seed;
using TheSecondTestSolution.Infrastructure.Database;

namespace TheSecondTestSolution.Infrastructure.Repositories
{
    internal class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        public IUnitOfWork UnitOfWork => _context;

        protected readonly TopicDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TopicDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            EntityEntry<T> entityEntry = await _dbSet.AddAsync(entity, cancellationToken);

            return entityEntry.Entity;
        }

        public virtual Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);

            return Task.CompletedTask;
        }

        public virtual IQueryable<T> GetAsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            entity.RefreshUpdateDate();
            EntityEntry<T> entityEntry = _dbSet.Update(entity);

            return Task.FromResult(entityEntry.Entity);
        }

        public virtual async Task<bool> ContainsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
