using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;       

class Person
    {
        private int age = 20;
    }

    internal class AccessPrivateField
    {
       public  static void Main(string[] args)
        {
            Person person = new Person();

            // Get type of Person class
            Type type = typeof(Person);

            // Access private field "age"
            FieldInfo field = type.GetField("age",BindingFlags.NonPublic | BindingFlags.Instance);

            // Modify value
            field.SetValue(person, 25);

            // Retrieve value
            int value = (int)field.GetValue(person);

            Console.WriteLine("Updated Age: " + value);
        }
    }
