using DoctorAppointment.Domain.Entities;


namespace DoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Doctor? GetByPhone(string phone);
    }
}
