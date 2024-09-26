using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Domain.Seed
{
    public interface IEntity
    {
        public int Id { get; }
        public DateTime CreateDate { get; }
        public DateTime UpdateDate { get; }
        public void RefreshUpdateDate();
        public IReadOnlyCollection<INotification> Events { get; }
        public void AddEvent(INotification notification);
        public void RemoveEvent(INotification notification);
        public void ClearEvents();
    }
}
