/*
Implicit numeric conversion syntax:
DestinationType result = sourceValue;

Complete conversion table:

sbyte  -> short, int, nint, long, float, double, decimal
byte   -> short, ushort, int, uint, nint, nuint, long, ulong, float, double, decimal
short  -> int, nint, long, float, double, decimal
ushort -> int, uint, nint, nuint, long, ulong, float, double, decimal
int    -> nint, long, float, double, decimal
uint   -> nuint, long, ulong, float, double, decimal
nint   -> long, float, double, decimal
nuint  -> ulong, float, double, decimal
long   -> float, double, decimal
ulong  -> float, double, decimal
char   -> ushort, int, uint, nint, nuint, long, ulong, float, double, decimal
float  -> double

No implicit numeric conversion starts from double or decimal.
No predefined implicit numeric conversion converts another type to char.
bool does not participate in numeric conversions.

Some conversions to float or double can lose precision even though
they are implicit.
*/

using System; // Import Console

internal class Program // Declare the program class
{
    static void Main() // Start the program
    {
        sbyte sbyteValue = 10; // Declare an sbyte value

        short sbyteToShort = sbyteValue; // Convert sbyte to short
        int sbyteToInt = sbyteValue; // Convert sbyte to int
        nint sbyteToNint = sbyteValue; // Convert sbyte to nint
        long sbyteToLong = sbyteValue; // Convert sbyte to long
        float sbyteToFloat = sbyteValue; // Convert sbyte to float
        double sbyteToDouble = sbyteValue; // Convert sbyte to double
        decimal sbyteToDecimal = sbyteValue; // Convert sbyte to decimal

        byte byteValue = 20; // Declare a byte value

        short byteToShort = byteValue; // Convert byte to short
        ushort byteToUshort = byteValue; // Convert byte to ushort
        int byteToInt = byteValue; // Convert byte to int
        uint byteToUint = byteValue; // Convert byte to uint
        nint byteToNint = byteValue; // Convert byte to nint
        nuint byteToNuint = byteValue; // Convert byte to nuint
        long byteToLong = byteValue; // Convert byte to long
        ulong byteToUlong = byteValue; // Convert byte to ulong
        float byteToFloat = byteValue; // Convert byte to float
        double byteToDouble = byteValue; // Convert byte to double
        decimal byteToDecimal = byteValue; // Convert byte to decimal

        short shortValue = 30; // Declare a short value

        int shortToInt = shortValue; // Convert short to int
        nint shortToNint = shortValue; // Convert short to nint
        long shortToLong = shortValue; // Convert short to long
        float shortToFloat = shortValue; // Convert short to float
        double shortToDouble = shortValue; // Convert short to double
        decimal shortToDecimal = shortValue; // Convert short to decimal

        ushort ushortValue = 40; // Declare a ushort value

        int ushortToInt = ushortValue; // Convert ushort to int
        uint ushortToUint = ushortValue; // Convert ushort to uint
        nint ushortToNint = ushortValue; // Convert ushort to nint
        nuint ushortToNuint = ushortValue; // Convert ushort to nuint
        long ushortToLong = ushortValue; // Convert ushort to long
        ulong ushortToUlong = ushortValue; // Convert ushort to ulong
        float ushortToFloat = ushortValue; // Convert ushort to float
        double ushortToDouble = ushortValue; // Convert ushort to double
        decimal ushortToDecimal = ushortValue; // Convert ushort to decimal

        int intValue = 50; // Declare an int value

        nint intToNint = intValue; // Convert int to nint
        long intToLong = intValue; // Convert int to long
        float intToFloat = intValue; // Convert int to float
        double intToDouble = intValue; // Convert int to double
        decimal intToDecimal = intValue; // Convert int to decimal

        uint uintValue = 60U; // Declare a uint value

        nuint uintToNuint = uintValue; // Convert uint to nuint
        long uintToLong = uintValue; // Convert uint to long
        ulong uintToUlong = uintValue; // Convert uint to ulong
        float uintToFloat = uintValue; // Convert uint to float
        double uintToDouble = uintValue; // Convert uint to double
        decimal uintToDecimal = uintValue; // Convert uint to decimal

        nint nintValue = 70; // Declare an nint value

        long nintToLong = nintValue; // Convert nint to long
        float nintToFloat = nintValue; // Convert nint to float
        double nintToDouble = nintValue; // Convert nint to double
        decimal nintToDecimal = nintValue; // Convert nint to decimal

        nuint nuintValue = 80; // Declare a nuint value

        ulong nuintToUlong = nuintValue; // Convert nuint to ulong
        float nuintToFloat = nuintValue; // Convert nuint to float
        double nuintToDouble = nuintValue; // Convert nuint to double
        decimal nuintToDecimal = nuintValue; // Convert nuint to decimal

        long longValue = 90L; // Declare a long value

        float longToFloat = longValue; // Convert long to float
        double longToDouble = longValue; // Convert long to double
        decimal longToDecimal = longValue; // Convert long to decimal

        ulong ulongValue = 100UL; // Declare a ulong value

        float ulongToFloat = ulongValue; // Convert ulong to float
        double ulongToDouble = ulongValue; // Convert ulong to double
        decimal ulongToDecimal = ulongValue; // Convert ulong to decimal

        char charValue = 'A'; // Declare a char value

        ushort charToUshort = charValue; // Convert char to ushort
        int charToInt = charValue; // Convert char to int
        uint charToUint = charValue; // Convert char to uint
        nint charToNint = charValue; // Convert char to nint
        nuint charToNuint = charValue; // Convert char to nuint
        long charToLong = charValue; // Convert char to long
        ulong charToUlong = charValue; // Convert char to ulong
        float charToFloat = charValue; // Convert char to float
        double charToDouble = charValue; // Convert char to double
        decimal charToDecimal = charValue; // Convert char to decimal

        float floatValue = 110.5F; // Declare a float value

        double floatToDouble = floatValue; // Convert float to double

        const int constantValue = 120; // Declare an int constant

        sbyte constantToSbyte = constantValue; // Convert fitting int constant to sbyte
        byte constantToByte = constantValue; // Convert fitting int constant to byte
        short constantToShort = constantValue; // Convert fitting int constant to short
        ushort constantToUshort = constantValue; // Convert fitting int constant to ushort
        uint constantToUint = constantValue; // Convert fitting int constant to uint
        nuint constantToNuint = constantValue; // Convert fitting int constant to nuint
        ulong constantToUlong = constantValue; // Convert fitting int constant to ulong

        const long positiveLongConstant = 130L; // Declare a positive long constant

        ulong constantLongToUlong = positiveLongConstant; // Convert positive long constant to ulong

        int normalValue = 140; // Declare a non-nullable value

        int? nullableInt = normalValue; // Convert int to nullable int
        long? nullableLong = normalValue; // Convert int to nullable long

        int? sourceNullable = 150; // Declare a nullable int

        long? convertedNullable = sourceNullable; // Convert nullable int to nullable long

        object boxedValue = normalValue; // Convert int to object by boxing
        ValueType boxedAsValueType = normalValue; // Convert int to ValueType
        IComparable boxedAsInterface = normalValue; // Convert int to an implemented interface

        Console.WriteLine("All implicit conversions compiled successfully."); // Display completion
    }
}