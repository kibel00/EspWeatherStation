using System.ComponentModel.DataAnnotations;

namespace EspWeatherStation.Server.Models;
public class EspData
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This {0} is required")]
    [StringLength(30)]
    public string Sensor { get; set; } = string.Empty;
    [Required(ErrorMessage = "This {0} is required")]
    [StringLength(30)]
    public string Location { get; set; } = string.Empty;
    [StringLength(10)]
    public string Value1 { get; set; } = string.Empty;
    [StringLength(10)]
    public string Value2 { get; set; } = string.Empty;
    [StringLength(10)]
    public string Value3 { get; set; } = string.Empty;
    public DateTime ReadingTime { get; set; } = DateTime.Now;
}