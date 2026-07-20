#nullable enable

/*
Variable syntax:

Type variableName;  // Declaration
Type variableName = value; // Declaration and initialization
variableName = newValue;  // Assignment
var variableName = value; // Compile-time type inference
Type? variableName = null;  // Nullable variable
value ?? fallbackValue // Use fallback when value is null
value ??= replacementValue  // Assign only when value is null
value?.Member // Access member only when value is not null
object boxed = valueTypeVariable;  // Boxing
ValueType unboxed = (ValueType)boxed;  // Unboxing
(Type name1, Type name2) tuple = (...);  // Named tuple
var anonymous = new { Member = value };  // Anonymous type
const Type name = constantValue; // Compile-time constant
readonly fields can be assigned at declaration or in a constructor.
static readonly fields can use runtime values.
ref local variables provide another name for the same storage.
*/

using System; // Import Console and DateTime

internal sealed class VariableDemo // Declare a supporting class
{
    private const int MaximumItems = 100; // Declare a compile-time constant field

    private readonly int _instanceId; // Declare an instance readonly field

    private static readonly DateTime StartedAt = DateTime.Now; // Declare a runtime constant-like field

    private static int _objectCount; // Declare a variable shared by all objects

    public VariableDemo(int instanceId) // Declare the constructor
    {
        _instanceId = instanceId; // Initialize the readonly field
        _objectCount++; // Update the shared variable
    }

    public void Demonstrate() // Demonstrate variable forms
    {
        int declaredNumber; // Declare a local variable

        declaredNumber = 10; // Initialize it after declaration

        int initializedNumber = 20; // Declare and initialize together

        initializedNumber = 25; // Assign a new value

        int firstNumber = 1, secondNumber = 2; // Declare multiple variables

        var inferredNumber = 30; // Infer int at compile time

        var inferredText = "C#"; // Infer string at compile time

        int defaultNumber = default; // Store the default int value

        string? defaultText = default; // Store the default nullable reference value

        DateTime defaultDate = default; // Store the default DateTime value

        int? nullableNumber = null; // Declare a nullable value-type variable

        nullableNumber = 40; // Store a value in the nullable variable

        bool containsValue = nullableNumber.HasValue; // Check whether a value exists

        int containedValue = nullableNumber.Value; // Read the stored value

        int safeContainedValue = nullableNumber.GetValueOrDefault(); // Read the value or zero

        nullableNumber = null; // Remove the stored value

        int numberOrFallback = nullableNumber ?? -1; // Use -1 when the value is null

        nullableNumber ??= 50; // Assign 50 because the variable is null

        string? nullableText = null; // Declare a nullable reference variable

        int? nullableLength = nullableText?.Length; // Produce null without accessing Length

        string textOrFallback = nullableText ?? "Unknown"; // Use fallback text

        nullableText ??= "Assigned by ??="; // Assign only because the variable is null

        object boxedNumber = initializedNumber; // Box the int inside an object

        int unboxedNumber = (int)boxedNumber; // Unbox the object back to int

        var employee = new // Create an anonymous-type variable
        {
            Id = 101, // Create an inferred read-only property
            Name = "Saad" // Create another inferred read-only property
        };

        (int Id, string Name) person = (102, "Aman"); // Declare a named tuple

        int personId = person.Id; // Access a named tuple element

        string personName = person.Name; // Access another tuple element

        (int id, string name) = person; // Deconstruct the tuple into variables

        var (_, selectedName) = person; // Discard the first tuple element

        (int, string) unnamedTuple = (103, "Sara"); // Declare an unnamed tuple

        int unnamedId = unnamedTuple.Item1; // Access an unnamed tuple element

        (firstNumber, secondNumber) = (secondNumber, firstNumber); // Swap variables using a tuple

        const int LocalLimit = 10; // Declare a local constant

        int originalNumber = 500; // Declare an original variable

        ref int referenceAlias = ref originalNumber; // Create an alias to the same storage

        referenceAlias = 600; // Modify the original through the alias

        ref readonly int readOnlyAlias = ref originalNumber; // Create a read-only reference alias

        object patternSource = "Pattern variable"; // Store a value as object

        if (patternSource is string message) // Declare a pattern variable after a successful match
        {
            Console.WriteLine(message); // Use the pattern variable
        }

        bool parsingSucceeded = int.TryParse("123", out int parsedNumber); // Declare an out variable

        dynamic runtimeVariable = 700; // Declare a runtime-bound variable

        runtimeVariable = "Dynamic text"; // Store a value of another type

        {
            int blockVariable = 800; // Declare a block-scoped variable

            Console.WriteLine($"Block variable: {blockVariable}"); // Use it within the block
        }

        Console.WriteLine($"Declared: {declaredNumber}"); // Display the declared variable
        Console.WriteLine($"Initialized: {initializedNumber}"); // Display the initialized variable
        Console.WriteLine($"Inferred: {inferredNumber}, {inferredText}"); // Display var variables
        Console.WriteLine($"Defaults: {defaultNumber}, {defaultText ?? "null"}, {defaultDate}"); // Display defaults
        Console.WriteLine($"Nullable: {containsValue}, {containedValue}, {safeContainedValue}"); // Display nullable results
        Console.WriteLine($"Coalescing: {numberOrFallback}, {nullableNumber}, {textOrFallback}"); // Display null handling
        Console.WriteLine($"Nullable text: {nullableText}, Length: {nullableLength?.ToString() ?? "null"}"); // Display null-safe access
        Console.WriteLine($"Boxed: {boxedNumber}, Unboxed: {unboxedNumber}"); // Display boxing results
        Console.WriteLine($"Anonymous: {employee.Id}, {employee.Name}"); // Display anonymous properties
        Console.WriteLine($"Tuple: {personId}, {personName}"); // Display named tuple values
        Console.WriteLine($"Deconstructed: {id}, {name}, {selectedName}"); // Display deconstructed values
        Console.WriteLine($"Unnamed tuple: {unnamedId}, {unnamedTuple.Item2}"); // Display unnamed tuple values
        Console.WriteLine($"Swapped: {firstNumber}, {secondNumber}"); // Display swapped variables
        Console.WriteLine($"Constants: {MaximumItems}, {LocalLimit}"); // Display constants
        Console.WriteLine($"Readonly: {_instanceId}, {StartedAt}"); // Display readonly fields
        Console.WriteLine($"Static variable: {_objectCount}"); // Display the shared variable
        Console.WriteLine($"Reference aliases: {originalNumber}, {referenceAlias}, {readOnlyAlias}"); // Display aliased storage
        Console.WriteLine($"Parsing: {parsingSucceeded}, {parsedNumber}"); // Display the out variable
        Console.WriteLine($"Dynamic: {runtimeVariable}"); // Display the runtime-bound variable
    }
}

internal static class Program // Declare the program class
{
    private static void Main() // Start the program
    {
        VariableDemo demo = new VariableDemo(1); // Create an object

        demo.Demonstrate(); // Run the variable demonstration
    }
}