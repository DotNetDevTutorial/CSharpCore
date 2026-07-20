/*
Stack in C# - Brief Summary

A stack is a linear data structure that follows the LIFO principle.

LIFO means:
Last In, First Out

The element inserted last is removed first.

Real-life examples:
1. A stack of plates.
2. Browser back history.
3. Undo operations in an editor.
4. Function-call management.

Basic representation:

Top -> 40
       30
       20
       10

Top:
The position from which elements are inserted and removed.

Generic stack syntax:
Stack<dataType> stackName = new Stack<dataType>();

Example:
Stack<int> numbers = new Stack<int>();

Important Stack<T> operations:

Push(value):
Adds an element to the top of the stack.

Pop():
Removes and returns the top element.
It throws an InvalidOperationException when the stack is empty.

Peek():
Returns the top element without removing it.
It throws an InvalidOperationException when the stack is empty.

TryPop(out value):
Safely removes and returns the top element.
It returns false when the stack is empty.

TryPeek(out value):
Safely reads the top element without removing it.

Count:
Returns the total number of elements.

Contains(value):
Checks whether a particular value exists.

Clear():
Removes all elements from the stack.

ToArray():
Copies stack elements into an array from top to bottom.

Time complexity:
Push: O(1)
Pop: O(1)
Peek: O(1)
Contains: O(n)

Required namespace:
using System.Collections.Generic;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import the generic Stack<T> class

class StackProgram // Define the StackProgram class
{
    // Display stack

    static void DisplayStack(Stack<int> stack) // Define a method to display an integer stack
    {
        if (stack.Count == 0) // Check whether the stack is empty
        {
            Console.WriteLine("Stack is empty."); // Display the empty-stack message
            return; // Stop the method
        }

        Console.WriteLine("Top"); // Display the top indicator

        foreach (int value in stack) // Visit every stack element from top to bottom
        {
            Console.WriteLine(" | " + value + " |"); // Display the current stack element
        }

        Console.WriteLine(" -----"); // Display the bottom of the stack
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create stack

        Stack<int> numbers = new Stack<int>(); // Create an empty stack of integers

        Console.WriteLine("Initial stack:"); // Display the initial-stack heading
        DisplayStack(numbers); // Display the initially empty stack

        // Check empty stack

        bool isEmpty = numbers.Count == 0; // Check whether the stack is empty
        Console.WriteLine("Is stack empty: " + isEmpty); // Display whether the stack is empty

        // Push elements

        numbers.Push(10); // Add 10 to the top of the stack
        numbers.Push(20); // Add 20 to the top of the stack
        numbers.Push(30); // Add 30 to the top of the stack
        numbers.Push(40); // Add 40 to the top of the stack
        numbers.Push(50); // Add 50 to the top of the stack

        Console.WriteLine("\nStack after Push() operations:"); // Display the push-operation heading
        DisplayStack(numbers); // Display the stack after adding elements

        // Count elements

        int totalElements = numbers.Count; // Store the total number of stack elements
        Console.WriteLine("Total elements: " + totalElements); // Display the total number of elements

        // Peek top element

        int topElement = numbers.Peek(); // Read the top element without removing it
        Console.WriteLine("\nTop element using Peek(): " + topElement); // Display the top element

        Console.WriteLine("Stack after Peek():"); // Display the stack-after-peek heading
        DisplayStack(numbers); // Show that Peek did not remove the element

        // Pop top element

        int removedElement = numbers.Pop(); // Remove and return the top element
        Console.WriteLine("\nRemoved element using Pop(): " + removedElement); // Display the removed element

        Console.WriteLine("Stack after Pop():"); // Display the stack-after-pop heading
        DisplayStack(numbers); // Display the stack after removing its top element

        // Safe pop using TryPop

        bool wasRemoved = numbers.TryPop(out int safelyRemovedElement); // Try to remove the top element safely

        if (wasRemoved) // Check whether an element was removed
        {
            Console.WriteLine("\nSafely removed element: " + safelyRemovedElement); // Display the safely removed element
        }
        else // Execute when the stack is empty
        {
            Console.WriteLine("\nNo element is available for removal."); // Display the removal-failure message
        }

        Console.WriteLine("Stack after TryPop():"); // Display the stack-after-TryPop heading
        DisplayStack(numbers); // Display the updated stack

        // Safe peek using TryPeek

        bool wasFound = numbers.TryPeek(out int safelyReadElement); // Try to read the top element safely

        if (wasFound) // Check whether a top element exists
        {
            Console.WriteLine("\nTop element using TryPeek(): " + safelyReadElement); // Display the safely read element
        }
        else // Execute when the stack is empty
        {
            Console.WriteLine("\nStack does not contain a top element."); // Display the empty-stack message
        }

        // Search an element

        int searchValue = 20; // Store the value that must be searched
        bool valueExists = numbers.Contains(searchValue); // Check whether the value exists in the stack

        if (valueExists) // Check whether the value was found
        {
            Console.WriteLine(searchValue + " exists in the stack."); // Display the value-found message
        }
        else // Execute when the value was not found
        {
            Console.WriteLine(searchValue + " does not exist in the stack."); // Display the value-not-found message
        }

        // Traverse stack using foreach

        Console.WriteLine("\nStack elements from top to bottom:"); // Display the traversal heading

        foreach (int number in numbers) // Visit every stack element from top to bottom
        {
            Console.WriteLine(number); // Display the current stack element
        }

        // Calculate sum

        int sum = 0; // Initialize the sum with zero

        foreach (int number in numbers) // Visit every element in the stack
        {
            sum = sum + number; // Add the current element to the sum
        }

        Console.WriteLine("\nSum of stack elements: " + sum); // Display the sum of stack elements

        // Calculate average

        if (numbers.Count > 0) // Check whether the stack contains at least one element
        {
            double average = (double)sum / numbers.Count; // Calculate the average of stack elements
            Console.WriteLine("Average of stack elements: " + average); // Display the average
        }

        // Find maximum value

        if (numbers.Count > 0) // Check whether the stack contains elements
        {
            int maximum = int.MinValue; // Initialize the maximum with the smallest integer value

            foreach (int number in numbers) // Visit every stack element
            {
                if (number > maximum) // Check whether the current value is greater than the maximum
                {
                    maximum = number; // Update the maximum value
                }
            }

            Console.WriteLine("Maximum value: " + maximum); // Display the maximum stack value
        }

        // Find minimum value

        if (numbers.Count > 0) // Check whether the stack contains elements
        {
            int minimum = int.MaxValue; // Initialize the minimum with the largest integer value

            foreach (int number in numbers) // Visit every stack element
            {
                if (number < minimum) // Check whether the current value is smaller than the minimum
                {
                    minimum = number; // Update the minimum value
                }
            }

            Console.WriteLine("Minimum value: " + minimum); // Display the minimum stack value
        }

        // Convert stack to array

        int[] stackArray = numbers.ToArray(); // Copy stack elements into an array from top to bottom

        Console.WriteLine("\nStack converted to array:"); // Display the array-conversion heading

        foreach (int number in stackArray) // Visit every element of the converted array
        {
            Console.Write(number + " "); // Display the current array element
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Create stack from collection

        int[] initialValues = { 100, 200, 300, 400 }; // Create an array containing initial values
        Stack<int> secondStack = new Stack<int>(initialValues); // Create a stack using the array values

        Console.WriteLine("\nStack created from an array:"); // Display the collection-constructor heading
        DisplayStack(secondStack); // Display the second stack

        // Understand collection order

        Console.WriteLine("Top element of second stack: " + secondStack.Peek()); // Display the last array value as the top element

        // Copy stack to another stack

        int[] temporaryArray = secondStack.ToArray(); // Copy the stack into an array from top to bottom
        Array.Reverse(temporaryArray); // Reverse the array to preserve the original stack order
        Stack<int> copiedStack = new Stack<int>(temporaryArray); // Create a new stack with the same element order

        Console.WriteLine("\nCopied stack:"); // Display the copied-stack heading
        DisplayStack(copiedStack); // Display the copied stack

        // Remove all elements using loop

        Console.WriteLine("\nRemoving every element from the second stack:"); // Display the removal-loop heading

        while (secondStack.Count > 0) // Continue while the second stack contains elements
        {
            int currentElement = secondStack.Pop(); // Remove the current top element
            Console.WriteLine("Removed: " + currentElement); // Display the removed element
        }

        Console.WriteLine("Second stack after removing all elements:"); // Display the empty-second-stack heading
        DisplayStack(secondStack); // Display the empty second stack

        // Prevent Pop exception

        if (secondStack.Count > 0) // Check whether Pop can be performed safely
        {
            int value = secondStack.Pop(); // Remove the top element
            Console.WriteLine("Removed value: " + value); // Display the removed value
        }
        else // Execute when the second stack is empty
        {
            Console.WriteLine("Pop cannot be performed because the stack is empty."); // Display the safety message
        }

        // Prevent Peek exception

        if (secondStack.Count > 0) // Check whether Peek can be performed safely
        {
            int value = secondStack.Peek(); // Read the top element
            Console.WriteLine("Top value: " + value); // Display the top value
        }
        else // Execute when the second stack is empty
        {
            Console.WriteLine("Peek cannot be performed because the stack is empty."); // Display the safety message
        }

        // String stack example

        Stack<string> browserHistory = new Stack<string>(); // Create an empty stack of webpage names

        browserHistory.Push("Home Page"); // Add the home page to browser history
        browserHistory.Push("Products Page"); // Add the products page to browser history
        browserHistory.Push("Cart Page"); // Add the cart page to browser history
        browserHistory.Push("Payment Page"); // Add the payment page to browser history

        Console.WriteLine("\nCurrent page: " + browserHistory.Peek()); // Display the current webpage

        string previousPage = browserHistory.Pop(); // Remove the current page to move backward
        Console.WriteLine("Leaving page: " + previousPage); // Display the page being left
        Console.WriteLine("Previous page: " + browserHistory.Peek()); // Display the previous webpage

        // Reverse values using stack

        string originalText = "STACK"; // Store the text that must be reversed
        Stack<char> characterStack = new Stack<char>(); // Create a stack of characters

        foreach (char character in originalText) // Visit every character in the original text
        {
            characterStack.Push(character); // Add the current character to the stack
        }

        string reversedText = ""; // Create an empty string for the reversed text

        while (characterStack.Count > 0) // Continue until every character has been removed
        {
            reversedText = reversedText + characterStack.Pop(); // Remove and append the top character
        }

        Console.WriteLine("\nOriginal text: " + originalText); // Display the original text
        Console.WriteLine("Reversed text: " + reversedText); // Display the reversed text

        // Clear stack

        Console.WriteLine("\nFirst stack before Clear():"); // Display the stack-before-clear heading
        DisplayStack(numbers); // Display the stack before clearing it

        numbers.Clear(); // Remove every element from the first stack

        Console.WriteLine("First stack after Clear():"); // Display the stack-after-clear heading
        DisplayStack(numbers); // Display the cleared stack

        // Final stack status

        Console.WriteLine("Final stack count: " + numbers.Count); // Display the final number of elements
        Console.WriteLine("Is final stack empty: " + (numbers.Count == 0)); // Display whether the final stack is empty
    }
}