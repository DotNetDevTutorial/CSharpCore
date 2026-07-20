/*
LINQ Partitioning Operators Using Method Syntax - Concept Summary

Partitioning operators divide a sequence and return only a particular
portion of its elements.

Main partitioning methods:

1. Take(count)
   Returns the first specified number of elements.

   Syntax:

   collection.Take(count);

2. Skip(count)
   Ignores the first specified number of elements and returns the rest.

   Syntax:

   collection.Skip(count);

3. TakeWhile(condition)
   Returns elements from the beginning while the condition remains true.

   Syntax:

   collection.TakeWhile(item => condition);

4. SkipWhile(condition)
   Ignores elements from the beginning while the condition remains true,
   then returns all remaining elements.

   Syntax:

   collection.SkipWhile(item => condition);

5. TakeLast(count)
   Returns the specified number of elements from the end.

6. SkipLast(count)
   Returns all elements except the specified number from the end.

Important difference between Where() and TakeWhile():

Where() checks every element.

TakeWhile() stops permanently when the first false result is found.

Example source:

10, 20, 50, 30, 40

TakeWhile(number => number < 40):

10, 20

Where(number => number < 40):

10, 20, 30

Pagination syntax:

collection
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize);

Important points:

1. Take() and Skip() use element count.
2. TakeWhile() and SkipWhile() work from the beginning.
3. TakeWhile() stops at the first false condition.
4. SkipWhile() starts returning values after the first false condition.
5. Negative or zero Take() count returns an empty sequence.
6. Negative or zero Skip() count skips nothing.
7. Asking Take() for more elements than available returns all elements.
8. Asking Skip() for more elements than available returns an empty sequence.
9. Partitioning operators do not modify the original collection.
10. These operators normally use deferred execution.
11. ToList() and ToArray() materialize the result immediately.
12. Complete traversal normally requires O(n) time.

Required namespace:

using System.Linq;
*/

using System; // Import Console
using System.Collections.Generic; // Import List<T>
using System.Linq; // Import LINQ partitioning methods

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public int Marks { get; set; } // Store the student marks
}

class PartitioningProgram // Define the main program class
{
    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method to display numbers
    {
        bool numberFound = false; // Track whether any number exists

        foreach (int number in numbers) // Visit every number
        {
            Console.Write(number + " "); // Display the current number

            numberFound = true; // Record that a number was found
        }

        if (!numberFound) // Check whether the sequence was empty
        {
            Console.Write("No values"); // Display the empty-result message
        }

        Console.WriteLine(); // Move to the next line
    }

    static void DisplayStudents(IEnumerable<Student> students) // Define a method to display students
    {
        bool studentFound = false; // Track whether any student exists

        foreach (Student student in students) // Visit every student
        {
            Console.WriteLine($"{student.Id} | {student.Name} | Marks: {student.Marks}"); // Display the student details

            studentFound = true; // Record that a student was found
        }

        if (!studentFound) // Check whether the sequence was empty
        {
            Console.WriteLine("No students"); // Display the empty-result message
        }
    }

    static void Main() // Define the program entry point
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create the number collection
        {
            10, // Add 10
            20, // Add 20
            30, // Add 30
            40, // Add 40
            50, // Add 50
            60, // Add 60
            70, // Add 70
            80, // Add 80
            90, // Add 90
            100 // Add 100
        };

        Console.WriteLine("Original numbers:"); // Display the original-sequence heading

        DisplayNumbers(numbers); // Display all numbers

        // Take first elements

        IEnumerable<int> firstThreeNumbers = numbers.Take(3); // Return the first three numbers

        Console.WriteLine("\nFirst 3 numbers using Take(3):"); // Display the Take heading

        DisplayNumbers(firstThreeNumbers); // Display the first three numbers

        // Skip first elements

        IEnumerable<int> numbersAfterThree = numbers.Skip(3); // Ignore the first three numbers

        Console.WriteLine("\nNumbers after Skip(3):"); // Display the Skip heading

        DisplayNumbers(numbersAfterThree); // Display the remaining numbers

        // Combine Skip and Take

        IEnumerable<int> middleNumbers = numbers // Begin with the number collection
            .Skip(3) // Ignore the first three numbers
            .Take(4); // Return the next four numbers

        Console.WriteLine("\nFour numbers after skipping the first 3:"); // Display the combined-partition heading

        DisplayNumbers(middleNumbers); // Display the selected middle portion

        // Take more elements than available

        IEnumerable<int> excessiveTakeResult = numbers.Take(50); // Request more values than the collection contains

