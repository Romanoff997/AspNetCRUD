namespace WebApplication2.Services
{
    public interface IJsonConverter
    {
        public string WriteJson<T>(T value);

        public T ReadJson<T>(string value);
    }
}