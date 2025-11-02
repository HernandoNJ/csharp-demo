
var weatherDataPositionalRec = new WeatherDataPositionalRecord(25.1m, 65);
var warmerWeatherData = weatherDataPositionalRec with { Temperature = 30 };
Console.ReadKey();

public class WeatherData : IEquatable<WeatherData?>
{
    public decimal Temperature { get; }
    public int Humidity { get; }

    public WeatherData(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }

    public override string ToString()
        => $"Temperature: {Temperature}, Humidity: {Humidity}";

    public override bool Equals(object? obj)
        => Equals(obj as WeatherData);

    public bool Equals(WeatherData? other)
        => other is not null
           && Temperature == other.Temperature
           && Humidity == other.Humidity;

    public override int GetHashCode()
        => HashCode.Combine(Temperature, Humidity);

    public static bool operator ==(WeatherData? left, WeatherData? right)
        => EqualityComparer<WeatherData>.Default.Equals(left, right);

    public static bool operator !=(WeatherData? left, WeatherData? right)
        => !(left == right);
}

// Record
public class WeatherDataRecord
{
    // Allows setting the value of a property
    public decimal Temperature { get; set; }
    public int Humidity { get; }

    public WeatherDataRecord(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }

    // Allows creating custom methods
    public void SomeMethod()
    {

    }
}

// Positional Record
public record WeatherDataPositionalRecord(decimal Temperature, int Humidity);

// Positional record struct, mutable
public record struct RectangleMutableRecord(int X, int Y);

// Positional record struct, immutable
public readonly record struct RectangleImmutableRecord(int X, int Y);