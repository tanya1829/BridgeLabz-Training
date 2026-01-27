using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

class Calculator
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    internal class InvokePrivateMethod
    {

       public static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            // Get type information
            Type type = typeof(Calculator);

            // Get private method
            MethodInfo method = type.GetMethod("Multiply",BindingFlags.NonPublic | BindingFlags.Instance);

            // Invoke method with parameters
            object result = method.Invoke(calc, new object[] { 5, 4 });

            Console.WriteLine("Multiplication Result: " + result);
        }
    }

