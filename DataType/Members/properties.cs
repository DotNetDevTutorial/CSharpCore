#nullable enable

/*
Property syntax:

[access_modifier] Type PropertyName
{
    get;
    set;
}

Property forms:

public string Name { get; set; }              // Read-write auto property
public int Id { get; }                        // Read-only property
public string Code { get; init; }             // Initialization-only property
public required string Email { get; init; }   // Required property
public string Status { get; private set; }     // Restricted accessor
public int Total => First + Second;            // Computed property

The get accessor returns a property value.
The set accessor assigns a value through the value keyword.
The init accessor allows assignment only during object initialization.
A property can use an explicit backing field or a compiler-generated field.
The field keyword accesses the generated backing field in C# 14.
Properties can be instance, static, abstract, virtual, or overridden.
*/


using System;


namespace PropertyDemonstration;


// Interface property

public interface INamed
{
    string Name { get; set; } // Declare a read-write property contract
}


// Abstract and virtual properties

public abstract class BaseItem
{
    public abstract string Description { get; } // Require a read-only property

    public virtual int Score { get; set; } // Declare an overridable property
}


// Property implementation

public sealed class Person : BaseItem, INamed
{
    private decimal _salary; // Backing field for Salary

    private string _password = string.Empty; // Backing field for Password


    // Static property

    public static int CreatedCount { get; private set; } // Store a shared value


    // Read-only auto property

    public int Id { get; } // Assignable in the constructor


    // Read-write auto property

    public string Name { get; set; } = "Unknown"; // Use generated storage


    // Nullable property

    public string? Nickname { get; set; } // Allow a string or null


    // Required init-only property

    public required string Email { get; init; } // Require initialization


    // Init-only property

    public string Code { get; init; } = "N/A"; // Prevent later assignment


    // Auto property with restricted setter

    public string Status { get; private set; } = "Created"; // Allow public reading only


    // Field-backed property using the field keyword

    public int Age
    {
        get; // Read the generated backing field

        set => field = value >= 0
            ? value
            : throw new ArgumentOutOfRangeException(nameof(value)); // Validate before assignment
    }


    // Property with an explicit backing field

    public decimal Salary
    {
        get
        {
            return _salary; // Return the backing field
        }

        private set
        {
            if (value < 0) // Validate the assigned value
            {
                throw new ArgumentOutOfRangeException(nameof(value)); // Reject negative salary
            }

            _salary = value; // Store the value
        }
    }


    // Expression-bodied computed property

    public string DisplayName =>
        Nickname ?? Name; // Return Nickname when available


    // Another computed property

    public bool IsAdult => Age >= 18; // Calculate the value when accessed


    // Write-only property

    public string Password
    {
        set
        {
            _password = value; // Store the assigned value
        }
    }


    // Read-only property using stored data

    public bool HasPassword =>
        _password.Length > 0; // Check whether a password was assigned


    // Abstract-property implementation

    public override string Description =>
        $"{Id}: {DisplayName}, Age {Age}"; // Implement the abstract property


    // Virtual-property override

    public override int Score { get; set; } // Override the base property


    // Constructor

    public Person(int id, decimal salary)
    {
        Id = id; // Assign the read-only property

        Salary = salary; // Use the private setter

        CreatedCount++; // Update the static property
    }


    // Method modifying private-set properties

    public void UpdateStatus(string status)
    {
        Status = status; // Modify the property inside the class
    }

    public void UpdateSalary(decimal salary)
    {
        Salary = salary; // Modify the property inside the class
    }
}


// Program

internal static class Program
{
    private static void Main()
    {
        // Object creation and property initialization

        Person person = new Person(101, 50000M)
        {
            Name = "Saad", // Call the set accessor

            Nickname = null, // Assign a nullable property

            Email = "saad@example.com", // Initialize the required property

            Code = "EMP-101", // Initialize the init-only property

            Age = 24, // Call the validated field-backed setter

            Score = 90 // Call the overridden setter
        };


        // Reading properties

        Console.WriteLine($"Id: {person.Id}"); // Read a get-only property

        Console.WriteLine($"Name: {person.Name}"); // Read an auto property

        Console.WriteLine($"Email: {person.Email}"); // Read a required property

        Console.WriteLine($"Code: {person.Code}"); // Read an init-only property

        Console.WriteLine($"Display name: {person.DisplayName}"); // Read a computed property

        Console.WriteLine($"Adult: {person.IsAdult}"); // Read a Boolean computed property

        Console.WriteLine($"Salary: {person.Salary}"); // Read a field-backed property

        Console.WriteLine($"Status: {person.Status}"); // Read a property with private setter


        // Updating writable properties

        person.Name = "Saad Arfin"; // Update a read-write property

        person.Nickname = "Saad"; // Update a nullable property

        person.Age = 25; // Update a validated property

        person.Score = 95; // Update an overridden property

        person.UpdateSalary(60000M); // Update a private-set property

        person.UpdateStatus("Active"); // Update another private-set property


        // Write-only property

        person.Password = "Secret123"; // Call the set-only accessor

        Console.WriteLine($"Password assigned: {person.HasPassword}"); // Check through another property


        // Interface property

        INamed namedItem = person; // View the object through the interface

        namedItem.Name = "Updated through interface"; // Use the interface property

        Console.WriteLine(namedItem.Name); // Read through the interface


        // Polymorphic properties

        BaseItem baseItem = person; // View the object through the base type

        Console.WriteLine(baseItem.Description); // Call the overridden property

        Console.WriteLine(baseItem.Score); // Read the overridden property


        // Static property

        Console.WriteLine($"Objects created: {Person.CreatedCount}"); // Read shared property data
    }
}