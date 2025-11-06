using EspWeatherStation.Server.Data;
using EspWeatherStation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EspWeatherStation.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherStationsController : ControllerBase
{
    private readonly EspWeatherStationServerContext _context;

    public WeatherStationsController(EspWeatherStationServerContext context)
    {
        _context = context;
    }

    // GET: api/WeatherStations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherStation>>> GetWeatherStation()
    {
        if (_context.WeatherStation == null)
        {
            return NotFound();
        }
        return await _context.WeatherStation.ToListAsync();
    }

    // GET: api/WeatherStations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherStation>> GetWeatherStation(int id)
    {
        if (_context.WeatherStation == null)
        {
            return NotFound();
        }
        var weatherStation = await _context.WeatherStation.FindAsync(id);

        if (weatherStation == null)
        {
            return NotFound();
        }

        return weatherStation;
    }

    // PUT: api/WeatherStations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutWeatherStation(int id, WeatherStation weatherStation)
    {
        if (id != weatherStation.Id)
        {
            return BadRequest();
        }

        _context.Entry(weatherStation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WeatherStationExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/WeatherStations
    [HttpPost]
    public async Task<ActionResult<WeatherStation>> PostWeatherStation(WeatherStation weatherStation)
    {
        if (_context.WeatherStation == null)
        {
            return Problem("Entity set 'EspWeatherStationServerContext.WeatherStation'  is null.");
        }
        _context.WeatherStation.Add(weatherStation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetWeatherStation", new { id = weatherStation.Id }, weatherStation);
    }

    // DELETE: api/WeatherStations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWeatherStation(int id)
    {
        if (_context.WeatherStation == null)
        {
            return NotFound();
        }
        var weatherStation = await _context.WeatherStation.FindAsync(id);
        if (weatherStation == null)
        {
            return NotFound();
        }

        _context.WeatherStation.Remove(weatherStation);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WeatherStationExists(int id)
    {
        return (_context.WeatherStation?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}