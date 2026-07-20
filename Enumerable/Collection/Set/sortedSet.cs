/*
SortedSet in C# - Brief Summary

A SortedSet is a collection that stores unique elements in sorted order.

It combines two important features:

1. Duplicate values are not allowed.
2. Values are automatically arranged in sorted order.

Basic syntax:

SortedSet<dataType> setName = new SortedSet<dataType>();

Example:

SortedSet<int> numbers = new SortedSet<int>();

If the following values are added:

40, 10, 30, 20, 10

The SortedSet stores:

10, 20, 30, 40

The duplicate value 10 is ignored, and the remaining values are sorted.

Important characteristics:

1. It stores only unique values.
2. Duplicate values are automatically ignored.
3. Elements are sorted automatically.
4. Elements cannot be accessed using an index.
5. foreach is normally used to traverse the elements.
6. A custom comparer can change the sorting order.
7. It supports mathematical set operations.
8. It provides Min and Max properties.
9. GetViewBetween() obtains elements within a specified range.
10. Reverse() traverses the elements in descending order.

Important methods and properties:

Add(value):
Adds a value and returns true when successful.
It returns false when the value already exists.

Remove(value):
Removes a value and returns true when successful.

Contains(value):
Checks whether a value exists.

Count:
Returns the number of unique elements.

Min:
Returns the smallest element according to the comparer.

Max:
Returns the largest element according to the comparer.

Reverse():
Returns the elements in reverse sorted order.

GetViewBetween(lowerValue, upperValue):
Returns a view containing values within the inclusive range.

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
Checks whether the sets have at least one common element.

RemoveWhere(condition):
Removes all elements that satisfy a condition.

Clear():
Removes every element.

Time complexity:

Add: O(log n)
Remove: O(log n)
Contains: O(log n)
Min: O(1)
Max: O(1)

Required namespace:

using System.Collections.Generic;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import the generic SortedSet<T> class

class SortedSetProgram // Define the SortedSetProgram class
{
    // Display integer SortedSet

    static void DisplaySet(SortedSet<int> set) // Define a method that accepts an integer SortedSet
    {
        if (set.Count == 0) // Check whether the SortedSet is empty
        {
            Console.WriteLine("SortedSet is empty."); // Display the empty-set message
            return; // Stop the method
        }

        Console.Write("{ "); // Display the opening set bracket

        foreach (int value in set) // Visit every element in ascending order
        {
            Console.Write(value + " "); // Display the current element
        }

        Console.WriteLine("}"); // Display the closing set bracket
    }

    // Display string SortedSet

    static void DisplayStringSet(SortedSet<string> set) // Define a method that accepts a string SortedSet
    {
        if (set.Count == 0) // Check whether the string SortedSet is empty
        {
            Console.WriteLine("SortedSet is empty."); // Display the empty-set message
            return; // Stop the method
        }

        Console.Write("{ "); // Display the opening set bracket

        foreach (string value in set) // Visit every string in sorted order
        {
            Console.Write(value + " "); // Display the current string
        }

        Console.WriteLine("}"); // Display the closing set bracket
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create SortedSet

        SortedSet<int> numbers = new SortedSet<int>(); // Create an empty SortedSet of integers

        Console.WriteLine("Initial SortedSet:"); // Display the initial-set heading

        DisplaySet(numbers); // Display the initially empty SortedSet

        // Check empty SortedSet

        bool isEmpty = numbers.Count == 0; // Check whether the SortedSet contains no elements

        Console.WriteLine("Is SortedSet empty: " + isEmpty); // Display whether the SortedSet is empty

        // Add elements

        bool firstResult = numbers.Add(40); // Add 40 and store whether insertion succeeded

        bool secondResult = numbers.Add(10); // Add 10 and store whether insertion succeeded

        bool thirdResult = numbers.Add(50); // Add 50 and store whether insertion succeeded

        bool fourthResult = numbers.Add(20); // Add 20 and store whether insertion succeeded

        bool fifthResult = numbers.Add(30); // Add 30 and store whether insertion succeeded

        Console.WriteLine("\nSortedSet after Add() operations:"); // Display the add-operation heading

        DisplaySet(numbers); // Display the elements in ascending order

        // Display Add results

        Console.WriteLine("Was 40 added: " + firstResult); // Display whether 40 was added

        Console.WriteLine("Was 10 added: " + secondResult); // Display whether 10 was added

        Console.WriteLine("Was 50 added: " + thirdResult); // Display whether 50 was added

        Console.WriteLine("Was 20 added: " + fourthResult); // Display whether 20 was added

        Console.WriteLine("Was 30 added: " + fifthResult); // Display whether 30 was added

        // Add duplicate element

        bool duplicateResult = numbers.Add(30); // Try to add duplicate value 30

        Console.WriteLine("\nWas duplicate 30 added: " + duplicateResult); // Display false because 30 already exists

        Console.WriteLine("SortedSet after adding duplicate 30:"); // Display the duplicate-addition heading

        DisplaySet(numbers); // Display the unchanged SortedSet

        // Count elements

        int totalElements = numbers.Count; // Store the total number of unique elements

        Console.WriteLine("Total unique elements: " + totalElements); // Display the total number of elements

        // Search an element

        int searchValue = 40; // Store the value that must be searched

        bool valueExists = numbers.Contains(searchValue); // Check whether the value exists

        if (valueExists) // Check whether the searched value was found
        {
            Console.WriteLine(searchValue + " exists in the SortedSet."); // Display the value-found message
        }
        else // Execute when the searched value was not found
        {
            Console.WriteLine(searchValue + " does not exist in the SortedSet."); // Display the value-not-found message
        }

        // Search missing element

        int missingValue = 100; // Store a value that does not exist

        bool missingValueExists = numbers.Contains(missingValue); // Check whether the missing value exists

        Console.WriteLine(missingValue + " exists: " + missingValueExists); // Display the search result

        // Minimum element

        if (numbers.Count > 0) // Check whether the SortedSet contains elements
        {
            int minimum = numbers.Min; // Get the smallest element

            Console.WriteLine("\nMinimum value: " + minimum); // Display the minimum value
        }

        // Maximum element

        if (numbers.Count > 0) // Check whether the SortedSet contains elements
        {
            int maximum = numbers.Max; // Get the largest element

            Console.WriteLine("Maximum value: " + maximum); // Display the maximum value
        }

        // Traverse in ascending order

        Console.WriteLine("\nElements in ascending order:"); // Display the ascending-order heading

        foreach (int number in numbers) // Visit every element in ascending order
        {
            Console.WriteLine(number); // Display the current element
        }

        // Traverse in descending order

        Console.WriteLine("\nElements in descending order:"); // Display the descending-order heading

        foreach (int number in numbers.Reverse()) // Visit every element in reverse sorted order
        {
            Console.WriteLine(number); // Display the current element
        }

        // Remove an element

        bool wasRemoved = numbers.Remove(20); // Remove 20 and store whether removal succeeded

        Console.WriteLine("\nWas 20 removed: " + wasRemoved); // Display the removal result

        Console.WriteLine("SortedSet after removing 20:"); // Display the removal heading

        DisplaySet(numbers); // Display the updated SortedSet

        // Remove missing element

        bool missingRemoval = numbers.Remove(200); // Try to remove a value that does not exist

        Console.WriteLine("Was 200 removed: " + missingRemoval); // Display false because 200 does not exist

        // Calculate sum

        int sum = 0; // Initialize the sum with zero

        foreach (int number in numbers) // Visit every element in the SortedSet
        {
            sum = sum + number; // Add the current element to the sum
        }

        Console.WriteLine("\nSum of SortedSet elements: " + sum); // Display the sum of all elements

        // Calculate average

        if (numbers.Count > 0) // Check whether the SortedSet contains at least one element
        {
            double average = (double)sum / numbers.Count; // Calculate the average of all elements

            Console.WriteLine("Average of SortedSet elements: " + average); // Display the calculated average
        }

        // Create SortedSet using collection initializer

        SortedSet<int> firstSet = new SortedSet<int>() // Create the first SortedSet
        {
            10, // Add 10 to the first set
            20, // Add 20 to the first set
            30, // Add 30 to the first set
            40 // Add 40 to the first set
        };

        SortedSet<int> secondSet = new SortedSet<int>() // Create the second SortedSet
        {
            30, // Add 30 to the second set
            40, // Add 40 to the second set
            50, // Add 50 to the second set
            60 // Add 60 to the second set
        };

        Console.WriteLine("\nFirst set:"); // Display the first-set heading

        DisplaySet(firstSet); // Display the first SortedSet

        Console.WriteLine("Second set:"); // Display the second-set heading

        DisplaySet(secondSet); // Display the second SortedSet

        // Union operation

        SortedSet<int> unionSet = new SortedSet<int>(firstSet); // Create a copy of the first set

        unionSet.UnionWith(secondSet); // Add all unique elements from the second set

        Console.WriteLine("\nUnion of both sets:"); // Display the union heading

        DisplaySet(unionSet); // Display all unique elements from both sets

        // Intersection operation

        SortedSet<int> intersectionSet = new SortedSet<int>(firstSet); // Create a copy for intersection

        intersectionSet.IntersectWith(secondSet); // Keep only elements common to both sets

        Console.WriteLine("\nIntersection of both sets:"); // Display the intersection heading

        DisplaySet(intersectionSet); // Display the common elements

        // Difference operation

        SortedSet<int> differenceSet = new SortedSet<int>(firstSet); // Create a copy for difference

        differenceSet.ExceptWith(secondSet); // Remove elements that exist in the second set

        Console.WriteLine("\nFirst set except second set:"); // Display the difference heading

        DisplaySet(differenceSet); // Display elements that exist only in the first set

        // Symmetric difference operation

        SortedSet<int> symmetricSet = new SortedSet<int>(firstSet); // Create a copy for symmetric difference

        symmetricSet.SymmetricExceptWith(secondSet); // Keep elements that exist in only one set

        Console.WriteLine("\nSymmetric difference of both sets:"); // Display the symmetric-difference heading

        DisplaySet(symmetricSet); // Display all non-common elements

        // Subset check

        SortedSet<int> smallSet = new SortedSet<int>() // Create a smaller SortedSet
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

        bool isSuperset = firstSet.IsSupersetOf(smallSet); // Check whether firstSet contains all smallSet elements

        Console.WriteLine("Is firstSet a superset of smallSet: " + isSuperset); // Display the superset result

        // Proper superset check

        bool isProperSuperset = firstSet.IsProperSupersetOf(smallSet); // Check whether firstSet is a strict superset

        Console.WriteLine("Is firstSet a proper superset of smallSet: " + isProperSuperset); // Display the proper-superset result

        // Set equality check

        SortedSet<int> equalSet = new SortedSet<int>() // Create a set containing the same elements as firstSet
        {
            40, // Add 40 in a different order
            10, // Add 10 in a different order
            30, // Add 30 in a different order
            20 // Add 20 in a different order
        };

        bool areEqual = firstSet.SetEquals(equalSet); // Check whether both sets contain the same elements

        Console.WriteLine("\nAre firstSet and equalSet equal: " + areEqual); // Display the equality result

        // Overlap check

        SortedSet<int> overlapSet = new SortedSet<int>() // Create another SortedSet
        {
            40, // Add a value that also exists in firstSet
            70, // Add 70 to the overlap set
            80 // Add 80 to the overlap set
        };

        bool hasOverlap = firstSet.Overlaps(overlapSet); // Check whether both sets share an element

        Console.WriteLine("Do firstSet and overlapSet overlap: " + hasOverlap); // Display the overlap result

        // Get values within range

        SortedSet<int> rangeSource = new SortedSet<int>() // Create a SortedSet for the range example
        {
            10, // Add 10 to the range source
            20, // Add 20 to the range source
            30, // Add 30 to the range source
            40, // Add 40 to the range source
            50, // Add 50 to the range source
            60, // Add 60 to the range source
            70, // Add 70 to the range source
            80 // Add 80 to the range source
        };

        SortedSet<int> rangeView = rangeSource.GetViewBetween(30, 60); // Obtain values from 30 to 60 inclusively

        Console.WriteLine("\nOriginal range source:"); // Display the original-range heading

        DisplaySet(rangeSource); // Display the complete range source

        Console.WriteLine("Values between 30 and 60:"); // Display the range-view heading

        DisplaySet(rangeView); // Display values within the specified range

        // Modify range view

        rangeView.Remove(40); // Remove 40 through the range view

        Console.WriteLine("Range view after removing 40:"); // Display the modified-view heading

        DisplaySet(rangeView); // Display the modified range view

        Console.WriteLine("Original set after modifying its view:"); // Display the original-set heading

        DisplaySet(rangeSource); // Show that the original SortedSet was also modified

        // Remove elements using condition

        SortedSet<int> conditionSet = new SortedSet<int>() // Create a set for conditional removal
        {
            10, // Add 10 to the condition set
            15, // Add 15 to the condition set
            20, // Add 20 to the condition set
            25, // Add 25 to the condition set
            30, // Add 30 to the condition set
            35, // Add 35 to the condition set
            40 // Add 40 to the condition set
        };

        int removedCount = conditionSet.RemoveWhere(number => number % 2 == 0); // Remove every even number

        Console.WriteLine("\nNumber of even elements removed: " + removedCount); // Display the number of removed elements

        Console.WriteLine("Set after removing even numbers:"); // Display the conditional-removal heading

        DisplaySet(conditionSet); // Display the remaining odd numbers

        // Copy SortedSet to array

        int[] copiedArray = new int[firstSet.Count]; // Create an array having the required size

        firstSet.CopyTo(copiedArray); // Copy all firstSet elements into the array

        Console.WriteLine("\nSortedSet copied to array:"); // Display the copy-to-array heading

        foreach (int number in copiedArray) // Visit every element of the copied array
        {
            Console.Write(number + " "); // Display the current array element
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Copy elements to array from index

        int[] largerArray = new int[8]; // Create an array with additional empty positions

        firstSet.CopyTo(largerArray, 2); // Copy firstSet elements starting from array index 2

        Console.WriteLine("\nSortedSet copied from array index 2:"); // Display the indexed-copy heading

        foreach (int number in largerArray) // Visit every element of the larger array
        {
            Console.Write(number + " "); // Display the current array element
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Create SortedSet from array

        int[] values = { 50, 20, 40, 10, 30, 20, 50 }; // Create an array containing unsorted duplicate values

        SortedSet<int> setFromArray = new SortedSet<int>(values); // Create a sorted set from the array

        Console.WriteLine("\nSortedSet created from an array:"); // Display the array-constructor heading

        DisplaySet(setFromArray); // Display sorted unique array values

        // String SortedSet

        SortedSet<string> fruits = new SortedSet<string>(); // Create an empty SortedSet of strings

        fruits.Add("Mango"); // Add Mango to the fruit set

        fruits.Add("Apple"); // Add Apple to the fruit set

        fruits.Add("Orange"); // Add Orange to the fruit set

        fruits.Add("Banana"); // Add Banana to the fruit set

        fruits.Add("Apple"); // Try to add duplicate Apple

        Console.WriteLine("\nString SortedSet:"); // Display the string-set heading

        DisplayStringSet(fruits); // Display the fruits alphabetically

        // String minimum and maximum

        if (fruits.Count > 0) // Check whether the fruit set contains elements
        {
            Console.WriteLine("Alphabetically first fruit: " + fruits.Min); // Display the alphabetically first fruit

            Console.WriteLine("Alphabetically last fruit: " + fruits.Max); // Display the alphabetically last fruit
        }

        // Case-sensitive SortedSet

        SortedSet<string> caseSensitiveSet = new SortedSet<string>(); // Create a case-sensitive string SortedSet

        caseSensitiveSet.Add("Apple"); // Add Apple with uppercase A

        caseSensitiveSet.Add("apple"); // Add apple with lowercase a

        Console.WriteLine("\nCase-sensitive SortedSet:"); // Display the case-sensitive heading

        DisplayStringSet(caseSensitiveSet); // Display both differently cased values

        Console.WriteLine("Case-sensitive count: " + caseSensitiveSet.Count); // Display the number of stored values

        // Case-insensitive SortedSet

        SortedSet<string> caseInsensitiveSet = new SortedSet<string>(StringComparer.OrdinalIgnoreCase); // Create a case-insensitive SortedSet

        bool uppercaseAdded = caseInsensitiveSet.Add("Apple"); // Add Apple with uppercase A

        bool lowercaseAdded = caseInsensitiveSet.Add("apple"); // Try to add apple with lowercase a

        caseInsensitiveSet.Add("Mango"); // Add Mango to the case-insensitive set

        caseInsensitiveSet.Add("Banana"); // Add Banana to the case-insensitive set

        Console.WriteLine("\nCase-insensitive SortedSet:"); // Display the case-insensitive heading

        DisplayStringSet(caseInsensitiveSet); // Display the case-insensitive set

        Console.WriteLine("Was Apple added: " + uppercaseAdded); // Display whether the first value was added

        Console.WriteLine("Was apple added again: " + lowercaseAdded); // Display false because case is ignored

        Console.WriteLine("Case-insensitive count: " + caseInsensitiveSet.Count); // Display the number of unique values

        // Try to obtain stored value

        bool actualValueFound = caseInsensitiveSet.TryGetValue("APPLE", out string? actualValue); // Search using a case-insensitive equal value

        if (actualValueFound) // Check whether an equal stored value was found
        {
            Console.WriteLine("Actual stored value for APPLE: " + actualValue); // Display the actual value stored in the set
        }
        else // Execute when an equal value was not found
        {
            Console.WriteLine("No equal value was found."); // Display the value-not-found message
        }

        // Descending SortedSet

        Comparer<int> descendingComparer = Comparer<int>.Create((first, second) => second.CompareTo(first)); // Create a descending-order comparer

        SortedSet<int> descendingSet = new SortedSet<int>(descendingComparer); // Create a SortedSet using the descending comparer

        descendingSet.Add(30); // Add 30 to the descending set

        descendingSet.Add(10); // Add 10 to the descending set

        descendingSet.Add(50); // Add 50 to the descending set

        descendingSet.Add(20); // Add 20 to the descending set

        descendingSet.Add(40); // Add 40 to the descending set

        Console.WriteLine("\nSortedSet using descending comparer:"); // Display the descending-set heading

        DisplaySet(descendingSet); // Display the values from largest to smallest

        // Comparer property

        IComparer<int> currentComparer = descendingSet.Comparer; // Obtain the comparer used by the SortedSet

        Console.WriteLine("Descending comparer is available: " + (currentComparer != null)); // Display whether the comparer exists

        // Clear SortedSet

        Console.WriteLine("\nSortedSet before Clear():"); // Display the set-before-clear heading

        DisplaySet(numbers); // Display the SortedSet before clearing it

        numbers.Clear(); // Remove every element from the SortedSet

        Console.WriteLine("SortedSet after Clear():"); // Display the set-after-clear heading

        DisplaySet(numbers); // Display the empty SortedSet

        // Final SortedSet status

        Console.WriteLine("Final SortedSet count: " + numbers.Count); // Display the final number of elements

        Console.WriteLine("Is final SortedSet empty: " + (numbers.Count == 0)); // Display whether the final SortedSet is empty
    }
}