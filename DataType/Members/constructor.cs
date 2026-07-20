#nullable enable

/*
Constructor syntax:

[access_modifier] TypeName(ParameterList)
{
    initializationStatements;
}

Constructor chaining:
TypeName() : this(arguments) { }        // Call another constructor of the same type
TypeName(...) : base(arguments) { }     // Call a base-class constructor

Primary constructor:
class TypeName(parameters) { }          // C# 12+
struct TypeName(parameters) { }         // C# 12+
record TypeName(parameters);            // Positional record

Static constructor:
static TypeName()
{
    staticInitialization;
}

Copy constructor:
TypeName(TypeName other)
{
    copyMembers;
}

Important rules:
A constructor has the same name as its containing type.
A constructor does not have a return type, including void.
Instance constructors can be overloaded.
A class with no instance constructor receives a public parameterless constructor.
Declaring any instance constructor prevents that compiler-generated class constructor.
Constructors can use public, protected, internal, private protected,
protected internal, or private accessibility.
Constructors are not inherited and cannot be virtual, abstract, or overridden.
A static constructor has no access modifier, parameters, or direct call.
A type can have only one static constructor.
A primary-constructor parameter does not automatically become a property.
Every struct has zero-initialized default construction.
*/


using System;


namespace ConstructorDemonstration;


// Compiler-generated parameterless constructor

public class EmptyClass
{
    // The compiler supplies: public EmptyClass()
}


// Instance, parameterized, overloaded, chained, and copy constructors

public class Person
{
    public string Name { get; } // Store the name

    public int Age { get; } // Store the age


    // Parameterless constructor

    public Person() : this("Unknown", 0)
    {
        Console.WriteLine("Person parameterless constructor"); // Run after the chained constructor
    }


    // Parameterized constructor

    public Person(string name, int age)
    {
        Name = name; // Initialize Name

        Age = age; // Initialize Age

        Console.WriteLine("Person parameterized constructor"); // Show constructor execution
    }


    // Overloaded constructor

    public Person(string name) : this(name, 0)
    {
        Console.WriteLine("Person one-parameter constructor"); // Show this overload
    }


    // Copy constructor

    public Person(Person other) : this(other.Name, other.Age)
    {
        Console.WriteLine("Person copy constructor"); // Copy another object's values
    }
}


// Base constructor and derived constructor

public class BaseEntity
{
    public int Id { get; } // Store the identifier

    protected BaseEntity(int id)
    {
        Id = id; // Initialize the base-class property

        Console.WriteLine("BaseEntity constructor"); // Base constructor runs first
    }
}

public class Student : BaseEntity
{
    public string Course { get; } // Store the course


    // Call the base-class constructor

    public Student(int id, string course) : base(id)
    {
        Course = course; // Initialize the derived-class property

        Console.WriteLine("Student constructor"); // Derived constructor runs after base
    }
}


// Static constructor

public class Configuration
{
    public static string Mode { get; } // Store shared configuration


    // Runs automatically before the type is first used

    static Configuration()
    {
        Mode = "Development"; // Initialize static data

        Console.WriteLine("Configuration static constructor"); // Runs only once
    }
}


// Private constructor and factory method

public class Ticket
{
    public int Number { get; } // Store the ticket number

    private Ticket(int number)
    {
        Number = number; // Initialize the ticket
    }

    public static Ticket Create(int number)
    {
        return new Ticket(number); // Create an object through the private constructor
    }
}


// Primary constructor

public class Product(string name, decimal price)
{
    public string Name { get; } = name; // Store the primary-constructor parameter

    public decimal Price { get; } = price; // Store the primary-constructor parameter


    // Additional constructor must call the primary constructor

    public Product() : this("Unknown", 0M)
    {
        Console.WriteLine("Product parameterless constructor"); // Run after primary initialization
    }

    public void Display()
    {
        Console.WriteLine($"{Name}: {Price:C}"); // Use primary-constructor values
    }
}


// Record primary constructor

public record Employee(string Name, int Age); // Generate properties and a primary constructor


// Struct constructor

public struct Point
{
    public int X { get; } // Store X

    public int Y { get; } // Store Y

    public Point(int x, int y)
    {
        X = x; // Initialize X

        Y = y; // Initialize Y
    }
}


// Primary constructor in a struct

public readonly struct Size(int width, int height)
{
    public int Width { get; } = width; // Store width

    public int Height { get; } = height; // Store height
}


// Program

internal static class Program
{
    private static void Main()
    {
        // Compiler-generated constructor

        EmptyClass empty = new EmptyClass(); // Call the compiler-generated constructor

        Console.WriteLine(empty.GetType().Name); // Use the created object


        // Parameterless constructor

        Person firstPerson = new Person(); // Chain to Person(string, int)

        Console.WriteLine($"{firstPerson.Name}, {firstPerson.Age}"); // Display initialized values


        // Parameterized constructor

        Person secondPerson = new Person("Saad", 24); // Supply all constructor arguments

        Console.WriteLine($"{secondPerson.Name}, {secondPerson.Age}"); // Display initialized values


        // Overloaded constructor

        Person thirdPerson = new Person("Aman"); // Select the one-parameter overload

        Console.WriteLine($"{thirdPerson.Name}, {thirdPerson.Age}"); // Display initialized values


        // Copy constructor

        Person copiedPerson = new Person(secondPerson); // Create a copy

        Console.WriteLine($"{copiedPerson.Name}, {copiedPerson.Age}"); // Display copied values


        // Base constructor

        Student student = new Student(101, "C#"); // BaseEntity runs before Student

        Console.WriteLine($"{student.Id}, {student.Course}"); // Display base and derived values


        // Static constructor

        Console.WriteLine(Configuration.Mode); // Trigger the static constructor

        Console.WriteLine(Configuration.Mode); // Static constructor does not run again


        // Private constructor

        Ticket ticket = Ticket.Create(5001); // Create through the factory method

        Console.WriteLine(ticket.Number); // Display the initialized value


        // Primary constructor

        Product product = new Product("Laptop", 50000M); // Call the primary constructor

        product.Display(); // Display stored values

        Product defaultProduct = new Product(); // Call the additional constructor

        defaultProduct.Display(); // Display default values


        // Record constructor

        Employee employee = new Employee("Sara", 25); // Call the generated primary constructor

        Employee copiedEmployee = employee with { Age = 26 }; // Use generated record copying

        Console.WriteLine(employee); // Display the original record

        Console.WriteLine(copiedEmployee); // Display the copied record


        // Struct constructors

        Point defaultPoint = new Point(); // Produce zero-initialized struct values

        Point point = new Point(10, 20); // Call the parameterized constructor

        Console.WriteLine($"{defaultPoint.X}, {defaultPoint.Y}"); // Display zero values

        Console.WriteLine($"{point.X}, {point.Y}"); // Display initialized values


        // Struct primary constructor

        Size size = new Size(1920, 1080); // Call the struct primary constructor

        Size defaultSize = default; // Produce a zero-initialized struct

        Console.WriteLine($"{size.Width} x {size.Height}"); // Display initialized values

        Console.WriteLine($"{defaultSize.Width} x {defaultSize.Height}"); // Display zero values
    }
}