using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Commands;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Queries;

namespace TheSecondTestSolution.Processor.Services
{
    internal class TopicUploadingService : ITopicUploadingService
    {
        //Чтобы не получить 429 ограничеваем скачивание топиков.
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(5);
        private readonly IMediator _mediator;

        public TopicUploadingService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task RunAsync()
        {
            GetTopicIdsFromWebApiQuery topicIdsQuery = new GetTopicIdsFromWebApiQuery();
            IReadOnlyCollection<int> topicIds = await _mediator.Send(topicIdsQuery);

            List<Task<TopicDto?>> tasks = new List<Task<TopicDto?>>();

            foreach (int id in topicIds.Take(20))
            {
                await _semaphore.WaitAsync();

                GetTopicFromWebApiQuery topicQuery = new GetTopicFromWebApiQuery { Id = id };

                Task<TopicDto?> task = Task.Run(async () =>
                {
                    try
                    {
                        TopicDto? topic = await _mediator.Send(topicQuery);
                        return topic;
                    }
                    finally
                    {
                        _semaphore.Release();
                    }
                });

                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            List<TopicDto> validTopics = new List<TopicDto>();

            foreach(Task<TopicDto?> topic in tasks)
            {
                if(topic.Result != null)
                {
                    validTopics.Add(topic.Result);
                }
            }

            AddTopicsCommand addTopicCommand = new AddTopicsCommand { Topics = validTopics };
            await _mediator.Send(addTopicCommand);
        }
    }
}
