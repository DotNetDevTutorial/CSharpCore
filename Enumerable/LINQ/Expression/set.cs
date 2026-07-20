/*
LINQ Quantifier Operators Using Method Syntax - Concept Summary

Quantifier operators check whether elements in a collection satisfy
a condition. They return a Boolean value: true or false.

Main quantifier operators:

1. Any()
   Checks whether the collection contains at least one element.

   Syntax:

   bool result = collection.Any();

2. Any(predicate)
   Checks whether at least one element satisfies a condition.

   Syntax:

   bool result = collection.Any(item => condition);

3. All(predicate)
   Checks whether every element satisfies a condition.

   Syntax:

   bool result = collection.All(item => condition);

4. Contains(value)
   Checks whether a specific value exists in the collection.

   Syntax:

   bool result = collection.Contains(value);

Important differences:

Any():

- Returns true when at least one element exists.
- Stops checking after finding the first matching element.

All():

- Returns true only when every element satisfies the condition.
- Stops checking after finding the first non-matching element.

Contains():

- Searches for a specific value.
- Uses the default equality comparison unless a comparer is supplied.

Empty collection behaviour:

emptyCollection.Any()                     -> false
emptyCollection.Any(condition)            -> false
emptyCollection.All(condition)            -> true
emptyCollection.Contains(value)           -> false

All() returns true for an empty collection because no element violates
the supplied condition.

Examples:

bool hasEvenNumber =
    numbers.Any(number => number % 2 == 0);

bool allPositive =
    numbers.All(number => number > 0);

bool containsThirty =
    numbers.Contains(30);

Important points:

1. Quantifier operators return bool.
2. They execute immediately.
3. They do not modify the original collection.
4. Any() is preferred over Count() > 0 when only existence is needed.
5. Any() and All() use short-circuit evaluation.
6. Contains() can use a custom equality comparer.
7. Complete checking normally requires O(n) time.
8. Execution may finish earlier when the result becomes known.

Required namespace:

using System.Linq;
*/

using System; // Import Console and StringComparer
using System.Collections.Generic; // Import List<T>
using System.Linq; // Import Any(), All() and Contains()

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public int Marks { get; set; } // Store the student marks
}

class QuantifierProgram // Define the main program class
{
    static void Main() // Define the program entry point
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a number collection
        {
            10, // Add 10
            20, // Add 20
            30, // Add 30
            40, // Add 40
            50 // Add 50
        };

        Console.WriteLine("Numbers: " + string.Join(", ", numbers)); // Display the number collection

        // Any without condition

        bool hasAnyNumber = numbers.Any(); // Check whether the collection contains at least one number

        Console.WriteLine("\nCollection contains at least one number: " + hasAnyNumber); // Display the Any() result

        // Any with condition

        bool hasNumberGreaterThanForty = numbers.Any(number => number > 40); // Check whether at least one number is greater than forty

        Console.WriteLine("Any number greater than 40: " + hasNumberGreaterThanForty); // Display the conditional Any() result

        bool hasOddNumber = numbers.Any(number => number % 2 != 0); // Check whether at least one odd number exists

        Console.WriteLine("Any odd number: " + hasOddNumber); // Display false because every number is even

        bool hasNumberDivisibleByThree = numbers.Any(number => number % 3 == 0); // Check whether at least one number is divisible by three

        Console.WriteLine("Any number divisible by 3: " + hasNumberDivisibleByThree); // Display the divisibility result

        // All with condition

        bool allNumbersArePositive = numbers.All(number => number > 0); // Check whether every number is positive

        Console.WriteLine("\nAll numbers are positive: " + allNumbersArePositive); // Display the All() result

        bool allNumbersAreEven = numbers.All(number => number % 2 == 0); // Check whether every number is even

        Console.WriteLine("All numbers are even: " + allNumbersAreEven); // Display true because all values are even

        bool allNumbersGreaterThanTwenty = numbers.All(number => number > 20); // Check whether every number is greater than twenty

        Console.WriteLine("All numbers are greater than 20: " + allNumbersGreaterThanTwenty); // Display false because some values are smaller

        // Contains

        bool containsThirty = numbers.Contains(30); // Check whether thirty exists in the collection

        Console.WriteLine("\nCollection contains 30: " + containsThirty); // Display the Contains() result

        bool containsHundred = numbers.Contains(100); // Check whether one hundred exists in the collection

        Console.WriteLine("Collection contains 100: " + containsHundred); // Display false because one hundred is absent

        // Combine quantifier conditions

        bool hasNumberWithinRange = numbers.Any(number => number >= 25 && number <= 45); // Check whether at least one number lies within the range

        Console.WriteLine("\nAny number between 25 and 45: " + hasNumberWithinRange); // Display the combined-condition result

        bool allNumbersWithinRange = numbers.All(number => number >= 10 && number <= 50); // Check whether every number lies within the range

        Console.WriteLine("All numbers are between 10 and 50: " + allNumbersWithinRange); // Display the range-checking result

        // Compare Any() and Count()

        bool existsUsingAny = numbers.Any(); // Check existence using Any()

        bool existsUsingCount = numbers.Count() > 0; // Check existence by counting all elements

        Console.WriteLine("\nExistence using Any(): " + existsUsingAny); // Display the Any() existence result

