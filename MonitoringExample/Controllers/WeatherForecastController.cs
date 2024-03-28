
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MonitoringExample.Data;
using MonitoringExample.Models;
using MonitoringExample.Monitoring;

namespace MonitoringExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public WeatherForecastController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var stopWatch = Stopwatch.StartNew();

        User user = new()
        {
            Id = Guid.NewGuid(),
            Name = "Hugh",
            Surname = "Jackman",
            Gender = true
        };

        Thread.Sleep(500);

        _dbContext.Add(user);
        _dbContext.SaveChanges();
        _dbContext.Dispose();

        Console.WriteLine("GetWeatherForecast took a request.");

        stopWatch.Stop();
        double elapsedTime = stopWatch.Elapsed.TotalMilliseconds;

        CustomMetrics.ObserveRequestDuration("Get", "GetWeatherForecast", elapsedTime);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

