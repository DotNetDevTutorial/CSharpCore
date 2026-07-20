/*
Linked List in C# - Brief Summary

A linked list is a linear data structure in which elements are stored
inside separate objects called nodes.

Each node of a singly linked list contains:
1. Data: The value stored inside the node.
2. Next: A reference to the next node.

Unlike an array, linked-list elements are not stored in continuous
memory locations.

Basic node structure:

class Node
{
    public int Data;
    public Node? Next;
}

Important terms:
Head:
The first node of the linked list.

Tail:
The last node of the linked list.

Next:
The reference that connects one node to the next node.

null:
The Next reference of the last node contains null.

Basic representation:
Head -> 10 -> 20 -> 30 -> null

Advantages:
1. The size can increase or decrease dynamically.
2. Insertion and deletion are easier than in an array.
3. Continuous memory locations are not required.

Disadvantages:
1. Elements cannot be accessed directly using an index.
2. Extra memory is needed to store references.
3. Traversal must begin from the head node.

Common operations:
1. Insert at beginning.
2. Insert at end.
3. Insert at a particular position.
4. Delete from beginning.
5. Delete from end.
6. Delete a particular value.
7. Search for a value.
8. Count nodes.
9. Reverse the linked list.
10. Display all nodes.

Time complexity:
Access/Search: O(n)
Insertion at beginning: O(1)
Insertion at end: O(n), or O(1) when a tail reference is maintained
Deletion from beginning: O(1)
*/

using System; // Import the System namespace

class Node // Define the structure of a linked-list node
{
    public int Data; // Store the value of the node

    public Node? Next; // Store the reference to the next node

    public Node(int data) // Define the constructor of the Node class
    {
        Data = data; // Store the received value inside the node

        Next = null; // Initially make the node point to nothing
    }
}

class SinglyLinkedList // Define a class for managing the linked list
{
    private Node? head; // Store the reference to the first node

    // Constructor

    public SinglyLinkedList() // Define the linked-list constructor
    {
        head = null; // Create an initially empty linked list
    }

    // Check whether the list is empty

    public bool IsEmpty() // Define a method to check whether the list is empty
    {
        return head == null; // Return true when the head does not contain a node
    }

    // Insert at beginning

    public void InsertAtBeginning(int data) // Define a method to insert a node at the beginning
    {
        Node newNode = new Node(data); // Create a new node with the supplied value

        newNode.Next = head; // Connect the new node to the current first node

        head = newNode; // Make the new node the first node
    }

    // Insert at end

    public void InsertAtEnd(int data) // Define a method to insert a node at the end
    {
        Node newNode = new Node(data); // Create a new node with the supplied value

        if (head == null) // Check whether the linked list is empty
        {
            head = newNode; // Make the new node the first node

            return; // Stop the method because insertion is complete
        }

        Node current = head; // Begin traversal from the first node

        while (current.Next != null) // Continue until the last node is reached
        {
            current = current.Next; // Move to the next node
        }

        current.Next = newNode; // Connect the last node to the new node
    }

    // Insert at position

    public void InsertAtPosition(int data, int position) // Define a method to insert a node at a given position
    {
        if (position < 1) // Check whether the supplied position is invalid
        {
            Console.WriteLine("Position must be 1 or greater."); // Display an invalid-position message

            return; // Stop the method
        }

        if (position == 1) // Check whether insertion is required at the beginning
        {
            InsertAtBeginning(data); // Insert the value at the beginning

            return; // Stop the method because insertion is complete
        }

        Node newNode = new Node(data); // Create a new node with the supplied value

        Node? current = head; // Begin traversal from the first node

        int currentPosition = 1; // Store the position of the current node

        while (current != null && currentPosition < position - 1) // Move to the node before the requested position
        {
            current = current.Next; // Move to the next node

            currentPosition++; // Increase the current position
        }

        if (current == null) // Check whether the requested position is outside the list
        {
            Console.WriteLine("Position is outside the linked list."); // Display an invalid-position message

            return; // Stop the method
        }

        newNode.Next = current.Next; // Connect the new node to the following node

        current.Next = newNode; // Connect the previous node to the new node
    }

    // Display linked list

    public void Display() // Define a method to display all nodes
    {
        if (head == null) // Check whether the linked list is empty
        {
            Console.WriteLine("Linked list is empty."); // Display the empty-list message

            return; // Stop the method
        }

        Node? current = head; // Begin traversal from the first node

        while (current != null) // Continue until all nodes have been visited
        {
            Console.Write(current.Data + " -> "); // Display the current node value

            current = current.Next; // Move to the next node
        }

        Console.WriteLine("null"); // Display null after the last node
    }

    // Delete from beginning

