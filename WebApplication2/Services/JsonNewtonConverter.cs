﻿using Newtonsoft.Json;

namespace WebApplication2.Services
{
    public class JsonNewtonConverter: IJsonConverter
    {
        public string WriteJson<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T ReadJson<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