        Console.WriteLine("\nTake(50) when only 10 values exist:"); // Display the excessive-Take heading

        DisplayNumbers(excessiveTakeResult); // Display all available numbers

        // Skip more elements than available

        IEnumerable<int> excessiveSkipResult = numbers.Skip(50); // Skip more values than the collection contains

        Console.WriteLine("\nSkip(50) when only 10 values exist:"); // Display the excessive-Skip heading

        DisplayNumbers(excessiveSkipResult); // Display the empty result

        // Take zero elements

        IEnumerable<int> zeroTakeResult = numbers.Take(0); // Request zero values

        Console.WriteLine("\nTake(0):"); // Display the zero-Take heading

        DisplayNumbers(zeroTakeResult); // Display the empty result

        // Skip zero elements

        IEnumerable<int> zeroSkipResult = numbers.Skip(0); // Skip no values

        Console.WriteLine("\nSkip(0):"); // Display the zero-Skip heading

        DisplayNumbers(zeroSkipResult); // Display the complete original sequence

        // TakeWhile with value condition

        IEnumerable<int> numbersBelowFifty = numbers.TakeWhile(number => number < 50); // Take values until one is not below fifty

        Console.WriteLine("\nTakeWhile(number < 50):"); // Display the TakeWhile heading

        DisplayNumbers(numbersBelowFifty); // Display 10 through 40

        // SkipWhile with value condition

        IEnumerable<int> numbersFromFifty = numbers.SkipWhile(number => number < 50); // Skip values while they are below fifty

        Console.WriteLine("\nSkipWhile(number < 50):"); // Display the SkipWhile heading

        DisplayNumbers(numbersFromFifty); // Display values starting from fifty

        // Demonstrate TakeWhile stopping at first false

        List<int> unorderedNumbers = new List<int>() // Create a sequence showing TakeWhile behaviour
        {
            10, // Add a matching value
            20, // Add another matching value
            50, // Add the first non-matching value
            30, // Add a later matching value
            40 // Add another later matching value
        };

        IEnumerable<int> takeWhileResult = unorderedNumbers.TakeWhile(number => number < 40); // Stop when fifty fails the condition

        IEnumerable<int> whereResult = unorderedNumbers.Where(number => number < 40); // Check every number independently

        Console.WriteLine("\nSource used to compare TakeWhile() and Where():"); // Display the comparison-source heading

        DisplayNumbers(unorderedNumbers); // Display the unordered values

        Console.WriteLine("\nTakeWhile(number < 40):"); // Display the TakeWhile comparison heading

        DisplayNumbers(takeWhileResult); // Display only 10 and 20

        Console.WriteLine("\nWhere(number < 40):"); // Display the Where comparison heading

        DisplayNumbers(whereResult); // Display 10, 20 and 30

        // TakeWhile using index

        IEnumerable<int> firstFourByIndex = numbers.TakeWhile((number, index) => index < 4); // Take elements while their indexes are below four

        Console.WriteLine("\nTakeWhile(index < 4):"); // Display the indexed-TakeWhile heading

        DisplayNumbers(firstFourByIndex); // Display the first four values

        // SkipWhile using index

        IEnumerable<int> afterFirstFourByIndex = numbers.SkipWhile((number, index) => index < 4); // Skip values while their indexes are below four

        Console.WriteLine("\nSkipWhile(index < 4):"); // Display the indexed-SkipWhile heading

        DisplayNumbers(afterFirstFourByIndex); // Display values beginning at index four

        // Take values from the end

        IEnumerable<int> lastThreeNumbers = numbers.TakeLast(3); // Return the final three numbers

        Console.WriteLine("\nLast 3 numbers using TakeLast(3):"); // Display the TakeLast heading

        DisplayNumbers(lastThreeNumbers); // Display 80, 90 and 100

        // Skip values from the end

        IEnumerable<int> numbersExceptLastThree = numbers.SkipLast(3); // Return all values except the final three

        Console.WriteLine("\nNumbers except the last 3 using SkipLast(3):"); // Display the SkipLast heading

        DisplayNumbers(numbersExceptLastThree); // Display values from 10 through 70

        // Filter before partitioning

        IEnumerable<int> firstThreeEvenNumbers = numbers // Begin with the number collection
            .Where(number => number % 2 == 0) // Keep even numbers
            .Take(3); // Return the first three matching values

        Console.WriteLine("\nFirst 3 even numbers:"); // Display the filtering-before-partitioning heading

        DisplayNumbers(firstThreeEvenNumbers); // Display 10, 20 and 30

        // Order before partitioning

