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
    public class NewTopicScoreNotificationEventHandler : INotificationHandler<NewTopicScoreEvent>
    {
        public ILogger<NewTopicScoreNotificationEventHandler> _logger;

        public NewTopicScoreNotificationEventHandler(ILogger<NewTopicScoreNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewTopicScoreEvent notification, CancellationToken cancellationToken)
        {
            int newValue = notification
                .Entity
                .Score
                .Value;

            _logger.LogInformation("Update link for topic. Old - {0}, new - {1}", notification.OldValue, newValue);

            return Task.CompletedTask;
        }
    }
}
