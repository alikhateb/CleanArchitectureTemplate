using Domain.Primitives;

namespace Domain.Entities;

public class Webinar : Entity
{
    public Webinar(
        Guid id,
        string name,
        DateTime scheduledOn
    ) : base(id)
    {
        Name = name;
        ScheduledOn = scheduledOn;
    }

    public string Name { get; }
    public DateTime ScheduledOn { get; }
}