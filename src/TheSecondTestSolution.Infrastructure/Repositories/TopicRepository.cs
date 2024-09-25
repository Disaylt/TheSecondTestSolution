using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Repositories;
using TheSecondTestSolution.Domain.Seed;
using TheSecondTestSolution.Infrastructure.Database;

namespace TheSecondTestSolution.Infrastructure.Repositories
{
    internal class TopicRepository : GenericRepository<TopicEntity>, ITopicRepository
    {
        public TopicRepository(TopicDbContext context) : base(context)
        {
        }

        public async Task<TopicEntity> FindByIdRequiredAsync(int id)
        {
            return await _dbSet.FindAsync(id)
                ?? throw new RootExeption(HttpStatusCode.NotFound, $"Id - {id} not found.");
        }

        public async Task<IEnumerable<TopicEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
