namespace EventTrackerApp;

public class UserActions
{
    [AuditTrail("UserLogin", "User logged into system")]
    public void Login()
    {
        Console.WriteLine("Login successful");
    }

    [AuditTrail("FileUpload", "User uploaded a file")]
    public void UploadFile()
    {
        Console.WriteLine("File uploaded");
    }

    [AuditTrail("DeleteFile", "User deleted a file")]
    public void DeleteFile()
    {
        Console.WriteLine("File deleted");
    }
}