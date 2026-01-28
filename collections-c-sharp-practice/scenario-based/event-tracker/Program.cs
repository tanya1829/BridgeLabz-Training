namespace EventTrackerApp;

class Program
{
    static void Main(string[] args)
    {
        UserActions actions = new UserActions();
        EventTracker.TrackEvents(actions);
    }
}