using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.DTOs;

// ⚠️ Property names must match the JSON field names exactly (case-sensitive) 
// unless a [JsonPropertyName] attribute is used. 
// For example:
// - If 'name' is renamed to 'PlanetName', the deserializer won't map the JSON "name" field.
// - If 'rotation_period' is renamed, add [JsonPropertyName("rotation_period")] to preserve mapping.
public record Result(
    string name,
    string rotation_period, 
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