using System;
using System.Threading;

public class RegistrationService
{
    public void Register(Student student)
    {
        Thread thread = new Thread(() =>
        {
            try
            {
                EmailValidator.Validate(student);

                FileManager.SaveEmail(student.Email);

                Console.WriteLine($"Registered: {student.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rejected ({student.Email}) : {ex.Message}");
            }
        });

        thread.Start();
    }
}