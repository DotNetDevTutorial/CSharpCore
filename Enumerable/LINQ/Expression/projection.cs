/*
LINQ Projection Operators Using Method Syntax - Concept Summary

Projection means transforming each element of a collection into a
different form.

The main LINQ projection methods are:

1. Select()
2. SelectMany()

--------------------------------------------------
1. Select()
--------------------------------------------------

Select() transforms every source element into one result element.

Syntax:

IEnumerable<TResult> result =
    collection.Select(item => expression);

Example:

IEnumerable<int> squares =
    numbers.Select(number => number * number);

Source:

1 2 3 4

Result:

1 4 9 16

Select() can be used to:

1. Select one property.
2. Perform calculations.
3. Create formatted strings.
4. Create anonymous objects.
5. Create named objects.
6. Change the result data type.

Select() also provides an index-aware overload:

collection.Select((item, index) => expression);

--------------------------------------------------
2. SelectMany()
--------------------------------------------------

SelectMany() transforms nested collections into one flat sequence.

Syntax:

IEnumerable<TResult> result =
    collection.SelectMany(item => item.NestedCollection);

Example:

students.SelectMany(student => student.Subjects);

Source structure:

Student 1 -> SQL, Python
Student 2 -> Java, C#

Flattened result:

SQL
Python
Java
C#

Difference:

Select():
Produces one result for every source element.

SelectMany():
Produces multiple results from every source element and combines them
into one flat sequence.

Important points:

1. Select() does not modify the original collection.
2. Select() can change the output data type.
3. Anonymous types are useful for temporary projected results.
4. SelectMany() is useful for nested collections.
5. Projection methods normally use deferred execution.
6. ToList() and ToArray() immediately materialize the result.
7. Select() usually requires O(n) time for complete traversal.

Required namespace:

using System.Linq;
*/

using System; // Import Console
using System.Collections.Generic; // Import List<T>
using System.Linq; // Import Select() and SelectMany()

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public int Marks { get; set; } // Store the student marks

    public List<string> Subjects { get; set; } = new List<string>(); // Store the student's subjects
}

class StudentSummary // Define a named projection-result class
{
    public string Name { get; set; } = ""; // Store the projected student name

    public string Result { get; set; } = ""; // Store the projected result status
}

class ProjectionProgram // Define the main program class
{
    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method for displaying numbers
    {
        foreach (int number in numbers) // Visit every number
        {
            Console.Write(number + " "); // Display the current number
        }

        Console.WriteLine(); // Move to the next line
    }

    static void DisplayStrings(IEnumerable<string> values) // Define a method for displaying strings
    {
        foreach (string value in values) // Visit every string
        {
            Console.WriteLine(value); // Display the current string
        }
    }

    static void Main() // Define the program entry point
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a number collection
        {
            1, // Add 1
            2, // Add 2
            3, // Add 3
            4, // Add 4
            5 // Add 5
        };

