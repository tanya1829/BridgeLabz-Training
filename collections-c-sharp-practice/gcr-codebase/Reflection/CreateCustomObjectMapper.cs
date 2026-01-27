using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
    
class Person
    {
        public string Name;
        public int Age;
    }

    class ObjectMapper
    {
        // Generic method to convert dictionary to object
        public static T ToObject<T>(Dictionary<string, object> properties)
            where T : new()
        {
            // Create object dynamically
            T obj = new T();

            Type type = typeof(T);

            foreach (var item in properties)
            {
                // Get field by name
                FieldInfo field = type.GetField(item.Key);

                if (field != null)
                {
                    // Set value to field
                    field.SetValue(obj, item.Value);
                }
            }
            return obj;
        }
    }

    internal class CreateCustomObjectMapper
    {
        public static void Main(string[] args)
        {
            Dictionary<string, object> data = new Dictionary<string, object>()
        {
            { "Name", "Navya" },
            { "Age", 22 }
        };

            Person person = ObjectMapper.ToObject<Person>(data);

            Console.WriteLine(person.Name + " - " + person.Age);
        }
    }

