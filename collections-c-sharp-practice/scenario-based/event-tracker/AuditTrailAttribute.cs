using System;
namespace EventTrackerApp;


[AttributeUsage(AttributeTargets.Method)]
public class AuditTrailAttribute : Attribute
{
    public string EventName { get; }
    public string Description { get; }

    public AuditTrailAttribute(string eventName, string description)
    {
        EventName = eventName;
        Description = description;
    }
}