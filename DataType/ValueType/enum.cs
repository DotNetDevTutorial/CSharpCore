/*
Enum syntax:

enum EnumName
{
    Member1,                    // Value starts from 0 by default
    Member2,                    // Previous value + 1
    Member3 = constantValue,    // Explicit value
    Alias = Member3             // Another name for the same value
}

enum EnumName : UnderlyingType
{
    Member = value
}

[Flags]
enum EnumName
{
    None = 0,
    Option1 = 1,
    Option2 = 2,
    Option3 = 4
}

Allowed underlying types:
sbyte, byte, short, ushort, int, uint, long and ulong

Important points:
The default underlying type is int.
An enum is a value type derived from System.Enum.
Enum members are named integral constants.
The first implicit value is 0 and each following value increases by 1.
Explicit and automatically calculated values can be mixed.
Two members may intentionally share the same value.
Aliases with the same value cannot be distinguished at runtime.
An enum body cannot contain methods, properties or normal fields.
The default enum value is always numeric zero, even when zero has no name.
Only a constant integer value of zero converts implicitly to an enum.
Other numeric-to-enum and enum-to-numeric conversions require casting.
A cast can create an enum value that has no declared member.
Use Enum.IsDefined when an undefined value must be rejected.
Flags members should normally use powers of two.
*/

using System; // Import Console and Enum

public enum Status // Use int as the underlying type
{
    None, // Automatically assign 0
    Pending = 5, // Explicitly assign 5
    Processing, // Automatically assign 6
    Completed = 10, // Explicitly assign 10
    Finished = Completed // Create an alias for Completed
}

public enum ErrorCode : ushort // Use ushort as the underlying type
{
    None = 0, // Represent no error
    InvalidInput = 100, // Assign an explicit value
    NotFound = 200 // Assign another explicit value
}

[Flags] // Mark the enum as a bit-field enum
public enum Permission : byte // Use byte as the underlying type
{
    None = 0, // Represent no selected flags
    Read = 1 << 0, // Store the first bit
    Write = 1 << 1, // Store the second bit
    Execute = 1 << 2, // Store the third bit
    ReadWrite = Read | Write, // Create a named combination
    All = Read | Write | Execute // Combine every flag
}

internal class Program
{
    static void DisplayEnum<TEnum>(TEnum value) where TEnum : struct, Enum // Accept only enum value types
    {
        Console.WriteLine($"{typeof(TEnum).Name}: {value}"); // Display the enum type and value
    }

