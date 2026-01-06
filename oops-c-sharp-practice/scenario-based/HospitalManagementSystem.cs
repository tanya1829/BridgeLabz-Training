using System;

interface IPayable
{
    double GetBillAmount();
}

//  Patient Base Class 
class Patient
{
    private int id;
    private string patientName;

    public void SetId(int pid)
    {
        id = pid;
    }

    public int GetId()
    {
        return id;
    }

    public void SetPatientName(string name)
    {
        patientName = name;
    }

    public string GetPatientName()
    {
        return patientName;
    }

    public void ShowDetails()
    {
        Console.WriteLine("Patient ID: " + id);
        Console.WriteLine("Patient Name: " + patientName);
    }
}

// OutPatient 
class OutPatient : Patient, IPayable
{
    private double consultationFee;

    public void SetConsultationFee(double fee)
    {
        consultationFee = fee;
    }

    public double GetBillAmount()
    {
        return consultationFee;
    }

    public void ShowDetails()
    {
        base.ShowDetails();
        Console.WriteLine("Patient Category: OutPatient");
        Console.WriteLine("Bill Amount: " + GetBillAmount());
    }
}

//  InPatient 
class InPatient : Patient, IPayable
{
    private int totalDays;
    private double perDayCharge;

    public void SetTotalDays(int days)
    {
        totalDays = days;
    }

    public void SetPerDayCharge(double charge)
    {
        perDayCharge = charge;
    }

    public double GetBillAmount()
    {
        return totalDays * perDayCharge;
    }

    public void ShowDetails()
    {
        base.ShowDetails();
        Console.WriteLine("Patient Category: InPatient");
        Console.WriteLine("Bill Amount: " + GetBillAmount());
    }
}

// Doctor Class 
class Doctor
{
    private int docId;
    private string docName;
    private string dept;

    public void SetDoctorDetails(int id, string name, string specialization)
    {
        docId = id;
        docName = name;
        dept = specialization;
    }

    public void ShowDoctorDetails()
    {
        Console.WriteLine("Doctor ID: " + docId);
        Console.WriteLine("Doctor Name: " + docName);
        Console.WriteLine("Specialization: " + dept);
    }
}

//  Main Program 
class Program
{
    static void Main()
    {
        InPatient inPatient = new InPatient();
        inPatient.SetId(201);
        inPatient.SetPatientName("Harshita");
        inPatient.SetTotalDays(5);
        inPatient.SetPerDayCharge(1500);

        OutPatient outPatient = new OutPatient();
        outPatient.SetId(202);
        outPatient.SetPatientName("Saurabh");
        outPatient.SetConsultationFee(900);

        Console.WriteLine("---- InPatient Details ----");
        inPatient.ShowDetails();

        Console.WriteLine("\n---- OutPatient Details ----");
        outPatient.ShowDetails();

        Doctor doctor = new Doctor();
        doctor.SetDoctorDetails(1, "Dr. Meghna", "Cardiology");

        Console.WriteLine("\n---- Doctor Details ----");
        doctor.ShowDoctorDetails();
    }
}
