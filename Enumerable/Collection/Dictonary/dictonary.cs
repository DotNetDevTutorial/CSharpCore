
/*
Dictionary in C# - Brief Summary

A Dictionary stores data in key-value pairs.

Each key is connected to one value.

Example:

Key        Value
101        "Saad"
102        "Aman"
103        "Rahul"

Basic syntax:

Dictionary<KeyType, ValueType> dictionaryName =
    new Dictionary<KeyType, ValueType>();

Example:

Dictionary<int, string> students =
    new Dictionary<int, string>();

Important characteristics:

1. Every key must be unique.
2. Duplicate keys are not allowed.
3. Different keys can contain the same value.
4. A value is accessed using its corresponding key.
5. Keys and values can have different data types.
6. Elements cannot be accessed using a numerical index.
7. Dictionary does not guarantee that elements will remain in a
   particular order.
8. It provides fast insertion, searching, updating, and deletion.

Important methods and properties:

Add(key, value):
Adds a new key-value pair.
It throws an exception when the key already exists.

TryAdd(key, value):
Adds a key-value pair safely.
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
Removes the key and its associated value.

Count:
Returns the total number of key-value pairs.

Keys:
Returns a collection containing all keys.

Values:
Returns a collection containing all values.

Clear():
Removes every key-value pair.

Time complexity on average:

Add: O(1)
Search by key: O(1)
Update by key: O(1)
Remove by key: O(1)
ContainsValue: O(n)

Required namespace:

using System.Collections.Generic;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import the generic Dictionary<TKey, TValue> class

class DictionaryProgram // Define the DictionaryProgram class
{
    // Display dictionary

    static void DisplayDictionary(Dictionary<int, string> students) // Define a method that accepts a student dictionary
    {
        if (students.Count == 0) // Check whether the dictionary is empty
        {
            Console.WriteLine("Dictionary is empty."); // Display the empty-dictionary message
            return; // Stop the method
        }

        Console.WriteLine("Student ID\tStudent Name"); // Display the column headings

        foreach (KeyValuePair<int, string> student in students) // Visit every key-value pair
        {
            Console.WriteLine(student.Key + "\t\t" + student.Value); // Display the current key and value
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create dictionary

        Dictionary<int, string> students = new Dictionary<int, string>(); // Create an empty dictionary

        Console.WriteLine("Initial dictionary:"); // Display the initial-dictionary heading

        DisplayDictionary(students); // Display the initially empty dictionary

        // Check empty dictionary

        bool isEmpty = students.Count == 0; // Check whether the dictionary contains no elements

        Console.WriteLine("Is dictionary empty: " + isEmpty); // Display whether the dictionary is empty

        // Add key-value pairs

        students.Add(101, "Saad"); // Add student ID 101 with name Saad

        students.Add(102, "Aman"); // Add student ID 102 with name Aman

        students.Add(103, "Rahul"); // Add student ID 103 with name Rahul

        students.Add(104, "Neha"); // Add student ID 104 with name Neha

        students.Add(105, "Priya"); // Add student ID 105 with name Priya

        Console.WriteLine("\nDictionary after Add() operations:"); // Display the add-operation heading

        DisplayDictionary(students); // Display all key-value pairs

        // Count key-value pairs

        int totalStudents = students.Count; // Store the total number of key-value pairs

        Console.WriteLine("Total students: " + totalStudents); // Display the total number of students

        // Access value using key

        string studentName = students[103]; // Obtain the value associated with key 103

        Console.WriteLine("\nStudent having ID 103: " + studentName); // Display the value associated with key 103

        // Update value using key

        students[103] = "Rahul Kumar"; // Replace the value associated with key 103

        Console.WriteLine("Updated name for ID 103: " + students[103]); // Display the updated value

        // Add using indexer

        students[106] = "Zoya"; // Add a new key-value pair using the indexer

        Console.WriteLine("\nDictionary after adding ID 106 using indexer:"); // Display the indexer-addition heading

        DisplayDictionary(students); // Display the updated dictionary

        // Difference between Add and indexer

        students[106] = "Zoya Khan"; // Update the existing key instead of creating a duplicate

        Console.WriteLine("Updated value for ID 106: " + students[106]); // Display the updated value

        // Add safely using TryAdd

        bool wasAdded = students.TryAdd(107, "Arjun"); // Try to add a new key-value pair safely

        Console.WriteLine("\nWas ID 107 added: " + wasAdded); // Display whether the new pair was added

        bool duplicateAdded = students.TryAdd(101, "Another Student"); // Try to add an already existing key

        Console.WriteLine("Was duplicate ID 101 added: " + duplicateAdded); // Display false because the key already exists

        // Check key using ContainsKey

        int searchKey = 104; // Store the key that must be searched

        bool keyExists = students.ContainsKey(searchKey); // Check whether the key exists

        if (keyExists) // Check whether the searched key was found
        {
            Console.WriteLine("\nStudent ID " + searchKey + " exists."); // Display the key-found message
        }
        else // Execute when the searched key does not exist
        {
            Console.WriteLine("\nStudent ID " + searchKey + " does not exist."); // Display the key-not-found message
        }

        // Check value using ContainsValue

        string searchName = "Neha"; // Store the value that must be searched

        bool valueExists = students.ContainsValue(searchName); // Check whether the value exists

        if (valueExists) // Check whether the searched value was found
        {
            Console.WriteLine(searchName + " exists in the dictionary."); // Display the value-found message
        }
        else // Execute when the searched value does not exist
        {
            Console.WriteLine(searchName + " does not exist in the dictionary."); // Display the value-not-found message
        }

        // Safe value access using TryGetValue

        int requiredId = 105; // Store the student ID whose value is required

        bool studentFound = students.TryGetValue(requiredId, out string? requiredName); // Try to obtain the value safely

        if (studentFound) // Check whether the key was found
        {
            Console.WriteLine("\nStudent having ID " + requiredId + ": " + requiredName); // Display the found student name
        }
        else // Execute when the key does not exist
        {
            Console.WriteLine("\nStudent ID " + requiredId + " was not found."); // Display the key-not-found message
        }

        // Prevent KeyNotFoundException

        int missingId = 500; // Store a key that does not exist

        if (students.ContainsKey(missingId)) // Check whether the missing key exists before accessing it
        {
            Console.WriteLine(students[missingId]); // Display the value associated with the key
        }
        else // Execute when the key does not exist
        {
            Console.WriteLine("Student ID " + missingId + " cannot be accessed because it does not exist."); // Display the safe-access message
        }

        // Traverse key-value pairs

        Console.WriteLine("\nAll key-value pairs:"); // Display the traversal heading

        foreach (KeyValuePair<int, string> student in students) // Visit every key-value pair
        {
            Console.WriteLine("Key: " + student.Key + ", Value: " + student.Value); // Display the current key and value
        }

        // Traverse using var

        Console.WriteLine("\nTraversal using var:"); // Display the var-traversal heading

        foreach (var student in students) // Visit every dictionary entry using inferred type
        {
            Console.WriteLine(student.Key + " -> " + student.Value); // Display the current key and value
        }

        // Display all keys

        Dictionary<int, string>.KeyCollection studentIds = students.Keys; // Obtain the collection of all dictionary keys

        Console.WriteLine("\nAll student IDs:"); // Display the keys heading

        foreach (int studentId in studentIds) // Visit every key in the dictionary
        {
            Console.WriteLine(studentId); // Display the current key
        }

        // Display all values

        Dictionary<int, string>.ValueCollection studentNames = students.Values; // Obtain the collection of all dictionary values

        Console.WriteLine("\nAll student names:"); // Display the values heading

        foreach (string name in studentNames) // Visit every value in the dictionary
        {
            Console.WriteLine(name); // Display the current value
        }

        // Remove key-value pair

        bool wasRemoved = students.Remove(102); // Remove key 102 and its associated value

        Console.WriteLine("\nWas student ID 102 removed: " + wasRemoved); // Display whether removal succeeded

        Console.WriteLine("Dictionary after removing ID 102:"); // Display the removal heading

        DisplayDictionary(students); // Display the updated dictionary

        // Remove missing key

        bool missingRemoved = students.Remove(900); // Try to remove a key that does not exist

        Console.WriteLine("Was missing ID 900 removed: " + missingRemoved); // Display false because the key does not exist

        // Remove and obtain value

        bool removedWithValue = students.Remove(104, out string? removedStudentName); // Remove key 104 and obtain its value

        if (removedWithValue) // Check whether the key-value pair was removed
        {
            Console.WriteLine("\nRemoved student: " + removedStudentName); // Display the removed value
        }
        else // Execute when the key was not found
        {
            Console.WriteLine("\nStudent could not be removed."); // Display the removal-failure message
        }

        Console.WriteLine("Dictionary after removing ID 104:"); // Display the updated-dictionary heading

        DisplayDictionary(students); // Display the remaining key-value pairs

        // Create dictionary using collection initializer

        Dictionary<string, double> productPrices = new Dictionary<string, double>() // Create a dictionary of products and prices
        {
            { "Laptop", 65000.00 }, // Add Laptop with its price
            { "Mouse", 800.00 }, // Add Mouse with its price
            { "Keyboard", 1500.00 }, // Add Keyboard with its price
            { "Monitor", 18000.00 } // Add Monitor with its price
        };

        Console.WriteLine("\nProduct-price dictionary:"); // Display the product-dictionary heading

        foreach (KeyValuePair<string, double> product in productPrices) // Visit every product-price pair
        {
            Console.WriteLine(product.Key + ": Rs. " + product.Value); // Display the current product and price
        }

        // Update product price

        productPrices["Laptop"] = 62000.00; // Update the price associated with Laptop

        Console.WriteLine("Updated Laptop price: Rs. " + productPrices["Laptop"]); // Display the updated price

        // Calculate total of dictionary values

        double totalPrice = 0; // Initialize the total price with zero

        foreach (double price in productPrices.Values) // Visit every price in the dictionary
        {
            totalPrice = totalPrice + price; // Add the current price to the total
        }

        Console.WriteLine("Total price of all products: Rs. " + totalPrice); // Display the total of all values

        // Find maximum value

        string mostExpensiveProduct = ""; // Create a variable for the most expensive product name

        double maximumPrice = double.MinValue; // Initialize maximum price with the smallest double value

        foreach (KeyValuePair<string, double> product in productPrices) // Visit every product-price pair
        {
            if (product.Value > maximumPrice) // Check whether the current price is greater than the maximum
            {
                maximumPrice = product.Value; // Update the maximum price

                mostExpensiveProduct = product.Key; // Store the corresponding product name
            }
        }

        Console.WriteLine("Most expensive product: " + mostExpensiveProduct); // Display the product having the maximum price

        Console.WriteLine("Maximum price: Rs. " + maximumPrice); // Display the maximum price

        // Different keys with same value

        Dictionary<int, string> departments = new Dictionary<int, string>(); // Create a dictionary for department names

        departments.Add(1, "Development"); // Add the first department

        departments.Add(2, "Testing"); // Add the second department

        departments.Add(3, "Development"); // Add another key having the same value

        Console.WriteLine("\nDifferent keys with the same value:"); // Display the duplicate-values heading

        foreach (KeyValuePair<int, string> department in departments) // Visit every department entry
        {
            Console.WriteLine(department.Key + " -> " + department.Value); // Display the current department key and value
        }

        // Dictionary with case-sensitive keys

        Dictionary<string, int> caseSensitiveDictionary = new Dictionary<string, int>(); // Create a case-sensitive dictionary

        caseSensitiveDictionary.Add("Apple", 10); // Add Apple with uppercase A

        caseSensitiveDictionary.Add("apple", 20); // Add apple with lowercase a as a different key

        Console.WriteLine("\nCase-sensitive dictionary count: " + caseSensitiveDictionary.Count); // Display two because both keys are different

        // Dictionary with case-insensitive keys

        Dictionary<string, int> caseInsensitiveDictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); // Create a case-insensitive dictionary

        bool uppercaseKeyAdded = caseInsensitiveDictionary.TryAdd("Apple", 10); // Add Apple with uppercase A

        bool lowercaseKeyAdded = caseInsensitiveDictionary.TryAdd("apple", 20); // Try to add apple with lowercase a

        Console.WriteLine("Was Apple added: " + uppercaseKeyAdded); // Display whether the first key was added

        Console.WriteLine("Was apple added again: " + lowercaseKeyAdded); // Display false because case is ignored

        Console.WriteLine("Case-insensitive dictionary count: " + caseInsensitiveDictionary.Count); // Display one unique key

        // Dictionary containing list values

        Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>(); // Create a dictionary whose values are lists

        courses.Add("Programming", new List<string>()); // Add Programming with an empty course list

        courses["Programming"].Add("C#"); // Add C# to the Programming list

        courses["Programming"].Add("Python"); // Add Python to the Programming list

        courses.Add("Database", new List<string>() { "SQL", "MongoDB" }); // Add Database with two course names

        Console.WriteLine("\nDictionary containing List values:"); // Display the list-value heading

        foreach (KeyValuePair<string, List<string>> category in courses) // Visit every category and course list
        {
            Console.WriteLine(category.Key + ":"); // Display the current category

            foreach (string course in category.Value) // Visit every course in the current list
            {
                Console.WriteLine("- " + course); // Display the current course
            }
        }

        // Copy dictionary

        Dictionary<int, string> copiedStudents = new Dictionary<int, string>(students); // Create a copy of the student dictionary

        Console.WriteLine("\nCopied student dictionary:"); // Display the copied-dictionary heading

        DisplayDictionary(copiedStudents); // Display the copied dictionary

        // Ensure dictionary capacity

        int capacity = students.EnsureCapacity(20); // Ensure that the dictionary can hold at least twenty entries

        Console.WriteLine("\nCapacity after EnsureCapacity(): " + capacity); // Display the resulting internal capacity

        // Trim excess capacity

        students.TrimExcess(); // Reduce unused internal storage when possible

        Console.WriteLine("TrimExcess() completed."); // Display the capacity-trimming message

        // Clear dictionary

        Console.WriteLine("\nDictionary before Clear():"); // Display the dictionary-before-clear heading

        DisplayDictionary(students); // Display the dictionary before clearing it

        students.Clear(); // Remove every key-value pair from the dictionary

        Console.WriteLine("Dictionary after Clear():"); // Display the dictionary-after-clear heading

        DisplayDictionary(students); // Display the empty dictionary

        // Final dictionary status

        Console.WriteLine("Final dictionary count: " + students.Count); // Display the final number of key-value pairs

        Console.WriteLine("Is final dictionary empty: " + (students.Count == 0)); // Display whether the final dictionary is empty
    }
}

