using System;

// Service Call Model
class SupportCall
{
    public string PhoneNo;
    public string IssueDetails;
    public DateTime LoggedTime;
}

//  Call Log Manager
{
    private SupportCall[] logs = new SupportCall[50];
    private int logCount = 0;

    public void AddLog(string phone, string issue, DateTime time)
    {
        if (logCount >= logs.Length)
        {
            Console.WriteLine("Call log storage is full");
            return;
        }

        SupportCall sc = new SupportCall();
        sc.PhoneNo = phone;
        sc.IssueDetails = issue;
        sc.LoggedTime = time;

        logs[logCount] = sc;
        logCount++;
    }

    public void SearchByKeyword(string keyword)
    {
        for (int i = 0; i < logCount; i++)
        {
            if (logs[i].IssueDetails.Contains(keyword))
            {
                Print(logs[i]);
            }
        }
    }

    public void FilterByTime(DateTime start, DateTime end)
    {
        for (int i = 0; i < logCount; i++)
        {
            if (logs[i].LoggedTime >= start && logs[i].LoggedTime <= end)
            {
                Print(logs[i]);
            }
        }
    }

    private void Print(SupportCall call)
    {
        Console.WriteLine(
            call.PhoneNo + " | " +
            call.IssueDetails + " | " +
            call.LoggedTime
        );
    }
}

//Main Program 
class Program
{
    static void Main()
    {
        CallLog callLog = new CallLog();

        callLog.AddLog("9876543210", "Internet problem", DateTime.Now.AddMinutes(-40));
        callLog.AddLog("9123456780", "Balance not updated", DateTime.Now.AddMinutes(-15));
        callLog.AddLog("9988776655", "Internet speed slow", DateTime.Now);

        Console.WriteLine("---- Keyword Search Result ----");
        callLog.SearchByKeyword("Internet");

        Console.WriteLine("\n---- Time Filter Result ----");
        callLog.FilterByTime(DateTime.Now.AddMinutes(-20), DateTime.Now);
    }
}
