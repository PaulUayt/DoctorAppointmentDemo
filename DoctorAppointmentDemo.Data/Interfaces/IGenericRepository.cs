using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : Auditable
    {
        TSource Create(TSource source);
        TSource? GetById(int id);
        TSource Update(int id, TSource source);
        public IEnumerable<T> GetAll<T>();
        bool Delete(int id);
        void ShowInfo(TSource source);
    }
}
