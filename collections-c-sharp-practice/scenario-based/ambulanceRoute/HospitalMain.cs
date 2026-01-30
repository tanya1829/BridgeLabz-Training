using System;
using System.Collections.Generic;
using System.Text;

    internal class HospitalMain
    {
        // Entry point of the application
        static void Main()
        {
            // Create menu object
            HospitalMenu menu = new HospitalMenu();

            // Display hospital menu
            menu.ShowMenu();
        }
    }
