using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;

namespace DoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(string appsetting, ISerializationService serializationService)
        {
            _patientRepository = new PatientRepository(appsetting, serializationService);
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
            return _patientRepository.GetAll<Patient>();
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
