using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Events;

namespace TheSecondTestSolution.Application.DomainEventHandlers
{
    public class NewTopicNotificationEventHandler : INotificationHandler<NewTopicEvent>
    {
        public ILogger<NewTopicNotificationEventHandler> _logger;

        public NewTopicNotificationEventHandler(ILogger<NewTopicNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewTopicEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create new topic - {0}", JsonSerializer.Serialize(notification.Entity));

            return Task.CompletedTask;
        }
    }
}
