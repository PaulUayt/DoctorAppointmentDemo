using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;

namespace DoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(string appsetting, ISerializationService serializationService)
        {
            _doctorRepository = new DoctorRepository(appsetting, serializationService);
        }

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public Doctor? Get(string phone)
        {
            return _doctorRepository.GetByPhone(phone);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll<Doctor>();
        }

        public void ShowInfo(Doctor doctor)
        {
            _doctorRepository.ShowInfo(doctor);
        }

        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }
    }
}
