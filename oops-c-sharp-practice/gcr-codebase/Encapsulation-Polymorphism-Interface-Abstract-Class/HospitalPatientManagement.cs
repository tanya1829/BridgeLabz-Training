using System;

//  Interface for Medical History 
interface IMedicalRecord
{
    void AddMedicalNote(string note);
    void ShowMedicalNotes();
}

// Abstract Patient 
abstract class Patient
{
    private int id;
    private string patientName;
    private int patientAge;

    public void SetId(int pid) { id = pid; }
    public int GetId() { return id; }

    public void SetPatientName(string name) { patientName = name; }
    public string GetPatientName() { return patientName; }

    public void SetPatientAge(int age) { patientAge = age; }
    public int GetPatientAge() { return patientAge; }

    public void ShowPatientInfo()
    {
        Console.WriteLine("Patient ID: " + id);
        Console.WriteLine("Name: " + patientName);
        Console.WriteLine("Age: " + patientAge);
    }

    public abstract double GetBillAmount();
}

//  InPatient
class InPatient : Patient, IMedicalRecord
{
    private double wardCharge;
    private double medicalCharge;
    private string note1;
    private string note2;

    public void SetWardCharge(double charge)
    {
        wardCharge = charge;
    }

    public void SetMedicalCharge(double charge)
    {
        medicalCharge = charge;
    }

    public override double GetBillAmount()
    {
        return wardCharge + medicalCharge;
    }

    public void AddMedicalNote(string note)
    {
        if (note1 == null)
            note1 = note;
        else
            note2 = note;
    }

    public void ShowMedicalNotes()
    {
        if (note1 != null) Console.WriteLine("Note 1: " + note1);
        if (note2 != null) Console.WriteLine("Note 2: " + note2);
    }

    public void ShowInPatientDetails()
    {
        ShowPatientInfo();
        Console.WriteLine("Total Bill: " + GetBillAmount());
        ShowMedicalNotes();
    }
}

//  OutPatient
class OutPatient : Patient, IMedicalRecord
{
    private double visitFee;
    private string note;

    public void SetVisitFee(double fee)
    {
        visitFee = fee;
    }

    public override double GetBillAmount()
    {
        return visitFee;
    }

    public void AddMedicalNote(string noteText)
    {
        note = noteText;
    }

    public void ShowMedicalNotes()
    {
        if (note != null)
            Console.WriteLine("Note: " + note);
    }

    public void ShowOutPatientDetails()
    {
        ShowPatientInfo();
        Console.WriteLine("Total Bill: " + GetBillAmount());
        ShowMedicalNotes();
    }
}

// Main Program 
class ProgramHospital
{
    static void Main()
    {
        InPatient inPatient = new InPatient();
        inPatient.SetId(101);
        inPatient.SetPatientName("Rahul");
        inPatient.SetPatientAge(30);
        inPatient.SetWardCharge(5000);
        inPatient.SetMedicalCharge(2000);
        inPatient.AddMedicalNote("Blood Test Completed");

        OutPatient outPatient = new OutPatient();
        outPatient.SetId(102);
        outPatient.SetPatientName("Anita");
        outPatient.SetPatientAge(25);
        outPatient.SetVisitFee(500);
        outPatient.AddMedicalNote("General Checkup");

        Console.WriteLine("---- InPatient Details ----");
        inPatient.ShowInPatientDetails();

        Console.WriteLine("\n---- OutPatient Details ----");
        outPatient.ShowOutPatientDetails();
    }
}
