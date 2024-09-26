using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicFromWebApiQuery : IRequest<TopicDto?>
    {
        public required int Id { get; set; }
    }
}
