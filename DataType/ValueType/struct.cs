/*
Struct syntax:

struct StructName
{
    members;
}

readonly struct StructName
{
    readonlyMembers;
}

ref struct StructName
{
    stackOnlyMembers;
}

readonly ref struct StructName
{
    readOnlyStackOnlyMembers;
}

record struct StructName(parameters);
readonly record struct StructName(parameters);

struct GenericStruct<T>(T parameter);     // Generic struct with primary constructor
partial struct StructName { }             // Struct divided into declarations

A struct is a value type and derives from System.ValueType.
Assignment, method arguments and return values copy the struct by default.
Use ref, in, out or ref readonly to avoid or control copying.
A struct can implement interfaces but cannot inherit from another class or struct.
A struct cannot be used as a base type and cannot declare a finalizer.
A struct can contain fields, properties, methods, constructors, events,
indexers, operators, constants, static members and nested types.
A struct cannot directly contain an instance field of its own type.
A normal struct cannot be null, but StructName? creates a nullable struct.
Converting a struct to object or an interface normally boxes it.

Every struct has a public parameterless constructor.
An explicitly declared parameterless constructor must be public.
new StructName() runs an explicit parameterless constructor.
default(StructName) always produces zero-initialized fields.
Struct arrays initially contain default values, not constructor-created values.
All fields must be assigned before a struct variable is read.
A field initializer requires the struct to declare a constructor.

A readonly struct cannot modify its instance state.
Fields in a readonly struct must be readonly.
Properties must be read-only or init-only.
Individual members of a mutable struct can also be marked readonly.

A ref struct is restricted to the stack and cannot be boxed.
It cannot normally be stored in an ordinary class, array or heap object.
It cannot be captured by a lambda or used across an await or yield boundary.
A record struct cannot also be a ref struct.

A record struct generates value equality, ToString, Deconstruct and with support.
Positional record struct properties are read-write.
Positional readonly record struct properties are init-only.

A normal primary-constructor parameter does not automatically become a property.
An inline array is a special struct containing a fixed number of elements.
*/

using System; // Import basic types

using System.Runtime.CompilerServices; // Import InlineArray

public interface IReadable // Declare an interface
{
    int Read(); // Declare a method
}

public struct Counter : IReadable // Declare a mutable struct
{
    public int Value { get; set; } = 1; // Initialize an instance property

    public static int CreatedCount { get; private set; } // Store shared data

    public Counter() // Declare a public parameterless constructor
    {
        CreatedCount++; // Count the constructed value
    }

    public Counter(int value) // Declare a parameterized constructor
    {
        Value = value; // Assign the property
        CreatedCount++; // Count the constructed value
    }

    public void Increment() // Declare a modifying method
    {
        Value++; // Modify the struct state
    }

    public readonly int Read() // Declare a non-modifying member
    {
        return Value; // Return the current value
    }

    public static Counter operator +(Counter left, Counter right) // Overload an operator
    {
        return new Counter(left.Value + right.Value); // Return a new struct value
    }

    public readonly override string ToString() // Override an inherited method
    {
        return Value.ToString(); // Return the value as text
    }
}

public struct PlainPair // Declare a struct with public fields
{
    public int Left; // Store the first value

    public int Right; // Store the second value
}

public readonly struct ReadOnlyPoint // Declare an immutable struct
{
    public int X { get; } // Declare a read-only property

    public int Y { get; } // Declare a read-only property

    public ReadOnlyPoint(int x, int y) // Initialize all properties
    {
        X = x; // Assign X
        Y = y; // Assign Y
    }

    public int Sum() // All instance members are implicitly readonly
    {
        return X + Y; // Return a calculated value
    }
}

public struct Pair<T>(T first, T second) // Declare a generic struct with a primary constructor
{
    public T First { get; } = first; // Store the first constructor parameter

    public T Second { get; } = second; // Store the second constructor parameter
}

public partial struct PartialValue // Declare the first part
{
    public int First; // Declare a member
}

public partial struct PartialValue // Declare the second part
{
    public int Second; // Declare another member
}

public record struct MutableRecord(int X, int Y); // Declare a mutable record struct

public readonly record struct ImmutableRecord(int X, int Y); // Declare a readonly record struct

public ref struct BufferView // Declare a stack-only struct
{
    private Span<int> buffer; // Store a stack-compatible span

    public BufferView(Span<int> buffer) // Receive a span
    {
        this.buffer = buffer; // Store the span
    }

    public int Length // Declare a property
    {
        get { return buffer.Length; } // Return the span length
    }

    public ref int this[int index] // Return an element by reference
    {
        get { return ref buffer[index]; } // Return the requested element
    }
}

public readonly ref struct ReadOnlyBufferView // Declare a readonly stack-only struct
{
    private readonly ReadOnlySpan<int> buffer; // Store a read-only span

    public ReadOnlyBufferView(ReadOnlySpan<int> buffer) // Receive a read-only span
    {
        this.buffer = buffer; // Store the span
    }

    public int this[int index] // Declare a read-only indexer
    {
        get { return buffer[index]; } // Return the requested value
    }
}

[InlineArray(3)] // Define the number of inline elements
public struct IntBuffer // Declare an inline-array struct
{
    private int firstElement; // Declare the required single field
}

