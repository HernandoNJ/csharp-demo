#nullable disable
// nullable warning disabled from here 
// to the end of the file or when enabled again
// warning removed from null keyword
string Text = null;
#nullable enable

string otherText = null; // string is not nullable
string otherText1 = "Hi"; // string with a valid value

// Reference types (class): Person, List, String
var person = new Person(null);
var list = new List<int>();

// otherText is not nullable
SomeMethodClassConstraint(otherText);
SomeMethodClassConstraint(otherText1);

SomeMethodNullableClassConstraint(otherText);
SomeMethodNullableClassConstraint(otherText1);
SomeMethodNullableClassConstraint(Text);
SomeMethodNullableClassConstraint(list);

var baseAnimal = new BaseAnimal();
var dog = new Dog();

SomeMethodNullableBaseClass(baseAnimal);
SomeMethodNullableDerivedClass(dog);

Console.ReadKey();

// class: non-nullable reference type
void SomeMethodClassConstraint<T>(T input) where T : class { }

// class?: allows nullable and non-nullable values
void SomeMethodNullableClassConstraint<T>(T input) where T : class? { }

// ? works for base and derived classes
void SomeMethodNullableBaseClass<T>(T input) where T : BaseAnimal? { }
void SomeMethodNullableDerivedClass<T>(T input) where T : Dog { }

// string name is not nullable, so it doesn't allow null as value
// string? allows null as value
class Person(string? name)
{
    public string Name { get; } = name;
}

class BaseAnimal { }
class Dog : BaseAnimal { }