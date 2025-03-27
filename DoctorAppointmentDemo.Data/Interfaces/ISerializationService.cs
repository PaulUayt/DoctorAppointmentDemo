namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface ISerializationService
    {
        void Serialize<T>(T data, string path);
        T Deserialize<T>(string path) where T : new();
    }
}
