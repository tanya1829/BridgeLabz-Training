using System.Reflection;
using System.Text.RegularExpressions;

public static class EmailValidator
{
    private static string regexPattern =
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,6}$";

    public static void Validate(object obj)
    {
        foreach (var prop in obj.GetType().GetProperties())
        {
            if (Attribute.IsDefined(prop, typeof(EmailValidationAttribute)))
            {
                string email = prop.GetValue(obj)?.ToString();

                if (string.IsNullOrEmpty(email))
                    throw new Exception("Email cannot be empty");

                if (!Regex.IsMatch(email, regexPattern))
                    throw new Exception("Invalid Email Format");
            }
        }
    }
}