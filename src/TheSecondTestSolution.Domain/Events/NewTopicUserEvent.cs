﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Domain.Events
{
    public class NewTopicUserEvent : BaseTopicEvent
    {
        public string User { get; }
        public NewTopicUserEvent(TopicEntity entity, string oldUser) : base(entity)
        {
            User = oldUser;
        }
    }
}
