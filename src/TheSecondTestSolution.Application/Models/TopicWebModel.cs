using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Application.Models
{
    public class TopicWebModel
    {
        public required string By { get; set; }
        public required string Title { get; set; }
        public required string Type { get; set; }
        public required string Url { get; set; }
        public int Score { get; set; }

    }
}
