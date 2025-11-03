// int? numberOrNull = null -> is assigning an instance of new struct Nullable<int>();
int? numberOrNull = null;
Nullable<bool> boolOrNull1 = null;
Nullable<bool> boolOrNull2 = true;

var heights = new List<Nullable<int>>
{
    140, null, 170, null, 140
};

var heights2 = new List<int?>
{
    160, null, 220, null, 160
};

var averageHeights = heights.Average();

var averageHeights2 = heights2
    .Where(height => height is not null)
    .Average();

Console.WriteLine("Average height: " + averageHeights);
Console.WriteLine("Average2 height: " + averageHeights2);

Console.ReadKey();
