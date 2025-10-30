var john = new Person(1, "John");
var marie1 = new Person(1, "Marie");
var marie2 = new Person(2, "Marie");

Console.WriteLine("john.Equals(marie1): " + john.Equals(marie1));
Console.WriteLine("john.Equals(marie2): " + john.Equals(marie2));

var point1 = new Point(1, 5);
var point2 = new Point(1, 5);
var areEqual = point1.Equals(point2);

Console.ReadKey();

// IEquatable<T> compares if 2 objects are equal and returns bool
// IComparable<T> checks in what order objects should appear if sorted and return an int (-1,0,1)

struct Point : IEquatable<Point>
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
    // It is defined in the base class object as public virtual bool Equals(object? obj);
    public override bool Equals(object? obj)
    {
        return obj is Point point &&
               Equals(point);
    }

    // Avoiding Boxing, Unboxing, because other is of type Point (struct), not object
    // If the runtime sees 2 methods with the same name in a type, it will choose the more specialized one
    // This is the method that implements IEquatable ... bool Equals(T? other);
    // T can be any type
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