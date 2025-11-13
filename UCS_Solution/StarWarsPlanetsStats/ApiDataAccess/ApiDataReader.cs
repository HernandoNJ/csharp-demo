namespace StarWarsPlanetsStats.ApiDataAccess;

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(requestUri);

        // HttpRequestException included in EnsureSuccessStatusCode method
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}