        IEnumerable<int> largestThreeNumbers = numbers // Begin with the number collection
            .OrderByDescending(number => number) // Arrange numbers from largest to smallest
            .Take(3); // Return the first three ordered values

        Console.WriteLine("\nLargest 3 numbers:"); // Display the top-values heading

        DisplayNumbers(largestThreeNumbers); // Display 100, 90 and 80

        // Pagination

        int pageNumber = 2; // Store the requested page number

        int pageSize = 3; // Store the number of values on each page

        IEnumerable<int> pageResult = numbers // Begin with the number collection
            .Skip((pageNumber - 1) * pageSize) // Skip values belonging to previous pages
            .Take(pageSize); // Return values for the requested page

        Console.WriteLine($"\nPage {pageNumber} with page size {pageSize}:"); // Display the pagination heading

        DisplayNumbers(pageResult); // Display values on the second page

        // Display all pages

        int totalPages = (int)Math.Ceiling((double)numbers.Count / pageSize); // Calculate the total number of pages

        Console.WriteLine("\nAll pages:"); // Display the all-pages heading

        for (int currentPage = 1; currentPage <= totalPages; currentPage++) // Visit every available page number
        {
            IEnumerable<int> currentPageResult = numbers // Begin with the number collection
                .Skip((currentPage - 1) * pageSize) // Skip values from previous pages
                .Take(pageSize); // Return the current page values

            Console.Write($"Page {currentPage}: "); // Display the current page number

            DisplayNumbers(currentPageResult); // Display the current page values
        }

        // Create student collection

        List<Student> students = new List<Student>() // Create a student collection
        {
            new Student { Id = 101, Name = "Saad", Marks = 85 }, // Add the first student
            new Student { Id = 102, Name = "Aman", Marks = 72 }, // Add the second student
            new Student { Id = 103, Name = "Neha", Marks = 95 }, // Add the third student
            new Student { Id = 104, Name = "Zoya", Marks = 88 }, // Add the fourth student
            new Student { Id = 105, Name = "Arjun", Marks = 65 } // Add the fifth student
        };

        Console.WriteLine("\nOriginal students:"); // Display the original-student heading

        DisplayStudents(students); // Display all students

        // Take top students

        IEnumerable<Student> topThreeStudents = students // Begin with the student collection
            .OrderByDescending(student => student.Marks) // Arrange students from highest to lowest marks
            .Take(3); // Return the first three students

        Console.WriteLine("\nTop 3 students:"); // Display the top-student heading

        DisplayStudents(topThreeStudents); // Display the highest-scoring students

        // Skip top students

        IEnumerable<Student> remainingStudents = students // Begin with the student collection
            .OrderByDescending(student => student.Marks) // Arrange students from highest to lowest marks
            .Skip(2); // Ignore the first two students

        Console.WriteLine("\nStudents after skipping the top 2:"); // Display the student-Skip heading

        DisplayStudents(remainingStudents); // Display the remaining students

        // TakeWhile after ordering

        IEnumerable<Student> studentsWithAtLeastEighty = students // Begin with the student collection
            .OrderByDescending(student => student.Marks) // Arrange marks from highest to lowest
            .TakeWhile(student => student.Marks >= 80); // Take students until marks fall below eighty

        Console.WriteLine("\nStudents having at least 80 marks:"); // Display the student-TakeWhile heading

        DisplayStudents(studentsWithAtLeastEighty); // Display matching students from the ordered sequence

        // Materialize partitioned result

        List<int> partitionSnapshot = numbers // Begin with the number collection
            .Skip(2) // Ignore the first two values
            .Take(4) // Return the next four values
            .ToList(); // Execute the query and create a list snapshot

        numbers.Add(110); // Add another value after creating the snapshot

        Console.WriteLine("\nMaterialized partition snapshot:"); // Display the snapshot heading

        DisplayNumbers(partitionSnapshot); // Display the unchanged stored snapshot

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a source for deferred execution
        {
            10, // Add 10
            20, // Add 20
            30 // Add 30
        };

        IEnumerable<int> deferredTakeQuery = deferredNumbers.Take(4); // Define a deferred Take query

        deferredNumbers.Add(40); // Add another value before traversing the query

        deferredNumbers.Add(50); // Add a fifth value before traversal

        Console.WriteLine("\nDeferred Take(4) result after adding 40 and 50:"); // Display the deferred-execution heading

        DisplayNumbers(deferredTakeQuery); // Display the first four current values

        Console.WriteLine("\nAll LINQ method-syntax partitioning examples completed successfully."); // Display the completion message
    }
}