    static void Main()
    {
        Status status = Status.Processing; // Assign a named enum member

        Status zeroStatus = 0; // Convert constant zero implicitly

        Status defaultStatus = default; // Produce the numeric value zero

        Status? optionalStatus = null; // Declare a nullable enum variable

        int numericValue = (int)status; // Convert an enum to its underlying number

        Status convertedStatus = (Status)10; // Convert a number to an enum

        Status undefinedStatus = (Status)99; // Create an unnamed enum value

        Console.WriteLine(status); // Display the member name

        Console.WriteLine(numericValue); // Display the underlying value

        Console.WriteLine(zeroStatus); // Display the member whose value is zero

        Console.WriteLine(defaultStatus); // Display the default enum value

        Console.WriteLine(optionalStatus?.ToString() ?? "null"); // Display a nullable enum

        Console.WriteLine(convertedStatus); // Display the value created by casting

        Console.WriteLine(undefinedStatus); // Display 99 because no member has this value

        bool knownValue = Enum.IsDefined(typeof(Status), convertedStatus); // Check a declared value

        bool unknownValue = Enum.IsDefined(typeof(Status), undefinedStatus); // Check an undeclared value

        Console.WriteLine($"Defined value: {knownValue}"); // Display true

        Console.WriteLine($"Undefined value: {unknownValue}"); // Display false

        Type underlyingType = Enum.GetUnderlyingType(typeof(Status)); // Get the underlying type

        Console.WriteLine($"Underlying type: {underlyingType.Name}"); // Display Int32

        string? memberName = Enum.GetName(typeof(Status), Status.Pending); // Get a name from a value

        Console.WriteLine($"Member name: {memberName}"); // Display Pending

        string[] memberNames = Enum.GetNames<Status>(); // Get all declared names

        foreach (string name in memberNames) // Visit every declared name
        {
            Status value = Enum.Parse<Status>(name); // Convert the name to its enum value

            Console.WriteLine($"{name} = {(int)value}"); // Display the name and number
        }

        Status[] memberValues = Enum.GetValues<Status>(); // Get one entry for every declared member

        Console.WriteLine($"Declared entries: {memberValues.Length}"); // Include duplicate-value members

        Status parsedStatus = Enum.Parse<Status>("Completed"); // Parse an exact member name

        bool parseSucceeded = Enum.TryParse<Status>( // Safely parse text
            "processing", // Supply a member name
            true, // Ignore uppercase and lowercase differences
            out Status parsedIgnoreCase); // Receive the parsed value

        Console.WriteLine(parsedStatus); // Display Completed

        Console.WriteLine($"{parseSucceeded}: {parsedIgnoreCase}"); // Display the parsing result

        bool numericParseSucceeded = Enum.TryParse<Status>("99", out Status parsedNumber); // Parse numeric text

        bool parsedNumberIsDefined = Enum.IsDefined(typeof(Status), parsedNumber); // Validate the parsed number

        Console.WriteLine($"{numericParseSucceeded}: {parsedNumber}"); // Parsing succeeds for numeric text

        Console.WriteLine($"Parsed number defined: {parsedNumberIsDefined}"); // Display false

        Console.WriteLine(status.ToString("G")); // Display the general name

        Console.WriteLine(status.ToString("D")); // Display the decimal value

        Console.WriteLine(status.ToString("X")); // Display the hexadecimal value

        string statusMessage = status switch // Use an enum in a switch expression
        {
            Status.None => "No status", // Match None
            Status.Pending => "Waiting", // Match Pending
            Status.Processing => "In progress", // Match Processing
            Status.Completed => "Completed", // Also covers its Finished alias
            _ => "Unknown status" // Handle an undefined value
        };

        Console.WriteLine(statusMessage); // Display the selected result

        Permission permissions = Permission.Read | Permission.Write; // Combine flags with OR

        bool hasRead = (permissions & Permission.Read) == Permission.Read; // Test a flag with AND

        bool hasWrite = permissions.HasFlag(Permission.Write); // Test a flag with HasFlag

        permissions |= Permission.Execute; // Add a flag

        permissions &= ~Permission.Write; // Remove a flag

        permissions ^= Permission.Execute; // Toggle a flag

        Console.WriteLine($"Permissions: {permissions}"); // Display the remaining flags

        Console.WriteLine($"Has Read: {hasRead}"); // Display the AND test

        Console.WriteLine($"Has Write: {hasWrite}"); // Display the HasFlag test

        Permission unnamedCombination = Permission.Read | Permission.Execute; // Create an unnamed combination

        bool combinationIsNamed = Enum.IsDefined(typeof(Permission), unnamedCombination); // Check for an exact named member

        Console.WriteLine(unnamedCombination.ToString("F")); // Format the value as separate flag names

        Console.WriteLine($"Named combination: {combinationIsNamed}"); // Display false

        byte permissionNumber = (byte)unnamedCombination; // Convert flags to the underlying byte

        Permission restoredPermissions = (Permission)permissionNumber; // Convert the byte back to flags

        Console.WriteLine(restoredPermissions); // Display the restored combination

        Enum boxedEnum = status; // Box the enum as System.Enum

        Status unboxedStatus = (Status)boxedEnum; // Unbox it to the original enum type

        Console.WriteLine(unboxedStatus); // Display the unboxed value

        DisplayEnum(ErrorCode.NotFound); // Use an enum with a generic Enum constraint
    }
}