using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository()
        {
            Config config = ReadFromAppSettings();

            Path = config.Database.Patients.Path;
            LastId = config.Database.Patients.LastId;
        }

        protected override void SaveLastId()
        {
            Config config = ReadFromAppSettings();
            config.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, JsonConvert.SerializeObject(config, Formatting.Indented));

        }

        public Patient? GetByPhone(string phone)
        {
            return GetAll().FirstOrDefault(x => x.Phone == phone);
        }
    }
}
