using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Application.Services
{
    public interface ITopicService
    {
        TopicEntity Create(TopicDto value);
    }
}
