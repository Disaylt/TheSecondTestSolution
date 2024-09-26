using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Events;

namespace TheSecondTestSolution.Application.DomainEventHandlers
{
    public class NewTopicTypeNotificationEventHandler : INotificationHandler<NewTopicTypeEvent>
    {
        public ILogger<NewTopicTypeNotificationEventHandler> _logger;

        public NewTopicTypeNotificationEventHandler(ILogger<NewTopicTypeNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewTopicTypeEvent notification, CancellationToken cancellationToken)
        {
            string newValue = notification
                .Entity
                .Type;

            _logger.LogInformation("Update link for topic. Old - {0}, new - {1}", notification.OldValue, newValue);

            return Task.CompletedTask;
        }
    }
}
