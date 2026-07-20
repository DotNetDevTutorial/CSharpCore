#nullable enable

/*
Indexer syntax:

[access_modifier] ReturnType this[ParameterType parameter]
{
    get
    {
        return value;
    }

    set
    {
        // value contains the assigned value
    }
}

Read-only indexer:
public ReturnType this[int index] => expression;

Write-only indexer:
public ReturnType this[int index]
{
    set { }
}

Multiple-parameter indexer:
public ReturnType this[int row, int column] { get; set; }

Interface indexer:
ReturnType this[int index] { get; set; }

Ref-returning indexer:
public ref ReturnType this[int index] => ref storage[index];

Rules:
An indexer lets an object use array-like [] syntax.
The keyword this is used instead of an indexer name.
An indexer must have at least one parameter.
Indexer parameters do not have to be integers.
Indexers can be overloaded using different parameter lists.
The return type alone cannot overload an indexer.
Indexers can contain get, set, or both accessors.
Indexers cannot be auto-implemented because they require storage logic.
The value keyword contains the value assigned through the set accessor.
An indexer is an instance member and cannot be static.
Interface indexers declare the indexing contract.
The default metadata name of an indexer is Item.
A normal indexer result is not a variable unless it returns by reference.
*/


using System; // Import basic .NET types
using System.Collections.Generic; // Import Dictionary


namespace IndexerDemonstration;


// Interface indexer

public interface IIndexedStore<T>
{
    T this[int index] { get; set; } // Declare a read-write indexer
}


// Generic read-write and overloaded indexers

public sealed class IndexedStore<T> : IIndexedStore<T>
{
    private readonly T[] _items; // Store integer-indexed values

    private readonly Dictionary<string, T> _namedItems = new(); // Store named values

    public IndexedStore(int size)
    {
        _items = new T[size]; // Create the backing array
    }


    // Integer indexer

    public T this[int index]
    {
        get
        {
            ValidateIndex(index); // Validate the supplied index

            return _items[index]; // Return the indexed value
        }

        set
        {
            ValidateIndex(index); // Validate the supplied index

            _items[index] = value; // Store the assigned value
        }
    }


    // String indexer overload

    public T this[string key]
    {
        get
        {
            return _namedItems[key]; // Return the value associated with the key
        }

        set
        {
            _namedItems[key] = value; // Add or replace the named value
        }
    }


    // Read-only Index indexer

    public T this[Index index] => _items[index]; // Support indexes such as ^1


    // Read-only Range indexer

    public T[] this[Range range] => _items[range]; // Return the selected range


    // Index validation

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= _items.Length) // Check the valid range
        {
            throw new IndexOutOfRangeException(); // Reject an invalid index
        }
    }
}


// Indexer with restricted setter

public sealed class RestrictedStore
{
    private readonly string[] _items = new string[3]; // Create backing storage

    public string this[int index]
    {
        get
        {
            return _items[index]; // Allow public reading
        }

        private set
        {
            _items[index] = value; // Allow writing only inside this class
        }
    }

    public void Update(int index, string value)
    {
        this[index] = value; // Use the private setter
    }
}


// Write-only indexer

public sealed class WriteOnlyLogger
{
    public string this[int priority]
    {
        set
        {
            Console.WriteLine($"Priority {priority}: {value}"); // Process the assigned value
        }
    }
}


// Multiple-parameter indexer

public sealed class Matrix<T>
{
    private readonly T[,] _values; // Store two-dimensional values

    public Matrix(int rows, int columns)
    {
        _values = new T[rows, columns]; // Create the two-dimensional array
    }

    public T this[int row, int column]
    {
        get
        {
            return _values[row, column]; // Return the selected cell
        }

        set
        {
            _values[row, column] = value; // Assign the selected cell
        }
    }
}


// Ref-returning indexer

public sealed class RefBuffer
{
    private readonly int[] _values = { 10, 20, 30 }; // Create backing storage

    public ref int this[int index] => ref _values[index]; // Return the element by reference
}


// Program

internal static class Program
{
    private static void Main()
    {
        // Integer read-write indexer

        IndexedStore<string> store = new IndexedStore<string>(4); // Create the indexed store

        store[0] = "Zero"; // Call the integer set accessor

        store[1] = "One"; // Store another value

        store[2] = "Two"; // Store another value

        store[3] = "Three"; // Store another value

        Console.WriteLine(store[0]); // Call the integer get accessor


        // Interface indexer

        IIndexedStore<string> interfaceStore = store; // View the object through the interface

        interfaceStore[1] = "Updated One"; // Call the interface indexer setter

        Console.WriteLine(interfaceStore[1]); // Call the interface indexer getter


        // String indexer overload

        store["admin"] = "Full access"; // Call the string indexer setter

        store["guest"] = "Read-only access"; // Store another named value

        Console.WriteLine(store["admin"]); // Call the string indexer getter


        // Index and Range indexers

        Console.WriteLine(store[^1]); // Read the last element using Index

        string[] selectedItems = store[1..3]; // Read a range of elements

        Console.WriteLine(string.Join(", ", selectedItems)); // Display the selected range


        // Restricted setter indexer

        RestrictedStore restrictedStore = new RestrictedStore(); // Create the restricted store

        restrictedStore.Update(0, "Updated internally"); // Write through a class method

        Console.WriteLine(restrictedStore[0]); // Read through the public getter


        // Write-only indexer

        WriteOnlyLogger logger = new WriteOnlyLogger(); // Create the logger

        logger[1] = "Application started"; // Call the write-only setter

        logger[2] = "Warning received"; // Assign another log message


        // Multiple-parameter indexer

        Matrix<int> matrix = new Matrix<int>(2, 2); // Create a two-dimensional store

        matrix[0, 0] = 10; // Set the first cell

        matrix[0, 1] = 20; // Set the second cell

        matrix[1, 0] = 30; // Set the third cell

        matrix[1, 1] = 40; // Set the fourth cell

        Console.WriteLine(matrix[1, 1]); // Read a cell using two parameters


        // Ref-returning indexer

        RefBuffer buffer = new RefBuffer(); // Create the reference buffer

        ref int selectedValue = ref buffer[1]; // Create an alias to the indexed element

        selectedValue = 200; // Modify the original element through the alias

        Console.WriteLine(buffer[1]); // Display the modified element
    }
}