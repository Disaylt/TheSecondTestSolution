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
        public string OldTitle { get; }
        public NewTopicTitleEvent(TopicEntity entity, string oldTitle) : base(entity)
        {
            OldTitle = oldTitle;
        }
    }
}
