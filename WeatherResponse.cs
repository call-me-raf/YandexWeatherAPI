using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexWeatherAPI
{
    class WeatherResponse
    {
        public MainInfo Fact { get; set; }
        public Info Info { get; set; }
    }
}
