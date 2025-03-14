﻿using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using Newtonsoft.Json;
using System.Reflection;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor> , IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository()
        {
            Config config = ReadFromAppSettings();

            Path = config.Database.Doctors.Path;
            LastId = config.Database.Doctors.LastId;
        }

        protected override void SaveLastId()
        {
            Config config = ReadFromAppSettings();
            config.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        public Doctor? GetByPhone(string phone)
        {
            return GetAll().FirstOrDefault(x => x.Phone == phone);
        }
    }
}
