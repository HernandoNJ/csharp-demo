
Console.ReadKey();

readonly struct Point
{
    private readonly int z;
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"X: {X}, Y: {Y}";
}

public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
}