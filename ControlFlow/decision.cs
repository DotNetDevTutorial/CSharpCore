/*
Decision-control syntax:

if (booleanExpression)
{
    statements;
}
else if (anotherBooleanExpression) // Optional and repeatable
{
    statements;
}
else // Optional and written once
{
    statements;
}

switch (expression)
{
    case pattern:
        statements;
        break;

    case pattern when booleanExpression: // Optional Boolean guard
        statements;
        break;

    default: // Optional unmatched case
        statements;
        break;
}

A case contains a value or pattern compatible with the switch expression:
switch(int)    -> case 10: or case >= 10:
switch(string) -> case "Admin":
switch(bool)   -> case true:
switch(object) -> case int number:

Only the condition after when must return bool.

Conditional operator:
result = booleanExpression ? valueWhenTrue : valueWhenFalse;

Switch expression:
result = expression switch
{
    pattern => resultValue,
    pattern when booleanExpression => resultValue,
    _ => defaultResult
};
*/

using System; // Import Console

internal class Program // Declare the program class
{
    static void Main() // Start the program
    {
        int marks = 76; // Store marks
        string role = "Admin"; // Store a role

        if (marks >= 80) // Check the first Boolean condition
        {
            Console.WriteLine("Grade A"); // Run when the first condition is true
        }
        else if (marks >= 50) // Check when the previous condition is false
        {
            Console.WriteLine("Grade B"); // Run when this condition is true
        }
        else // Handle the remaining condition
        {
            Console.WriteLine("Fail"); // Run when all conditions are false
        }

        switch (marks) // Match the integer value with case patterns
        {
            case 0: // Constant pattern
                Console.WriteLine("Zero marks"); // Run when marks equals zero
                break; // Exit the switch

            case > 0 and < 50: // Relational and logical pattern
                Console.WriteLine("Below passing marks"); // Run for marks from 1 to 49
                break; // Exit the switch

            case int value when value % 2 == 0: // Type pattern with a Boolean guard
                Console.WriteLine("Passing even marks"); // Run for an even integer
                break; // Exit the switch

            default: // Handle every unmatched value
                Console.WriteLine("Passing odd marks"); // Run when no previous case matches
                break; // Exit the switch
        }

        string result = marks >= 50 ? "Pass" : "Fail"; // Select one of two values

        string access = role switch // Match role and return a value
        {
            "Admin" => "Full access", // Constant pattern
            "User" => "Limited access", // Another constant pattern
            string value when value.Length == 0 => "Empty role", // Pattern with a guard
            _ => "Unknown access" // Match every remaining value
        };

        Console.WriteLine(result); // Display the conditional-operator result
        Console.WriteLine(access); // Display the switch-expression result
    }
}