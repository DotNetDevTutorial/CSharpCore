
/*
SortedDictionary in C# - Brief Summary

A SortedDictionary stores information in key-value pairs and automatically
arranges those pairs according to their keys.

Each key is connected to one value.

Example:

Key        Value
101        "Saad"
102        "Aman"
103        "Rahul"

Basic syntax:

SortedDictionary<KeyType, ValueType> dictionaryName =
    new SortedDictionary<KeyType, ValueType>();

Example:

SortedDictionary<int, string> students =
    new SortedDictionary<int, string>();

If the following keys are added:

104, 101, 103, 102

The SortedDictionary displays them as:

101, 102, 103, 104

Important characteristics:

1. Every key must be unique.
2. Duplicate keys are not allowed.
3. Different keys can contain the same value.
4. Entries are automatically sorted according to their keys.
5. Values are accessed using their corresponding keys.
6. Elements cannot be accessed using a numerical index.
7. A custom comparer can change the key-sorting order.
8. SortedDictionary is useful when sorted traversal is required.
9. It normally uses more comparison operations than Dictionary.
10. It is implemented using a balanced binary search tree.

Important methods and properties:

Add(key, value):
Adds a new key-value pair.
It throws an exception when the key already exists.

TryAdd(key, value):
Safely adds a key-value pair.
It returns false when the key already exists.

dictionary[key]:
Reads or updates the value associated with a key.

ContainsKey(key):
Checks whether a particular key exists.

ContainsValue(value):
Checks whether a particular value exists.

TryGetValue(key, out value):
Safely obtains the value associated with a key.

Remove(key):
Removes a key and its associated value.

Count:
Returns the total number of key-value pairs.

Keys:
Returns all keys in sorted order.

Values:
Returns values according to the sorted order of their keys.

Comparer:
Returns the comparer used for arranging keys.

Clear():
Removes all key-value pairs.

Difference between Dictionary and SortedDictionary:

Dictionary:
Provides fast average-time access but does not guarantee sorted keys.

SortedDictionary:
Maintains keys in sorted order but its operations generally require
logarithmic time.

Time complexity:

Add: O(log n)
Search by key: O(log n)
Update by key: O(log n)
Remove by key: O(log n)
ContainsValue: O(n)

Required namespace:

using System.Collections.Generic;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import SortedDictionary<TKey, TValue>

class SortedDictionaryProgram // Define the SortedDictionaryProgram class
{
    // Display integer-key SortedDictionary

    static void DisplayStudents(SortedDictionary<int, string> students) // Define a method to display student entries
    {
        if (students.Count == 0) // Check whether the SortedDictionary is empty
        {
            Console.WriteLine("SortedDictionary is empty."); // Display the empty-dictionary message
            return; // Stop the method
        }

        Console.WriteLine("Student ID\tStudent Name"); // Display the column headings

        foreach (KeyValuePair<int, string> student in students) // Visit every entry according to sorted keys
        {
            Console.WriteLine(student.Key + "\t\t" + student.Value); // Display the current key and value
        }
    }

    // Display string-key SortedDictionary

    static void DisplayProducts(SortedDictionary<string, double> products) // Define a method to display product entries
    {
        if (products.Count == 0) // Check whether the product dictionary is empty
        {
            Console.WriteLine("SortedDictionary is empty."); // Display the empty-dictionary message
            return; // Stop the method
        }

        foreach (KeyValuePair<string, double> product in products) // Visit every product according to sorted keys
        {
            Console.WriteLine(product.Key + " -> Rs. " + product.Value); // Display the product name and price
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create SortedDictionary

        SortedDictionary<int, string> students = new SortedDictionary<int, string>(); // Create an empty SortedDictionary

        Console.WriteLine("Initial SortedDictionary:"); // Display the initial-dictionary heading

        DisplayStudents(students); // Display the initially empty SortedDictionary

        // Check empty SortedDictionary

        bool isEmpty = students.Count == 0; // Check whether the SortedDictionary contains no entries

        Console.WriteLine("Is SortedDictionary empty: " + isEmpty); // Display whether the dictionary is empty

        // Add key-value pairs

        students.Add(105, "Priya"); // Add key 105 with value Priya

        students.Add(101, "Saad"); // Add key 101 with value Saad

        students.Add(104, "Neha"); // Add key 104 with value Neha

        students.Add(102, "Aman"); // Add key 102 with value Aman

        students.Add(103, "Rahul"); // Add key 103 with value Rahul

        Console.WriteLine("\nSortedDictionary after Add() operations:"); // Display the add-operation heading

        DisplayStudents(students); // Display entries automatically arranged by student ID

        // Count entries

        int totalStudents = students.Count; // Store the total number of key-value pairs

        Console.WriteLine("Total students: " + totalStudents); // Display the total number of students

        // Access value using key

        string studentName = students[103]; // Obtain the value associated with key 103

        Console.WriteLine("\nStudent having ID 103: " + studentName); // Display the value associated with key 103

        // Update value using key

        students[103] = "Rahul Kumar"; // Replace the value associated with key 103

        Console.WriteLine("Updated name for ID 103: " + students[103]); // Display the updated value

        // Add entry using indexer

        students[106] = "Zoya"; // Add a new key-value pair using the indexer

        Console.WriteLine("\nSortedDictionary after adding ID 106 using indexer:"); // Display the indexer-addition heading

        DisplayStudents(students); // Display the updated SortedDictionary

        // Update existing entry using indexer

        students[106] = "Zoya Khan"; // Update the value associated with the existing key

        Console.WriteLine("Updated value for ID 106: " + students[106]); // Display the updated value

        // Add safely using TryAdd

        bool wasAdded = students.TryAdd(107, "Arjun"); // Try to add a new key-value pair safely

        Console.WriteLine("\nWas ID 107 added: " + wasAdded); // Display whether the entry was added

        bool duplicateAdded = students.TryAdd(101, "Another Student"); // Try to add a duplicate key

        Console.WriteLine("Was duplicate ID 101 added: " + duplicateAdded); // Display false because the key already exists

        // Check key using ContainsKey

        int searchKey = 104; // Store the key that must be searched

        bool keyExists = students.ContainsKey(searchKey); // Check whether the required key exists

        if (keyExists) // Check whether the key was found
        {
            Console.WriteLine("\nStudent ID " + searchKey + " exists."); // Display the key-found message
        }
        else // Execute when the key was not found
        {
            Console.WriteLine("\nStudent ID " + searchKey + " does not exist."); // Display the key-not-found message
        }

        // Check value using ContainsValue

        string searchValue = "Neha"; // Store the value that must be searched

        bool valueExists = students.ContainsValue(searchValue); // Check whether the required value exists

        if (valueExists) // Check whether the value was found
        {
            Console.WriteLine(searchValue + " exists in the SortedDictionary."); // Display the value-found message
        }
        else // Execute when the value was not found
        {
            Console.WriteLine(searchValue + " does not exist in the SortedDictionary."); // Display the value-not-found message
        }

        // Safe value access using TryGetValue

        int requiredId = 105; // Store the student ID whose value is required

        bool studentFound = students.TryGetValue(requiredId, out string? requiredName); // Try to obtain the value safely

        if (studentFound) // Check whether the key was found
        {
            Console.WriteLine("\nStudent having ID " + requiredId + ": " + requiredName); // Display the found value
        }
        else // Execute when the key was not found
        {
            Console.WriteLine("\nStudent ID " + requiredId + " was not found."); // Display the key-not-found message
        }

        // Prevent KeyNotFoundException

        int missingId = 500; // Store a key that does not exist

        if (students.ContainsKey(missingId)) // Check whether the key exists before accessing it
        {
            Console.WriteLine(students[missingId]); // Display the value associated with the key
        }
        else // Execute when the key does not exist
        {
            Console.WriteLine("Student ID " + missingId + " cannot be accessed because it does not exist."); // Display the safe-access message
        }

        // Traverse key-value pairs

        Console.WriteLine("\nAll key-value pairs in ascending key order:"); // Display the traversal heading

        foreach (KeyValuePair<int, string> student in students) // Visit every key-value pair in sorted order
        {
            Console.WriteLine("Key: " + student.Key + ", Value: " + student.Value); // Display the current key and value
        }

        // Traverse using var

        Console.WriteLine("\nTraversal using var:"); // Display the var-traversal heading

        foreach (var student in students) // Visit every entry using an inferred data type
        {
            Console.WriteLine(student.Key + " -> " + student.Value); // Display the current key-value pair
        }

        // Display all keys

        SortedDictionary<int, string>.KeyCollection studentIds = students.Keys; // Obtain all keys in sorted order

        Console.WriteLine("\nAll student IDs:"); // Display the keys heading

        foreach (int studentId in studentIds) // Visit every key
        {
            Console.WriteLine(studentId); // Display the current key
        }

        // Display all values

        SortedDictionary<int, string>.ValueCollection studentNames = students.Values; // Obtain values according to sorted key order

        Console.WriteLine("\nAll student names:"); // Display the values heading

        foreach (string name in studentNames) // Visit every value
        {
            Console.WriteLine(name); // Display the current value
        }

        // Obtain key comparer

        IComparer<int> keyComparer = students.Comparer; // Obtain the comparer used to arrange integer keys

        int comparisonResult = keyComparer.Compare(101, 102); // Compare key 101 with key 102

        Console.WriteLine("\nComparer result for 101 and 102: " + comparisonResult); // Display a negative result because 101 comes before 102

        // Remove key-value pair

        bool wasRemoved = students.Remove(102); // Remove key 102 and its associated value

        Console.WriteLine("\nWas student ID 102 removed: " + wasRemoved); // Display whether removal succeeded

        Console.WriteLine("SortedDictionary after removing ID 102:"); // Display the removal heading

        DisplayStudents(students); // Display the updated SortedDictionary

        // Remove missing key

        bool missingRemoved = students.Remove(900); // Try to remove a key that does not exist

        Console.WriteLine("Was missing ID 900 removed: " + missingRemoved); // Display false because the key does not exist

        // Remove key and obtain value

        bool removedWithValue = students.Remove(104, out string? removedStudentName); // Remove key 104 and obtain its associated value

        if (removedWithValue) // Check whether the entry was removed
        {
            Console.WriteLine("\nRemoved student: " + removedStudentName); // Display the removed value
        }
        else // Execute when the key was not found
        {
            Console.WriteLine("\nStudent could not be removed."); // Display the removal-failure message
        }

        Console.WriteLine("SortedDictionary after removing ID 104:"); // Display the updated-dictionary heading

        DisplayStudents(students); // Display the remaining key-value pairs

        // Create using collection initializer

        SortedDictionary<string, double> productPrices = new SortedDictionary<string, double>() // Create a product-price SortedDictionary
        {
            { "Monitor", 18000.00 }, // Add Monitor with its price
            { "Laptop", 65000.00 }, // Add Laptop with its price
            { "Mouse", 800.00 }, // Add Mouse with its price
            { "Keyboard", 1500.00 } // Add Keyboard with its price
        };

        Console.WriteLine("\nProduct-price SortedDictionary:"); // Display the product-dictionary heading

        DisplayProducts(productPrices); // Display products alphabetically according to their keys

        // Update product price

        productPrices["Laptop"] = 62000.00; // Update the price associated with Laptop

        Console.WriteLine("Updated Laptop price: Rs. " + productPrices["Laptop"]); // Display the updated price

        // Calculate total of values

        double totalPrice = 0; // Initialize the total price with zero

        foreach (double price in productPrices.Values) // Visit every value in the dictionary
        {
            totalPrice = totalPrice + price; // Add the current price to the total
        }

        Console.WriteLine("Total price of all products: Rs. " + totalPrice); // Display the total of all values

        // Calculate average of values

        if (productPrices.Count > 0) // Check whether the product dictionary contains entries
        {
            double averagePrice = totalPrice / productPrices.Count; // Calculate the average product price

            Console.WriteLine("Average product price: Rs. " + averagePrice); // Display the average price
        }

        // Find maximum value

        string mostExpensiveProduct = ""; // Create a variable for the most expensive product name

        double maximumPrice = double.MinValue; // Initialize maximum price with the smallest double value

        foreach (KeyValuePair<string, double> product in productPrices) // Visit every product-price pair
        {
            if (product.Value > maximumPrice) // Check whether the current price is greater than maximum
            {
                maximumPrice = product.Value; // Update the maximum price

                mostExpensiveProduct = product.Key; // Store the corresponding product name
            }
        }

        Console.WriteLine("Most expensive product: " + mostExpensiveProduct); // Display the product having the maximum price

        Console.WriteLine("Maximum product price: Rs. " + maximumPrice); // Display the maximum price

        // Find minimum value

        string cheapestProduct = ""; // Create a variable for the cheapest product name

        double minimumPrice = double.MaxValue; // Initialize minimum price with the largest double value

        foreach (KeyValuePair<string, double> product in productPrices) // Visit every product-price pair
        {
            if (product.Value < minimumPrice) // Check whether the current price is smaller than minimum
            {
                minimumPrice = product.Value; // Update the minimum price

                cheapestProduct = product.Key; // Store the corresponding product name
            }
        }

        Console.WriteLine("Cheapest product: " + cheapestProduct); // Display the product having the minimum price

        Console.WriteLine("Minimum product price: Rs. " + minimumPrice); // Display the minimum price

        // Different keys with same value

        SortedDictionary<int, string> departments = new SortedDictionary<int, string>(); // Create a department SortedDictionary

        departments.Add(3, "Development"); // Add the third department

        departments.Add(1, "Development"); // Add another key with the same value

        departments.Add(2, "Testing"); // Add the second department

        Console.WriteLine("\nDifferent keys with the same value:"); // Display the duplicate-values heading

        foreach (KeyValuePair<int, string> department in departments) // Visit every department entry in key order
        {
            Console.WriteLine(department.Key + " -> " + department.Value); // Display the current department entry
        }

        // Case-sensitive string keys

        SortedDictionary<string, int> caseSensitiveDictionary = new SortedDictionary<string, int>(); // Create a case-sensitive SortedDictionary

        caseSensitiveDictionary.Add("Apple", 10); // Add Apple with uppercase A

        caseSensitiveDictionary.Add("apple", 20); // Add apple with lowercase a as a separate key

        Console.WriteLine("\nCase-sensitive SortedDictionary:"); // Display the case-sensitive heading

        foreach (KeyValuePair<string, int> item in caseSensitiveDictionary) // Visit each case-sensitive entry
        {
            Console.WriteLine(item.Key + " -> " + item.Value); // Display the current key-value pair
        }

        Console.WriteLine("Case-sensitive count: " + caseSensitiveDictionary.Count); // Display two because key casing is different

        // Case-insensitive string keys

        SortedDictionary<string, int> caseInsensitiveDictionary = new SortedDictionary<string, int>(StringComparer.OrdinalIgnoreCase); // Create a case-insensitive SortedDictionary

        bool uppercaseKeyAdded = caseInsensitiveDictionary.TryAdd("Apple", 10); // Add Apple with uppercase A

        bool lowercaseKeyAdded = caseInsensitiveDictionary.TryAdd("apple", 20); // Try to add apple with lowercase a

        caseInsensitiveDictionary.Add("Mango", 30); // Add Mango to the dictionary

        caseInsensitiveDictionary.Add("Banana", 40); // Add Banana to the dictionary

        Console.WriteLine("\nCase-insensitive SortedDictionary:"); // Display the case-insensitive heading

        foreach (KeyValuePair<string, int> item in caseInsensitiveDictionary) // Visit each case-insensitive entry
        {
            Console.WriteLine(item.Key + " -> " + item.Value); // Display the current key-value pair
        }

        Console.WriteLine("Was Apple added: " + uppercaseKeyAdded); // Display whether the first key was added

        Console.WriteLine("Was apple added again: " + lowercaseKeyAdded); // Display false because case is ignored

        Console.WriteLine("Case-insensitive count: " + caseInsensitiveDictionary.Count); // Display the number of unique keys

        // Descending key order

        Comparer<int> descendingComparer = Comparer<int>.Create((first, second) => second.CompareTo(first)); // Create a descending integer comparer

        SortedDictionary<int, string> descendingStudents = new SortedDictionary<int, string>(descendingComparer); // Create a SortedDictionary using descending key order

        descendingStudents.Add(101, "Saad"); // Add student ID 101

        descendingStudents.Add(104, "Neha"); // Add student ID 104

        descendingStudents.Add(102, "Aman"); // Add student ID 102

        descendingStudents.Add(105, "Priya"); // Add student ID 105

        descendingStudents.Add(103, "Rahul"); // Add student ID 103

        Console.WriteLine("\nSortedDictionary in descending key order:"); // Display the descending-order heading

        DisplayStudents(descendingStudents); // Display entries from the largest key to the smallest key

        // Dictionary containing list values

        SortedDictionary<string, List<string>> courses = new SortedDictionary<string, List<string>>(); // Create a SortedDictionary whose values are lists

        courses.Add("Programming", new List<string>()); // Add Programming with an empty list

        courses["Programming"].Add("C#"); // Add C# to the Programming list

        courses["Programming"].Add("Python"); // Add Python to the Programming list

        courses.Add("Database", new List<string>() { "SQL", "MongoDB" }); // Add Database with two courses

        courses.Add("Cloud", new List<string>() { "Azure", "AWS" }); // Add Cloud with two technologies

        Console.WriteLine("\nSortedDictionary containing List values:"); // Display the list-values heading

        foreach (KeyValuePair<string, List<string>> category in courses) // Visit every category in alphabetical order
        {
            Console.WriteLine(category.Key + ":"); // Display the current category

            foreach (string course in category.Value) // Visit every course in the current category
            {
                Console.WriteLine("- " + course); // Display the current course
            }
        }

        // Create copy of SortedDictionary

        SortedDictionary<int, string> copiedStudents = new SortedDictionary<int, string>(students); // Create a copy of the student SortedDictionary

        Console.WriteLine("\nCopied student SortedDictionary:"); // Display the copied-dictionary heading

        DisplayStudents(copiedStudents); // Display the copied SortedDictionary

        // Copy entries to an array

        KeyValuePair<int, string>[] studentArray = new KeyValuePair<int, string>[students.Count]; // Create an array large enough to store every entry

        int arrayIndex = 0; // Initialize the destination array index

        foreach (KeyValuePair<int, string> student in students) // Visit every dictionary entry
        {
            studentArray[arrayIndex] = student; // Copy the current entry into the array

            arrayIndex++; // Move to the next array position
        }

        Console.WriteLine("\nSortedDictionary copied to array:"); // Display the array-copy heading

        foreach (KeyValuePair<int, string> student in studentArray) // Visit every copied array entry
        {
            Console.WriteLine(student.Key + " -> " + student.Value); // Display the copied key and value
        }

        // Clear SortedDictionary

        Console.WriteLine("\nSortedDictionary before Clear():"); // Display the dictionary-before-clear heading

        DisplayStudents(students); // Display the SortedDictionary before clearing it

        students.Clear(); // Remove every key-value pair

        Console.WriteLine("SortedDictionary after Clear():"); // Display the dictionary-after-clear heading

        DisplayStudents(students); // Display the empty SortedDictionary

        // Final SortedDictionary status

        Console.WriteLine("Final SortedDictionary count: " + students.Count); // Display the final number of entries

        Console.WriteLine("Is final SortedDictionary empty: " + (students.Count == 0)); // Display whether the final SortedDictionary is empty
    }
}
