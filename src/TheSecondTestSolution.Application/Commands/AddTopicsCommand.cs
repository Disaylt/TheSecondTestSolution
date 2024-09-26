using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Models;

namespace TheSecondTestSolution.Application.Commands
{
    public class AddTopicsCommand : ICommand<Unit>
    {
        public IEnumerable<TopicDto> Topics { get; set; } = Enumerable.Empty<TopicDto>();
    }
}
