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
    public class NewTopicTitleNotificationEventHandler : INotificationHandler<NewTopicTitleEvent>
    {
        public ILogger<NewTopicTitleNotificationEventHandler> _logger;

        public NewTopicTitleNotificationEventHandler(ILogger<NewTopicTitleNotificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewTopicTitleEvent notification, CancellationToken cancellationToken)
        {
            string newValue = notification
                .Entity
                .Title;

            _logger.LogInformation("Update link for topic. Old - {0}, new - {1}", notification.OldValue, newValue);

            return Task.CompletedTask;
        }
    }
}
