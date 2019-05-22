using System.Data.Entity;

namespace YandexWeatherAPI
{
    class FieldContext:DbContext
    {
        public DbSet<Field> Fields { get; set; }
    }
}
