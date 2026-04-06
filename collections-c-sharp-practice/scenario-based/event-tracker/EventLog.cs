namespace EventTrackerApp;

public class EventLog
{
    public required string Event { get; set; }
    public required string Description { get; set; }
    public required string MethodName { get; set; }
    public required string ClassName { get; set; }
    public DateTime TimeStamp { get; set; }
}
