using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Application.Utilities
{
    public interface ITopicMapper
    {
        public TopicDto FromEntity(TopicEntity entity);
        public TopicDto FromWeb(TopicWebModel web);
    }
}
