// Question:
// Create a Patient class using static, this, readonly and is operator
// for Hospital Management System.

using System;
class HospitalManagement
{
    // Static hospital name
    public static string HospitalName = "City Hospital";
    private static int totalPatients = 0;

    // Readonly patient ID
    public readonly int PatientID;
    public string Name;
    public int Age;
    public string Ailment;

    // Constructor using this keyword
    public Patient(int PatientID, string Name, int Age, string Ailment)
    {
        this.PatientID = PatientID;
        this.Name = Name;
        this.Age = Age;
        this.Ailment = Ailment;
        totalPatients++;
    }

    // Static method to get total patients
    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients: " + totalPatients);
    }

    static void Main()
    {
        Patient p = new Patient(1, "Ana", 21, "Fever");

        if (p is Patient)
        {
            Console.WriteLine(p.Name + " - " + p.Ailment);
        }

        GetTotalPatients();
    }
}