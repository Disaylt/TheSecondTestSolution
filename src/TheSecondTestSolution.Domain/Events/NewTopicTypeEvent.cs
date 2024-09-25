using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Domain.Events
{
    public class NewTopicTypeEvent : BaseTopicEvent
    {
        public string Type { get; }
        public NewTopicTypeEvent(TopicEntity entity, string type) : base(entity)
        {
            Type = type;
        }
    }
}