        Console.WriteLine("Existence using Count() > 0: " + existsUsingCount); // Display the Count() existence result

        // Create empty collection

        List<int> emptyNumbers = new List<int>(); // Create an empty integer collection

        bool emptyAnyResult = emptyNumbers.Any(); // Check whether the empty collection contains an element

        bool emptyConditionalAnyResult = emptyNumbers.Any(number => number > 0); // Check whether an element satisfies the condition

        bool emptyAllResult = emptyNumbers.All(number => number > 0); // Check whether every element satisfies the condition

        bool emptyContainsResult = emptyNumbers.Contains(10); // Check whether ten exists in the empty collection

        Console.WriteLine("\nEMPTY COLLECTION RESULTS:"); // Display the empty-collection heading

        Console.WriteLine("Any(): " + emptyAnyResult); // Display false because no element exists

        Console.WriteLine("Any(number > 0): " + emptyConditionalAnyResult); // Display false because no matching element exists

        Console.WriteLine("All(number > 0): " + emptyAllResult); // Display true because no element violates the condition

        Console.WriteLine("Contains(10): " + emptyContainsResult); // Display false because ten is absent

        // Create string collection

        List<string> technologies = new List<string>() // Create a technology collection
        {
            "C#", // Add C#
            "Python", // Add Python
            "SQL", // Add SQL
            "PySpark" // Add PySpark
        };

        bool containsPython = technologies.Contains("Python"); // Check for Python using case-sensitive comparison

        Console.WriteLine("\nContains Python: " + containsPython); // Display the case-sensitive result

        bool containsLowercasePython = technologies.Contains("python"); // Check for lowercase python using default comparison

        Console.WriteLine("Contains lowercase python: " + containsLowercasePython); // Display false because comparison is case-sensitive

        bool containsPythonIgnoringCase = technologies.Contains("python", StringComparer.OrdinalIgnoreCase); // Check for python without considering letter case

        Console.WriteLine("Contains python ignoring case: " + containsPythonIgnoringCase); // Display true using the custom comparer

        bool hasLongTechnologyName = technologies.Any(technology => technology.Length > 5); // Check whether any technology name has more than five characters

        Console.WriteLine("Any technology name longer than 5 characters: " + hasLongTechnologyName); // Display the string Any() result

        bool allTechnologyNamesAreNonEmpty = technologies.All(technology => !string.IsNullOrWhiteSpace(technology)); // Check whether every technology name contains usable text

        Console.WriteLine("All technology names are non-empty: " + allTechnologyNamesAreNonEmpty); // Display the string All() result

        // Create student collection

        List<Student> students = new List<Student>() // Create a student collection
        {
            new Student { Id = 101, Name = "Saad", Marks = 85 }, // Add the first student
            new Student { Id = 102, Name = "Aman", Marks = 65 }, // Add the second student
            new Student { Id = 103, Name = "Neha", Marks = 92 }, // Add the third student
            new Student { Id = 104, Name = "Zoya", Marks = 75 } // Add the fourth student
        };

        // Any with objects

        bool hasTopScoringStudent = students.Any(student => student.Marks >= 90); // Check whether any student has at least ninety marks

        Console.WriteLine("\nAny student with at least 90 marks: " + hasTopScoringStudent); // Display the object Any() result

        bool hasStudentNamedAman = students.Any(student => student.Name == "Aman"); // Check whether a student named Aman exists

        Console.WriteLine("Student named Aman exists: " + hasStudentNamedAman); // Display the name-search result

        // All with objects

        bool allStudentsPassed = students.All(student => student.Marks >= 40); // Check whether every student passed

        Console.WriteLine("All students passed: " + allStudentsPassed); // Display the object All() result

        bool allStudentsScoredAboveEighty = students.All(student => student.Marks > 80); // Check whether every student scored above eighty

        Console.WriteLine("All students scored above 80: " + allStudentsScoredAboveEighty); // Display false because some students scored less

        // Check filtered result using Any

        bool developmentConditionResult = students // Begin with the student collection
            .Where(student => student.Marks >= 80) // Keep students having at least eighty marks
            .Any(); // Check whether the filtered sequence contains an element

        Console.WriteLine("\nAny student after filtering marks >= 80: " + developmentConditionResult); // Display the filtered existence result

        // Short-circuit demonstration for Any

        Console.WriteLine("\nANY() SHORT-CIRCUIT CHECK:"); // Display the Any() short-circuit heading

        bool anyGreaterThanTwenty = numbers.Any(number => // Check numbers until a match is found
        {
            Console.WriteLine("Checking " + number); // Display the number currently being tested

            return number > 20; // Return true when the number is greater than twenty
        });

        Console.WriteLine("Result: " + anyGreaterThanTwenty); // Display true after checking only the required elements

        // Short-circuit demonstration for All

        Console.WriteLine("\nALL() SHORT-CIRCUIT CHECK:"); // Display the All() short-circuit heading

        bool allBelowThirtyFive = numbers.All(number => // Check numbers until a failure is found
        {
            Console.WriteLine("Checking " + number); // Display the number currently being tested

            return number < 35; // Return false when the number reaches forty
        });

        Console.WriteLine("Result: " + allBelowThirtyFive); // Display false after the first failing element

        Console.WriteLine("\nAll LINQ method-syntax quantifier examples completed successfully."); // Display the completion message
    }
}