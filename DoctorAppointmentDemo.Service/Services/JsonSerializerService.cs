using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;

namespace DoctorAppointment.Service.Services
{
    public class JsonSerializerService : ISerializationService
    {
        public T Deserialize<T>(string path) where T : new() => JsonConvert.DeserializeObject<T>(File.ReadAllText(path))!;
        public void Serialize<T>(T data, string path) => File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
    }
}
