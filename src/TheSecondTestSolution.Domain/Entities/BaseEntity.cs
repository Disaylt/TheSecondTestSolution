using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; protected set; }
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; private set; }

        private List<INotification> _notifications = new List<INotification>();
        public IReadOnlyCollection<INotification> Events => _notifications.AsReadOnly();


        public virtual void AddEvent(INotification notification)
        {
            _notifications.Add(notification);
        }

        public virtual void ClearEvents()
        {
            _notifications.Clear();
        }

        public virtual void RemoveEvent(INotification notification)
        {
            _notifications.Remove(notification);
        }

        public virtual void RefreshUpdateDate()
        {
            UpdateDate = DateTime.UtcNow;
        }
    }
}
