#nullable enable

/*
Record class syntax:

[access_modifier] [abstract | sealed] [partial] record RecordName
{
    members;
}

[access_modifier] [abstract | sealed] [partial] record class RecordName
{
    members;
}

Positional record class:

[access_modifier] record RecordName(Type Property1, Type Property2);

[access_modifier] record class RecordName(
    Type Property1,
    Type Property2);

Record struct syntax:

[access_modifier] [readonly] [partial] record struct RecordName
{
    members;
}

Positional record struct:

[access_modifier] record struct RecordName(
    Type Property1,
    Type Property2);

readonly record struct RecordName(
    Type Property1,
    Type Property2);

Record inheritance:

record DerivedRecord(parameters)
    : BaseRecord(baseArguments), IInterface;

Generic record:

record Pair<T>(T First, T Second);

record Result<T>(T Value)
    where T : class;

Copy expression:

RecordType copy = original with
{
    Property = newValue
};

Deconstruction:

var (first, second) = positionalRecord;

Record means record class when class or struct is not written.
A record class is a reference type.
A record struct is a value type.
A record class can inherit only from another record class.
A record struct cannot inherit from another type but can implement interfaces.
Classes cannot inherit from records, and records cannot inherit from normal classes.
Both record classes and record structs can implement interfaces.

Positional record class properties are public and init-only.
Positional record struct properties are public and read-write.
Positional readonly record struct properties are public and init-only.

Positional records generate a primary constructor and Deconstruct method.
Records generate value equality, ==, !=, GetHashCode and ToString.
Record classes generate copying support used by with expressions.
A with expression performs a shallow copy by default.
A custom record-class copy constructor can change copying behavior.

A top-level record is internal by default.
A nested record is private by default.
Top-level records can use public, internal or file.
Records can be abstract, sealed, partial and generic.
There is no generic constraint that restricts T specifically to record types.
*/


using System;


namespace RecordDemonstration;


// Positional record class

public record Person(string Name, int Age);


// Explicit record class syntax

public record class Customer(string Name);


// Non-positional record class

public record Product
{
    public required string Name { get; init; } // Store required data

    public decimal Price { get; set; } // Store mutable data
}


// Positional property with changed accessibility

public record Account(string Username, string Secret)
{
    internal string Secret { get; init; } = Secret; // Replace the generated property
}


// Positional record struct

public record struct Point(int X, int Y);


// Readonly record struct

public readonly record struct Size(int Width, int Height);


// Interface implementation

public interface IDisplayable
{
    string Display(); // Declare a contract
}


public record Message(string Text) : IDisplayable
{
    public string Display()
    {
        return Text; // Implement the interface
    }
}


// Record inheritance

public abstract record Entity(int Id); // Declare an abstract base record


public sealed record Employee(
    int Id,
    string Name,
    string Department)
    : Entity(Id), IDisplayable
{
    public string Display()
    {
        return $"{Id}: {Name}, {Department}"; // Return record information
    }
}


public sealed record Contractor(
    int Id,
    string Name)
    : Entity(Id);


// Generic record

public record Pair<T>(T First, T Second);


// Generic record with constraint

public record Result<T>(T Value)
    where T : class;


// Partial record: first declaration

public partial record Settings
{
    public string Mode { get; init; } = "Default"; // Declare one property
}


// Partial record: second declaration

public partial record Settings
{
    public bool Enabled { get; init; } // Declare another property
}


// File-local record

file record FileNote(string Text);


// Record demonstrating shallow copying

public record Project(string Name, string[] Technologies);


// Record with a custom copy constructor

public record Report(string Title, string[] Sections)
{
    protected Report(Report original)
    {
        Title = original.Title; // Copy the text value

        Sections = (string[])original.Sections.Clone(); // Copy the array
    }
}


// Record containing a computed property

public record Coordinate(int X, int Y)
{
    public double Distance =>
        Math.Sqrt((X * X) + (Y * Y)); // Calculate from current values
}


// Program

