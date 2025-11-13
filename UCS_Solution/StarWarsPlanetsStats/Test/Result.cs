using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.Test;

// DTO representing a planet result from the API.
// Each property is explicitly mapped to its JSON field using [JsonPropertyName]. 
// This means property names in C# can be freely renamed (e.g., 'name' → 'PlanetName') without breaking deserialization. 
// Although renaming works, it’s best to keep DTOs consistent with the original JSON schema for clarity and maintainability.
// Deserialization Example:
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