// Topics: Reading data from a public API using async and await

/* The 'using' keyword ensures the client object is automatically disposed
   when the method ends, preventing memory and socket leaks.
   It’s shorthand for: using (var client = new HttpClient()) { ... }
   Since HttpClient implements IDisposable, it must be disposed properly.
   However, in real applications, it’s recommended to reuse a single static
   HttpClient instance instead of creating one per request. */

/* Example of a reusable HttpClient service:
public static class HttpService
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<string> GetDataAsync(string url)
    {
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
*/

// Async methods execute without blocking the main thread, allowing other code to run concurrently.
// 'await' pauses the execution until the awaited task completes and returns its result.

using System.Text.Json;

using var client = new HttpClient 
{ BaseAddress = new Uri("https://api.census.gov/data/") };

var results = new List<object>();

// The previous api endpoint is not available
// https://datausa.io/api/data?drilldowns=Nation&measures=Population
// The new api endpoint response is available for each year, without 2020
for (int year = 2014; year <= 2024; year++)
{
    if (year == 2020) continue;

    string endpoint = $"{year}/acs/acs1?get=NAME,B01003_001E&for=us:1";
    HttpResponseMessage response = await client.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();

    var jsonString = await response.Content.ReadAsStringAsync();

    var json = JsonSerializer.Deserialize<object[][]>(jsonString);

    if (json?.Length > 1)
    {
        AddItemsToJson(results, year, json);
    }
}

// Serialized json with data as the sample json
string formatted = JsonSerializer
    .Serialize(new { data = results },
               new JsonSerializerOptions { WriteIndented = true });

// Save to file
await File.WriteAllTextAsync("us_population.json", formatted);

Console.WriteLine("Data saved to us_population.json");

Console.ReadKey();

static void AddItemsToJson(List<object> results, int year, object[][] json)
{
    string name = json[1][0]?.ToString() ?? "United States";
    string popValue = json[1][1]?.ToString() ?? "0";

    if (int.TryParse(popValue, out int population))
    {
        results.Add(new
        {
            ID_Nation = "01000US",
            Nation = name,
            ID_Year = year,
            Year = year.ToString(),
            Population = population,
            Slug_Nation = "united-states"
        });
    }
}