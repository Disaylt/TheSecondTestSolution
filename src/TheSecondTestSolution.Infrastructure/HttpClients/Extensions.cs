using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Infrastructure.HttpClients
{
    internal static class Extensions
    {
        public static async Task<T> ReadFromJsonRequiredAsync<T>(this HttpResponseMessage response)
        {
            return await response.Content.ReadFromJsonAsync<T>()
                ?? throw new HttpRequestException($"Bad convert response body. " +
                $"Url: {response.RequestMessage?.RequestUri};" +
                $"Code: {response.StatusCode};");
        }
    }
}
