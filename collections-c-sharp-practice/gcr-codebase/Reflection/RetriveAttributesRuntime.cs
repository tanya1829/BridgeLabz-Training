using System;
using System.Collections.Generic;
using System.Text;
     
// Create custom attribute
[AttributeUsage(AttributeTargets.Class)]
    class AuthorAttribute : Attribute
    {
        public string Name { get; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }

    // Apply attribute to class
    [Author("Navya Yadav")]
    class DemoClass
    {
    }

    internal class RetrieveAttributesRuntime
    {
        public static void Main(string[] args)
        {
            // Get type information
            Type type = typeof(DemoClass);

            // Get custom attribute
            AuthorAttribute attribute =
                (AuthorAttribute)Attribute.GetCustomAttribute(type, typeof(AuthorAttribute));

            if (attribute != null)
            {
                Console.WriteLine("Author Name: " + attribute.Name);
            }
            else
            {
                Console.WriteLine("Author attribute not found.");
            }
        }
    }

