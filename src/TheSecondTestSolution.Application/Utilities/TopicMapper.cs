using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Application.Utilities
{
    internal class TopicMapper : ITopicMapper
    {
        public TopicDto FromEntity(TopicEntity entity)
        {
            return new TopicDto
            {
                By = entity.UserName,
                Score = entity.Score.Value,
                Title = entity.Title,
                Type = entity.Type,
                Url = entity.Link.Value
            };
        }

        public TopicDto FromWeb(TopicWebModel web)
        {
            return new TopicDto
            {
                By = web.By,
                Score = web.Score,
                Title = web.Title,
                Type = web.Type,
                Url = web.Url
            };
        }
    }
}
