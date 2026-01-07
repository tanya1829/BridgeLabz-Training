using System;

class CallRecord
{
    public string Number;
    public string Text;
    public string TimeStamp;   // stored as string
}

class CallManager
{
    private CallRecord[] recordList = new CallRecord[40];
    private int count = 0;

    public void InsertLog(string number, string text, string time)
    {
        if (count >= recordList.Length)
        {
            Console.WriteLine("No space left to store logs");
            return;
        }

        CallRecord cr = new CallRecord();
        cr.Number = number;
        cr.Text = text;
        cr.TimeStamp = time;

        recordList[count] = cr;
        count++;
    }

    public void FindByWord(string word)
    {
        for (int i = 0; i < count; i++)
        {
            if (recordList[i].Text.Contains(word))
            {
                Show(recordList[i]);
            }
        }
    }

    public void FilterBetweenTime(string startTime, string endTime)
    {
        for (int i = 0; i < count; i++)
        {
            if (string.Compare(recordList[i].TimeStamp, startTime) >= 0 &&
                string.Compare(recordList[i].TimeStamp, endTime) <= 0)
            {
                Show(recordList[i]);
            }
        }
    }

    private void Show(CallRecord r)
    {
        Console.WriteLine(r.Number + " | " + r.Text + " | " + r.TimeStamp);
    }
}

class Program
{
    static void Main()
    {
        CallManager cm = new CallManager();

        cm.InsertLog("9878765634", "Signal problem", "10:30");
        cm.InsertLog("8975367289", "Recharge not working", "10:50");
        cm.InsertLog("8769265509", "Internet very slow", "11:00");

        Console.WriteLine("Keyword search:");
        cm.FindByWord("slow");

        Console.WriteLine("\nTime filter:");
        cm.FilterBetweenTime("10:40", "11:10");
    }
}