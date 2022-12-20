using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private HttpClient _client;
    public HomeController()
    {
        _client = new HttpClient();
        var uri = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["uri"];
        _client.BaseAddress = new Uri(uri);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Single works!");
    }

    [HttpGet("network")]
    public IActionResult NetworkRequest()
    {
        var response = _client.GetAsync("WeatherForecast").Result;
        return Ok(response.Content.ReadAsStringAsync().Result);
    }
}