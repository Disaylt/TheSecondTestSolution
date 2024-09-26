using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Domain.Events
{
    public class NewTopicTitleEvent : BaseTopicEvent
    {
        public string OldValue { get; }
        public NewTopicTitleEvent(TopicEntity entity, string oldValue) : base(entity)
        {
            OldValue = oldValue;
        }
    }
}