        Console.WriteLine("Original numbers:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display the original numbers

        // Select original values

        IEnumerable<int> selectedNumbers = numbers.Select(number => number); // Select every number without changing it

        Console.WriteLine("\nNumbers selected without transformation:"); // Display the basic-projection heading

        DisplayNumbers(selectedNumbers); // Display the selected values

        // Project square values

        IEnumerable<int> squareNumbers = numbers.Select(number => number * number); // Convert every number into its square

        Console.WriteLine("\nSquares using Select():"); // Display the square-projection heading

        DisplayNumbers(squareNumbers); // Display the square values

        // Project cube values

        IEnumerable<int> cubeNumbers = numbers.Select(number => number * number * number); // Convert every number into its cube

        Console.WriteLine("\nCubes using Select():"); // Display the cube-projection heading

        DisplayNumbers(cubeNumbers); // Display the cube values

        // Change result type

        IEnumerable<string> numberDescriptions = numbers // Begin with the number collection
            .Select(number => $"Number: {number}, Square: {number * number}"); // Convert every number into a string

        Console.WriteLine("\nNumbers projected into strings:"); // Display the type-conversion heading

        DisplayStrings(numberDescriptions); // Display the projected strings

        // Use index-aware Select

        IEnumerable<string> indexedNumbers = numbers // Begin with the number collection
            .Select((number, index) => $"Index {index} -> Value {number}"); // Project each number together with its index

        Console.WriteLine("\nIndex-aware Select():"); // Display the indexed-projection heading

        DisplayStrings(indexedNumbers); // Display the index and value information

        // Create anonymous objects

        var numberDetails = numbers.Select(number => new // Project every number into an anonymous object
        {
            Number = number, // Store the original number
            Square = number * number, // Store its square
            Type = number % 2 == 0 ? "Even" : "Odd" // Store whether it is even or odd
        });

        Console.WriteLine("\nAnonymous-object projection:"); // Display the anonymous-projection heading

        foreach (var item in numberDetails) // Visit every projected object
        {
            Console.WriteLine($"{item.Number} | Square: {item.Square} | {item.Type}"); // Display the projected properties
        }

        // Filter before projection

        IEnumerable<int> evenSquares = numbers // Begin with the number collection
            .Where(number => number % 2 == 0) // Keep only even numbers
            .Select(number => number * number); // Convert matching numbers into squares

        Console.WriteLine("\nSquares of even numbers:"); // Display the filter-and-projection heading

        DisplayNumbers(evenSquares); // Display the projected square values

        // Create student collection

        List<Student> students = new List<Student>() // Create a student collection
        {
            new Student // Create the first student
            {
                Id = 101, // Set the first student identifier
                Name = "Saad", // Set the first student name
                Marks = 85, // Set the first student marks
                Subjects = new List<string>() { "SQL", "Python" } // Add the first student's subjects
            },
            new Student // Create the second student
            {
                Id = 102, // Set the second student identifier
                Name = "Aman", // Set the second student name
                Marks = 65, // Set the second student marks
                Subjects = new List<string>() { "Java", "C#" } // Add the second student's subjects
            },
            new Student // Create the third student
            {
                Id = 103, // Set the third student identifier
                Name = "Neha", // Set the third student name
                Marks = 92, // Set the third student marks
                Subjects = new List<string>() { "Python", "PySpark" } // Add the third student's subjects
            }
        };

        // Select one object property

        IEnumerable<string> studentNames = students.Select(student => student.Name); // Select only student names

        Console.WriteLine("\nStudent names:"); // Display the property-projection heading

        DisplayStrings(studentNames); // Display the projected names

        // Select multiple properties

        var studentDetails = students.Select(student => new // Project students into anonymous objects
        {
            student.Id, // Store the student identifier
            student.Name, // Store the student name
            student.Marks // Store the student marks
        });

        Console.WriteLine("\nSelected student properties:"); // Display the multiple-property heading

        foreach (var student in studentDetails) // Visit every projected student
        {
            Console.WriteLine($"{student.Id} | {student.Name} | {student.Marks}"); // Display the selected properties
        }

        // Project calculated property

        var studentResults = students.Select(student => new // Create calculated student results
        {
            StudentName = student.Name, // Store the student name
            Status = student.Marks >= 40 ? "Pass" : "Fail", // Calculate the result status
            Grade = student.Marks >= 80 ? "A" : student.Marks >= 60 ? "B" : "C" // Calculate the grade
        });

        Console.WriteLine("\nCalculated student projection:"); // Display the calculated-projection heading

        foreach (var student in studentResults) // Visit every projected result
        {
            Console.WriteLine($"{student.StudentName} | {student.Status} | Grade {student.Grade}"); // Display the calculated values
        }

        // Project into named class

        IEnumerable<StudentSummary> summaries = students.Select(student => new StudentSummary // Create a named result object
        {
            Name = student.Name, // Store the student name
            Result = student.Marks >= 40 ? "Pass" : "Fail" // Calculate and store the result
        });

        Console.WriteLine("\nProjection into StudentSummary objects:"); // Display the named-object heading

        foreach (StudentSummary summary in summaries) // Visit every named result object
        {
            Console.WriteLine($"{summary.Name} -> {summary.Result}"); // Display the student summary
        }

        // Select nested collections

        IEnumerable<List<string>> nestedSubjects = students.Select(student => student.Subjects); // Select one subject collection for every student

        Console.WriteLine("\nSelect() produces nested subject collections:"); // Display the nested-Select heading

        foreach (List<string> subjectList in nestedSubjects) // Visit every nested subject collection
        {
            Console.WriteLine(string.Join(", ", subjectList)); // Display one student's subject collection
        }

        // Flatten nested collections

        IEnumerable<string> allSubjects = students.SelectMany(student => student.Subjects); // Combine all nested subject collections into one sequence

        Console.WriteLine("\nAll subjects using SelectMany():"); // Display the SelectMany heading

        DisplayStrings(allSubjects); // Display the flattened subjects

        // Flatten and remove duplicates

        IEnumerable<string> uniqueSubjects = students // Begin with the student collection
            .SelectMany(student => student.Subjects) // Flatten all subject collections
            .Distinct() // Remove duplicate subject names
            .OrderBy(subject => subject); // Arrange subject names alphabetically

        Console.WriteLine("\nUnique subjects:"); // Display the unique-subject heading

        DisplayStrings(uniqueSubjects); // Display unique subject names

        // SelectMany with result selector

        var studentSubjectPairs = students.SelectMany( // Flatten subjects while preserving student information
            student => student.Subjects, // Select each student's subject collection
            (student, subject) => new // Create one result for every student-subject pair
            {
                StudentName = student.Name, // Store the student name
                SubjectName = subject // Store the current subject
            });

        Console.WriteLine("\nStudent and subject pairs:"); // Display the result-selector heading

        foreach (var item in studentSubjectPairs) // Visit every student-subject pair
        {
            Console.WriteLine($"{item.StudentName} -> {item.SubjectName}"); // Display the student and subject
        }

        // Materialize projection

        List<string> nameSnapshot = students // Begin with the student collection
            .Select(student => student.Name) // Select student names
            .ToList(); // Execute the query and create a list snapshot

        students.Add(new Student // Add another student after creating the snapshot
        {
            Id = 104, // Set the new student identifier
            Name = "Zoya", // Set the new student name
            Marks = 78, // Set the new student marks
            Subjects = new List<string>() { "MongoDB" } // Set the new student subject
        });

        Console.WriteLine("\nMaterialized name snapshot:"); // Display the snapshot heading

        DisplayStrings(nameSnapshot); // Display names without the newly added student

        // Demonstrate deferred execution

        IEnumerable<string> deferredNames = students.Select(student => student.Name); // Define a deferred projection query

        students.Add(new Student // Add another student before traversing the query
        {
            Id = 105, // Set the student identifier
            Name = "Arjun", // Set the student name
            Marks = 72, // Set the student marks
            Subjects = new List<string>() { "Azure" } // Set the student subject
        });

        Console.WriteLine("\nDeferred Select() result after adding Arjun:"); // Display the deferred-execution heading

        DisplayStrings(deferredNames); // Execute the query and include Arjun

        Console.WriteLine("\nAll LINQ method-syntax projection examples completed successfully."); // Display the completion message
    }
}