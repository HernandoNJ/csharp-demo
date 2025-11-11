using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.DTOs;

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