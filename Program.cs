using System;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace YandexWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (true)
            {
                string url = "https://api.weather.yandex.ru/v1/forecast?lat=55.828862&lon=49.067642&extra=true";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Headers.Add("X-Yandex-API-Key: 3aa2e4f0-781d-4440-8bc8-7db26e5e1709");
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string jsonresponce;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    jsonresponce = streamReader.ReadToEnd();
                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(jsonresponce);
                using (FieldContext db = new FieldContext())
                {
                    db.Fields.Add(new Field { Name = weatherResponse.Info.Tzinfo.Name, Temp = weatherResponse.Fact.Temp, Feels_like = weatherResponse.Fact.Feels_like, Wind_speed = weatherResponse.Fact.Wind_speed, Pressure_mm = weatherResponse.Fact.Pressure_mm, Humidity = weatherResponse.Fact.Humidity, Season = weatherResponse.Fact.Season, DateTime = DateTime.Now });
                    db.SaveChanges();
                }
                Console.WriteLine($"Местоположение: {weatherResponse.Info.Tzinfo.Name}\nТемпература: {weatherResponse.Fact.Temp}°C\nОщущается как: {weatherResponse.Fact.Feels_like}°C\nСкорость ветра: {weatherResponse.Fact.Wind_speed}м/c\nДавление: {weatherResponse.Fact.Pressure_mm}мм.рт.ст.\nВлажность: {weatherResponse.Fact.Humidity}%\nВремя года: {weatherResponse.Fact.Season}\n");
                Console.WriteLine($"Погода через {i++} мин:\n");
                Thread.Sleep(60000);
            }
        }
    }
}
