using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.ValueObjects;

namespace TheSecondTestSolution.Domain.Entities
{
    public class TopicEntity : BaseEntity
    {
        public int Id { get; private set; }
        public ScoreValueObject Score { get; private set; }
        public LinkValueObject Link { get; private set; }
        public string UserName { get; private set; }
        public string Type { get; private set; }
        public string Title { get; private set; }

        protected TopicEntity()
        {

        }

        public TopicEntity(ScoreValueObject score,
            LinkValueObject link,
            string userName,
            string type,
            string title)
        {
            Score = score;
            Link = link;
            UserName = userName;
            Type = type;
            Title = title;
        }


    }
}
