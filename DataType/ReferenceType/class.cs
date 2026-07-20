#nullable enable

/*
Class syntax:

[access_modifier] [class_modifier] class ClassName
{
    members;
}

Common class forms:

class BasicClass { }                         // Regular class
abstract class BaseClass { }                // Cannot be instantiated
sealed class FinalClass { }                 // Cannot be inherited
static class UtilityClass { }               // Contains only static members
partial class SplitClass { }                // Defined across multiple declarations
class GenericClass<T> { }                   // Works with a type parameter
class DerivedClass : BaseClass, IInterface  // One base class and interfaces
class Outer { class Nested { } }             // Nested class
record class DataRecord(...);               // Class with generated value equality
file class FileOnlyClass { }                 // Visible only in this source file

A class is a reference type.
Assigning a class variable copies the reference, not the object.
Multiple variables can therefore refer to the same object.
A class variable can be null.
A class can inherit from only one class but can implement multiple interfaces.
All classes ultimately derive from object.
A top-level class is internal by default.
A nested class is private by default.
*/


using System;


namespace ClassDemonstration;


// Regular class

internal class BasicClass
{
    public string Name { get; set; } = "Basic"; // Store minimal object state
}


// Interface used by a class

public interface IDescribable
{
    string Describe(); // Declare a contract
}


// Base class

public class BaseClass
{
    public virtual string Describe()
    {
        return "Base class"; // Return base-class information
    }
}


// Derived class

public class DerivedClass : BaseClass, IDescribable
{
    public override string Describe()
    {
        return "Derived class"; // Replace the inherited implementation
    }
}


// Abstract class

public abstract class AbstractClass
{
    public abstract string GetTypeName(); // Require derived-class implementation
}


// Sealed class

public sealed class FinalClass : AbstractClass
{
    public override string GetTypeName()
    {
        return "Sealed class"; // Implement the abstract member
    }
}


// Static class

public static class UtilityClass
{
    public static string GetMessage()
    {
        return "Static class"; // Return a shared result
    }
}


// Partial class: first declaration

public partial class PartialClass
{
    public string FirstPart()
    {
        return "First partial declaration"; // Represent the first part
    }
}


// Partial class: second declaration

public partial class PartialClass
{
    public string SecondPart()
    {
        return "Second partial declaration"; // Represent the second part
    }
}


// Generic class

public class Box<T>
{
    public T Value { get; } // Store a value of type T

    public Box(T value)
    {
        Value = value; // Initialize the generic value
    }
}


// Nested class

public class OuterClass
{
    public class NestedClass
    {
        public string Message => "Nested class"; // Return nested-class information
    }
}


// Record class

public record class PersonRecord(string Name); // Generate value equality and other members


// File-local class

file class FileOnlyClass
{
    public string Message => "File-local class"; // Accessible only in this file
}


// Program

internal static class Program
{
    private static void Main()
    {
        // Regular class object

        BasicClass first = new BasicClass(); // Create an object

        BasicClass second = first; // Copy the reference

        second.Name = "Changed through second reference"; // Modify the shared object

        Console.WriteLine(first.Name); // Show that both variables reference the same object

        Console.WriteLine(ReferenceEquals(first, second)); // Confirm identical references


        // Nullable class variable

        BasicClass? optionalObject = null; // Store no object reference

        Console.WriteLine(optionalObject?.Name ?? "null"); // Access safely


        // Inheritance and polymorphism

        BaseClass baseObject = new DerivedClass(); // Store a derived object in a base variable

        Console.WriteLine(baseObject.Describe()); // Call the overridden implementation


        // Abstract and sealed classes

        AbstractClass finalObject = new FinalClass(); // Use a sealed derived object

        Console.WriteLine(finalObject.GetTypeName()); // Call through the abstract base type


        // Static class

        Console.WriteLine(UtilityClass.GetMessage()); // Call without creating an object


        // Partial class

        PartialClass partialObject = new PartialClass(); // Create the combined partial class

        Console.WriteLine(partialObject.FirstPart()); // Use the first declaration

        Console.WriteLine(partialObject.SecondPart()); // Use the second declaration


        // Generic class

        Box<int> numberBox = new Box<int>(100); // Create a class for int

        Box<string> textBox = new Box<string>("Generic class"); // Create a class for string

        Console.WriteLine(numberBox.Value); // Display the integer value

        Console.WriteLine(textBox.Value); // Display the string value


        // Nested class

        OuterClass.NestedClass nestedObject =
            new OuterClass.NestedClass(); // Create a nested-class object

        Console.WriteLine(nestedObject.Message); // Use the nested class


        // Record class equality

        PersonRecord person1 = new PersonRecord("Saad"); // Create the first record object

        PersonRecord person2 = new PersonRecord("Saad"); // Create another equal record object

        Console.WriteLine(person1 == person2); // Compare generated value equality


        // File-local class

        FileOnlyClass fileObject = new FileOnlyClass(); // Create the file-local object

        Console.WriteLine(fileObject.Message); // Use it inside the same file


        // Every class derives from object

        object generalObject = first; // Store a class object as object

        Console.WriteLine(generalObject.GetType().Name); // Display its runtime class name
    }
}