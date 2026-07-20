/*
Priority Queue in C# - Brief Summary

A priority queue stores elements together with their priority.

Unlike a normal queue, elements are not removed strictly according
to their insertion order. The element having the highest priority
is removed first.

In the built-in C# PriorityQueue<TElement, TPriority>, the smallest
priority value is treated as the highest priority by default.

Example:

Element       Priority
Emergency     1
Important     2
Normal        3

Removal order:
Emergency -> Important -> Normal

Basic syntax:

PriorityQueue<ElementType, PriorityType> queueName =
    new PriorityQueue<ElementType, PriorityType>();

Example:

PriorityQueue<string, int> tasks =
    new PriorityQueue<string, int>();

Important operations:

Enqueue(element, priority):
Adds an element with a priority.

Dequeue():
Removes and returns the element having the smallest priority value.
It throws an InvalidOperationException when the queue is empty.

Peek():
Returns the highest-priority element without removing it.

TryDequeue(out element, out priority):
Safely removes the highest-priority element.

TryPeek(out element, out priority):
Safely reads the highest-priority element without removing it.

EnqueueRange():
Adds multiple elements and their priorities.

EnqueueDequeue(element, priority):
Adds a new element and then removes the highest-priority element.

DequeueEnqueue(element, priority):
Removes the highest-priority element and then adds a new element.

Count:
Returns the number of elements.

Clear():
Removes all elements.

UnorderedItems:
Provides access to all elements and priorities, but not in guaranteed
priority order.

Important points:

1. Smaller priority values are processed first by default.
2. Duplicate priorities are allowed.
3. Elements with equal priorities may not follow insertion order.
4. A custom comparer can create a maximum-priority queue.
5. PriorityQueue<TElement, TPriority> is available in modern .NET.

Time complexity:

Enqueue: O(log n)
Dequeue: O(log n)
Peek: O(1)
Count: O(1)

Required namespace:

using System.Collections.Generic;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import PriorityQueue<TElement, TPriority>

class PriorityQueueProgram // Define the PriorityQueueProgram class
{
    // Display priority queue

    static void DisplayQueue(PriorityQueue<string, int> queue) // Define a method to display queue elements
    {
        if (queue.Count == 0) // Check whether the priority queue is empty
        {
            Console.WriteLine("Priority queue is empty."); // Display the empty-queue message
            return; // Stop the method
        }

        PriorityQueue<string, int> temporaryQueue = new PriorityQueue<string, int>(); // Create a temporary priority queue

        foreach ((string Element, int Priority) item in queue.UnorderedItems) // Visit every element and priority
        {
            temporaryQueue.Enqueue(item.Element, item.Priority); // Copy the current item into the temporary queue
        }

        Console.WriteLine("Removal order:"); // Display the removal-order heading

        while (temporaryQueue.Count > 0) // Continue until the temporary queue becomes empty
        {
            temporaryQueue.TryDequeue(out string? element, out int priority); // Remove the next highest-priority element safely
            Console.WriteLine(element + " - Priority: " + priority); // Display the removed element and its priority
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create priority queue

        PriorityQueue<string, int> tasks = new PriorityQueue<string, int>(); // Create an empty priority queue

        Console.WriteLine("Initial priority queue:"); // Display the initial-queue heading
        DisplayQueue(tasks); // Display the initially empty priority queue

        // Check empty queue

        bool isEmpty = tasks.Count == 0; // Check whether the priority queue is empty
        Console.WriteLine("Is priority queue empty: " + isEmpty); // Display whether the queue is empty

        // Enqueue elements

        tasks.Enqueue("Reply to normal email", 4); // Add a normal email task with priority 4
        tasks.Enqueue("Fix production error", 1); // Add an urgent production task with priority 1
        tasks.Enqueue("Attend team meeting", 3); // Add a meeting task with priority 3
        tasks.Enqueue("Submit project report", 2); // Add a report task with priority 2
        tasks.Enqueue("Clean workspace", 5); // Add a low-priority task with priority 5

        Console.WriteLine("\nPriority queue after Enqueue() operations:"); // Display the enqueue heading
        DisplayQueue(tasks); // Display elements according to removal priority

        // Count elements

        int totalElements = tasks.Count; // Store the total number of elements
        Console.WriteLine("Total elements: " + totalElements); // Display the number of elements

        // Peek highest-priority element

        string highestPriorityTask = tasks.Peek(); // Read the highest-priority task without removing it
        Console.WriteLine("\nHighest-priority task using Peek(): " + highestPriorityTask); // Display the highest-priority task
        Console.WriteLine("Total elements after Peek(): " + tasks.Count); // Show that Peek did not remove the task

        // Safe peek with priority

        bool taskWasFound = tasks.TryPeek(out string? peekedTask, out int peekedPriority); // Try to read the highest-priority task and priority

        if (taskWasFound) // Check whether a task was found
        {
            Console.WriteLine("Task using TryPeek(): " + peekedTask); // Display the safely read task
            Console.WriteLine("Priority using TryPeek(): " + peekedPriority); // Display the task's priority
        }
        else // Execute when the priority queue is empty
        {
            Console.WriteLine("No task is available."); // Display the empty-queue message
        }

        // Dequeue highest-priority element

        string removedTask = tasks.Dequeue(); // Remove the task having the smallest priority value
        Console.WriteLine("\nRemoved using Dequeue(): " + removedTask); // Display the removed task

        Console.WriteLine("Priority queue after Dequeue():"); // Display the queue-after-dequeue heading
        DisplayQueue(tasks); // Display the remaining tasks

        // Safe dequeue with priority

        bool taskWasRemoved = tasks.TryDequeue(out string? safelyRemovedTask, out int removedPriority); // Try to remove the highest-priority task safely

        if (taskWasRemoved) // Check whether a task was removed
        {
            Console.WriteLine("\nSafely removed task: " + safelyRemovedTask); // Display the safely removed task
            Console.WriteLine("Removed task priority: " + removedPriority); // Display the removed task's priority
        }
        else // Execute when the priority queue is empty
        {
            Console.WriteLine("\nNo task is available for removal."); // Display the removal-failure message
        }

        Console.WriteLine("Priority queue after TryDequeue():"); // Display the queue-after-safe-dequeue heading
        DisplayQueue(tasks); // Display the updated priority queue

        // Duplicate priorities

        tasks.Enqueue("Prepare presentation", 2); // Add a task with priority 2
        tasks.Enqueue("Review presentation", 2); // Add another task with the same priority
        tasks.Enqueue("Send presentation", 2); // Add a third task with the same priority

        Console.WriteLine("\nQueue after adding duplicate priorities:"); // Display the duplicate-priority heading
        DisplayQueue(tasks); // Display all tasks

        Console.WriteLine("Elements having equal priorities may not follow insertion order."); // Explain equal-priority behaviour

        // View unordered items

        Console.WriteLine("\nElements using UnorderedItems:"); // Display the unordered-items heading

        foreach ((string Element, int Priority) item in tasks.UnorderedItems) // Visit every stored element and priority
        {
            Console.WriteLine(item.Element + " - Priority: " + item.Priority); // Display the current element and priority
        }

        // Enqueue range

        (string Element, int Priority)[] additionalTasks = // Create an array of elements and priorities
        {
            ("Update documentation", 4), // Store a documentation task with priority 4
            ("Resolve security issue", 1), // Store a security task with priority 1
            ("Take system backup", 3) // Store a backup task with priority 3
        };

        tasks.EnqueueRange(additionalTasks); // Add all array items to the priority queue

        Console.WriteLine("\nQueue after EnqueueRange():"); // Display the enqueue-range heading
        DisplayQueue(tasks); // Display the updated queue

        // EnqueueDequeue operation

        string enqueueDequeueResult = tasks.EnqueueDequeue("Check server status", 1); // Add a task and remove the highest-priority task
        Console.WriteLine("\nElement returned by EnqueueDequeue(): " + enqueueDequeueResult); // Display the task removed by the operation

        Console.WriteLine("Queue after EnqueueDequeue():"); // Display the queue-after-operation heading
        DisplayQueue(tasks); // Display the updated priority queue

        // DequeueEnqueue operation

        if (tasks.Count > 0) // Check whether the queue contains an element
        {
            string dequeueEnqueueResult = tasks.DequeueEnqueue("Schedule training", 5); // Remove the highest-priority task and add a new task
            Console.WriteLine("\nElement returned by DequeueEnqueue(): " + dequeueEnqueueResult); // Display the removed task
        }
        else // Execute when the queue is empty
        {
            Console.WriteLine("\nDequeueEnqueue() cannot be used on an empty queue."); // Display the safety message
        }

        Console.WriteLine("Queue after DequeueEnqueue():"); // Display the queue-after-operation heading
        DisplayQueue(tasks); // Display the updated queue

        // Process all elements

        PriorityQueue<string, int> processingQueue = new PriorityQueue<string, int>(); // Create a priority queue for processing tasks

        processingQueue.Enqueue("Low-priority task", 3); // Add a low-priority task
        processingQueue.Enqueue("Emergency task", 1); // Add an emergency task
        processingQueue.Enqueue("Medium-priority task", 2); // Add a medium-priority task

        Console.WriteLine("\nProcessing all tasks according to priority:"); // Display the processing heading

        while (processingQueue.Count > 0) // Continue while tasks remain in the queue
        {
            processingQueue.TryDequeue(out string? currentTask, out int currentPriority); // Remove the next task and its priority
            Console.WriteLine("Processing: " + currentTask + ", Priority: " + currentPriority); // Display the task being processed
        }

        // Numeric priority queue

        PriorityQueue<int, int> numbers = new PriorityQueue<int, int>(); // Create a priority queue containing integer elements

        numbers.Enqueue(100, 3); // Add 100 with priority 3
        numbers.Enqueue(200, 1); // Add 200 with priority 1
        numbers.Enqueue(300, 2); // Add 300 with priority 2

        Console.WriteLine("\nInteger priority queue removal order:"); // Display the integer-queue heading

        while (numbers.Count > 0) // Continue until the integer queue becomes empty
        {
            numbers.TryDequeue(out int number, out int priority); // Remove the next integer and priority
            Console.WriteLine("Element: " + number + ", Priority: " + priority); // Display the removed integer and priority
        }

        // Maximum-priority queue

        Comparer<int> descendingComparer = Comparer<int>.Create((first, second) => second.CompareTo(first)); // Create a comparer that treats larger numbers as higher priority

        PriorityQueue<string, int> maximumPriorityQueue = new PriorityQueue<string, int>(descendingComparer); // Create a maximum-priority queue

        maximumPriorityQueue.Enqueue("Bronze member", 1); // Add a bronze member with priority 1
        maximumPriorityQueue.Enqueue("Gold member", 3); // Add a gold member with priority 3
        maximumPriorityQueue.Enqueue("Silver member", 2); // Add a silver member with priority 2
        maximumPriorityQueue.Enqueue("Platinum member", 4); // Add a platinum member with priority 4

        Console.WriteLine("\nMaximum-priority queue:"); // Display the maximum-priority-queue heading
        Console.WriteLine("Larger priority numbers are processed first."); // Explain the custom ordering

        while (maximumPriorityQueue.Count > 0) // Continue until the maximum-priority queue becomes empty
        {
            maximumPriorityQueue.TryDequeue(out string? member, out int priority); // Remove the element having the largest priority value
            Console.WriteLine(member + " - Priority: " + priority); // Display the removed member and priority
        }

        // Prevent exception on empty queue

        PriorityQueue<string, int> emptyQueue = new PriorityQueue<string, int>(); // Create an empty priority queue

        if (emptyQueue.Count > 0) // Check whether Dequeue can be performed safely
        {
            string element = emptyQueue.Dequeue(); // Remove the highest-priority element
            Console.WriteLine("Removed element: " + element); // Display the removed element
        }
        else // Execute when the priority queue is empty
        {
            Console.WriteLine("\nDequeue cannot be performed because the priority queue is empty."); // Display the safety message
        }

        // Ensure capacity

        int newCapacity = tasks.EnsureCapacity(20); // Ensure that the queue can hold at least twenty elements
        Console.WriteLine("\nPriority queue capacity after EnsureCapacity(): " + newCapacity); // Display the resulting queue capacity

        // Trim excess capacity

        tasks.TrimExcess(); // Reduce unused internal storage when possible
        Console.WriteLine("TrimExcess() completed."); // Display the capacity-trimming message

        // Clear priority queue

        Console.WriteLine("\nQueue before Clear():"); // Display the queue-before-clear heading
        DisplayQueue(tasks); // Display the priority queue before clearing it

        tasks.Clear(); // Remove all elements from the priority queue

        Console.WriteLine("Queue after Clear():"); // Display the queue-after-clear heading
        DisplayQueue(tasks); // Display the cleared priority queue

        // Final status

        Console.WriteLine("Final queue count: " + tasks.Count); // Display the final number of elements
        Console.WriteLine("Is final priority queue empty: " + (tasks.Count == 0)); // Display whether the final queue is empty
    }
}