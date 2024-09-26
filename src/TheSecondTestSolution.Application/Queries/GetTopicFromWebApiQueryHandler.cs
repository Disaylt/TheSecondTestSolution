using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.HttpClients;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Utilities;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicFromWebApiQueryHandler : IRequestHandler<GetTopicFromWebApiQuery, TopicDto?>
    {
        private readonly ITopicHttpClient _topicHttpClient;
        private readonly ITopicMapper _topicMapper;

        public GetTopicFromWebApiQueryHandler(ITopicHttpClient topicHttpClient, ITopicMapper topicMapper)
        {
            _topicHttpClient = topicHttpClient;
            _topicMapper = topicMapper;
        }

        public async Task<TopicDto?> Handle(GetTopicFromWebApiQuery request, CancellationToken cancellationToken)
        {
            TopicWebModel web = await _topicHttpClient.GetByIdAsync(request.Id);

            if(_topicMapper.TryFromWeb(web, out TopicDto topic))
            {
                return topic;
            }

            return null;
        }
    }
}
