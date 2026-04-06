using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

class Student
    {
        public Student()
        {
            Console.WriteLine("Student object created!");
        }

        public void Show()
        {
            Console.WriteLine("Welcome Student");
        }
    }

    internal class DynamicallyCreateObjects
    {

       public static void Main(string[] args)
        {
            // Get type of Student class
            Type type = typeof(Student);

            // Create object dynamically
            object obj = Activator.CreateInstance(type);

            // Call method using reflection
            MethodInfo method = type.GetMethod("Show");
            method.Invoke(obj, null);
        }
    }

