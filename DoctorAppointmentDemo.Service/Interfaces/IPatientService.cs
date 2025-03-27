using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient? Get(int id);
        Patient? Get(string phone);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
        void ShowInfo(Patient patient);
    }
}
