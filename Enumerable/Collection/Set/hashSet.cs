/*
HashSet in C# - Brief Summary

A HashSet is a collection that stores only unique values.

It does not allow duplicate elements. If the same value is added more
than once, only one copy remains in the HashSet.

Basic syntax:

HashSet<dataType> setName = new HashSet<dataType>();

Example:

HashSet<int> numbers = new HashSet<int>();

Important characteristics:

1. It stores only unique elements.
2. Duplicate values are automatically ignored.
3. Elements are not stored in a guaranteed order.
4. It provides fast searching, insertion, and deletion.
5. Elements are accessed using foreach because HashSet has no index.
6. It supports mathematical set operations.

Important methods and properties:

Add(value):
Adds a new value and returns true.
Returns false when the value already exists.

Remove(value):
Removes a value and returns true.
Returns false when the value does not exist.

Contains(value):
Checks whether a value exists.

Count:
Returns the total number of unique elements.

Clear():
Removes all elements.

UnionWith(set):
Keeps all unique elements from both sets.

IntersectWith(set):
Keeps only elements common to both sets.

ExceptWith(set):
Removes elements that exist in another set.

SymmetricExceptWith(set):
Keeps elements that exist in only one of the sets.

IsSubsetOf(set):
Checks whether every element exists in another set.

IsSupersetOf(set):
Checks whether the set contains every element of another set.

SetEquals(set):
Checks whether two sets contain the same elements.

Overlaps(set):
Checks whether two sets have at least one common element.

RemoveWhere(condition):
Removes elements that satisfy a condition.

Time complexity on average:

Add: O(1)
Remove: O(1)
Contains: O(1)

Required namespace:

using System.Collections.Generic;
*/

using System; // Import basic classes such as Console and Array
using System.Collections.Generic; // Import the generic HashSet<T> class

class HashSetProgram // Define the HashSetProgram class
{
    // Display integer HashSet

