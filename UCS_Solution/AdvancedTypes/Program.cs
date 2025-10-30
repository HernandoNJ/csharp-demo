var john1 = new Person(1, "John");
var marie1 = new Person(1, "Marie");
var marie2 = new Person(2, "Marie");

Console.WriteLine("john.Equals(marie1): " + john1.Equals(marie1));
Console.WriteLine("john.Equals(marie2): " + john1.Equals(marie2));

var point1 = new Point(1, 5);
var point2 = new Point(1, 5);
Console.WriteLine("point1.Equals(point2): " + point1.Equals(point2));

Console.ReadKey();

struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

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