using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Domain.Events
{
    public abstract class BaseTopicEvent : INotification
    {
        public TopicEntity Entity { get; }

        public BaseTopicEvent(TopicEntity entity)
        {
            Entity = entity;
        }
    }
}
