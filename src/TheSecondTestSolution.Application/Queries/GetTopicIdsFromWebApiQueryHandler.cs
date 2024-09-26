using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.HttpClients;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicIdsFromWebApiQueryHandler : IRequestHandler<GetTopicIdsFromWebApiQuery, IReadOnlyCollection<int>>
    {
        private readonly ITopicHttpClient _topicHttpClient;

        public GetTopicIdsFromWebApiQueryHandler(ITopicHttpClient topicHttpClient)
        {
            _topicHttpClient = topicHttpClient;
        }

        public Task<IReadOnlyCollection<int>> Handle(GetTopicIdsFromWebApiQuery request, CancellationToken cancellationToken)
        {
            return _topicHttpClient.GetIdsAsync();
        }
    }
}
