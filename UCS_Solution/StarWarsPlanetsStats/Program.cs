using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.DTOs;

// Documentation comments
// Possible exceptions
// **********************************************************
// What happens if an exception is thrown? the program should continue? Or print error message and shut down?
// For ApiDataReader, if the http request fails, mock api can be used

var baseAddress = "https://swapi.dev/";
var requestUri = "api/planets";
string? json = null;

// Adding try/catch block for api data reader
try
{
    // API may be down and/or expected data not provided
    IApiDataReader apiDataReader = new ApiDataReader();
    json = await apiDataReader.Read(baseAddress, requestUri);
}
catch (HttpRequestException ex)
{
    Console.WriteLine("API request unsuccessful, switching to mock api data. Exception message: " + ex.Message);
}

if(json is null)
{
    IApiDataReader apiDataReader = new MockStarWarsApiDataReader();
    json = await apiDataReader.Read(baseAddress, requestUri);
}

// Deserialize<T>() contains 3 types of exceptions
// Here the program execution may fail because the Json data may not be deserialized correctly
// In this case, the program cannot continue and the developers must investigate the issue.
var root = JsonSerializer.Deserialize<Root>(json);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();