    public void DeleteFromBeginning() // Define a method to delete the first node
    {
        if (head == null) // Check whether the linked list is empty
        {
            Console.WriteLine("Linked list is empty."); // Display the empty-list message

            return; // Stop the method
        }

        int deletedValue = head.Data; // Store the value of the node being deleted

        head = head.Next; // Make the second node the new first node

        Console.WriteLine(deletedValue + " deleted from the beginning."); // Display the deleted value
    }

    // Delete from end

    public void DeleteFromEnd() // Define a method to delete the last node
    {
        if (head == null) // Check whether the linked list is empty
        {
            Console.WriteLine("Linked list is empty."); // Display the empty-list message

            return; // Stop the method
        }

        if (head.Next == null) // Check whether the linked list contains only one node
        {
            int deletedValue = head.Data; // Store the only node's value

            head = null; // Make the linked list empty

            Console.WriteLine(deletedValue + " deleted from the end."); // Display the deleted value

            return; // Stop the method
        }

        Node current = head; // Begin traversal from the first node

        while (current.Next?.Next != null) // Continue until the second-last node is reached
        {
            current = current.Next; // Move to the next node
        }

        int lastValue = current.Next!.Data; // Store the value of the last node

        current.Next = null; // Remove the reference to the last node

        Console.WriteLine(lastValue + " deleted from the end."); // Display the deleted value
    }

    // Delete a particular value

    public void DeleteValue(int value) // Define a method to delete the first occurrence of a value
    {
        if (head == null) // Check whether the linked list is empty
        {
            Console.WriteLine("Linked list is empty."); // Display the empty-list message

            return; // Stop the method
        }

        if (head.Data == value) // Check whether the first node contains the required value
        {
            head = head.Next; // Remove the first node

            Console.WriteLine(value + " deleted successfully."); // Display the success message

            return; // Stop the method
        }

        Node? current = head; // Begin traversal from the first node

        while (current.Next != null && current.Next.Data != value) // Search for the node before the required node
        {
            current = current.Next; // Move to the next node
        }

        if (current.Next == null) // Check whether the value was not found
        {
            Console.WriteLine(value + " was not found."); // Display the value-not-found message

            return; // Stop the method
        }

        current.Next = current.Next.Next; // Skip the node containing the required value

        Console.WriteLine(value + " deleted successfully."); // Display the success message
    }

    // Delete from position

    public void DeleteFromPosition(int position) // Define a method to delete a node from a given position
    {
        if (position < 1) // Check whether the supplied position is invalid
        {
            Console.WriteLine("Position must be 1 or greater."); // Display the invalid-position message

            return; // Stop the method
        }

        if (head == null) // Check whether the linked list is empty
        {
            Console.WriteLine("Linked list is empty."); // Display the empty-list message

            return; // Stop the method
        }

        if (position == 1) // Check whether the first node must be deleted
        {
            DeleteFromBeginning(); // Delete the first node

            return; // Stop the method
        }

        Node? current = head; // Begin traversal from the first node

        int currentPosition = 1; // Store the position of the current node

        while (current.Next != null && currentPosition < position - 1) // Move to the node before the required position
        {
            current = current.Next; // Move to the next node

            currentPosition++; // Increase the current position
        }

        if (current.Next == null) // Check whether the requested position exists
        {
            Console.WriteLine("Position is outside the linked list."); // Display the invalid-position message

            return; // Stop the method
        }

        int deletedValue = current.Next.Data; // Store the value of the node being deleted

        current.Next = current.Next.Next; // Remove the node from the linked list

        Console.WriteLine(deletedValue + " deleted from position " + position + "."); // Display the deleted value and position
    }

    // Search for a value

    public int Search(int value) // Define a method to search for a value
    {
        Node? current = head; // Begin traversal from the first node

        int position = 1; // Start the node position from one

        while (current != null) // Continue until all nodes have been checked
        {
            if (current.Data == value) // Check whether the current node contains the required value
            {
                return position; // Return the position of the matching node
            }

            current = current.Next; // Move to the next node

            position++; // Increase the position
        }

        return -1; // Return minus one when the value is not found
    }

    // Count nodes

    public int CountNodes() // Define a method to count the number of nodes
    {
        int count = 0; // Initialize the node count with zero

        Node? current = head; // Begin traversal from the first node

        while (current != null) // Continue until all nodes have been visited
        {
            count++; // Increase the node count

            current = current.Next; // Move to the next node
        }

        return count; // Return the total number of nodes
    }

    // Find maximum value

    public int? FindMaximum() // Define a method to find the maximum value
    {
        if (head == null) // Check whether the linked list is empty
        {
            return null; // Return null because no maximum value exists
        }

        int maximum = head.Data; // Assume the first node contains the maximum value

        Node? current = head.Next; // Begin comparison from the second node

        while (current != null) // Continue until all nodes have been checked
        {
            if (current.Data > maximum) // Check whether the current value is greater
            {
                maximum = current.Data; // Update the maximum value
            }

            current = current.Next; // Move to the next node
        }

        return maximum; // Return the maximum value
    }

