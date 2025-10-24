// *** We can access all the class' metadata using Reflection ***
// ---
// The metadata contains the info that this class is named "Person", is public, non-static, non-sealed, etc.
// It contains only 2 get only properties called "Name" and "YearOfBirth"
// It has one public constructor taking two parameters and one taking one parameter
// The actual data stored in a instance of this class would be the string representing the name and an int representing the year of birth - "John", 1952
// ---
// When we want to add extra metadata to a type or a method
// We use attributes
// ---
// Lets say we want to have a common way of validating some data
// in the application.
// No matter the type, we want to be able to specify that some members, for example strings, must have certain length.
// ---
// Person -> public string Name { get; } // length must be between 2 and 25
// Dog -> public string Name { get; } // length must be between 2 and 10
// ---
// Lets create a validator class that will be able to take objects of any class and check if for any of their properties this validation is required
// if so, it should check if the values of those properties are valid

// First, lets write how we would like to use the validator and then we'll implement it

using System.Runtime.CompilerServices;

var validPerson = new Person("John", 1981);
var invalidDog = new Dog("R");
var testValidator = new TestValidator();
Console.WriteLine(testValidator.Validate(validPerson) ?
    "Person is valid" :
    "Person is invalid");

Console.WriteLine(testValidator.Validate(invalidDog) ?
    "Dog is valid" :
    "Dog is invalid");

// Now we will add some metadata to the Name properties in both Person and Dog types defining length
// As this is extra metadata, we must use a custom attribute
// [StringLengthValidate(2,25)]

Console.ReadKey();


// StringLengthValidate is additional metadata added to the class
public class Person
{
    [StringLengthValidate(2, 25)]
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public Person(string name) => Name = name;
}

// StringLengthValidate is additional metadata added to the class
public class Dog
{
    [StringLengthValidate(2, 10)]
    public string Name { get; }
    public Dog(string name) => Name = name;
}

// This attribute must only hold the metadata about the min and max length of the string property
// We can enforce this attribute to be applied only to properties by using AttributeUsage
[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidateAttribute : Attribute
{
    public StringLengthValidateAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public int Min { get; }
    public int Max { get; }

}

// This class simply contains the Validate method
class TestValidator
{
    // This method takes an object and will look
    // for its properties with the StringLengthValidate
    // attribute defined
    public bool Validate(
        object obj,
        [CallerArgumentExpression(nameof(obj))] string instanceName = "")
    {
        // .Where(property ... selects the properties of the type for which the attribute is defined using LINQ's Where and the AttributeIsDefined methods.
        // Later, we make sure that the property is a string so we can iterate those properties, and for the values, check if their lengths are correct

        var objName = nameof(obj);
        var type = obj.GetType();

        var propertiesToValidate =
            type
            .GetProperties()
            .Where(property =>
                Attribute.IsDefined(
                    property,
                    typeof(StringLengthValidateAttribute)));

        foreach(var propertyItem in propertiesToValidate)
        {
            object? propertyValue = propertyItem.GetValue(obj);


            if(propertyValue is not string)
            {
                // throw an exception because it means the developer added the attribute to a wrong type
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidateAttribute)} can only be applied to strings.");
            }

            // Casting value property to string
            // It is safe because it was already checked before
            var value = (string)propertyValue;

            // Trying to access the attribute object by using the GetCustomAttributes() method from the property
            // The method takes the type of the attribute and a bool saying if we should also check the attributes have been inherited from the base type
            // First returns a collection tooking the first element
            var attribute =
                (StringLengthValidateAttribute)propertyItem
                .GetCustomAttributes(
                    typeof(StringLengthValidateAttribute),
                    true)
                .First();

            // Actual validation
            if(value.Length < attribute.Min ||
               value.Length > attribute.Max)
            {
                Console.WriteLine($"Property called --- {propertyItem.Name} --- in variable called --- {instanceName} --- is invalid, value is: {value}");
                return false;
            }
        }

        return true;
    }
}