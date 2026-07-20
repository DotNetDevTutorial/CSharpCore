/*
C# built-in simple value types commonly called primitive types:

Integral: sbyte, byte, short, ushort, int, uint, long, ulong, nint, nuint
Floating-point: float, double, decimal
Other: char, bool

Syntax:
Type variable = value;

Integer literals use no suffix by default.
Use U for uint, L for long, UL for ulong, F for float and M for decimal.
string and object are built-in types, but they are not primitive value types.
*/

using System; // Import Console

internal class Program // Declare the program class
{
    static void Main() // Start the program
    {
        sbyte signedByte = -100; // Store an 8-bit signed integer
        byte unsignedByte = 200; // Store an 8-bit unsigned integer

        short signedShort = -30000; // Store a 16-bit signed integer
        ushort unsignedShort = 60000; // Store a 16-bit unsigned integer

        int signedInteger = -2000000000; // Store a 32-bit signed integer
        uint unsignedInteger = 4000000000U; // Store a 32-bit unsigned integer

        long signedLong = -9000000000000000000L; // Store a 64-bit signed integer
        ulong unsignedLong = 18000000000000000000UL; // Store a 64-bit unsigned integer

        nint nativeInteger = -500; // Store a native-sized signed integer
        nuint nativeUnsignedInteger = 500U; // Store a native-sized unsigned integer

        float singlePrecision = 10.5F; // Store a 32-bit floating-point value
        double doublePrecision = 20.123456; // Store a 64-bit floating-point value
        decimal decimalValue = 30.123456789M; // Store a high-precision decimal value

        char character = 'A'; // Store one Unicode character
        bool booleanValue = true; // Store true or false

        Console.WriteLine($"sbyte: {signedByte}"); // Display the sbyte value
        Console.WriteLine($"byte: {unsignedByte}"); // Display the byte value
        Console.WriteLine($"short: {signedShort}"); // Display the short value
        Console.WriteLine($"ushort: {unsignedShort}"); // Display the ushort value
        Console.WriteLine($"int: {signedInteger}"); // Display the int value
        Console.WriteLine($"uint: {unsignedInteger}"); // Display the uint value
        Console.WriteLine($"long: {signedLong}"); // Display the long value
        Console.WriteLine($"ulong: {unsignedLong}"); // Display the ulong value
        Console.WriteLine($"nint: {nativeInteger}"); // Display the nint value
        Console.WriteLine($"nuint: {nativeUnsignedInteger}"); // Display the nuint value
        Console.WriteLine($"float: {singlePrecision}"); // Display the float value
        Console.WriteLine($"double: {doublePrecision}"); // Display the double value
        Console.WriteLine($"decimal: {decimalValue}"); // Display the decimal value
        Console.WriteLine($"char: {character}"); // Display the character
        Console.WriteLine($"bool: {booleanValue}"); // Display the Boolean value

        Console.WriteLine($"int range: {int.MinValue} to {int.MaxValue}"); // Display the int range
        Console.WriteLine($"double range: {double.MinValue} to {double.MaxValue}"); // Display the double range
        Console.WriteLine($"char range: {(int)char.MinValue} to {(int)char.MaxValue}"); // Display Unicode numeric range

        Console.WriteLine($"int size: {sizeof(int)} bytes"); // Display the int size
        Console.WriteLine($"double size: {sizeof(double)} bytes"); // Display the double size
        Console.WriteLine($"decimal size: {sizeof(decimal)} bytes"); // Display the decimal size
        Console.WriteLine($"char size: {sizeof(char)} bytes"); // Display the char size
        Console.WriteLine($"bool size: {sizeof(bool)} byte"); // Display the bool size

        int defaultInteger = default; // Store the default int value
        double defaultDouble = default; // Store the default double value
        char defaultCharacter = default; // Store the default char value
        bool defaultBoolean = default; // Store the default bool value

        Console.WriteLine($"Default int: {defaultInteger}"); // Display zero
        Console.WriteLine($"Default double: {defaultDouble}"); // Display zero
        Console.WriteLine($"Default char code: {(int)defaultCharacter}"); // Display the null-character code
        Console.WriteLine($"Default bool: {defaultBoolean}"); // Display false
    }
}