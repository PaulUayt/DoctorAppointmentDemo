using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Doctor? GetByPhone(string phone);
    }
}
