var john = new Person(1, "John");
var marie1 = new Person(1, "Marie");
var marie2 = new Person(2, "Marie");

Console.WriteLine("john.Equals(marie1): " + john.Equals(marie1));
Console.WriteLine("john.Equals(marie2): " + john.Equals(marie2));

Console.ReadKey();

struct Point
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"X: {X}, Y: {Y}";

    // Equals takes obj as parameter, so an argument of type Point (struct) must be boxed
    // Check if obj is of type Point. If so, obj is unboxed
    // Fields and properties are compared using reflection
    // Boxing, Unboxing, Reflection
    // Even if avoiding reflection, boxing and unboxing is applied
    public override bool Equals(object? obj)
    {
        return obj is Point point &&
               X == point.X &&
               Y == point.Y;
    }

    public bool Equals(Point other)
    {
        return X == other.X &&
               Y == other.Y;
    }
}

public class Person
{
    public int Id { get; init; }
    public string Name { get; init; }

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }

    // Overriding Equals() in a reference type.
    // It's recommended to also override GetHashCode() when overriding Equals.
    public override bool Equals(object? obj)
    {
        return obj is Person other &&
               Id == other.Id;
    }
}