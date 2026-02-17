public class Student
{
    [EmailValidation]
    public string Email { get; set; }

    public Student(string email)
    {
        Email = email;
    }
}