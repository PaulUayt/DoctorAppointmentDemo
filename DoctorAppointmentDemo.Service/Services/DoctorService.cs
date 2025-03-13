using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;

namespace MyDoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
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
            return _doctorRepository.GetAll();
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
