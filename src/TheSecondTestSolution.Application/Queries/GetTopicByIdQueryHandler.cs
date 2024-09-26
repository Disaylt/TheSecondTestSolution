using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Utilities;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Repositories;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicByIdQueryHandler : IRequestHandler<GetTopicByIdQuery, TopicDto>
    {
        private readonly ICacheRepository<TopicDto> _cacheRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly ITopicMapper _topicMapper;

        public GetTopicByIdQueryHandler(ICacheRepository<TopicDto> cacheRepository, 
            ITopicRepository topicRepository,
            ITopicMapper topicMapper)
        {
            _cacheRepository = cacheRepository;
            _topicRepository = topicRepository;
            _topicMapper = topicMapper;
        }

        public async Task<TopicDto> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken)
        {
            string key = request.Id.ToString();
            TopicDto? cacheTopic = await _cacheRepository.GetAsync(key);

            if(cacheTopic == null)
            {
                TopicEntity entity = await _topicRepository.FindByIdRequiredAsync(request.Id);
                TopicDto topic = _topicMapper.FromEntity(entity);
                await _cacheRepository.SetAsync(key, topic, TimeSpan.FromMinutes(5));

                return topic;
            }

            return cacheTopic;
        }
    }
}
