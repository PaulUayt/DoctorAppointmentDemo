using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient? Get(string phone)
        {
            return _patientRepository.GetByPhone(phone);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public void ShowInfo(Patient patient)
        {
            _patientRepository.ShowInfo(patient);
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }
    }
}
