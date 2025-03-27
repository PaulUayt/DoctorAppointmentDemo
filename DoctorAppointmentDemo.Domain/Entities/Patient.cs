using DoctorAppointment.Domain.Enums;
using System.Xml.Serialization;

namespace DoctorAppointment.Domain.Entities
{
    [XmlRoot("ArrayOfPatient")]
    public class Patient : UserBase
    {
        public Patient() { }
        
        public IllnessTypes IllnessType { get; set; }

        public string? AdditionalInfo { get; set; }

        public string? Address { get; set; }
    }
}
