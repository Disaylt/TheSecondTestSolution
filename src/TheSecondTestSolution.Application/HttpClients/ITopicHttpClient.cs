using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;

namespace TheSecondTestSolution.Application.HttpClients
{
    public interface ITopicHttpClient
    {
        Task<IReadOnlyCollection<int>> GetIdsAsync();
        Task<TopicWebModel> GetByIdAsync(int id);
    }
}
