using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Patient? GetByPhone(string phone);
    }
}