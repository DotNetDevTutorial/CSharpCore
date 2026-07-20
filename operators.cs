/*
Syntax:
operand1 operator operand2;

Example:
int result = 10 + 5;

This program demonstrates the major C# operators:
Arithmetic, relational, logical, assignment, unary, bitwise, shift,
conditional, null-related, type, index, range, and other useful operators.
*/

using System; // Import the System namespace

class Animal // Create a parent class for demonstrating type operators
{
    public string Name { get; set; } = "Animal"; // Declare and initialize the Name property
}

class Dog : Animal // Create a child class that inherits from Animal
{
    public void Bark() // Declare a method
    {
        Console.WriteLine("Dog is barking"); // Display a message
    }
}

class Program // Declare the main program class
{
    static void Main() // Declare the entry point of the program
    {
        // Arithmetic operators

        int a = 10; // Store 10 in variable a
        int b = 3; // Store 3 in variable b

        Console.WriteLine($"Addition: {a + b}"); // Add a and b using the + operator
        Console.WriteLine($"Subtraction: {a - b}"); // Subtract b from a using the - operator
        Console.WriteLine($"Multiplication: {a * b}"); // Multiply a and b using the * operator
        Console.WriteLine($"Division: {a / b}"); // Divide a by b using the / operator
        Console.WriteLine($"Remainder: {a % b}"); // Find the remainder using the % operator

        // Relational or comparison operators

        Console.WriteLine($"Equal: {a == b}"); // Check whether a is equal to b
        Console.WriteLine($"Not equal: {a != b}"); // Check whether a is not equal to b
        Console.WriteLine($"Greater than: {a > b}"); // Check whether a is greater than b
        Console.WriteLine($"Less than: {a < b}"); // Check whether a is less than b
        Console.WriteLine($"Greater than or equal: {a >= b}"); // Check whether a is greater than or equal to b
        Console.WriteLine($"Less than or equal: {a <= b}"); // Check whether a is less than or equal to b

        // Logical operators

        bool firstCondition = true; // Store true in firstCondition
        bool secondCondition = false; // Store false in secondCondition

        Console.WriteLine($"Logical AND: {firstCondition && secondCondition}"); // Return true only when both conditions are true
        Console.WriteLine($"Logical OR: {firstCondition || secondCondition}"); // Return true when at least one condition is true
        Console.WriteLine($"Logical NOT: {!firstCondition}"); // Reverse the Boolean value using the ! operator

        // Assignment operators

        int number = 20; // Assign 20 to number
        Console.WriteLine($"Simple assignment: {number}"); // Display the assigned value

        number += 5; // Add 5 and assign the result to number
        Console.WriteLine($"After += 5: {number}"); // Display the result of +=

        number -= 3; // Subtract 3 and assign the result to number
        Console.WriteLine($"After -= 3: {number}"); // Display the result of -=

        number *= 2; // Multiply by 2 and assign the result to number
        Console.WriteLine($"After *= 2: {number}"); // Display the result of *=

        number /= 4; // Divide by 4 and assign the result to number
        Console.WriteLine($"After /= 4: {number}"); // Display the result of /=

        number %= 5; // Find the remainder and assign it to number
        Console.WriteLine($"After %= 5: {number}"); // Display the result of %=

        // Increment and decrement operators

        int count = 5; // Initialize count with 5

        Console.WriteLine($"Original value: {count}"); // Display the original count
        Console.WriteLine($"Post-increment: {count++}"); // Use the value first and then increase it
        Console.WriteLine($"After post-increment: {count}"); // Display the increased value
        Console.WriteLine($"Pre-increment: {++count}"); // Increase the value first and then use it
        Console.WriteLine($"Post-decrement: {count--}"); // Use the value first and then decrease it
        Console.WriteLine($"Pre-decrement: {--count}"); // Decrease the value first and then use it

        // Unary operators

        int positiveNumber = 8; // Store a positive number
        int negativeNumber = -positiveNumber; // Convert the number to negative using unary minus
        int sameNumber = +positiveNumber; // Keep the number positive using unary plus

        Console.WriteLine($"Unary plus: {sameNumber}"); // Display the result of unary plus
        Console.WriteLine($"Unary minus: {negativeNumber}"); // Display the result of unary minus
        Console.WriteLine($"Logical negation: {!firstCondition}"); // Reverse a Boolean value
        Console.WriteLine($"Bitwise complement: {~positiveNumber}"); // Reverse every bit using the ~ operator

        // Bitwise operators

        int x = 5; // Store binary value 0101
        int y = 3; // Store binary value 0011

        Console.WriteLine($"Bitwise AND: {x & y}"); // Perform AND operation on corresponding bits
        Console.WriteLine($"Bitwise OR: {x | y}"); // Perform OR operation on corresponding bits
        Console.WriteLine($"Bitwise XOR: {x ^ y}"); // Return 1 when corresponding bits are different
        Console.WriteLine($"Bitwise complement: {~x}"); // Reverse all bits of x

        // Bitwise assignment operators

        int bitValue = 6; // Store binary value 0110

        bitValue &= 3; // Perform bitwise AND and assign the result
        Console.WriteLine($"After &= 3: {bitValue}"); // Display the result of &=

        bitValue |= 4; // Perform bitwise OR and assign the result
        Console.WriteLine($"After |= 4: {bitValue}"); // Display the result of |=

        bitValue ^= 2; // Perform bitwise XOR and assign the result
        Console.WriteLine($"After ^= 2: {bitValue}"); // Display the result of ^=

        // Shift operators

        int shiftNumber = 8; // Store 8 for shift operations

        Console.WriteLine($"Left shift: {shiftNumber << 1}"); // Shift bits one position to the left
        Console.WriteLine($"Right shift: {shiftNumber >> 1}"); // Shift bits one position to the right

        shiftNumber <<= 1; // Left-shift the bits and assign the result
        Console.WriteLine($"After <<= 1: {shiftNumber}"); // Display the result of left-shift assignment

        shiftNumber >>= 1; // Right-shift the bits and assign the result
        Console.WriteLine($"After >>= 1: {shiftNumber}"); // Display the result of right-shift assignment

        // Conditional or ternary operator

        int age = 20; // Store the person's age
        string eligibility = age >= 18 ? "Eligible to vote" : "Not eligible to vote"; // Select a value based on a condition

        Console.WriteLine(eligibility); // Display the selected message

        // Null-coalescing operator

        string? userName = null; // Declare a nullable string with null value
        string displayedName = userName ?? "Guest"; // Use Guest when userName is null

        Console.WriteLine($"Displayed name: {displayedName}"); // Display the non-null value

        // Null-coalescing assignment operator

        string? city = null; // Declare a nullable city variable
        city ??= "Delhi"; // Assign Delhi only when city is null

        Console.WriteLine($"City: {city}"); // Display the city

        // Null-conditional operators

        string? message = null; // Declare a nullable string
        int? messageLength = message?.Length; // Access Length only when message is not null

        Console.WriteLine($"Message length: {messageLength?.ToString() ?? "No message"}"); // Safely display the message length

        int[]? nullableNumbers = null; // Declare a nullable integer array
        int? firstNumber = nullableNumbers?[0]; // Access the first element only when the array is not null

        Console.WriteLine($"First number: {firstNumber?.ToString() ?? "Array is null"}"); // Safely display the first array element

        // Type operators

        Animal animal = new Dog(); // Create a Dog object and store it in an Animal reference
        bool isDog = animal is Dog; // Check whether the object is a Dog

        Console.WriteLine($"animal is Dog: {isDog}"); // Display the result of the is operator

        Dog? dog = animal as Dog; // Safely convert Animal to Dog using the as operator
        dog?.Bark(); // Call Bark only when the conversion is successful

        // Explicit and implicit casting operators

        int wholeNumber = 25; // Store an integer value
        double decimalNumber = wholeNumber; // Implicitly convert int to double

        Console.WriteLine($"Implicit conversion: {decimalNumber}"); // Display the converted double value

        double price = 99.75; // Store a double value
        int roundedPrice = (int)price; // Explicitly convert double to int

        Console.WriteLine($"Explicit conversion: {roundedPrice}"); // Display the integer part of the value

        // Member access and method invocation operators

        string text = "Hello C#"; // Store text in a string variable
        int textLength = text.Length; // Access the Length member using the dot operator

        Console.WriteLine($"Text length: {textLength}"); // Invoke the WriteLine method using parentheses

        // Array access operator

        int[] values = { 10, 20, 30, 40, 50 }; // Create and initialize an integer array
        int selectedValue = values[2]; // Access the element at index 2 using square brackets

        Console.WriteLine($"Element at index 2: {selectedValue}"); // Display the selected array value

        // Index-from-end operator

        int lastValue = values[^1]; // Access the last element using the ^ operator
        int secondLastValue = values[^2]; // Access the second-last element using the ^ operator

        Console.WriteLine($"Last element: {lastValue}"); // Display the last element
        Console.WriteLine($"Second-last element: {secondLastValue}"); // Display the second-last element

        // Range operator

        int[] middleValues = values[1..4]; // Select elements from index 1 up to but not including index 4

        Console.WriteLine($"Range values: {string.Join(", ", middleValues)}"); // Display the selected range

        // typeof operator

        Type integerType = typeof(int); // Obtain type information for int

        Console.WriteLine($"Type name: {integerType.Name}"); // Display the type name

        // nameof operator

        string variableName = nameof(age); // Obtain the name of the age variable

        Console.WriteLine($"Variable name: {variableName}"); // Display the variable name

        // default operator

        int defaultInteger = default; // Store the default value of int
        bool defaultBoolean = default; // Store the default value of bool
        string? defaultString = default; // Store the default value of string

        Console.WriteLine($"Default int: {defaultInteger}"); // Display the default integer value
        Console.WriteLine($"Default bool: {defaultBoolean}"); // Display the default Boolean value
        Console.WriteLine($"Default string: {defaultString ?? "null"}"); // Display the default string value

        // new operator

        Dog newDog = new Dog(); // Create a new Dog object using the new operator
        newDog.Name = "Bruno"; // Assign a value to the Name property

        Console.WriteLine($"New dog name: {newDog.Name}"); // Display the object's property

        // String concatenation operator

        string firstName = "Saad"; // Store the first name
        string lastName = "Arfin"; // Store the last name
        string fullName = firstName + " " + lastName; // Join strings using the + operator

        Console.WriteLine($"Full name: {fullName}"); // Display the concatenated string

        // Operator precedence

        int precedenceResult = 10 + 5 * 2; // Perform multiplication before addition
        int bracketResult = (10 + 5) * 2; // Perform addition first because of parentheses

        Console.WriteLine($"Without parentheses: {precedenceResult}"); // Display the normal precedence result
        Console.WriteLine($"With parentheses: {bracketResult}"); // Display the result produced using parentheses

        // Checked operator

        int maximumValue = int.MaxValue; // Store the maximum possible int value

        try // Begin exception-handling block
        {
            int overflowResult = checked(maximumValue + 1); // Detect arithmetic overflow
            Console.WriteLine(overflowResult); // Display the result when no overflow occurs
        }
        catch (OverflowException) // Handle the overflow exception
        {
            Console.WriteLine("Overflow detected by checked operator"); // Display the overflow message
        }

        // Unchecked operator

        int uncheckedResult = unchecked(maximumValue + 1); // Allow overflow without throwing an exception

        Console.WriteLine($"Unchecked result: {uncheckedResult}"); // Display the wrapped overflow value
    }
}