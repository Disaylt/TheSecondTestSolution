using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Services;
using TheSecondTestSolution.Application.Utilities;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Application.Commands
{
    public class AddTopicCommandHandler : IRequestHandler<AddTopicCommand, TopicDto>
    {
        private readonly IRepository<TopicEntity> _topicRepository;
        private readonly ITopicService _topicService;
        private readonly ICacheRepository<TopicDto> _cacheRepository;
        private readonly ITopicMapper _topicMapper;

        public AddTopicCommandHandler(IRepository<TopicEntity> topicRepository,
            ITopicService topicService,
            ICacheRepository<TopicDto> cacheRepository,
            ITopicMapper topicMapper)
        {
            _topicRepository = topicRepository;
            _topicService = topicService;
            _cacheRepository = cacheRepository;
            _topicMapper = topicMapper;
        }

        public async Task<TopicDto> Handle(AddTopicCommand request, CancellationToken cancellationToken)
        {
            TopicEntity entity = _topicService.Create(request.Topic);
            await _topicRepository.AddAsync(entity, cancellationToken);

            await _topicRepository
                .UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            await _cacheRepository.DeleteRangeAsync(Constants.AllCacheKey);

            return _topicMapper.FromEntity(entity);
        }
    }
}
