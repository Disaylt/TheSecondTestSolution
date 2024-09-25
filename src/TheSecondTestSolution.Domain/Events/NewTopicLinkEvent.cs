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
        public LinkValueObject OldLink { get; }
        public NewTopicLinkEvent(TopicEntity entity, LinkValueObject oldLink) : base(entity)
        {
            OldLink = oldLink;
        }
    }
}
