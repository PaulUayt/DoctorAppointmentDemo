using DoctorAppointmentDemo.Data.Interfaces;
using System.Xml.Serialization;

namespace DoctorAppointment.Service.Services
{
    public class XmlSerializerService : ISerializationService
    {
        public T Deserialize<T>(string path) where T : new()
        {
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                return new T();
            }

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                return (T)serializer.Deserialize(fileStream)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialisation error: {ex.Message}");
                return new T();
            }
        }

        public void Serialize<T>(T data, string path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
                serializer.Serialize(fileStream, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialisation error: {ex.Message}");
            }
        }
    }
}
