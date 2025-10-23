// Using reflection to access the information about some type 
// at runtime and read the names and values of its properties
var converter = new ObjectToTextConverter();
Console.WriteLine(
    converter.Convert(
        new House("123 Maple Road", 170.6f, 2)));

Console.ReadKey();

public class ObjectToTextConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();
        var properties = type
            .GetProperties()
            .Where(p => p.Name != "EqualityContract");

        return string.Join(
            ", ",
            properties
            .Select(property =>
            $"{property.Name} is {property.GetValue(obj)}"));
    }

}

public record Pet(string Name, PetType PetType, float Weight);
public record House(string Address, float Area, int Floors);
public enum PetType { Cat, Dog, Fish }
