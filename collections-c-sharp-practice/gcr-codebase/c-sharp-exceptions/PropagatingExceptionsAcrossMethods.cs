using System;
using System.Collections.Generic;
using System.Text;

internal class PropagatingExceptionsAcrossMethods
    {
          
            // Method1: Exception occurs here
            static void Method1()
            {
                // This causes DivideByZeroException at runtime
                int result = 10 / 0;
            }

            // Method2: Calls Method1
            static void Method2()
            {
                Method1();
            }

            public static void Main(string[] args)
            {
                try
                {
                    // Call Method2
                    Method2();
                }
                catch (DivideByZeroException)
                {
                    // Exception is handled here
                    Console.WriteLine("Handled exception in Main");
                }

                // Program continues safely
                Console.WriteLine("Program ended normally");
            }
        }




