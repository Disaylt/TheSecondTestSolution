using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Domain.Repositories
{
    public interface ITopicRepository : IRepository<TopicEntity>
    {
        Task<TopicEntity> FindByIdRequiredAsync(int id);
        Task<IEnumerable<TopicEntity>> GetAllAsync();
    }
}
