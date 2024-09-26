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
    public class GetTopicsQueryHandler : IRequestHandler<GetTopicsQuery, IEnumerable<TopicDto>>
    {
        private readonly ICacheRepository<TopicDto> _cacheRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly ITopicMapper _topicMapper;

        public GetTopicsQueryHandler(ICacheRepository<TopicDto> cacheRepository,
            ITopicRepository topicRepository,
            ITopicMapper topicMapper)
        {
            _cacheRepository = cacheRepository;
            _topicRepository = topicRepository;
            _topicMapper = topicMapper;
        }

        public async Task<IEnumerable<TopicDto>> Handle(GetTopicsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TopicDto>? cacheTopics = await _cacheRepository.GetRangeAsync(Constants.AllCacheKey);
            
            if (cacheTopics == null)
            {
                IEnumerable<TopicEntity> entities = await _topicRepository.GetAllAsync();
                IEnumerable<TopicDto> topics = entities.Select(_topicMapper.FromEntity);
                await _cacheRepository.SetRangeAsync(Constants.AllCacheKey, topics, TimeSpan.FromMinutes(5));

                return topics;
            }

            return cacheTopics;
        }
    }
}
