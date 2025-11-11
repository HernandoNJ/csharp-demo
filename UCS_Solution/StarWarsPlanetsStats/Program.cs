using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.DTOs;

// read data from starwars api
var baseAddress = "https://swapi.dev/";
var requestUri = "api/planets";

IApiDataReader apiDataReader = new ApiDataReader();

// Get Json data (string) from api
var json = await apiDataReader.Read(baseAddress, requestUri);

// Deserialize Json data to C# objects
var root = JsonSerializer.Deserialize<Root>(json);

Console.ReadKey();