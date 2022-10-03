using Domain.Entity.Common;

namespace Domain.Entity
{
    public class Webinar : BaseEntity
    {
        public Webinar(Guid id, string name, DateTime scheduledOn)
            : base(id)
        {
            Name = name;
            ScheduledOn = scheduledOn;
        }

        private Webinar()
        {
        }

        public string Name { get; set; }
        public DateTime ScheduledOn { get; set; }
    }
}
