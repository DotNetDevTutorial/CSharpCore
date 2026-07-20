#nullable enable

/*
Interface declaration:

[access_modifier] [partial] interface IName
{
}

Generic interface:

interface IName<T>
{
}

Generic interface with variance:

interface IProducer<out T>      // Covariant: T is returned
{
    T Produce();
}

interface IConsumer<in T>       // Contravariant: T is received
{
    void Consume(T value);
}

Interface inheritance:

interface IChild : IParent1, IParent2
{
}

Generic constraints:

interface IRepository<T>
    where T : class
{
}

Interface member syntax:

ReturnType Method(parameters);

Type Property { get; set; }

Type this[ParameterType index] { get; set; }

event EventHandler EventName;

const Type ConstantName = value;

Default interface member:

void Method()
{
    statements;
}

Private helper member:

private void Helper()
{
    statements;
}

Static members:

static Type FieldName = value;

static Type PropertyName => value;

static void Method()
{
    statements;
}

Static constructor:

static IName()
{
    statements;
}

Required static member:

static abstract Type PropertyName { get; }

static abstract ReturnType Method(parameters);

static abstract ReturnType operator +(Type left, Type right);

Optional static implementation:

static virtual ReturnType Method(parameters)
{
    statements;
}

Implicit implementation:

class ClassName : IName
{
    public ReturnType Method(parameters)
    {
    }
}

Explicit implementation:

class ClassName : IName
{
    ReturnType IName.Method(parameters)
    {
    }

    Type IName.Property
    {
        get;
        set;
    }

    Type IName.this[int index]
    {
        get;
        set;
    }

    event EventHandler IName.EventName
    {
        add;
        remove;
    }
}

An explicit implementation has no access modifier.
It is accessed through an interface reference.

Interfaces can be implemented by:
class, struct, record class and record struct.

An interface can inherit multiple interfaces.
An interface cannot inherit a class.
An interface cannot be instantiated directly.
Interface members are public by default.
Interfaces cannot contain instance fields, instance constructors or finalizers.
Top-level interfaces are internal by default.
A top-level interface can be public, internal or file.
*/


using System;

namespace InterfaceDemonstration;


// Basic interface

public interface IPrintable
{
    void Print(); // Declare a method
}


// Class implementation

public class Document : IPrintable
{
    public void Print() // Implicit implementation must be public
    {
        Console.WriteLine("Document printed.");
    }
}


// Struct implementation

public readonly struct Point : IPrintable
{
    public Point(int x, int y)
    {
        X = x; // Store X
        Y = y; // Store Y
    }

    public int X { get; } // Store X

    public int Y { get; } // Store Y

    public void Print()
    {
        Console.WriteLine($"Point: {X}, {Y}");
    }
}


// Record implementation

public record Message(string Text) : IPrintable
{
    public void Print()
    {
        Console.WriteLine(Text);
    }
}


// Property, indexer, event and method

public interface IDataStore
{
    string Name { get; set; } // Declare a property

    int this[int index] { get; set; } // Declare an indexer

    event EventHandler? Changed; // Declare an event

    void Update(int index, int value); // Declare a method
}


public class DataStore : IDataStore
{
    private readonly int[] _values = new int[3]; // Store indexed values

    public string Name { get; set; } = "Store"; // Implement the property

    public int this[int index]
    {
        get => _values[index]; // Implement the getter

        set => _values[index] = value; // Implement the setter
    }

    public event EventHandler? Changed; // Implement the event

    public void Update(int index, int value)
    {
        this[index] = value; // Update through the indexer

        Changed?.Invoke(this, EventArgs.Empty); // Raise the event
    }
}


// Explicit implementation

public interface IReader
{
    void Access(); // Declare Access
}


public interface IWriter
{
    void Access(); // Declare the same member
}


public class FileManager : IReader, IWriter
{
    void IReader.Access() // Explicitly implement IReader
    {
        Console.WriteLine("Reading file.");
    }

    void IWriter.Access() // Explicitly implement IWriter
    {
        Console.WriteLine("Writing file.");
    }
}


// Interface inheritance

public interface IIdentified
{
    int Id { get; } // Declare the ID contract
}


public interface INamed
{
    string Name { get; } // Declare the name contract
}


public interface IEmployee : IIdentified, INamed
{
    string Department { get; } // Add another contract
}


public class Employee : IEmployee
{
    public int Id { get; init; } // Implement IIdentified

    public string Name { get; init; } = string.Empty; // Implement INamed

    public string Department { get; init; } = string.Empty; // Implement IEmployee
}


// Default interface implementation

public interface IGreeter
{
    void Greet() // Provide a default implementation
    {
        Display("Default greeting.");
    }

    private static void Display(string message) // Private interface helper
    {
        Console.WriteLine(message);
    }
}


public class DefaultGreeter : IGreeter
{
    // Uses the default implementation
}


public class CustomGreeter : IGreeter
{
    public void Greet() // Replace the default implementation
    {
        Console.WriteLine("Custom greeting.");
    }
}


// Static interface members

public interface IApplicationInfo
{
    const string Name = "Interface demonstration"; // Declare a constant

    private static int _calls; // Declare a static field

    static IApplicationInfo() // Declare a static constructor
    {
        _calls = 0; // Initialize static data
    }

    public static int Calls => _calls; // Declare a static property

