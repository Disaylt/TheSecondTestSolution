using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Application.Models
{
    public record class TopicDto
    {
        public string By { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public string Type { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
        public int Score { get; init; }
    }
}
