using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointmentDemo.Data.Interfaces;

namespace DoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(string appsetting, ISerializationService serializationService) 
        {
            _appointmentRepository = new AppointmentRepository(appsetting, serializationService);
        }
        
        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll<Appointment>();
        }

        public void ShowInfo(Appointment appointment)
        {
            _appointmentRepository.ShowInfo(appointment);
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
    }
}
