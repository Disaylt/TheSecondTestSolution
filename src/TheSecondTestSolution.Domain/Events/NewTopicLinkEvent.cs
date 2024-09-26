using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.ValueObjects;

namespace TheSecondTestSolution.Domain.Events
{
    public class NewTopicLinkEvent : BaseTopicEvent
    {
        public LinkValueObject OldValue { get; }
        public NewTopicLinkEvent(TopicEntity entity, LinkValueObject oldValue) : base(entity)
        {
            OldValue = oldValue;
        }
    }
}
