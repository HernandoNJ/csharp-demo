// Enforce non-null at construction instead of many null checks
// Nullable reference types help the compiler detect possible nulls

var houses = new[]
{
    new House("name1", new Address("Street1", "453")),
    new House("name2", null) // ❌ will throw exception at runtime
};

foreach (var house in houses)
{
    Console.WriteLine($"Owner: {house.OwnerName}, "
                      + $"Address: {house.Address.Street}, {house.Address.Number}");
}

static string FormatHouseData(IEnumerable<House> houses) =>
    string.Join("\n", 
    houses.Select(house =>
        $"Owner: {house.OwnerName}, " +
        $"Address: {house.Address.Number} {house.Address.Street}"));
// ⚠️ Requires non-null Address; enforced via constructors below

static int GetLength(string? nullableText)
{
    // warning: nullable text may be null here
    return nullableText.Length;
}

static int GetLength2(string? nullableText)
{
    if (nullableText == null) return 0;
    return nullableText.Length;
}

class House
{
    public string OwnerName { get; }
    public Address Address { get; }

    public House(string ownerName, Address address)
    {
        OwnerName = ownerName ?? throw new ArgumentNullException(nameof(ownerName));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }
}

class Address
{
    public string Street { get; }
    public string Number { get; }

    public Address(string street, string number)
    {
        Street = street ?? throw new ArgumentNullException(nameof(street));
        Number = number ?? throw new ArgumentNullException(nameof(number));
    }
}

class Address2
{
    public string Street { get; }
    public string Number { get; }

    public Address2(string number)
    {
        Number = number;
    }
}

