/*
Exception-handling syntax:

try
{
    statementsThatMayFail;
}
catch (SpecificException exception) when (booleanCondition) // Filter is optional
{
    handlingStatements;
}
catch (Exception exception) // General catch should come after specific catches
{
    handlingStatements;
}
finally // Optional
{
    cleanupStatements;
}

throw new ExceptionType("Message"); // Create and throw an exception
throw; // Rethrow the current exception without losing its original details

try contains code that may cause an exception.
catch handles a matching exception.
Multiple catch blocks are checked from top to bottom.
finally executes whether an exception occurs or not.
A try statement requires at least one catch or finally block.
*/

using System; // Import exception and Console classes

internal class InvalidValueException : Exception // Declare a custom exception
{
    public InvalidValueException(string message) : base(message) // Pass the message to Exception
    {
    }
}

internal class Program // Declare the program class
{
    static int Divide(int firstNumber, int secondNumber) // Declare a method that may fail
    {
        if (secondNumber == 0) // Check an invalid value
        {
            throw new DivideByZeroException("The divisor cannot be zero."); // Throw a built-in exception
        }

        return firstNumber / secondNumber; // Return the division result
    }

    static void ValidateNumber(int number) // Declare a validation method
    {
        if (number < 0) // Check the validation rule
        {
            throw new InvalidValueException("The number cannot be negative."); // Throw a custom exception
        }
    }

    static void ProcessNumber(int number) // Declare a method that rethrows an exception
    {
        try // Start protected code
        {
            ValidateNumber(number); // Call the validation method
        }
        catch (InvalidValueException) // Catch the custom exception
        {
            Console.WriteLine("The validation failed."); // Perform local handling
            throw; // Rethrow while preserving the original exception information
        }
    }

    static void Main() // Start the program
    {
        try // Start code that may cause exceptions
        {
            int number = int.Parse("25"); // Convert text to an integer

            ProcessNumber(number); // Validate the number

            int result = Divide(number, 0); // Call a method that throws an exception

            Console.WriteLine(result); // Run only when no exception occurs
        }
        catch (FormatException exception) // Handle an invalid numeric format
        {
            Console.WriteLine(exception.Message); // Display the exception message
        }
        catch (DivideByZeroException exception) when (exception.Message.Length > 0) // Handle with a filter
        {
            Console.WriteLine(exception.Message); // Display the filtered exception
        }
        catch (InvalidValueException exception) // Handle the custom exception
        {
            Console.WriteLine(exception.Message); // Display the validation message
        }
        catch (Exception exception) // Handle any remaining exception
        {
            Console.WriteLine(exception.GetType().Name); // Display the exception type
            Console.WriteLine(exception.Message); // Display the exception message
        }
        finally // Execute after try and catch
        {
            Console.WriteLine("Exception handling completed."); // Perform final cleanup
        }
    }
}