var tuple1 = new Tuple<string, bool>("aaa", true);
var tuple2 = Tuple.Create(10, true);
var tuple3 = Tuple.Create(10, true);

Console.WriteLine($"tuple2 == tuple3: {tuple2 == tuple3}"); // false       
Console.WriteLine($"tuple2.Equals(tuple3): "
                  + $"{tuple2.Equals(tuple3)}"); // true

var valueTuple1 = (x: 10, y: 20);
var valueTuple2 = (x: 10, y: 20);

Console.WriteLine($"valueTuple1 == valueTuple2: "
                  + $"{valueTuple1 == valueTuple2}"); // true
Console.WriteLine($"valueTuple1.Equals(valueTuple2): "
                  + $"{valueTuple1.Equals(valueTuple2)}"); // true

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