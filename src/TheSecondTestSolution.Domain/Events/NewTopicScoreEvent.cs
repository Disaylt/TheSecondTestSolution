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
        public ScoreValueObject OldScore { get; }
        public NewTopicScoreEvent(TopicEntity entity, ScoreValueObject oldScore) : base(entity)
        {
            OldScore = oldScore;
        }
    }
}
