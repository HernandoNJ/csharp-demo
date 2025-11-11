using System.Text.Json;
using System.Text.Json.Serialization;
using StarWarsPlanetsStats.ApiDataAccess;

// read data from starwars api
var baseAddress = "https://swapi.dev/";
var requestUri = "api/planets";

IApiDataReader apiDataReader = new ApiDataReader();

// Get Json data (string) from api
var json = await apiDataReader.Read(baseAddress, requestUri);

// Deserialize Json data to C# objects
var root = JsonSerializer.Deserialize<Root>(json);

Console.ReadKey();

// [property: JsonPropertyName("name")] can be removed and the code still works
// But if somebody changes the name to other like PlanetName, it won't work
// Changing the C# property name in [property: JsonPropertyName("diameter")] string PlanetDiameter will work
// WARNING: Result property names must not be changed
// If required, use the JsonPropertyName attribute
// Property names like rotation_period don't meet C# guidelines, but it is better
// To leave them as they are
// This type (Result) purpose is to represent what is given to us in Json
// We will transform it into custom types, keeping only the data and operations needed
// Types like these, used only to transfer data from one place to another are usually referred as DTOs (Data Transfer Objects)
// We should keep them simple and separate from our domain types

public record Result(
    string name,
    string rotation_period, // if changed to Rotation_period, won't work
    string orbital_period,
    [property: JsonPropertyName("diameter")] string PlanetDiameter,
    string climate,
    string gravity,
    string terrain,
    string surface_water,
    string population,
    IReadOnlyList<string> residents,
    IReadOnlyList<string> films,
    DateTime created,
    DateTime edited,
    string url
);

public record Root(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Result> results
);

// The Result items generated from the Json to C# webpage
// In this case, the C# property name can be changed.
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Result1(
    [property: JsonPropertyName("name")] string name, // PlanetName
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter, // PlanetDiameter
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