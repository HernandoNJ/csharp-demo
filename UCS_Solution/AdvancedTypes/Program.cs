var point1 = new Point(3, 7);
var point2 = new Point(7, 10);
var sum = point1 + point2;

var pointTuple = (10, 20);

// Implicit conversion from ValuTuple to Point
// Explicit conversion can also be implemented
Point point3 = pointTuple;
Point point4 = (30, 40);

Console.ReadKey();

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
}