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
    public class NewTopicLinkNotificationEventHandler : INotificationHandler<NewTopicLinkEvent>
    {
        public ILogger<NewTopicLinkNotificationEventHandler> _logger;

        public NewTopicLinkNotificationEventHandler(ILogger<NewTopicLinkNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewTopicLinkEvent notification, CancellationToken cancellationToken)
        {
            string newLink = notification
                .Entity
                .Link
                .Value;

            _logger.LogInformation("Update link for topic. Old - {0}, new - {1}", notification.OldValue, newLink);

            return Task.CompletedTask;
        }
    }
}