internal static class Program
{
    private static void Main()
    {
        // Positional record construction

        Person firstPerson = new Person("Saad", 24);

        Person secondPerson = new Person("Saad", 24);

        Console.WriteLine(firstPerson);


        // Value equality

        Console.WriteLine(firstPerson == secondPerson); // Same values produce true

        Console.WriteLine(
            ReferenceEquals(firstPerson, secondPerson)); // Different objects produce false

        Console.WriteLine(
            firstPerson.GetHashCode() == secondPerson.GetHashCode()); // Equal records have equal hashes


        // Reference-type assignment

        Person assignedPerson = firstPerson; // Copy the reference

        Console.WriteLine(
            ReferenceEquals(firstPerson, assignedPerson)); // Both variables reference one object


        // With expression

        Person olderPerson = firstPerson with
        {
            Age = 25 // Change one property in the copied record
        };

        Person identicalCopy = firstPerson with { }; // Copy without changing values

        Console.WriteLine(firstPerson);

        Console.WriteLine(olderPerson);

        Console.WriteLine(firstPerson == olderPerson); // Display false

        Console.WriteLine(firstPerson == identicalCopy); // Display true

        Console.WriteLine(
            ReferenceEquals(firstPerson, identicalCopy)); // Display false


        // Deconstruction

        (string personName, int personAge) = firstPerson;

        Console.WriteLine($"{personName}, {personAge}");


        // Explicit record class syntax

        Customer customer = new Customer("Aman");

        Console.WriteLine(customer);


        // Non-positional record

        Product product = new Product
        {
            Name = "Laptop", // Initialize the required property

            Price = 50000M // Initialize the mutable property
        };

        product.Price = 48000M; // Modify a settable record property

        Console.WriteLine(product);


        // Record implementing an interface

        IDisplayable message = new Message("Record interface implementation");

        Console.WriteLine(message.Display());


        // Record inheritance

        Entity employee = new Employee(
            101,
            "Saad",
            "Data Engineering");

        Entity anotherEmployee = new Employee(
            101,
            "Saad",
            "Data Engineering");

        Entity contractor = new Contractor(
            101,
            "Saad");

        Console.WriteLine(employee == anotherEmployee); // Same runtime type and values

        Console.WriteLine(employee == contractor); // Different runtime record types

        Console.WriteLine(((IDisplayable)employee).Display());


        // Record struct value semantics

        Point firstPoint = new Point(10, 20);

        Point secondPoint = firstPoint; // Copy the complete value

        secondPoint.X = 100; // Modify only the copied value

        Console.WriteLine(firstPoint);

        Console.WriteLine(secondPoint);

        Console.WriteLine(firstPoint == new Point(10, 20)); // Use generated equality


        // Record struct with expression

        Point movedPoint = firstPoint with
        {
            Y = 50 // Change the copied value
        };

        Console.WriteLine(movedPoint);


        // Default record struct value

        Point defaultPoint = default; // Set all fields to their default values

        Console.WriteLine(defaultPoint);


        // Readonly record struct

        Size size = new Size(1920, 1080);

        Size resized = size with
        {
            Width = 1280 // Initialize a changed copy
        };

        Console.WriteLine(size);

        Console.WriteLine(resized);


        // Generic record

        Pair<int> numberPair = new Pair<int>(10, 20);

        Pair<string> textPair = new Pair<string>("First", "Second");

        Console.WriteLine(numberPair);

        Console.WriteLine(textPair);


        // Generic record with constraint

        Result<string> result = new Result<string>("Success");

        Console.WriteLine(result);


        // Partial record

        Settings settings = new Settings
        {
            Mode = "Production",

            Enabled = true
        };

        Console.WriteLine(settings);


        // File-local record

        FileNote note = new FileNote("Visible only in this source file");

        Console.WriteLine(note);


        // Shallow copy

        Project firstProject = new Project(
            "Application",
            new[] { "C#", "SQL" });

        Project secondProject = firstProject with
        {
            Name = "Copied Application"
        };

        secondProject.Technologies[0] = "Java"; // Modify the shared array

        Console.WriteLine(firstProject.Technologies[0]); // Also displays Java

        Console.WriteLine(
            ReferenceEquals(
                firstProject.Technologies,
                secondProject.Technologies)); // Display true


        // Custom copy constructor

        Report firstReport = new Report(
            "Original",
            new[] { "Introduction", "Conclusion" });

        Report secondReport = firstReport with
        {
            Title = "Copied Report"
        };

        secondReport.Sections[0] = "Modified introduction"; // Modify the copied array

        Console.WriteLine(firstReport.Sections[0]); // Original array remains unchanged

        Console.WriteLine(secondReport.Sections[0]);

        Console.WriteLine(
            ReferenceEquals(
                firstReport.Sections,
                secondReport.Sections)); // Display false


        // Computed property

        Coordinate coordinate = new Coordinate(3, 4);

        Coordinate changedCoordinate = coordinate with
        {
            X = 6
        };

        Console.WriteLine(coordinate.Distance); // Calculate using 3 and 4

        Console.WriteLine(changedCoordinate.Distance); // Recalculate using 6 and 4


        // Nullable records

        Person? optionalPerson = null; // Nullable record-class reference

        Point? optionalPoint = null; // Nullable record struct

        Console.WriteLine(optionalPerson?.Name ?? "No person");

        Console.WriteLine(optionalPoint?.ToString() ?? "No point");
    }
}