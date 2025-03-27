using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Patient? GetByPhone(string phone);
    }
}