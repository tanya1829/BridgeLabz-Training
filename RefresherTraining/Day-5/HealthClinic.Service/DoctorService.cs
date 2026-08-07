using HealthClinic.Entities;
using HealthClinic.Repository;

namespace HealthClinic.Service
{
    public class DoctorService
    {
        private readonly DoctorRepository doctorRepository = new DoctorRepository();

        public void AddDoctor(Doctor doctor)
        {
            doctorRepository.AddDoctor(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAllDoctors();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            doctorRepository.UpdateDoctor(doctor);
        }

        public void DeleteDoctor(int doctorId)
        {
            doctorRepository.DeleteDoctor(doctorId);
        }
    }
}