using System;
using System.Reflection;
using System.Text.Json;
namespace EventTrackerApp;


public class EventTracker
{
    public static void TrackEvents(object obj)
    {
        Type type = obj.GetType();

        foreach (MethodInfo method in type.GetMethods())
        {
            var attr = method.GetCustomAttribute<AuditTrailAttribute>();

            if (attr != null)
            {
                method.Invoke(obj, null);

                EventLog log = new EventLog
                {
                    Event = attr.EventName,
                    Description = attr.Description,
                    MethodName = method.Name,
                    ClassName = type.Name,
                    TimeStamp = DateTime.Now
                };

                string jsonLog = JsonSerializer.Serialize(log, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                Console.WriteLine("\nAudit Log:");
                Console.WriteLine(jsonLog);
            }
        }
    }
}