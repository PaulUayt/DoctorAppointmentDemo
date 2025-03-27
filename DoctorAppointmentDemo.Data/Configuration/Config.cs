namespace DoctorAppointment.Data.Configuration
{
    public class Config
    {
        public DatabaseInfo Database { get; set; }

        public class DatabaseInfo
        {
            public DatabaseEntity Doctors { get; set; }
            public DatabaseEntity Patients { get; set; }
            public DatabaseEntity Appointments { get; set; }

            public class DatabaseEntity
            {
                public int LastId { get; set; }
                public string Path { get; set; }
            }
        }
    }
}