internal class Program // Declare the program class
{
    static void ChangeCopy(Counter value) // Receive a copied struct
    {
        value.Increment(); // Modify only the copy
    }

    static void ChangeReference(ref Counter value) // Receive the original struct
    {
        value.Increment(); // Modify the original value
    }

    static int ReadReference(in Counter value) // Receive a read-only reference
    {
        return value.Read(); // Read without copying the complete struct
    }

    static void CreateValue(out Counter value) // Receive an output variable
    {
        value = new Counter(50); // Assign the output struct
    }

    static void Main() // Start the program
    {
        Counter constructed = new Counter(); // Run the explicit parameterless constructor

        Counter parameterized = new Counter(10); // Run the parameterized constructor

        Counter defaultValue = default; // Produce the zero-initialized value

        Counter[] counterArray = new Counter[2]; // Create default-initialized struct elements

        Console.WriteLine(constructed.Value); // Display 1

        Console.WriteLine(parameterized.Value); // Display 10

        Console.WriteLine(defaultValue.Value); // Display 0

        Console.WriteLine(counterArray[0].Value); // Display 0

        PlainPair directValue; // Declare a struct without new

        directValue.Left = 10; // Assign the first field

        directValue.Right = 20; // Assign the second field

        Console.WriteLine(directValue.Left + directValue.Right); // Read after assigning all fields

        Counter copiedValue = parameterized; // Copy the complete struct

        copiedValue.Increment(); // Modify only the copied value

        Console.WriteLine(parameterized.Value); // Display the unchanged original value

        Console.WriteLine(copiedValue.Value); // Display the changed copied value

        ChangeCopy(parameterized); // Pass a copied struct

        Console.WriteLine(parameterized.Value); // Original value remains unchanged

        ChangeReference(ref parameterized); // Pass the original struct by reference

        Console.WriteLine(parameterized.Value); // Original value is changed

        int readValue = ReadReference(in parameterized); // Pass a read-only reference

        Console.WriteLine(readValue); // Display the read value

        CreateValue(out Counter outputValue); // Receive an assigned struct

        Console.WriteLine(outputValue.Value); // Display the output value

        Counter combined = parameterized + outputValue; // Use the overloaded operator

        Console.WriteLine(combined.Value); // Display the combined value

        Counter changedCopy = parameterized with { Value = 100 }; // Copy and change one property

        Console.WriteLine(parameterized.Value); // Display the original value

        Console.WriteLine(changedCopy.Value); // Display the changed copy

        Counter? nullableValue = null; // Declare a nullable struct

        nullableValue = parameterized; // Store a struct value

        Console.WriteLine(nullableValue.HasValue); // Check whether it contains a value

        object boxedValue = parameterized; // Box the struct as object

        Counter unboxedValue = (Counter)boxedValue; // Unbox it to the original type

        Console.WriteLine(unboxedValue.Value); // Display the unboxed value

        IReadable boxedInterface = parameterized; // Box the struct as an interface

        Console.WriteLine(boxedInterface.Read()); // Call the interface member

        ReadOnlyPoint point = new ReadOnlyPoint(4, 6); // Create a readonly struct

        Console.WriteLine(point.Sum()); // Use its readonly state

        Pair<string> pair = new Pair<string>("First", "Second"); // Create a generic struct

        Console.WriteLine($"{pair.First}, {pair.Second}"); // Display its values

        PartialValue partial = new PartialValue // Create the combined partial struct
        {
            First = 1, // Initialize a member from the first declaration
            Second = 2 // Initialize a member from the second declaration
        };

        Console.WriteLine(partial.First + partial.Second); // Use both partial members

        MutableRecord record1 = new MutableRecord(1, 2); // Create a record struct

        MutableRecord record2 = record1 with { X = 10 }; // Create a modified copy

        bool recordsEqual = record1 == new MutableRecord(1, 2); // Use generated value equality

        var (recordX, recordY) = record2; // Use generated deconstruction

        Console.WriteLine(record1); // Use generated formatting

        Console.WriteLine($"{recordX}, {recordY}"); // Display deconstructed values

        Console.WriteLine(recordsEqual); // Display the equality result

        ImmutableRecord immutableRecord = new ImmutableRecord(5, 6); // Create a readonly record struct

        Console.WriteLine(immutableRecord); // Use generated formatting

        Span<int> storage = stackalloc int[] { 1, 2, 3 }; // Allocate stack storage

        BufferView bufferView = new BufferView(storage); // Create a ref struct

        bufferView[0] = 100; // Modify storage through the ref indexer

        ref int secondElement = ref bufferView[1]; // Store a reference to an element

        secondElement = 200; // Modify the referenced element

        Console.WriteLine($"{bufferView[0]}, {bufferView[1]}"); // Display modified values

        ReadOnlyBufferView readOnlyView = new ReadOnlyBufferView(storage); // Create a readonly ref struct

        Console.WriteLine(readOnlyView[2]); // Read a value

        IntBuffer inlineBuffer = default; // Create an inline array

        inlineBuffer[0] = 10; // Assign the first inline element

        inlineBuffer[1] = 20; // Assign the second inline element

        inlineBuffer[2] = 30; // Assign the third inline element

        Console.WriteLine(inlineBuffer[0] + inlineBuffer[1] + inlineBuffer[2]); // Read inline elements
    }
}