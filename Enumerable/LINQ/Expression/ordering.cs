/*
LINQ Ordering Operators Using Method Syntax - Concept Summary

LINQ ordering operators arrange sequence elements in ascending or
descending order.

Main ordering methods:

1. OrderBy()
   Arranges elements in ascending order.

   Syntax:

   collection.OrderBy(item => item.Property);

2. OrderByDescending()
   Arranges elements in descending order.

   Syntax:

   collection.OrderByDescending(item => item.Property);

3. ThenBy()
   Applies secondary ascending ordering when primary values are equal.

   Syntax:

   collection
       .OrderBy(item => item.FirstProperty)
       .ThenBy(item => item.SecondProperty);

4. ThenByDescending()
   Applies secondary descending ordering when primary values are equal.

   Syntax:

   collection
       .OrderBy(item => item.FirstProperty)
       .ThenByDescending(item => item.SecondProperty);

5. Reverse()
   Reverses the current sequence order.

Important points:

1. OrderBy() uses ascending order by default.
2. OrderByDescending() uses descending order.
3. ThenBy() and ThenByDescending() must follow an ordering method.
4. Multiple ThenBy() methods can be chained.
5. Ordering does not modify the original collection.
6. Ordering methods normally use deferred execution.
7. ToList() or ToArray() immediately stores the ordered result.
8. Calling another OrderBy() replaces the previous primary ordering.
9. ThenBy() preserves the previous ordering and adds another level.
10. Sorting normally requires O(n log n) time.

Required namespace:

using System.Linq;
*/

using System; // Import the Console class
using System.Collections.Generic; // Import List<T>
using System.Linq; // Import LINQ ordering methods

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public string Course { get; set; } = ""; // Store the course name

    public int Marks { get; set; } // Store the student's marks
}

class OrderingProgram // Define the main program class
{
    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method to display numbers
    {
        foreach (int number in numbers) // Visit every number
        {
            Console.Write(number + " "); // Display the current number
        }

        Console.WriteLine(); // Move to the next line
    }

    static void DisplayStudents(IEnumerable<Student> students) // Define a method to display students
    {
        foreach (Student student in students) // Visit every student
        {
            Console.WriteLine($"{student.Id} | {student.Name} | {student.Course} | {student.Marks}"); // Display student details
        }
    }

    static void Main() // Define the program entry point
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create an unordered number collection
        {
            40, // Add 40
            10, // Add 10
            50, // Add 50
            20, // Add 20
            30 // Add 30
        };

