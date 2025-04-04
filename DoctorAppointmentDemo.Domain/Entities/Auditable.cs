﻿namespace DoctorAppointment.Domain.Entities
{
    public abstract class Auditable
    {
        public Auditable() { }
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
