using DoctorAppointment.Domain.Enums;
using System.Xml.Serialization;

namespace DoctorAppointment.Domain.Entities
{
    [XmlRoot("ArrayOfDoctor")]
    public class Doctor : UserBase
    {
        public Doctor() { }
        public DoctorTypes DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }
    }
}
