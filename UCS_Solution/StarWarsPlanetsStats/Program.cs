using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.DTOs;

// This global try/catch block will intercept all exceptions thrown in the program that were not caught elsewhere.
try
{
    await new StartWarsPlanetsStatsApp(
        new ApiDataReader(), 
        new MockStarWarsApiDataReader()).RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. Exception message: " + ex.Message);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public class StartWarsPlanetsStatsApp
{
    // Applying Dependency Inversion principle
    // This class must not depend on concrete types but on abstractions
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;

    private readonly string baseAddress = "https://swapi.dev/";
    private readonly string requestUri = "api/planets";

    public StartWarsPlanetsStatsApp(IApiDataReader apiDataReader,
                                    IApiDataReader secondaryApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
    }

    public async Task RunAsync()
    {
        string? json = null;

        // Adding try/catch block for api data reader
        try
        {
            json = await _apiDataReader.Read(baseAddress, requestUri);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API request unsuccessful, switching to mock api data. Exception message: " + ex.Message);
        }

        if (json is null)
        {
            json = await _secondaryApiDataReader.Read(baseAddress, requestUri);
        }

        // If deserialization fails, the global try catch block throws an exception
        var root = JsonSerializer.Deserialize<Root>(json);
    }
}
