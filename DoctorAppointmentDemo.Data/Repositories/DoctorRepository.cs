using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;


namespace DoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor> , IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository(string appsetting, ISerializationService serializationService) : base(appsetting, serializationService)
        {
            Config config = ReadFromAppSettings();

            Path = config.Database.Doctors.Path;
            LastId = config.Database.Doctors.LastId;
        }

        protected override void SaveLastId()
        {
            Config config = ReadFromAppSettings();
            config.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPathJson, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        public Doctor? GetByPhone(string phone)
        {
            return GetAll<Doctor>().FirstOrDefault(x => x.Phone == phone);
        }
    }
}
