namespace Domain.Exceptions;

public class WebinarNotFoundException : Exception
{
    public WebinarNotFoundException(Guid webinarId)
        : base($"this webinar with the identifire {webinarId} was not found.")
    {
    }
}