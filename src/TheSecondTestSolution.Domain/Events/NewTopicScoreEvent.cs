using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.ValueObjects;

namespace TheSecondTestSolution.Domain.Events
{
    public class NewTopicScoreEvent : BaseTopicEvent
    {
        public ScoreValueObject OldValue { get; }
        public NewTopicScoreEvent(TopicEntity entity, ScoreValueObject oldValue) : base(entity)
        {
            OldValue = oldValue;
        }
    }
}
