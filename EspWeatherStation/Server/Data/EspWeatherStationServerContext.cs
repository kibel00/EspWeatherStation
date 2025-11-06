using EspWeatherStation.Shared;
using Microsoft.EntityFrameworkCore;

namespace EspWeatherStation.Server.Data;

public class EspWeatherStationServerContext : DbContext
{
    public EspWeatherStationServerContext(DbContextOptions<EspWeatherStationServerContext> options)
        : base(options)
    {
    }

    public DbSet<WeatherStation> WeatherStation { get; set; } = default!;
}