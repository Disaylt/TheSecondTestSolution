using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Events;
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

        public void SetTitle(string title)
        {
            string oldValue = Title;
            Title = title;

            AddEvent(new NewTopicTitleEvent(this, oldValue));
        }

        public void SetType(string type)
        {
            string oldValue = Type;
            Type = type;

            AddEvent(new NewTopicTypeEvent(this, oldValue));
        }

        public void SetUserName(string userName)
        {
            string oldValue = UserName;
            UserName = userName;

            AddEvent(new NewTopicUserEvent(this, oldValue));
        }

        public void SetLink(LinkValueObject link)
        {
            LinkValueObject oldValue = Link;
            Link = link;

            AddEvent(new NewTopicLinkEvent(this, oldValue));
        }

        public void SetScore(ScoreValueObject score)
        {
            ScoreValueObject oldValue = Score;
            Score = score;

            AddEvent(new NewTopicScoreEvent(this, oldValue));
        }

    }
}
