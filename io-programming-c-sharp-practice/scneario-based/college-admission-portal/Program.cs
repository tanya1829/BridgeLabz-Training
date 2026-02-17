class Program
{
    static void Main()
    {
        RegistrationService service = new RegistrationService();

        string[] emails =
        {
             "aarav.kumar@yahoo.com",
            "sneha.patel@protonmail.com",
            "contact@techworld.org",
            "vikram123@gmail",
            "example.com",
            "neha!singh@domain.net"
        };

        foreach (var email in emails)
        {
            Student student = new Student(email);
            service.Register(student);
        }

        Console.ReadLine();
    }
}