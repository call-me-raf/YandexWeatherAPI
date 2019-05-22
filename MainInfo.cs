using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexWeatherAPI
{
    class MainInfo
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public string Season { get; set; }
        public double Wind_speed { get; set; }
        public double Pressure_mm { get; set; }
        public double Humidity { get; set; }
    }
}