    public static void RegisterCall() // Declare a static method
    {
        _calls++; // Modify static data
    }
}


// Generic interface

public interface IRepository<T>
{
    void Add(T item); // Receive T

    T Get(); // Return T
}


public class Repository<T> : IRepository<T>
{
    private T? _item; // Store the item

    public void Add(T item)
    {
        _item = item; // Save the item
    }

    public T Get()
    {
        return _item
            ?? throw new InvalidOperationException("No item exists."); // Return the item
    }
}


// Covariant interface

public interface IProducer<out T>
{
    T Produce(); // T is used as output
}


public class Animal
{
    public string Name { get; init; } = string.Empty; // Store a name
}


public class Dog : Animal
{
}


public class DogProducer : IProducer<Dog>
{
    public Dog Produce()
    {
        return new Dog { Name = "Rocky" }; // Produce a Dog
    }
}


// Contravariant interface

public interface IConsumer<in T>
{
    void Consume(T item); // T is used as input
}


public class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal item)
    {
        Console.WriteLine($"Consumed: {item.Name}");
    }
}


// Static abstract members

public interface IAddable<TSelf>
    where TSelf : IAddable<TSelf>
{
    static abstract TSelf Zero { get; } // Require a static property

    static abstract TSelf operator +(TSelf left, TSelf right); // Require an operator
}


public readonly struct Number : IAddable<Number>
{
    public Number(int value)
    {
        Value = value; // Store the value
    }

    public int Value { get; } // Expose the value

    public static Number Zero => new Number(0); // Implement the static property

    public static Number operator +(Number left, Number right)
    {
        return new Number(left.Value + right.Value); // Implement the operator
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}


// Partial interface

public partial interface IService
{
    void Start(); // Declare the first part
}


public partial interface IService
{
    void Stop(); // Declare the second part
}


public class Service : IService
{
    public void Start()
    {
        Console.WriteLine("Service started.");
    }

    public void Stop()
    {
        Console.WriteLine("Service stopped.");
    }
}


// Nested interface

public class Container
{
    public interface INested
    {
        void Run(); // Declare a nested interface member
    }
}


public class NestedService : Container.INested
{
    public void Run()
    {
        Console.WriteLine("Nested interface executed.");
    }
}


// File-local interface

file interface IFileService
{
    void Execute(); // Visible only in this source file
}


file class FileService : IFileService
{
    public void Execute()
    {
        Console.WriteLine("File-local interface executed.");
    }
}


// Generic operation using static abstract members

internal static class InterfaceOperations
{
    public static T Add<T>(T first, T second)
        where T : IAddable<T>
    {
        return first + second; // Use the interface operator
    }

    public static T GetZero<T>()
        where T : IAddable<T>
    {
        return T.Zero; // Use the static interface property
    }
}


// Program

internal static class Program
{
    private static void Main()
    {
        // Class, struct and record implementation

        IPrintable document = new Document();

        IPrintable point = new Point(10, 20);

        IPrintable message = new Message("Record implementation.");

        document.Print();

        point.Print();

        message.Print();


        // Property, indexer, event and method

        IDataStore store = new DataStore();

        store.Changed += HandleChanged;

        store.Name = "Main Store";

        store[0] = 10;

        store.Update(1, 20);

        Console.WriteLine($"{store.Name}: {store[0]}, {store[1]}");


        // Explicit implementation

        FileManager manager = new FileManager();

        IReader reader = manager;

        IWriter writer = manager;

        reader.Access();

        writer.Access();


        // Interface inheritance

        IEmployee employee = new Employee
        {
            Id = 101,
            Name = "Saad",
            Department = "Data Engineering"
        };

        Console.WriteLine(
            $"{employee.Id}, {employee.Name}, {employee.Department}");


        // Default implementation

        IGreeter defaultGreeter = new DefaultGreeter();

        IGreeter customGreeter = new CustomGreeter();

        defaultGreeter.Greet();

        customGreeter.Greet();


        // Static interface members

        Console.WriteLine(IApplicationInfo.Name);

        IApplicationInfo.RegisterCall();

        IApplicationInfo.RegisterCall();

        Console.WriteLine(IApplicationInfo.Calls);


        // Generic interface

        IRepository<string> repository = new Repository<string>();

        repository.Add("Stored value");

        Console.WriteLine(repository.Get());


        // Covariance

        IProducer<Dog> dogProducer = new DogProducer();

        IProducer<Animal> animalProducer = dogProducer;

        Animal animal = animalProducer.Produce();

        Console.WriteLine(animal.Name);


        // Contravariance

        IConsumer<Animal> animalConsumer = new AnimalConsumer();

        IConsumer<Dog> dogConsumer = animalConsumer;

        dogConsumer.Consume(new Dog { Name = "Bruno" });


        // Static abstract members

        Number total = InterfaceOperations.Add(
            new Number(10),
            new Number(20));

        Number zero = InterfaceOperations.GetZero<Number>();

        Console.WriteLine($"Total: {total}, Zero: {zero}");


        // Partial interface

        IService service = new Service();

        service.Start();

        service.Stop();


        // Nested interface

        Container.INested nested = new NestedService();

        nested.Run();


        // File-local interface

        IFileService fileService = new FileService();

        fileService.Execute();
    }

    private static void HandleChanged(object? sender, EventArgs arguments)
    {
        Console.WriteLine("Store changed.");
    }
}