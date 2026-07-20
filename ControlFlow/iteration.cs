/*
Loop statement syntax:

for (initialization; booleanCondition; iterator)
{
    statements;
}

while (booleanCondition)
{
    statements;
}

do
{
    statements;
}
while (booleanCondition);

foreach (Type item in collection)
{
    statements;
}

for is generally used when the number of iterations is controlled by a counter.
while checks its condition before every iteration and may execute zero times.
do-while checks its condition after every iteration and executes at least once.
foreach processes each element of a collection without using an index.
break terminates the nearest loop.
continue skips the remaining statements of the current iteration.
All three parts of for are optional, so for (;;) creates an infinite loop.
*/

using System; // Import Console

internal class Program // Declare the program class
{
    static void Main() // Start the program
    {
        for (int index = 0; index < 5; index++) // Initialize, check and update the counter
        {
            if (index == 1) // Check whether this iteration should be skipped
            {
                continue; // Start the next iteration
            }

            if (index == 4) // Check whether the loop should end
            {
                break; // Terminate the nearest loop
            }

            Console.WriteLine($"for: {index}"); // Display the current counter
        }

        int count = 0; // Initialize the value outside the while loop

        while (count < 2) // Check the condition before each iteration
        {
            Console.WriteLine($"while: {count}"); // Display the current value
            count++; // Update the value to prevent an infinite loop
        }

        bool repeat = false; // Store a false condition

        do // Execute the body before checking the condition
        {
            Console.WriteLine("do-while: executed once"); // This runs at least once
        }
        while (repeat); // Check whether another iteration is required

        string[] items = { "First", "Second", "Third" }; // Create an enumerable collection

        foreach (string item in items) // Receive each collection element one at a time
        {
            Console.WriteLine($"foreach: {item}"); // Use the current element
        }
    }
}