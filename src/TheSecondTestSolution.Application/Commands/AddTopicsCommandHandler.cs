using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Services;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Application.Commands
{
    public class AddTopicsCommandHandler : IRequestHandler<AddTopicsCommand, Unit>
    {
        private readonly IRepository<TopicEntity> _topicRepository;
        private readonly ITopicService _topicService;
        private readonly ICacheRepository<TopicDto> _cacheRepository;

        public AddTopicsCommandHandler(IRepository<TopicEntity> topicRepository,
            ITopicService topicService,
            ICacheRepository<TopicDto> cacheRepository)
        {
            _topicRepository = topicRepository;
            _topicService = topicService;
            _cacheRepository = cacheRepository;
        }

        public async Task<Unit> Handle(AddTopicsCommand request, CancellationToken cancellationToken)
        {
            foreach (var topic in request.Topics)
            {
                TopicEntity entity = _topicService.Create(topic);
                await _topicRepository.AddAsync(entity, cancellationToken);
            }

            await _topicRepository
                .UnitOfWork
                .SaveEntitiesAsync(cancellationToken);

            await _cacheRepository.DeleteAsync(Constants.AllCacheKey);

            return Unit.Value;
        }
    }
}
