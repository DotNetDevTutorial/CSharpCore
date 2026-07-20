/*
Queue in C# - Brief Summary

A queue is a linear data structure that follows the FIFO principle.

FIFO means:
First In, First Out

The element inserted first is removed first.

Real-life example:
People standing in a ticket line.
The person who enters the line first gets served first.

Basic representation:
Front -> 10, 20, 30, 40 <- Rear

Front:
The position from which an element is removed.

Rear:
The position at which a new element is inserted.

Generic Queue syntax:
Queue<dataType> queueName = new Queue<dataType>();

Example:
Queue<int> numbers = new Queue<int>();

Important Queue<T> operations:

Enqueue(value):
Adds an element at the rear of the queue.

Dequeue():
Removes and returns the element at the front.
It throws an exception when the queue is empty.

Peek():
Returns the front element without removing it.
It throws an exception when the queue is empty.

TryDequeue(out value):
Safely removes the front element and returns true.
It returns false when the queue is empty.

TryPeek(out value):
Safely reads the front element without removing it.

Count:
Returns the total number of elements.

Contains(value):
Checks whether a particular value exists.

Clear():
Removes all elements from the queue.

ToArray():
Copies queue elements into an array.

Time complexity:
Enqueue: O(1)
Dequeue: O(1)
Peek: O(1)
Search using Contains: O(n)

Namespace required:
using System.Collections.Generic;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import the generic Queue<T> class

class QueueProgram // Define the QueueProgram class
{
    // Display queue

    static void DisplayQueue(Queue<int> queue) // Define a method that accepts an integer queue
    {
        if (queue.Count == 0) // Check whether the queue contains no elements
        {
            Console.WriteLine("Queue is empty."); // Display the empty-queue message

            return; // Stop the method
        }

        Console.Write("Front -> "); // Display the front indicator

        foreach (int value in queue) // Visit every element from front to rear
        {
            Console.Write(value + " "); // Display the current queue element
        }

        Console.WriteLine("<- Rear"); // Display the rear indicator
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create queue

        Queue<int> numbers = new Queue<int>(); // Create an empty queue of integers

        Console.WriteLine("Initial queue:"); // Display the initial-queue heading

        DisplayQueue(numbers); // Display the initially empty queue

        // Check empty queue

        bool isEmpty = numbers.Count == 0; // Check whether the queue is empty

        Console.WriteLine("Is queue empty: " + isEmpty); // Display whether the queue is empty

        // Enqueue elements

        numbers.Enqueue(10); // Add 10 at the rear of the queue

        numbers.Enqueue(20); // Add 20 at the rear of the queue

        numbers.Enqueue(30); // Add 30 at the rear of the queue

        numbers.Enqueue(40); // Add 40 at the rear of the queue

        numbers.Enqueue(50); // Add 50 at the rear of the queue

        Console.WriteLine("\nQueue after enqueue operations:"); // Display the enqueue heading

        DisplayQueue(numbers); // Display all queue elements

        // Count elements

        int totalElements = numbers.Count; // Store the total number of queue elements

        Console.WriteLine("Total elements: " + totalElements); // Display the total number of elements

        // Peek front element

        int frontElement = numbers.Peek(); // Read the front element without removing it

        Console.WriteLine("Front element using Peek(): " + frontElement); // Display the front element

        Console.WriteLine("Queue after Peek():"); // Display the queue-after-peek heading

        DisplayQueue(numbers); // Show that Peek did not remove the front element

        // Dequeue element

        int removedElement = numbers.Dequeue(); // Remove and return the front element

        Console.WriteLine("\nRemoved element using Dequeue(): " + removedElement); // Display the removed element

        Console.WriteLine("Queue after Dequeue():"); // Display the queue-after-dequeue heading

        DisplayQueue(numbers); // Display the queue after removing its front element

        // Safe dequeue using TryDequeue

        bool wasRemoved = numbers.TryDequeue(out int safelyRemovedElement); // Try to remove the front element safely

        if (wasRemoved) // Check whether an element was successfully removed
        {
            Console.WriteLine("\nSafely removed element: " + safelyRemovedElement); // Display the safely removed element
        }
        else // Execute when the queue is empty
        {
            Console.WriteLine("\nNo element is available for removal."); // Display the removal-failure message
        }

        Console.WriteLine("Queue after TryDequeue():"); // Display the queue-after-safe-dequeue heading

        DisplayQueue(numbers); // Display the updated queue

        // Safe peek using TryPeek

        bool wasFound = numbers.TryPeek(out int safelyReadElement); // Try to read the front element safely

        if (wasFound) // Check whether a front element exists
        {
            Console.WriteLine("\nFront element using TryPeek(): " + safelyReadElement); // Display the safely read front element
        }
        else // Execute when the queue is empty
        {
            Console.WriteLine("\nQueue does not have a front element."); // Display the empty-queue message
        }

        // Search an element

        int searchValue = 40; // Store the value that must be searched

        bool valueExists = numbers.Contains(searchValue); // Check whether the search value exists

        if (valueExists) // Check whether the value was found
        {
            Console.WriteLine(searchValue + " exists in the queue."); // Display the value-found message
        }
        else // Execute when the value was not found
        {
            Console.WriteLine(searchValue + " does not exist in the queue."); // Display the value-not-found message
        }

        // Traverse queue using foreach

        Console.WriteLine("\nQueue elements using foreach loop:"); // Display the traversal heading

        foreach (int number in numbers) // Visit every queue element without removing it
        {
            Console.WriteLine(number); // Display the current element
        }

        // Calculate sum

        int sum = 0; // Initialize the sum with zero

        foreach (int number in numbers) // Visit every element in the queue
        {
            sum = sum + number; // Add the current element to the sum
        }

        Console.WriteLine("\nSum of queue elements: " + sum); // Display the sum of all queue elements

        // Calculate average

        if (numbers.Count > 0) // Check whether the queue contains at least one element
        {
            double average = (double)sum / numbers.Count; // Calculate the average of the elements

            Console.WriteLine("Average of queue elements: " + average); // Display the average
        }

        // Convert queue to array

        int[] queueArray = numbers.ToArray(); // Copy queue elements into an integer array

        Console.WriteLine("\nQueue converted to array:"); // Display the array-conversion heading

        foreach (int number in queueArray) // Visit every element of the converted array
        {
            Console.Write(number + " "); // Display the current array element
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Create queue from collection

        int[] initialValues = { 100, 200, 300 }; // Create an array containing initial values

        Queue<int> secondQueue = new Queue<int>(initialValues); // Create a queue from the array values

        Console.WriteLine("\nQueue created from an array:"); // Display the collection-constructor heading

        DisplayQueue(secondQueue); // Display the second queue

        // Remove all elements using loop

        Console.WriteLine("\nRemoving every element from the second queue:"); // Display the removal-loop heading

        while (secondQueue.Count > 0) // Continue while the second queue contains elements
        {
            int currentElement = secondQueue.Dequeue(); // Remove the current front element

            Console.WriteLine("Removed: " + currentElement); // Display the removed element
        }

        Console.WriteLine("Second queue after removing all elements:"); // Display the empty-second-queue heading

        DisplayQueue(secondQueue); // Display the empty second queue

        // Prevent exception on empty queue

        if (secondQueue.Count > 0) // Check whether Dequeue can be performed safely
        {
            int value = secondQueue.Dequeue(); // Remove the front element

            Console.WriteLine("Removed value: " + value); // Display the removed value
        }
        else // Execute when the second queue is empty
        {
            Console.WriteLine("Dequeue cannot be performed because the queue is empty."); // Display the safety message
        }

        // Clear queue

        Console.WriteLine("\nFirst queue before Clear():"); // Display the queue-before-clear heading

        DisplayQueue(numbers); // Display the queue before clearing it

        numbers.Clear(); // Remove every element from the first queue

        Console.WriteLine("First queue after Clear():"); // Display the queue-after-clear heading

        DisplayQueue(numbers); // Display the cleared queue

        // Final queue status

        Console.WriteLine("Final queue count: " + numbers.Count); // Display the final number of elements

        Console.WriteLine("Is final queue empty: " + (numbers.Count == 0)); // Display whether the final queue is empty
    }
}