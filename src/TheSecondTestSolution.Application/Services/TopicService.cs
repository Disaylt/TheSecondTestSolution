using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Domain.Entities;
using TheSecondTestSolution.Domain.ValueObjects;

namespace TheSecondTestSolution.Application.Services
{
    internal class TopicService : ITopicService
    {
        public TopicEntity Create(TopicDto value)
        {
            return new TopicEntity(
                new ScoreValueObject(value.Score),
                new LinkValueObject(value.Url),
                value.By,
                value.Type,
                value.Title);
        }
    }
}
