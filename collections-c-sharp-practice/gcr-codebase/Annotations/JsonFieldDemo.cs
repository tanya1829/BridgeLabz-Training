using System;
using System.Reflection;
using System.Text;

[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }

    public JsonFieldAttribute(string name)
    {
        Name = name;
    }
}

class User
{
    [JsonField("user_name")]
    public string Username;

    [JsonField("user_age")]
    public int Age;

    public User(string username, int age)
    {
        Username = username;
        Age = age;
    }
}

class JsonSerializer
{
    public static string Serialize(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields();

        StringBuilder json = new StringBuilder();
        json.Append("{");

        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];
            JsonFieldAttribute attr =
                (JsonFieldAttribute)Attribute.GetCustomAttribute(field, typeof(JsonFieldAttribute));

            if (attr != null)
            {
                json.Append($"\"{attr.Name}\": \"{field.GetValue(obj)}\"");

                if (i < fields.Length - 1)
                    json.Append(", ");
            }
        }

        json.Append("}");
        return json.ToString();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string name = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        User user = new User(name, age);

        string json = JsonSerializer.Serialize(user);
        Console.WriteLine("\nGenerated JSON:");
        Console.WriteLine(json);
    }
}

