using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            Config config = ReadFromAppSettings();

            Path = config.Database.Appointments.Path;
            LastId = config.Database.Appointments.LastId;
        }

        protected override void SaveLastId()
        {
            throw new NotImplementedException();
        }
    }
}