    // Find minimum value

    public int? FindMinimum() // Define a method to find the minimum value
    {
        if (head == null) // Check whether the linked list is empty
        {
            return null; // Return null because no minimum value exists
        }

        int minimum = head.Data; // Assume the first node contains the minimum value

        Node? current = head.Next; // Begin comparison from the second node

        while (current != null) // Continue until all nodes have been checked
        {
            if (current.Data < minimum) // Check whether the current value is smaller
            {
                minimum = current.Data; // Update the minimum value
            }

            current = current.Next; // Move to the next node
        }

        return minimum; // Return the minimum value
    }

    // Reverse linked list

    public void Reverse() // Define a method to reverse the linked list
    {
        Node? previous = null; // Initially store no previous node

        Node? current = head; // Begin traversal from the first node

        while (current != null) // Continue until every node has been reversed
        {
            Node? nextNode = current.Next; // Temporarily store the next node

            current.Next = previous; // Reverse the current node's reference

            previous = current; // Move the previous reference to the current node

            current = nextNode; // Move the current reference to the next node
        }

        head = previous; // Make the previous last node the new first node
    }

    // Clear linked list

    public void Clear() // Define a method to remove every node
    {
        head = null; // Remove the reference to the first node
    }
}

class LinkedListProgram // Define the main program class
{
    static void Main() // Define the entry point of the program
    {
        // Create linked list

        SinglyLinkedList list = new SinglyLinkedList(); // Create an empty singly linked list

        Console.WriteLine("Is list empty: " + list.IsEmpty()); // Display whether the linked list is empty

        // Insert at beginning

        list.InsertAtBeginning(30); // Insert 30 at the beginning

        list.InsertAtBeginning(20); // Insert 20 at the beginning

        list.InsertAtBeginning(10); // Insert 10 at the beginning

        Console.WriteLine("\nAfter insertion at beginning:"); // Display the insertion heading

        list.Display(); // Display all linked-list nodes

        // Insert at end

        list.InsertAtEnd(40); // Insert 40 at the end

        list.InsertAtEnd(50); // Insert 50 at the end

        Console.WriteLine("\nAfter insertion at end:"); // Display the insertion heading

        list.Display(); // Display all linked-list nodes

        // Insert at position

        list.InsertAtPosition(25, 3); // Insert 25 at the third position

        Console.WriteLine("\nAfter inserting 25 at position 3:"); // Display the insertion heading

        list.Display(); // Display all linked-list nodes

        // Count nodes

        int totalNodes = list.CountNodes(); // Get the total number of nodes

        Console.WriteLine("\nTotal nodes: " + totalNodes); // Display the total number of nodes

        // Search value

        int searchValue = 40; // Store the value that must be searched

        int foundPosition = list.Search(searchValue); // Search for the value and store its position

        if (foundPosition != -1) // Check whether the value was found
        {
            Console.WriteLine(searchValue + " found at position " + foundPosition + "."); // Display the position of the value
        }
        else // Execute when the value was not found
        {
            Console.WriteLine(searchValue + " was not found."); // Display the value-not-found message
        }

        // Maximum and minimum

        int? maximum = list.FindMaximum(); // Find the maximum value in the linked list

        int? minimum = list.FindMinimum(); // Find the minimum value in the linked list

        Console.WriteLine("Maximum value: " + maximum); // Display the maximum linked-list value

        Console.WriteLine("Minimum value: " + minimum); // Display the minimum linked-list value

        // Delete from beginning

        list.DeleteFromBeginning(); // Delete the first node

        Console.WriteLine("After deletion from beginning:"); // Display the deletion heading

        list.Display(); // Display the updated linked list

        // Delete from end

        list.DeleteFromEnd(); // Delete the last node

        Console.WriteLine("After deletion from end:"); // Display the deletion heading

        list.Display(); // Display the updated linked list

        // Delete a value

        list.DeleteValue(25); // Delete the first node containing 25

        Console.WriteLine("After deleting value 25:"); // Display the deletion heading

        list.Display(); // Display the updated linked list

        // Delete from position

        list.DeleteFromPosition(2); // Delete the node at the second position

        Console.WriteLine("After deleting from position 2:"); // Display the deletion heading

        list.Display(); // Display the updated linked list

        // Reverse linked list

        list.Reverse(); // Reverse the order of all linked-list nodes

        Console.WriteLine("\nAfter reversing the linked list:"); // Display the reverse heading

        list.Display(); // Display the reversed linked list

        // Clear linked list

        list.Clear(); // Remove every node from the linked list

        Console.WriteLine("\nAfter clearing the linked list:"); // Display the clear heading

        list.Display(); // Display the empty linked list
    }
}