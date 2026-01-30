using System;
using System.Collections.Generic;
using System.Text;


    class HospitalUnit
    {
        // Name of the hospital unit
        public string Name;

        // Availability status of the unit
        public bool IsAvailable;

        // Reference to the next unit (linked list)
        public HospitalUnit Next;

        // Constructor to initialize a hospital unit
        public HospitalUnit(string name)
        {
            Name = name;          // Set unit name
            IsAvailable = true;   // Unit is available by default
            Next = null;          // No next unit initially
        }
    }