        Console.WriteLine("Original numbers:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display the original numbers

        // Order numbers in ascending order

        IEnumerable<int> ascendingNumbers = numbers // Begin with the number collection
            .OrderBy(number => number); // Arrange numbers from smallest to largest

        Console.WriteLine("\nAscending order using OrderBy():"); // Display the ascending-order heading

        DisplayNumbers(ascendingNumbers); // Display the ascending numbers

        // Order numbers in descending order

        IEnumerable<int> descendingNumbers = numbers // Begin with the number collection
            .OrderByDescending(number => number); // Arrange numbers from largest to smallest

        Console.WriteLine("\nDescending order using OrderByDescending():"); // Display the descending-order heading

        DisplayNumbers(descendingNumbers); // Display the descending numbers

        // Confirm original collection remains unchanged

        Console.WriteLine("\nOriginal numbers after ordering:"); // Display the unchanged-collection heading

        DisplayNumbers(numbers); // Display the original order again

        // Order numbers using a calculated value

        List<int> mixedNumbers = new List<int>() // Create numbers containing negative values
        {
            -20, // Add negative twenty
            5, // Add five
            -10, // Add negative ten
            15, // Add fifteen
            2 // Add two
        };

        IEnumerable<int> orderedByAbsoluteValue = mixedNumbers // Begin with the mixed-number collection
            .OrderBy(number => Math.Abs(number)); // Order numbers according to absolute value

        Console.WriteLine("\nNumbers ordered by absolute value:"); // Display the calculated-order heading

        DisplayNumbers(orderedByAbsoluteValue); // Display the ordered values

        // Reverse a sequence

        IEnumerable<int> reversedNumbers = numbers // Begin with the original number collection
            .Reverse(); // Reverse the existing sequence order

        Console.WriteLine("\nOriginal sequence reversed using Reverse():"); // Display the reverse heading

        DisplayNumbers(reversedNumbers); // Display the reversed sequence

        // Reverse an ordered sequence

        IEnumerable<int> reversedAscendingNumbers = numbers // Begin with the number collection
            .OrderBy(number => number) // First arrange numbers in ascending order
            .Reverse(); // Reverse the ascending result

        Console.WriteLine("\nAscending result reversed:"); // Display the ordered-reverse heading

        DisplayNumbers(reversedAscendingNumbers); // Display the reversed ordered sequence

        // Create string collection

        List<string> technologies = new List<string>() // Create an unordered string collection
        {
            "Python", // Add Python
            "C#", // Add C#
            "JavaScript", // Add JavaScript
            "SQL", // Add SQL
            "Java" // Add Java
        };

        // Order strings alphabetically

        IEnumerable<string> alphabeticalTechnologies = technologies // Begin with the technology collection
            .OrderBy(technology => technology); // Arrange technology names alphabetically

        Console.WriteLine("\nTechnologies in alphabetical order:"); // Display the alphabetical-order heading

        foreach (string technology in alphabeticalTechnologies) // Visit every ordered technology
        {
            Console.WriteLine(technology); // Display the technology name
        }

        // Order strings by length

        IEnumerable<string> technologiesByLength = technologies // Begin with the technology collection
            .OrderBy(technology => technology.Length) // First order names by length
            .ThenBy(technology => technology); // Order equal-length names alphabetically

        Console.WriteLine("\nTechnologies ordered by length and then name:"); // Display the string-length heading

        foreach (string technology in technologiesByLength) // Visit every ordered technology
        {
            Console.WriteLine($"{technology} -> Length: {technology.Length}"); // Display the technology and its length
        }

        // Create student collection

        List<Student> students = new List<Student>() // Create a collection of students
        {
            new Student { Id = 101, Name = "Saad", Course = "Development", Marks = 85 }, // Add the first student
            new Student { Id = 102, Name = "Aman", Course = "Testing", Marks = 70 }, // Add the second student
            new Student { Id = 103, Name = "Neha", Course = "Development", Marks = 92 }, // Add the third student
            new Student { Id = 104, Name = "Zoya", Course = "Testing", Marks = 70 }, // Add the fourth student
            new Student { Id = 105, Name = "Arjun", Course = "Development", Marks = 85 } // Add the fifth student
        };

        Console.WriteLine("\nOriginal students:"); // Display the original-student heading

        DisplayStudents(students); // Display the original student collection

        // Order students by name

        IEnumerable<Student> studentsByName = students // Begin with the student collection
            .OrderBy(student => student.Name); // Arrange students alphabetically by name

        Console.WriteLine("\nStudents ordered by name:"); // Display the name-order heading

        DisplayStudents(studentsByName); // Display students ordered by name

        // Order students by marks descending

        IEnumerable<Student> studentsByMarks = students // Begin with the student collection
            .OrderByDescending(student => student.Marks); // Arrange students from highest to lowest marks

        Console.WriteLine("\nStudents ordered by marks descending:"); // Display the marks-order heading

        DisplayStudents(studentsByMarks); // Display students ordered by marks

        // Use ThenBy

        IEnumerable<Student> studentsByMarksThenName = students // Begin with the student collection
            .OrderByDescending(student => student.Marks) // First order students by descending marks
            .ThenBy(student => student.Name); // Order equal-mark students alphabetically

        Console.WriteLine("\nStudents ordered by marks descending and name ascending:"); // Display the secondary-order heading

        DisplayStudents(studentsByMarksThenName); // Display the multi-level ordered result

        // Use ThenByDescending

        IEnumerable<Student> studentsByCourseThenMarks = students // Begin with the student collection
            .OrderBy(student => student.Course) // First order students by course
            .ThenByDescending(student => student.Marks) // Order students in each course by descending marks
            .ThenBy(student => student.Name); // Order equal-mark students alphabetically

        Console.WriteLine("\nStudents ordered by course, marks and name:"); // Display the multiple-order heading

        DisplayStudents(studentsByCourseThenMarks); // Display the multi-level result

        // Filter before ordering

        IEnumerable<Student> highScoringStudents = students // Begin with the student collection
            .Where(student => student.Marks >= 80) // Keep students having at least eighty marks
            .OrderByDescending(student => student.Marks) // Arrange matching students by descending marks
            .ThenBy(student => student.Name); // Arrange equal-mark students alphabetically

        Console.WriteLine("\nStudents having at least 80 marks:"); // Display the filter-and-order heading

        DisplayStudents(highScoringStudents); // Display the filtered ordered students

        // Project after ordering

        IEnumerable<string> orderedStudentNames = students // Begin with the student collection
            .OrderByDescending(student => student.Marks) // Arrange students by descending marks
            .ThenBy(student => student.Name) // Arrange equal-mark students alphabetically
            .Select(student => $"{student.Name} -> {student.Marks}"); // Convert students into formatted strings

        Console.WriteLine("\nOrdered student names and marks:"); // Display the order-and-projection heading

        foreach (string studentInformation in orderedStudentNames) // Visit every projected result
        {
            Console.WriteLine(studentInformation); // Display the student information
        }

        // Materialize ordered result

        List<Student> orderedStudentList = students // Begin with the student collection
            .OrderBy(student => student.Name) // Arrange students alphabetically
            .ToList(); // Immediately store the ordered result in a list

        Console.WriteLine("\nOrdered result converted to List<Student>:"); // Display the materialization heading

        DisplayStudents(orderedStudentList); // Display the stored ordered list

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a collection for deferred execution
        {
            30, // Add 30
            10, // Add 10
            20 // Add 20
        };

        IEnumerable<int> deferredOrderingQuery = deferredNumbers // Begin with the number collection
            .OrderBy(number => number); // Define the ordering query without executing it

        deferredNumbers.Add(5); // Add another number after defining the query

        Console.WriteLine("\nDeferred ordering result after adding 5:"); // Display the deferred-execution heading

        DisplayNumbers(deferredOrderingQuery); // Execute the query and include five

        // Demonstrate materialized snapshot

        List<int> orderedSnapshot = deferredNumbers // Begin with the current source collection
            .OrderBy(number => number) // Arrange its values
            .ToList(); // Create an immediate snapshot

        deferredNumbers.Add(1); // Add another value after creating the snapshot

        Console.WriteLine("\nMaterialized ordered snapshot:"); // Display the snapshot heading

        DisplayNumbers(orderedSnapshot); // Display the snapshot without one

        Console.WriteLine("\nDeferred query after adding 1:"); // Display the updated-query heading

        DisplayNumbers(deferredOrderingQuery); // Display the deferred query including one

        Console.WriteLine("\nAll LINQ method-syntax ordering examples completed successfully."); // Display the completion message
    }
}