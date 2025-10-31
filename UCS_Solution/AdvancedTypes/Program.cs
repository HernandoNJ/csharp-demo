var point1 = new Point(3, 7);
var point2 = new Point(3, 7);
var point3 = new Point(6, -1);

// Default GetHashCode() implementation
// It may be slow or cause many hash code conflicts
Console.WriteLine("point1: " + point1.GetHashCode());
Console.WriteLine("point2: " + point2.GetHashCode());
Console.WriteLine("point3: " + point3.GetHashCode());

var person1 = new Person(1, "Ana");
var person1a = new Person(1, "Ana");
var person2 = new Person(2, "Bella");
Console.WriteLine("person1: " + person1.GetHashCode());
Console.WriteLine("person2: " + person1a.GetHashCode());

Console.ReadKey();

struct Point3d(int x, int y, int z)
{
    public int X = x;
    public int Y = y;
    public int Z = z;
}

struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y) { X = x; Y = y; }

    // operators overloading
    public static Point operator +(Point p1, Point p2)
        => new(p1.X + p2.X, p1.Y + p2.Y);

    public static bool operator ==(Point p1, Point p2)
        => p1.Equals(p2);

    public static bool operator !=(Point p1, Point p2)
        => !p1.Equals(p2);

    // Using ValueTuple to avoid using Tuple.Create
    public static implicit operator Point(ValueTuple<int, int> tuple)
        => new(tuple.Item1, tuple.Item2);

    public override string ToString()
        => $"X: {X}, Y: {Y}";

    public override bool Equals(object? obj)
        => obj is Point point && Equals(point);

    public bool Equals(Point other)
        => X == other.X && Y == other.Y;

    // It takes any objects and combines their hash codes
    // The objects can be anything and more than two items
    // Also, Equals() and this method are aligned by using X,Y
    public override int GetHashCode()
        => HashCode.Combine(X, Y);
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

    public override bool Equals(object? obj)
        => obj is Person other && Id == other.Id;

    public override int GetHashCode() => Id;
}