// Pure function: no side effects, output depends only on input
var numbers = new List<int> { 1, 2, 3, 4 };
int Sum(IEnumerable<int> numbers)
{
    int sum = 0;
    foreach (var number in numbers)
        sum += number;
    return sum;
}

// calling pure function multiple times is safe
Console.WriteLine(Sum(numbers)); // 10
Console.WriteLine(Sum(numbers)); // 10 again, always same result

// *************

var numbersA = new List<int> { 1, 2, 3 };

// Shared state
// Needs to be reset to 0 before test
var _sum = 0;

// Impure: modifies shared state
int SumSoFar(int number)
{
    _sum += number; // Alters the field of the class
    return _sum; // result depends on a field
}

// Impure: modifies external object
void Add(List<int> list, int number)
{
    // Alters input parameter
    list.Add(number);
}

// Impure SumSoFar result depends on previous calls
Console.WriteLine(SumSoFar(5)); // 5
Console.WriteLine(SumSoFar(3)); // 8 (depends on previous state)
Console.WriteLine(SumSoFar(2)); // 10

// Impure Add modifies original list
Add(numbersA, 4);

// ************

// Identity mutation
var dictionary = new Dictionary<Person, string>();
var person = new Person("123456", "Ana", 1990);

// person is the key
// The hash code is calculated based on the Id
dictionary[person] = "aaa";

// The field Id is mutable, so it can be modified
// and the hashcode used by the dictionary is lost
person.Id = "new Id";
Console.WriteLine(dictionary[person]);

//Console.ReadKey();

public class Person(string id, string name, int birthYear)
{
    public string Id = id;
    public string Name = name;
    public int BirthYear = birthYear;

    public override int GetHashCode() => Id.GetHashCode();
}