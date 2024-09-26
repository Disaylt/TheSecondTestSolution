using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Domain.Events
{
    public class NewTopicEvent : BaseTopicEvent
    {
        public NewTopicEvent(TopicEntity entity) : base(entity)
        {
        }
    }
}