    static void DisplaySet(HashSet<int> set) // Define a method that accepts an integer HashSet
    {
        if (set.Count == 0) // Check whether the HashSet is empty
        {
            Console.WriteLine("HashSet is empty."); // Display the empty-set message
            return; // Stop the method
        }

        Console.Write("{ "); // Display the opening set bracket

        foreach (int value in set) // Visit every unique element in the HashSet
        {
            Console.Write(value + " "); // Display the current element
        }

        Console.WriteLine("}"); // Display the closing set bracket
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create HashSet

        HashSet<int> numbers = new HashSet<int>(); // Create an empty HashSet of integers

        Console.WriteLine("Initial HashSet:"); // Display the initial-set heading
        DisplaySet(numbers); // Display the initially empty HashSet

        // Check empty HashSet

        bool isEmpty = numbers.Count == 0; // Check whether the HashSet contains no elements
        Console.WriteLine("Is HashSet empty: " + isEmpty); // Display whether the HashSet is empty

        // Add elements

        bool firstResult = numbers.Add(10); // Add 10 and store whether insertion succeeded
        bool secondResult = numbers.Add(20); // Add 20 and store whether insertion succeeded
        bool thirdResult = numbers.Add(30); // Add 30 and store whether insertion succeeded
        bool fourthResult = numbers.Add(40); // Add 40 and store whether insertion succeeded
        bool fifthResult = numbers.Add(50); // Add 50 and store whether insertion succeeded

        Console.WriteLine("\nHashSet after Add() operations:"); // Display the add-operation heading
        DisplaySet(numbers); // Display all unique elements

        // Add duplicate element

        bool duplicateResult = numbers.Add(30); // Try to add duplicate value 30

        Console.WriteLine("\nWas duplicate 30 added: " + duplicateResult); // Display false because 30 already exists
        Console.WriteLine("HashSet after adding duplicate 30:"); // Display the duplicate-addition heading
        DisplaySet(numbers); // Display the unchanged HashSet

        // Count elements

        int totalElements = numbers.Count; // Store the total number of unique elements
        Console.WriteLine("Total unique elements: " + totalElements); // Display the number of unique elements

        // Search an element

        int searchValue = 40; // Store the value that must be searched
        bool valueExists = numbers.Contains(searchValue); // Check whether 40 exists in the HashSet

        if (valueExists) // Check whether the searched value was found
        {
            Console.WriteLine(searchValue + " exists in the HashSet."); // Display the value-found message
        }
        else // Execute when the searched value does not exist
        {
            Console.WriteLine(searchValue + " does not exist in the HashSet."); // Display the value-not-found message
        }

        // Remove an element

        bool wasRemoved = numbers.Remove(20); // Remove 20 and store whether removal succeeded

        Console.WriteLine("\nWas 20 removed: " + wasRemoved); // Display the removal result
        Console.WriteLine("HashSet after removing 20:"); // Display the removal heading
        DisplaySet(numbers); // Display the updated HashSet

        // Remove missing element

        bool missingRemoval = numbers.Remove(100); // Try to remove a value that does not exist

        Console.WriteLine("Was 100 removed: " + missingRemoval); // Display false because 100 does not exist

        // Traverse HashSet

        Console.WriteLine("\nHashSet elements using foreach loop:"); // Display the traversal heading

        foreach (int number in numbers) // Visit every unique HashSet element
        {
            Console.WriteLine(number); // Display the current element
        }

        // Calculate sum

        int sum = 0; // Initialize the sum with zero

        foreach (int number in numbers) // Visit every element in the HashSet
        {
            sum = sum + number; // Add the current element to the sum
        }

        Console.WriteLine("\nSum of HashSet elements: " + sum); // Display the sum of all elements

        // Calculate average

        if (numbers.Count > 0) // Check whether the HashSet contains at least one element
        {
            double average = (double)sum / numbers.Count; // Calculate the average of the elements
            Console.WriteLine("Average of HashSet elements: " + average); // Display the calculated average
        }

        // Find maximum value

        if (numbers.Count > 0) // Check whether the HashSet contains elements
        {
            int maximum = int.MinValue; // Initialize maximum with the smallest integer value

            foreach (int number in numbers) // Visit every HashSet element
            {
                if (number > maximum) // Check whether the current element is greater than maximum
                {
                    maximum = number; // Update the maximum value
                }
            }

            Console.WriteLine("Maximum value: " + maximum); // Display the maximum element
        }

        // Find minimum value

        if (numbers.Count > 0) // Check whether the HashSet contains elements
        {
            int minimum = int.MaxValue; // Initialize minimum with the largest integer value

            foreach (int number in numbers) // Visit every HashSet element
            {
                if (number < minimum) // Check whether the current element is smaller than minimum
                {
                    minimum = number; // Update the minimum value
                }
            }

            Console.WriteLine("Minimum value: " + minimum); // Display the minimum element
        }

        // Create HashSet using collection initializer

        HashSet<int> firstSet = new HashSet<int>() // Create the first HashSet
        {
            10, // Add 10 to the first set
            20, // Add 20 to the first set
            30, // Add 30 to the first set
            40 // Add 40 to the first set
        };

        HashSet<int> secondSet = new HashSet<int>() // Create the second HashSet
        {
            30, // Add 30 to the second set
            40, // Add 40 to the second set
            50, // Add 50 to the second set
            60 // Add 60 to the second set
        };

        Console.WriteLine("\nFirst set:"); // Display the first-set heading
        DisplaySet(firstSet); // Display the first set

        Console.WriteLine("Second set:"); // Display the second-set heading
        DisplaySet(secondSet); // Display the second set

        // Union operation

        HashSet<int> unionSet = new HashSet<int>(firstSet); // Create a copy of the first set

        unionSet.UnionWith(secondSet); // Add all unique elements from the second set

        Console.WriteLine("\nUnion of both sets:"); // Display the union heading
        DisplaySet(unionSet); // Display all unique elements from both sets

        // Intersection operation

        HashSet<int> intersectionSet = new HashSet<int>(firstSet); // Create another copy of the first set

        intersectionSet.IntersectWith(secondSet); // Keep only elements common to both sets

        Console.WriteLine("\nIntersection of both sets:"); // Display the intersection heading
        DisplaySet(intersectionSet); // Display common elements

        // Difference operation

        HashSet<int> differenceSet = new HashSet<int>(firstSet); // Create a copy for the difference operation

        differenceSet.ExceptWith(secondSet); // Remove elements that also exist in the second set

        Console.WriteLine("\nFirst set except second set:"); // Display the difference heading
        DisplaySet(differenceSet); // Display elements found only in the first set

        // Symmetric difference operation

        HashSet<int> symmetricSet = new HashSet<int>(firstSet); // Create a copy for symmetric difference

        symmetricSet.SymmetricExceptWith(secondSet); // Keep elements that exist in only one set

        Console.WriteLine("\nSymmetric difference of both sets:"); // Display the symmetric-difference heading
        DisplaySet(symmetricSet); // Display non-common elements

        // Subset check

        HashSet<int> smallSet = new HashSet<int>() // Create a smaller set
        {
            10, // Add 10 to the smaller set
            20 // Add 20 to the smaller set
        };

        bool isSubset = smallSet.IsSubsetOf(firstSet); // Check whether smallSet is a subset of firstSet

        Console.WriteLine("\nIs smallSet a subset of firstSet: " + isSubset); // Display the subset result

        // Proper subset check

        bool isProperSubset = smallSet.IsProperSubsetOf(firstSet); // Check whether smallSet is a strict subset

        Console.WriteLine("Is smallSet a proper subset of firstSet: " + isProperSubset); // Display the proper-subset result

        // Superset check

        bool isSuperset = firstSet.IsSupersetOf(smallSet); // Check whether firstSet contains every smallSet element

        Console.WriteLine("Is firstSet a superset of smallSet: " + isSuperset); // Display the superset result

        // Proper superset check

        bool isProperSuperset = firstSet.IsProperSupersetOf(smallSet); // Check whether firstSet is a strict superset

        Console.WriteLine("Is firstSet a proper superset of smallSet: " + isProperSuperset); // Display the proper-superset result

        // Set equality check

        HashSet<int> equalSet = new HashSet<int>() // Create a set containing the same elements as firstSet
        {
            40, // Add 40 in a different order
            30, // Add 30 in a different order
            20, // Add 20 in a different order
            10 // Add 10 in a different order
        };

        bool areEqual = firstSet.SetEquals(equalSet); // Check whether both sets contain the same elements

        Console.WriteLine("\nAre firstSet and equalSet equal: " + areEqual); // Display the set-equality result

        // Overlap check

        HashSet<int> overlapSet = new HashSet<int>() // Create another set
        {
            40, // Add a value that also exists in firstSet
            70, // Add 70 to the overlap set
            80 // Add 80 to the overlap set
        };

        bool hasOverlap = firstSet.Overlaps(overlapSet); // Check whether both sets share at least one element

        Console.WriteLine("Do firstSet and overlapSet overlap: " + hasOverlap); // Display the overlap result

        // Remove elements using condition

        HashSet<int> conditionSet = new HashSet<int>() // Create a set for conditional removal
        {
            10, // Add 10 to the condition set
            15, // Add 15 to the condition set
            20, // Add 20 to the condition set
            25, // Add 25 to the condition set
            30, // Add 30 to the condition set
            35 // Add 35 to the condition set
        };

        int removedCount = conditionSet.RemoveWhere(number => number % 2 == 0); // Remove every even number

        Console.WriteLine("\nNumber of even elements removed: " + removedCount); // Display the number of removed elements
        Console.WriteLine("Set after removing even numbers:"); // Display the conditional-removal heading
        DisplaySet(conditionSet); // Display the remaining odd numbers

        // Copy HashSet to array

        int[] numberArray = new int[firstSet.Count]; // Create an array having the required size

        firstSet.CopyTo(numberArray); // Copy all firstSet elements into the array

        Console.WriteLine("\nHashSet copied to array:"); // Display the copy-to-array heading

        foreach (int number in numberArray) // Visit every element of the copied array
        {
            Console.Write(number + " "); // Display the current array element
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Create HashSet from array

        int[] values = { 10, 20, 20, 30, 30, 40 }; // Create an array containing duplicate values

        HashSet<int> setFromArray = new HashSet<int>(values); // Create a HashSet that automatically removes duplicates

        Console.WriteLine("\nHashSet created from an array with duplicates:"); // Display the array-constructor heading
        DisplaySet(setFromArray); // Display only unique array values

        // String HashSet

        HashSet<string> fruits = new HashSet<string>(); // Create an empty HashSet of strings

        fruits.Add("Apple"); // Add Apple to the string HashSet
        fruits.Add("Mango"); // Add Mango to the string HashSet
        fruits.Add("Banana"); // Add Banana to the string HashSet
        fruits.Add("Apple"); // Try to add duplicate Apple

        Console.WriteLine("\nString HashSet:"); // Display the string-set heading

        foreach (string fruit in fruits) // Visit every unique fruit
        {
            Console.WriteLine(fruit); // Display the current fruit
        }

        // Case-sensitive HashSet

        HashSet<string> caseSensitiveSet = new HashSet<string>(); // Create a case-sensitive string HashSet

        caseSensitiveSet.Add("Apple"); // Add Apple with uppercase A
        caseSensitiveSet.Add("apple"); // Add apple with lowercase a

        Console.WriteLine("\nCase-sensitive HashSet count: " + caseSensitiveSet.Count); // Display two because the values differ by case

        // Case-insensitive HashSet

        HashSet<string> caseInsensitiveSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Create a case-insensitive string HashSet

        caseInsensitiveSet.Add("Apple"); // Add Apple with uppercase A
        caseInsensitiveSet.Add("apple"); // Try to add apple with lowercase a

        Console.WriteLine("Case-insensitive HashSet count: " + caseInsensitiveSet.Count); // Display one because case is ignored

        // Ensure capacity

        int capacity = numbers.EnsureCapacity(20); // Ensure that the HashSet can store at least twenty elements

        Console.WriteLine("\nCapacity after EnsureCapacity(): " + capacity); // Display the available internal capacity

        // Trim excess capacity

        numbers.TrimExcess(); // Reduce unused internal storage when possible

        Console.WriteLine("TrimExcess() completed."); // Display the capacity-trimming message

        // Clear HashSet

        Console.WriteLine("\nHashSet before Clear():"); // Display the set-before-clear heading
        DisplaySet(numbers); // Display the HashSet before removing its elements

        numbers.Clear(); // Remove every element from the HashSet

        Console.WriteLine("HashSet after Clear():"); // Display the set-after-clear heading
        DisplaySet(numbers); // Display the empty HashSet

        // Final HashSet status

        Console.WriteLine("Final HashSet count: " + numbers.Count); // Display the final number of elements
        Console.WriteLine("Is final HashSet empty: " + (numbers.Count == 0)); // Display whether the final HashSet is empty
    }
}