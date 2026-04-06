using System.IO;

public static class FileManager
{
    private static string filePath = "ValidEmails.txt";

    // lock object for synchronization
    private static readonly object fileLock = new object();

    public static void SaveEmail(string email)
    {
        lock (fileLock)
        {
            File.AppendAllText(filePath,
                email + Environment.NewLine);
        }
    }
}