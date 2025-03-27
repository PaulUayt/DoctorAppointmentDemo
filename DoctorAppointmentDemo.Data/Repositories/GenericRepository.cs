using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;
using System.Reflection;

namespace DoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        private readonly ISerializationService _serializationService;
        protected string Appsettings { get; set; }

        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }


        public GenericRepository(string appsettings, ISerializationService serializationService)
        {
            _serializationService = serializationService;
            Appsettings = appsettings;
        }

        public TSource Create(TSource source)
        {
            var patients = GetAll<TSource>().ToList();
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            patients.Add(source);

            _serializationService.Serialize(patients, Path);
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null) return false;
            _serializationService.Serialize(GetAll<TSource>().Where(x => x.Id != id), Path);
            return true;
        }

        public IEnumerable<T> GetAll<T>()
        {
            if (!File.Exists(Path) || new FileInfo(Path).Length == 0) return new List<T>();

            try
            {
                return _serializationService.Deserialize<List<T>>(Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialisation error: {ex.Message}");
                return new List<T>();
            }
        }

        public TSource? GetById(int id) => GetAll<TSource>().FirstOrDefault(x => x.Id == id);

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            _serializationService.Serialize(GetAll<TSource>().Select(x => x.Id == id ? source : x), Path);

            return source;
        }

        public void ShowInfo(TSource source)
        {
            if (source == null)
            {
                Console.WriteLine("Object not found");
                return;
            }

            Type type = source.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine($"Info about {type.Name}:");
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.GetValue(source) ?? "Not found";
                Console.WriteLine($"{prop.Name}: {value}");
            }
        }

        protected abstract void SaveLastId();
        protected Config ReadFromAppSettings() => JsonConvert.DeserializeObject<Config>(File.ReadAllText(Appsettings))!;
    }
}
