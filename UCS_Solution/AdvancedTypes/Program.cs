var point = new Point(1, 3);
var anotherPoint = point;
anotherPoint.Y = 100;

Point a = null;

Console.WriteLine("point is: " + point);
Console.WriteLine("another point is: " + anotherPoint);

SomeMethod(5);
SomeMethod(new Person());

Console.ReadKey();

void SomeMethod<T>(T param) where T : struct
{

}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

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