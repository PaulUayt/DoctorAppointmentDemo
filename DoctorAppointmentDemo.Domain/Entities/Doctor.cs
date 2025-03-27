using DoctorAppointment.Domain.Enums;

namespace DoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public Doctor() { }
        public DoctorTypes DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }
    }
}
