using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Domain.Seed
{
    public interface IRepository<T> where T : class, IEntity
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<T> GetAsQueryable();
        Task<bool> ContainsByIdAsync(int id, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    }
}
