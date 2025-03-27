using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;

namespace DoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ISerializationService _serializationService;

        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository(string appsetting, ISerializationService serializationService) : base(appsetting, serializationService)
        {
            _serializationService = serializationService;

            Config config = ReadFromAppSettings();

            Path = config.Database.Patients.Path;
            LastId = config.Database.Patients.LastId;
        }

        protected override void SaveLastId()
        {
            Config config = ReadFromAppSettings();
            config.Database.Patients.LastId = LastId;

            File.WriteAllText(Appsettings, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        public Patient? GetByPhone(string phone)
        {
            return GetAll<Patient>().FirstOrDefault(x => x.Phone == phone);
        }
    }
}
