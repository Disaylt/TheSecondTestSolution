using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.HttpClients;
using TheSecondTestSolution.Application.Models;

namespace TheSecondTestSolution.Infrastructure.HttpClients
{
    internal class TopicHttpClient : ITopicHttpClient
    {
        private readonly HttpClient _httpClient;

        public TopicHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://hacker-news.firebaseio.com");
        }

        public async Task<TopicWebModel> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"v0/item/{id}.json");
            response.EnsureSuccessStatusCode();

            return await response.ReadFromJsonRequiredAsync<TopicWebModel>();
        }

        public async Task<IReadOnlyCollection<int>> GetIdsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("v0/topstories.json");
            response.EnsureSuccessStatusCode();

            return await response.ReadFromJsonRequiredAsync<List<int>>();
        }
    }
}
