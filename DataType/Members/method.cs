#nullable enable

/*
General method syntax:

[access_modifier] [modifier] ReturnType MethodName(ParameterList)
{
    statements;
    return value;
}

Parameter forms:

Type value                         // Passed by value
ref Type value                     // Input and output; caller initializes
out Type value                     // Output; method must assign
in Type value                      // Read-only reference
Type value = defaultValue          // Optional parameter
params Type[] values               // Variable number of arguments

Calling forms:

Method(argument);
Method(ref variable);
Method(out variable);
Method(in variable);
Method(parameterName: argument);   // Named argument

C# has no inout keyword; ref provides input-and-output behavior.
A method returning void does not return a value.
A method can be overloaded by changing its parameter list.
The return type alone cannot distinguish overloaded methods.
Optional parameters must follow required parameters.
A params parameter must be the final parameter.
*/


using System; // Import Console
using System.Threading.Tasks; // Import Task


namespace MethodDemonstration;


// Extension methods

public static class StringExtensions
{
    public static int WordCount(this string text) // Extend the string type
    {
        return text.Split( // Split the string
            ' ', // Use a space as the separator
            StringSplitOptions.RemoveEmptyEntries).Length; // Return the word count
    }
}


// Method declarations

internal sealed class MethodDemo
{
    private readonly int[] _numbers = { 10, 20, 30 }; // Store values for ref return


    // Instance method with return value

    public int Add(int first, int second)
    {
        return first + second; // Return the sum
    }


    // Void method

    public void Display(string message)
    {
        Console.WriteLine(message); // Display the supplied message
    }


    // Static method

    public static int Square(int number)
    {
        return number * number; // Return the squared value
    }


    // Expression-bodied method

    public int Multiply(int first, int second) =>
        first * second; // Return the product


    // Method overloading

    public double Add(double first, double second)
    {
        return first + second; // Return the double sum
    }

    public int Add(int first, int second, int third)
    {
        return first + second + third; // Return the sum of three values
    }


    // Value parameter

    public void ChangeByValue(int value)
    {
        value = 100; // Modify only the local copy
    }


    // ref parameter

    public void ChangeByReference(ref int value)
    {
        value = 200; // Modify the original variable
    }


    // out parameter

    public bool TryDivide(
        int dividend,
        int divisor,
        out int result)
    {
        if (divisor == 0) // Check whether division is possible
        {
            result = 0; // Assign the out parameter

            return false; // Report failure
        }

        result = dividend / divisor; // Assign the division result

        return true; // Report success
    }


    // in parameter

    public int ReadValue(in int value)
    {
        return value; // Read without modifying the parameter
    }


    // Optional parameters

    public void Greet(
        string name = "Guest",
        string message = "Welcome")
    {
        Console.WriteLine($"{message}, {name}"); // Use supplied or default values
    }


    // params parameter

    public int Sum(params int[] numbers)
    {
        int total = 0; // Store the total

        foreach (int number in numbers) // Visit every supplied argument
        {
            total += number; // Add the current number
        }

        return total; // Return the total
    }


    // Generic method

    public T Echo<T>(T value)
    {
        return value; // Return a value of the supplied type
    }


    // Tuple-returning method

    public (int Minimum, int Maximum) GetLimits(
        int first,
        int second)
    {
        return first < second
            ? (first, second)
            : (second, first); // Return two named values
    }


    // Method returning a reference

    public ref int GetNumberReference(int index)
    {
        return ref _numbers[index]; // Return the original array element
    }


    // Asynchronous method

    public async Task<int> DoubleAsync(int number)
    {
        await Task.Delay(10); // Represent asynchronous work

        return number * 2; // Return the asynchronous result
    }
}


// Program

internal static class Program
{
    private static async Task Main()
    {
        MethodDemo demo = new MethodDemo(); // Create the method container


        // Instance and returning methods

        int sum = demo.Add(10, 20); // Call the instance method

        Console.WriteLine($"Add: {sum}"); // Display the returned value


        // Void method

        demo.Display("Void method"); // Call a method without a return value


        // Static method

        int square = MethodDemo.Square(5); // Call the method through its type

        Console.WriteLine($"Square: {square}"); // Display the result


        // Expression-bodied method

        Console.WriteLine(
            $"Multiply: {demo.Multiply(4, 5)}"); // Call the expression-bodied method


        // Overloaded methods

        Console.WriteLine(demo.Add(1.5, 2.5)); // Select the double overload

        Console.WriteLine(demo.Add(1, 2, 3)); // Select the three-parameter overload


        // Value parameter

        int valueNumber = 10; // Initialize the variable

        demo.ChangeByValue(valueNumber); // Pass a copy

        Console.WriteLine($"By value: {valueNumber}"); // Original remains unchanged


        // ref parameter

        int referenceNumber = 10; // Initialize before passing with ref

        demo.ChangeByReference(ref referenceNumber); // Pass the original variable

        Console.WriteLine($"ref: {referenceNumber}"); // Display the modified value


        // out parameter

        bool divided = demo.TryDivide(20, 4, out int quotient); // Receive an output value

        Console.WriteLine($"out: {divided}, {quotient}"); // Display the results


        // in parameter

        int inputNumber = 30; // Initialize before passing with in

        int readNumber = demo.ReadValue(in inputNumber); // Pass a read-only reference

        Console.WriteLine($"in: {readNumber}"); // Display the returned value


        // Optional arguments

        demo.Greet(); // Use both default arguments

        demo.Greet("Saad"); // Supply the first argument only

        demo.Greet("Saad", "Hello"); // Supply both arguments


        // Named arguments

        demo.Greet(
            message: "Good morning",
            name: "Saad"); // Supply arguments by parameter name


        // params arguments

        int paramsTotal = demo.Sum(1, 2, 3, 4); // Pass separate arguments

        int arrayTotal = demo.Sum(new[] { 5, 6, 7 }); // Pass an array

        Console.WriteLine($"params: {paramsTotal}, {arrayTotal}"); // Display both totals


        // Generic method

        int integerResult = demo.Echo(100); // Infer T as int

        string textResult = demo.Echo<string>("Generic method"); // Specify T explicitly

        Console.WriteLine($"{integerResult}, {textResult}"); // Display generic results


        // Tuple return

        (int minimum, int maximum) = demo.GetLimits(30, 10); // Deconstruct returned values

        Console.WriteLine($"Limits: {minimum}, {maximum}"); // Display both values


        // Ref return

        ref int numberReference =
            ref demo.GetNumberReference(1); // Create an alias to an array element

        numberReference = 200; // Modify the original element

        Console.WriteLine(
            $"Ref return: {demo.GetNumberReference(1)}"); // Read the changed element


        // Local function

        int Subtract(int first, int second)
        {
            return first - second; // Return the difference
        }

        Console.WriteLine($"Local function: {Subtract(10, 4)}"); // Call the local function


        // Extension method

        int wordCount =
            "C sharp extension method".WordCount(); // Call the method like an instance member

        Console.WriteLine($"Words: {wordCount}"); // Display the word count


        // Async method

        int asynchronousResult =
            await demo.DoubleAsync(25); // Await the asynchronous method

        Console.WriteLine($"Async: {asynchronousResult}"); // Display the result
    }
}