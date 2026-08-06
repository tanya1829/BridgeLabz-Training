using HealthClinicApp.Entities;
using HealthClinicApp.Service;

namespace HealthClinicApp.Menu
{
    // Handles all console-based user interaction (input/output)
    public class HealthMenu
    {
        private readonly DoctorService doctorService = new DoctorService();
        private readonly PatientService patientService = new PatientService();
        private readonly AppointmentService appointmentService = new AppointmentService();

        // Main menu loop
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===== HEALTH CLINIC MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Doctor Management");
                Console.WriteLine("2. Patient Management");
                Console.WriteLine("3. Appointment Management");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": DoctorMenu(); break;
                    case "2": PatientMenu(); break;
                    case "3": AppointmentMenu(); break;
                    case "4": exit = true; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        // Sub-menu for Doctor operations
        private void DoctorMenu()
        {
            Console.WriteLine("\n-- Doctor Menu --");
            Console.WriteLine("1. Add Doctor  2. View Doctors  3. Update Doctor  4. Delete Doctor  5. Back");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Add doctor
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Specialization: ");
                    string spec = Console.ReadLine();

                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();

                    doctorService.AddDoctor(new Doctor
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Specialization = spec,
                        Phone = phone
                    });
                    break;

                case "2": // View doctors
                    foreach (var d in doctorService.GetAllDoctors())
                        Console.WriteLine($"{d.DoctorId} | {d.FirstName} {d.LastName} | {d.Specialization} | {d.Phone}");
                    break;

                case "3": // Update doctor
                    Console.Write("Doctor ID to update: ");
                    int uid = int.Parse(Console.ReadLine());

                    Console.Write("New First Name: ");
                    string ufirst = Console.ReadLine();

                    Console.Write("New Last Name: ");
                    string ulast = Console.ReadLine();

                    Console.Write("New Specialization: ");
                    string uspec = Console.ReadLine();

                    Console.Write("New Phone: ");
                    string uphone = Console.ReadLine();

                    doctorService.UpdateDoctor(new Doctor
                    {
                        DoctorId = uid,
                        FirstName = ufirst,
                        LastName = ulast,
                        Specialization = uspec,
                        Phone = uphone
                    });
                    break;

                case "4": // Delete doctor
                    Console.Write("Doctor ID to delete: ");
                    int did = int.Parse(Console.ReadLine());

                    doctorService.DeleteDoctor(did);
                    break;
            }
        }

        // Sub-menu for Patient operations
        private void PatientMenu()
        {
            Console.WriteLine("\n-- Patient Menu --");
            Console.WriteLine("1. Add Patient  2. View Patients  3. Back");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Add patient
                    Console.Write("First Name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Date of Birth (yyyy-MM-dd): ");
                    DateTime dob = DateTime.Parse(Console.ReadLine());

                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();

                    Console.Write("Address: ");
                    string address = Console.ReadLine();

                    Console.Write("Gender (M/F/O): ");
                    char gender = Console.ReadLine()[0];

                    patientService.AddPatient(new Patient
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dob,
                        Phone = phone,
                        Address = address,
                        Gender = gender
                    });
                    break;

                case "2": // View patients
                    foreach (var p in patientService.GetAllPatients())
                        Console.WriteLine($"{p.PatientId} | {p.FirstName} {p.LastName} | {p.Phone} | {p.Gender}");
                    break;
            }
        }

        // Sub-menu for Appointment operations
        private void AppointmentMenu()
        {
            Console.WriteLine("\n-- Appointment Menu --");
            Console.WriteLine("1. Book Appointment  2. View Appointments  3. Cancel Appointment  4. Back");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Book appointment
                    Console.Write("Patient ID: ");
                    int patId = int.Parse(Console.ReadLine());

                    Console.Write("Doctor ID: ");
                    int docId = int.Parse(Console.ReadLine());

                    Console.Write("Date (yyyy-MM-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    appointmentService.BookAppointment(new Appointment
                    {
                        PatientId = patId,
                        DoctorId = docId,
                        AppointmentDate = date,
                        Status = "Scheduled"
                    });
                    break;

                case "2": // View appointments
                    foreach (var a in appointmentService.GetAllAppointments())
                        Console.WriteLine($"{a.AppointmentId} | Pat {a.PatientId} | Doc {a.DoctorId} | {a.AppointmentDate:d} | {a.Status}");
                    break;

                case "3": // Cancel appointment
                    Console.Write("Appointment ID to cancel: ");
                    int aid = int.Parse(Console.ReadLine());

                    appointmentService.CancelAppointment(aid);
                    break;
            }
        }
    }
}