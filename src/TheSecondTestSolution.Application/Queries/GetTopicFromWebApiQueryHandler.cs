using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicFromWebApiQueryHandler : IRequestHandler<GetTopicFromWebApiQuery, IEnumerable<TopicDto>>
    {
        public Task<IEnumerable<TopicDto>> Handle(GetTopicFromWebApiQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
