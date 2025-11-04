/* Topics: 
 Class that read json from an open api
 How to make a method asynchronous.
 Deserializing json data to C# objects*/

using System.Text.Json;
using System.Text.Json.Serialization;

var baseAddress = "https://swapi.dev/api/"; ;
var requestUri= "planets";

IApiDataReader apiDataReader = new ApiDataReader();

/* Read() is asynchronous, runs in the background and returns a Task<string>
 A Task acts like a promise — it takes some time to provide the final result
 The 'await' keyword tells the program to pause here until the Task completes
 then it extracts the string from the result of Task<string> Read().*/
var json = await apiDataReader.Read(baseAddress, requestUri);
var root = JsonSerializer.Deserialize<Root>(json);

if(root != null)
{
    foreach (var planet in root.results)
    {
        Console.WriteLine($"Name: {planet.name}, "
                          + $"Population: {planet.population}");
    }
}

Console.ReadKey();

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}

public class ApiDataReader : IApiDataReader
{
    // await can only be used inside asynchronous methods
    // All async methods return Tasks, in this case, Task<string>
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Result(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("climate")] string climate,
    [property: JsonPropertyName("gravity")] string gravity,
    [property: JsonPropertyName("terrain")] string terrain,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population,
    [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
    [property: JsonPropertyName("films")] IReadOnlyList<string> films,
    [property: JsonPropertyName("created")] DateTime created,
    [property: JsonPropertyName("edited")] DateTime edited,
    [property: JsonPropertyName("url")] string url
);

public record Root(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);

