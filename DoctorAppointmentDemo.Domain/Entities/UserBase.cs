namespace DoctorAppointment.Domain.Entities
{
    public abstract class UserBase : Auditable
    {
        public UserBase() { }
        
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string? Email { get; set; }
    }
}
