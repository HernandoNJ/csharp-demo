// moving point.x 1 unit to the right directly is not possible ... point.X += 1;
var point = new Point(10, 20);

// using with to create a new object with the modified value of point.x
var movedPoint1 = point with { X = 11 };
var movedPoint2 = point with { X = point.X +1 };

// Conditions for using with: the Properties (X,Y)
// Must be public, have get and init or set 
// It only works for structs, records and record structs and anonymous types
var pet = new { Name = "Lara", Type = "Fish" };
var pet2 = pet with { Type = "Bird" };

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
}

public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
}