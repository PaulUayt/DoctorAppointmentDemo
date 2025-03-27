using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;

namespace DoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository(string appsetting, ISerializationService serializationService) : base(appsetting, serializationService)
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
