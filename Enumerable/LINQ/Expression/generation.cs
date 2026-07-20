/*
LINQ Generation Operators Using Method Syntax - Complete Concept Summary

LINQ generation operators create new sequences without requiring an
existing collection.

The main LINQ generation operators are:

1. Enumerable.Empty<T>()
2. Enumerable.Range()
3. Enumerable.Repeat<T>()

Unlike most LINQ operators, these methods are static methods of the
Enumerable class.

They are normally called using:

Enumerable.Empty<int>();
Enumerable.Range(1, 10);
Enumerable.Repeat("Hello", 5);

--------------------------------------------------
1. Enumerable.Empty<T>()
--------------------------------------------------

Empty<T>() creates an empty sequence of the specified type.

Syntax:

IEnumerable<T> result = Enumerable.Empty<T>();

Examples:

IEnumerable<int> emptyNumbers =
    Enumerable.Empty<int>();

IEnumerable<string> emptyNames =
    Enumerable.Empty<string>();

Important:

1. It contains zero elements.
2. It does not return null.
3. It is useful as a safe replacement for a null collection.
4. It can be combined with other LINQ operations.
5. Count() returns zero.
6. Any() returns false.
7. FirstOrDefault() returns the default value.
8. It does not create collection elements.
9. Traversing it immediately finishes.
10. It is safer than returning null from methods.

Null-safe example:

IEnumerable<int> safeNumbers =
    nullableNumbers ?? Enumerable.Empty<int>();

Empty<T>() can also be used with Concat():

IEnumerable<int> result =
    numbers.Concat(Enumerable.Empty<int>());

--------------------------------------------------
2. Enumerable.Range()
--------------------------------------------------

Range() generates a sequence of consecutive integer values.

Syntax:

IEnumerable<int> result =
    Enumerable.Range(start, count);

Parameters:

start:
The first integer in the generated sequence.

count:
The total number of integers to generate.

Example:

IEnumerable<int> numbers =
    Enumerable.Range(1, 5);

Result:

1 2 3 4 5

Important:

The second argument is the count, not the final value.

Example:

Enumerable.Range(10, 5);

Result:

10 11 12 13 14

It does not generate values through 5.

Range with zero count:

Enumerable.Range(10, 0);

Result:

An empty sequence.

Range can be combined with:

Where()
Select()
OrderBy()
GroupBy()
Sum()
Average()
ToList()
ToArray()

Examples:

IEnumerable<int> evenNumbers = Enumerable
    .Range(1, 20)
    .Where(number => number % 2 == 0);

IEnumerable<int> squares = Enumerable
    .Range(1, 10)
    .Select(number => number * number);

Range exception conditions:

1. count is negative.
2. start + count - 1 exceeds Int32.MaxValue.

Both cases cause ArgumentOutOfRangeException.

--------------------------------------------------
3. Enumerable.Repeat<T>()
--------------------------------------------------

Repeat<T>() generates a sequence containing the same value a specified
number of times.

Syntax:

IEnumerable<T> result =
    Enumerable.Repeat(value, count);

Example:

IEnumerable<string> messages =
    Enumerable.Repeat("Hello", 3);

Result:

Hello
Hello
Hello

Repeat with numbers:

IEnumerable<int> zeroValues =
    Enumerable.Repeat(0, 5);

Result:

0 0 0 0 0

Repeat with zero count:

Enumerable.Repeat("Hello", 0);

Result:

An empty sequence.

Repeat exception condition:

A negative count causes ArgumentOutOfRangeException.

--------------------------------------------------
Repeating Reference-Type Objects
--------------------------------------------------

When Repeat<T>() receives a reference-type object, it repeats the same
object reference.

Example:

Employee employee = new Employee
{
    Name = "Saad"
};

IEnumerable<Employee> employees =
    Enumerable.Repeat(employee, 3);

This does not create three independent Employee objects.

All three sequence positions refer to the same Employee object.

Changing the object through one position is visible through all
positions.

To create separate objects, use Range() with Select():

IEnumerable<Employee> employees = Enumerable
    .Range(1, 3)
    .Select(id => new Employee
    {
        Id = id,
        Name = "Employee " + id
    });

--------------------------------------------------
Deferred Execution
--------------------------------------------------

Range() and Repeat<T>() generate elements when the sequence is
traversed.

Example:

IEnumerable<int> numbers =
    Enumerable.Range(1, 100);

The values are produced during traversal.

Materialization methods such as:

ToList()
ToArray()
ToHashSet()

execute the sequence and store its values.

Empty<T>() contains no values and traversal immediately completes.

--------------------------------------------------
Common Uses
--------------------------------------------------

Empty<T>():

1. Return an empty result instead of null.
2. Initialize an IEnumerable<T> variable.
3. Safely handle nullable collections.
4. Represent a query having no result.

Range():

1. Generate serial numbers.
2. Generate indexes.
3. Generate page numbers.
4. Create multiplication tables.
5. Generate dates using Select().
6. Generate test data.
7. Create objects using Select().
8. Repeat an operation a specified number of times.

Repeat<T>():

1. Create default values.
2. Create placeholders.
3. Repeat messages.
4. Initialize fixed-size sequences.
5. Create padding values.
6. Repeat separators or symbols.

--------------------------------------------------
Time Complexity
--------------------------------------------------

Enumerable.Empty<T>():

Creation: O(1)
Traversal: O(1)

Enumerable.Range():

Creation: O(1)
Complete traversal: O(count)

Enumerable.Repeat<T>():

Creation: O(1)
Complete traversal: O(count)

Materializing with ToList() or ToArray():

Time: O(count)
Additional memory: O(count)

--------------------------------------------------
Important Points
--------------------------------------------------

1. Generation operators do not require an existing source collection.
2. They are called through the Enumerable class.
3. Empty<T>() creates a non-null empty sequence.
4. Range() generates consecutive integers.
5. Range() uses start and count parameters.
6. Repeat<T>() repeats the same supplied value.
7. Repeat<T>() repeats the same reference for reference-type objects.
8. Range() with Select() can create independent objects.
9. Negative counts cause ArgumentOutOfRangeException.
10. Range() and Repeat<T>() normally generate values during traversal.
11. ToList() and ToArray() materialize generated sequences.
12. Generated sequences can be chained with all suitable LINQ methods.

Required namespaces:

using System;
using System.Collections.Generic;
using System.Linq;
*/

#nullable enable // Enable nullable-reference-type analysis

using System; // Import basic classes such as Console and DateTime
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ generation and query methods

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public decimal Salary { get; set; } // Store the employee salary
}

class Product // Define a class representing a product
{
    public int Id { get; set; } // Store the product identifier

    public string Name { get; set; } = ""; // Store the product name

    public decimal Price { get; set; } // Store the product price
}

class MutableBox // Define a mutable class for demonstrating repeated references
{
    public int Value { get; set; } // Store the mutable integer value
}

class GenerationProgram // Define the main program class
{
    // Display integer sequence

    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method that accepts an integer sequence
    {
        bool numberFound = false; // Track whether the sequence contains any number

        foreach (int number in numbers) // Visit every number in the sequence
        {
            Console.Write(number + " "); // Display the current number on the same line

            numberFound = true; // Record that at least one number was found
        }

        if (!numberFound) // Check whether the sequence was empty
        {
            Console.Write("No values"); // Display a message for an empty sequence
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display string sequence

    static void DisplayStrings(IEnumerable<string> values) // Define a method that accepts a string sequence
    {
        bool valueFound = false; // Track whether the sequence contains any string

        foreach (string value in values) // Visit every string in the sequence
        {
            Console.WriteLine(value); // Display the current string

            valueFound = true; // Record that at least one string was found
        }

        if (!valueFound) // Check whether the sequence was empty
        {
            Console.WriteLine("No values"); // Display a message for an empty sequence
        }
    }

    // Display employee sequence

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        bool employeeFound = false; // Track whether the sequence contains any employee

        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | Rs. {employee.Salary:F2}"); // Display the employee details

            employeeFound = true; // Record that at least one employee was found
        }

        if (!employeeFound) // Check whether the sequence was empty
        {
            Console.WriteLine("No employees"); // Display a message for an empty employee sequence
        }
    }

    // Return nullable number collection

    static IEnumerable<int>? GetNullableNumbers(bool returnValues) // Define a method that may return a collection or null
    {
        if (returnValues) // Check whether values should be returned
        {
            return new List<int>() { 10, 20, 30 }; // Return a populated integer collection
        }

        return null; // Return null for demonstration purposes
    }

    // Return safe empty collection

    static IEnumerable<Employee> GetEmployees(bool recordsAvailable) // Define a method that always returns a non-null sequence
    {
        if (recordsAvailable) // Check whether employee records are available
        {
            return new List<Employee>() // Return a populated employee collection
            {
                new Employee { Id = 101, Name = "Saad", Department = "Development", Salary = 65000m }, // Add the first employee
                new Employee { Id = 102, Name = "Priya", Department = "Data Engineering", Salary = 82000m } // Add the second employee
            };
        }

        return Enumerable.Empty<Employee>(); // Return an empty non-null employee sequence
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Empty integer sequence

        IEnumerable<int> emptyNumbers = Enumerable.Empty<int>(); // Create an empty integer sequence

        Console.WriteLine("Empty integer sequence:"); // Display the empty-integer heading

        DisplayNumbers(emptyNumbers); // Traverse and display the empty sequence

        // Empty string sequence

        IEnumerable<string> emptyStrings = Enumerable.Empty<string>(); // Create an empty string sequence

        Console.WriteLine("\nEmpty string sequence:"); // Display the empty-string heading

        DisplayStrings(emptyStrings); // Traverse and display the empty string sequence

        // Empty employee sequence

        IEnumerable<Employee> emptyEmployees = Enumerable.Empty<Employee>(); // Create an empty Employee sequence

        Console.WriteLine("\nEmpty employee sequence:"); // Display the empty-employee heading

        DisplayEmployees(emptyEmployees); // Traverse and display the empty employee sequence

        // Check empty sequence properties

        int emptyNumberCount = emptyNumbers.Count(); // Count the elements in the empty sequence

        bool emptyNumbersContainValues = emptyNumbers.Any(); // Check whether the empty sequence contains any element

        int firstEmptyNumber = emptyNumbers.FirstOrDefault(); // Return the default integer because no element exists

        Console.WriteLine("\nEmpty sequence information:"); // Display the empty-sequence-information heading

        Console.WriteLine("Count: " + emptyNumberCount); // Display the empty sequence count

        Console.WriteLine("Any values: " + emptyNumbersContainValues); // Display whether any element exists

        Console.WriteLine("FirstOrDefault(): " + firstEmptyNumber); // Display the default integer value

        // Safe replacement for nullable collection

        IEnumerable<int>? nullableNumbers = GetNullableNumbers(false); // Receive a null collection from the method

        IEnumerable<int> safeNumbers = nullableNumbers ?? Enumerable.Empty<int>(); // Replace null with an empty integer sequence

        Console.WriteLine("\nNull collection replaced with Enumerable.Empty<int>():"); // Display the null-safe heading

        DisplayNumbers(safeNumbers); // Safely display the non-null empty sequence

        // Safe replacement when collection contains values

        nullableNumbers = GetNullableNumbers(true); // Receive a populated collection from the method

        safeNumbers = nullableNumbers ?? Enumerable.Empty<int>(); // Use the populated collection because it is not null

        Console.WriteLine("\nNon-null collection with the same fallback expression:"); // Display the populated-fallback heading

        DisplayNumbers(safeNumbers); // Display the returned values

        // Return Empty instead of null

        IEnumerable<Employee> unavailableEmployees = GetEmployees(false); // Receive an empty sequence instead of null

        Console.WriteLine("\nMethod returning Enumerable.Empty<Employee>():"); // Display the safe-return heading

        DisplayEmployees(unavailableEmployees); // Traverse the result without performing a null check

        // Concat with empty sequence

        List<int> existingNumbers = new List<int>() // Create a populated integer collection
        {
            10, // Add 10 to the collection
            20, // Add 20 to the collection
            30 // Add 30 to the collection
        };

        IEnumerable<int> concatenatedWithEmpty = existingNumbers.Concat(Enumerable.Empty<int>()); // Combine numbers with an empty sequence

        Console.WriteLine("\nNumbers concatenated with an empty sequence:"); // Display the empty-Concat heading

        DisplayNumbers(concatenatedWithEmpty); // Display the unchanged number sequence

        // Basic Range

        IEnumerable<int> oneToTen = Enumerable.Range(1, 10); // Generate ten consecutive numbers starting at one

        Console.WriteLine("\nNumbers from 1 through 10 using Range():"); // Display the basic-Range heading

        DisplayNumbers(oneToTen); // Display the generated numbers

        // Range starting from ten

        IEnumerable<int> tenToFourteen = Enumerable.Range(10, 5); // Generate five numbers starting at ten

        Console.WriteLine("\nEnumerable.Range(10, 5):"); // Display the start-and-count heading

        DisplayNumbers(tenToFourteen); // Display 10 through 14

        // Range with negative starting value

        IEnumerable<int> negativeRange = Enumerable.Range(-5, 11); // Generate eleven numbers beginning at negative five

        Console.WriteLine("\nRange from -5 through 5:"); // Display the negative-start heading

        DisplayNumbers(negativeRange); // Display the generated negative and positive values

        // Range with zero count

        IEnumerable<int> zeroCountRange = Enumerable.Range(100, 0); // Generate an empty sequence because count is zero

        Console.WriteLine("\nRange with count equal to zero:"); // Display the zero-count heading

        DisplayNumbers(zeroCountRange); // Display the empty result

        // Convert Range to list

        List<int> generatedNumberList = Enumerable // Access the Enumerable class
            .Range(1, 15) // Generate numbers from one through fifteen
            .ToList(); // Materialize the generated sequence as a list

        Console.WriteLine("\nRange converted to List<int>:"); // Display the Range-ToList heading

        DisplayNumbers(generatedNumberList); // Display the generated list

        // Convert Range to array

        int[] generatedNumberArray = Enumerable // Access the Enumerable class
            .Range(50, 6) // Generate six numbers starting at fifty
            .ToArray(); // Materialize the generated sequence as an array

        Console.WriteLine("\nRange converted to an integer array:"); // Display the Range-ToArray heading

        DisplayNumbers(generatedNumberArray); // Display the generated array

        // Generate even numbers

        IEnumerable<int> evenNumbers = Enumerable // Access the Enumerable class
            .Range(1, 30) // Generate numbers from one through thirty
            .Where(number => number % 2 == 0); // Keep numbers divisible by two

        Console.WriteLine("\nEven numbers from 1 through 30:"); // Display the generated-even heading

        DisplayNumbers(evenNumbers); // Display the even numbers

        // Generate odd numbers

        IEnumerable<int> oddNumbers = Enumerable // Access the Enumerable class
            .Range(1, 30) // Generate numbers from one through thirty
            .Where(number => number % 2 != 0); // Keep numbers not divisible by two

        Console.WriteLine("\nOdd numbers from 1 through 30:"); // Display the generated-odd heading

        DisplayNumbers(oddNumbers); // Display the odd numbers

        // Generate multiples of five

        IEnumerable<int> multiplesOfFive = Enumerable // Access the Enumerable class
            .Range(1, 20) // Generate position values from one through twenty
            .Select(number => number * 5); // Convert every position into a multiple of five

        Console.WriteLine("\nFirst 20 multiples of 5:"); // Display the multiples heading

        DisplayNumbers(multiplesOfFive); // Display the generated multiples

        // Generate squares

        IEnumerable<int> squareNumbers = Enumerable // Access the Enumerable class
            .Range(1, 10) // Generate numbers from one through ten
            .Select(number => number * number); // Calculate the square of every generated number

        Console.WriteLine("\nSquares of numbers from 1 through 10:"); // Display the square heading

        DisplayNumbers(squareNumbers); // Display the generated squares

        // Generate cubes

        IEnumerable<int> cubeNumbers = Enumerable // Access the Enumerable class
            .Range(1, 10) // Generate numbers from one through ten
            .Select(number => number * number * number); // Calculate the cube of every generated number

        Console.WriteLine("\nCubes of numbers from 1 through 10:"); // Display the cube heading

        DisplayNumbers(cubeNumbers); // Display the generated cubes

        // Generate number details

        var numberDetails = Enumerable // Access the Enumerable class
            .Range(1, 10) // Generate numbers from one through ten
            .Select(number => new // Create an anonymous result for every number
            {
                Number = number, // Store the original generated number
                Square = number * number, // Store the square of the number
                Cube = number * number * number, // Store the cube of the number
                Type = number % 2 == 0 ? "Even" : "Odd" // Classify the number as even or odd
            });

        Console.WriteLine("\nGenerated number details:"); // Display the number-details heading

        foreach (var item in numberDetails) // Visit every generated number detail
        {
            Console.WriteLine($"{item.Number} | Square: {item.Square} | Cube: {item.Cube} | {item.Type}"); // Display the calculated number information
        }

        // Generate reverse order

        IEnumerable<int> reverseGeneratedNumbers = Enumerable // Access the Enumerable class
            .Range(1, 10) // Generate numbers from one through ten
            .Reverse(); // Reverse the generated sequence

        Console.WriteLine("\nGenerated numbers in reverse order:"); // Display the reverse-Range heading

        DisplayNumbers(reverseGeneratedNumbers); // Display numbers from ten down to one

        // Generate descending values using Select

        IEnumerable<int> descendingValues = Enumerable // Access the Enumerable class
            .Range(0, 10) // Generate indexes from zero through nine
            .Select(index => 100 - index * 10); // Convert each index into a descending multiple of ten

        Console.WriteLine("\nGenerated descending values from 100 to 10:"); // Display the calculated-descending heading

        DisplayNumbers(descendingValues); // Display the generated descending values

        // Generate indexes

        IEnumerable<int> indexValues = Enumerable.Range(0, 10); // Generate zero-based indexes from zero through nine

        Console.WriteLine("\nGenerated zero-based indexes:"); // Display the index heading

        DisplayNumbers(indexValues); // Display the generated indexes

        // Generate serial numbers

        IEnumerable<string> serialNumbers = Enumerable // Access the Enumerable class
            .Range(1, 10) // Generate serial positions from one through ten
            .Select(number => $"EMP-{number:D3}"); // Convert each number into a formatted employee code

        Console.WriteLine("\nGenerated employee serial numbers:"); // Display the serial-number heading

        DisplayStrings(serialNumbers); // Display the formatted serial numbers

        // Generate page numbers

        int totalRecords = 47; // Store the total number of records

        int pageSize = 10; // Store the number of records displayed on each page

        int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // Calculate the total number of required pages

        IEnumerable<int> pageNumbers = Enumerable.Range(1, totalPages); // Generate page numbers starting at one

        Console.WriteLine("\nGenerated page numbers:"); // Display the pagination heading

        DisplayNumbers(pageNumbers); // Display all page numbers

        // Generate pagination details

        var paginationDetails = Enumerable // Access the Enumerable class
            .Range(1, totalPages) // Generate each page number
            .Select(pageNumber => new // Create pagination information
            {
                PageNumber = pageNumber, // Store the current page number
                Skip = (pageNumber - 1) * pageSize, // Calculate the number of records to skip
                Take = pageSize // Store the number of records to request
            });

        Console.WriteLine("\nPagination details:"); // Display the pagination-details heading

        foreach (var page in paginationDetails) // Visit every page detail
        {
            Console.WriteLine($"Page: {page.PageNumber} | Skip: {page.Skip} | Take: {page.Take}"); // Display the page information
        }

        // Generate multiplication table

        int tableNumber = 7; // Store the number whose multiplication table is required

        IEnumerable<string> multiplicationTable = Enumerable // Access the Enumerable class
            .Range(1, 10) // Generate multipliers from one through ten
            .Select(multiplier => $"{tableNumber} x {multiplier} = {tableNumber * multiplier}"); // Create each multiplication-table row

        Console.WriteLine("\nMultiplication table of 7:"); // Display the multiplication-table heading

        DisplayStrings(multiplicationTable); // Display the complete table

        // Generate multiple multiplication tables

        var multiplicationTables = Enumerable // Access the Enumerable class
            .Range(2, 4) // Generate table numbers from two through five
            .Select(table => new // Create a table result for each generated number
            {
                TableNumber = table, // Store the table number
                Rows = Enumerable // Access the Enumerable class for the nested sequence
                    .Range(1, 5) // Generate multipliers from one through five
                    .Select(multiplier => $"{table} x {multiplier} = {table * multiplier}") // Generate each row of the table
            });

        Console.WriteLine("\nMultiplication tables from 2 through 5:"); // Display the multiple-table heading

        foreach (var table in multiplicationTables) // Visit every generated multiplication table
        {
            Console.WriteLine("\nTable of " + table.TableNumber); // Display the current table number

            DisplayStrings(table.Rows); // Display the rows belonging to the current table
        }

        // Generate dates

        DateTime startingDate = new DateTime(2026, 7, 20); // Store the first date

        IEnumerable<DateTime> sevenDates = Enumerable // Access the Enumerable class
            .Range(0, 7) // Generate day offsets from zero through six
            .Select(offset => startingDate.AddDays(offset)); // Add each offset to the starting date

        Console.WriteLine("\nSeven generated dates:"); // Display the date-generation heading

        foreach (DateTime date in sevenDates) // Visit every generated date
        {
            Console.WriteLine(date.ToString("dd-MM-yyyy")); // Display the date using day-month-year format
        }

        // Generate working days

        IEnumerable<DateTime> workingDays = Enumerable // Access the Enumerable class
            .Range(0, 14) // Generate fourteen day offsets
            .Select(offset => startingDate.AddDays(offset)) // Convert every offset into a date
            .Where(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday); // Remove Saturdays and Sundays

        Console.WriteLine("\nGenerated working days within two weeks:"); // Display the working-day heading

        foreach (DateTime date in workingDays) // Visit every generated working day
        {
            Console.WriteLine($"{date:dd-MM-yyyy} | {date.DayOfWeek}"); // Display the date and weekday
        }

        // Generate months

        IEnumerable<string> monthNames = Enumerable // Access the Enumerable class
            .Range(1, 12) // Generate month numbers from one through twelve
            .Select(month => new DateTime(2026, month, 1).ToString("MMMM")); // Convert every month number into its complete name

        Console.WriteLine("\nGenerated month names:"); // Display the month-generation heading

        DisplayStrings(monthNames); // Display all month names

        // Generate independent Employee objects

        IEnumerable<Employee> generatedEmployees = Enumerable // Access the Enumerable class
            .Range(1, 5) // Generate five employee positions
            .Select(number => new Employee // Create a new Employee object for every generated number
            {
                Id = 100 + number, // Generate an employee identifier
                Name = "Employee " + number, // Generate an employee name
                Department = number % 2 == 0 ? "Testing" : "Development", // Assign a department according to the generated number
                Salary = 40000m + number * 5000m // Calculate the employee salary
            });

        Console.WriteLine("\nEmployees generated using Range() and Select():"); // Display the generated-employee heading

        DisplayEmployees(generatedEmployees); // Display the generated employee objects

        // Materialize generated employees

        List<Employee> generatedEmployeeList = generatedEmployees.ToList(); // Execute the generated employee query and store it as a list

        generatedEmployeeList[0].Name = "Updated Employee"; // Modify the first independent employee object

        Console.WriteLine("\nGenerated employees after modifying only the first object:"); // Display the independent-object heading

        DisplayEmployees(generatedEmployeeList); // Show that only the first employee was modified

        // Generate Product objects

        List<Product> generatedProducts = Enumerable // Access the Enumerable class
            .Range(1, 5) // Generate five product numbers
            .Select(number => new Product // Create a new Product object for every number
            {
                Id = 200 + number, // Generate the product identifier
                Name = "Product " + number, // Generate the product name
                Price = number * 1500m // Calculate the product price
            })
            .ToList(); // Materialize the generated products as a list

        Console.WriteLine("\nProducts generated using Range():"); // Display the product-generation heading

        foreach (Product product in generatedProducts) // Visit every generated product
        {
            Console.WriteLine($"{product.Id} | {product.Name} | Rs. {product.Price:F2}"); // Display the generated product details
        }

        // Generate repeated integer values

        IEnumerable<int> repeatedZeros = Enumerable.Repeat(0, 10); // Generate ten zero values

        Console.WriteLine("\nTen zero values using Repeat():"); // Display the repeated-zero heading

        DisplayNumbers(repeatedZeros); // Display the repeated integer values

        // Repeat another integer

        IEnumerable<int> repeatedHundreds = Enumerable.Repeat(100, 5); // Generate five values containing one hundred

        Console.WriteLine("\nFive repeated values of 100:"); // Display the repeated-number heading

        DisplayNumbers(repeatedHundreds); // Display the repeated values

        // Repeat string

        IEnumerable<string> repeatedMessages = Enumerable.Repeat("LINQ Method Syntax", 4); // Generate the same message four times

        Console.WriteLine("\nRepeated string values:"); // Display the repeated-string heading

        DisplayStrings(repeatedMessages); // Display the repeated messages

        // Repeat separator

        string repeatedSeparator = string.Concat(Enumerable.Repeat("-", 50)); // Generate fifty hyphen strings and combine them

        Console.WriteLine("\nRepeated separator:"); // Display the separator heading

        Console.WriteLine(repeatedSeparator); // Display the generated separator line

        // Repeat with index using Select

        IEnumerable<string> numberedMessages = Enumerable // Access the Enumerable class
            .Repeat("Processing item", 5) // Generate the same message five times
            .Select((message, index) => $"{index + 1}. {message}"); // Add a number to every repeated message

        Console.WriteLine("\nRepeated messages with generated positions:"); // Display the indexed-Repeat heading

        DisplayStrings(numberedMessages); // Display the numbered repeated messages

        // Repeat with zero count

        IEnumerable<string> zeroRepeatResult = Enumerable.Repeat("Hello", 0); // Generate an empty sequence because count is zero

        Console.WriteLine("\nRepeat() with count equal to zero:"); // Display the zero-Repeat heading

        DisplayStrings(zeroRepeatResult); // Display the empty repeated sequence

        // Repeat and filter

        IEnumerable<int> filteredRepeatedNumbers = Enumerable // Access the Enumerable class
            .Repeat(25, 5) // Generate five values containing twenty-five
            .Where(number => number > 20); // Keep repeated values greater than twenty

        Console.WriteLine("\nRepeated values after filtering:"); // Display the Repeat-filter heading

        DisplayNumbers(filteredRepeatedNumbers); // Display all matching repeated values

        // Repeat and project

        IEnumerable<int> projectedRepeatedNumbers = Enumerable // Access the Enumerable class
            .Repeat(10, 5) // Generate five values containing ten
            .Select((number, index) => number + index); // Add the zero-based index to each repeated value

        Console.WriteLine("\nRepeated values transformed using Select():"); // Display the Repeat-projection heading

        DisplayNumbers(projectedRepeatedNumbers); // Display 10 through 14

        // Create fixed-size placeholder sequence

        IEnumerable<string> placeholders = Enumerable // Access the Enumerable class
            .Repeat("Not Assigned", 5); // Generate five placeholder values

        Console.WriteLine("\nGenerated placeholder values:"); // Display the placeholder heading

        DisplayStrings(placeholders); // Display the placeholder values

        // Repeat one reference-type object

        MutableBox sharedBox = new MutableBox { Value = 10 }; // Create one mutable object

        List<MutableBox> repeatedBoxes = Enumerable // Access the Enumerable class
            .Repeat(sharedBox, 3) // Repeat the same object reference three times
            .ToList(); // Materialize the repeated references as a list

        Console.WriteLine("\nRepeated reference-type object values before modification:"); // Display the reference-repeat heading

        foreach (MutableBox box in repeatedBoxes) // Visit every repeated reference
        {
            Console.WriteLine(box.Value); // Display the shared value
        }

        repeatedBoxes[0].Value = 999; // Modify the object through the first list position

        Console.WriteLine("\nRepeated reference-type object values after modifying the first position:"); // Display the shared-reference-change heading

        foreach (MutableBox box in repeatedBoxes) // Visit every repeated reference again
        {
            Console.WriteLine(box.Value); // Display 999 because every position refers to the same object
        }

        bool firstAndSecondAreSameObject = ReferenceEquals(repeatedBoxes[0], repeatedBoxes[1]); // Check whether two positions refer to the same object

        Console.WriteLine("First and second positions reference the same object: " + firstAndSecondAreSameObject); // Display the reference comparison result

        // Create independent objects instead of repeating reference

        List<MutableBox> independentBoxes = Enumerable // Access the Enumerable class
            .Range(1, 3) // Generate three positions
            .Select(number => new MutableBox { Value = number * 10 }) // Create a separate object for every position
            .ToList(); // Materialize the independent objects

        independentBoxes[0].Value = 500; // Modify only the first independent object

        Console.WriteLine("\nIndependent objects created using Range() and Select():"); // Display the independent-object heading

        foreach (MutableBox box in independentBoxes) // Visit every independent object
        {
            Console.WriteLine(box.Value); // Display each object's individual value
        }

        bool independentObjectsAreSame = ReferenceEquals(independentBoxes[0], independentBoxes[1]); // Compare two independently created objects

        Console.WriteLine("First and second independent boxes reference the same object: " + independentObjectsAreSame); // Display false because they are separate objects

        // Aggregate generated Range

        int generatedSum = Enumerable.Range(1, 100).Sum(); // Generate numbers from one through one hundred and calculate their sum

        double generatedAverage = Enumerable.Range(1, 100).Average(); // Generate numbers and calculate their average

        int generatedMinimum = Enumerable.Range(1, 100).Min(); // Find the minimum generated number

        int generatedMaximum = Enumerable.Range(1, 100).Max(); // Find the maximum generated number

        Console.WriteLine("\nAggregations on Enumerable.Range(1, 100):"); // Display the Range-aggregation heading

        Console.WriteLine("Sum: " + generatedSum); // Display the generated-number sum

        Console.WriteLine("Average: " + generatedAverage.ToString("F2")); // Display the generated-number average

        Console.WriteLine("Minimum: " + generatedMinimum); // Display the minimum generated value

        Console.WriteLine("Maximum: " + generatedMaximum); // Display the maximum generated value

        // Group generated numbers

        var generatedNumberGroups = Enumerable // Access the Enumerable class
            .Range(1, 20) // Generate numbers from one through twenty
            .GroupBy(number => number % 2 == 0 ? "Even" : "Odd"); // Group generated numbers as even or odd

        Console.WriteLine("\nGenerated numbers grouped as even and odd:"); // Display the Range-grouping heading

        foreach (IGrouping<string, int> numberGroup in generatedNumberGroups) // Visit every generated-number group
        {
            Console.Write(numberGroup.Key + ": "); // Display the group key

            DisplayNumbers(numberGroup); // Display numbers belonging to the current group
        }

        // Combine Range and Repeat

        IEnumerable<string> generatedPattern = Enumerable // Access the Enumerable class
            .Range(1, 5) // Generate line numbers from one through five
            .Select(lineNumber => string.Concat(Enumerable.Repeat("*", lineNumber))); // Repeat the star according to the line number

        Console.WriteLine("\nPattern generated using Range() and Repeat():"); // Display the combined-generation heading

        DisplayStrings(generatedPattern); // Display the generated star pattern

        // Generate square pattern

        IEnumerable<string> squarePattern = Enumerable // Access the Enumerable class
            .Repeat(string.Concat(Enumerable.Repeat("# ", 5)), 5); // Create one row of five hashes and repeat the row five times

        Console.WriteLine("\nSquare pattern generated using Repeat():"); // Display the square-pattern heading

        DisplayStrings(squarePattern); // Display the generated square pattern

        // Demonstrate negative Range count exception

        Console.WriteLine("\nAttempting Range() with a negative count:"); // Display the negative-Range heading

        try // Begin protected code that may throw an exception
        {
            IEnumerable<int> invalidRange = Enumerable.Range(1, -5); // Attempt to generate a sequence using a negative count

            DisplayNumbers(invalidRange); // Traverse the invalid sequence if creation succeeds
        }
        catch (ArgumentOutOfRangeException exception) // Handle the invalid-count exception
        {
            Console.WriteLine("Range() failed because count cannot be negative."); // Explain why Range failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Demonstrate Range overflow exception

        Console.WriteLine("\nAttempting Range() beyond Int32.MaxValue:"); // Display the Range-overflow heading

        try // Begin protected code that may throw an exception
        {
            IEnumerable<int> overflowingRange = Enumerable.Range(int.MaxValue - 2, 4); // Attempt to generate values beyond the maximum integer

            DisplayNumbers(overflowingRange); // Traverse the sequence if creation succeeds
        }
        catch (ArgumentOutOfRangeException exception) // Handle the range-overflow exception
        {
            Console.WriteLine("Range() failed because the generated sequence would exceed Int32.MaxValue."); // Explain why Range failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Demonstrate negative Repeat count exception

        Console.WriteLine("\nAttempting Repeat() with a negative count:"); // Display the negative-Repeat heading

        try // Begin protected code that may throw an exception
        {
            IEnumerable<string> invalidRepeat = Enumerable.Repeat("Hello", -3); // Attempt to repeat a value a negative number of times

            DisplayStrings(invalidRepeat); // Traverse the sequence if creation succeeds
        }
        catch (ArgumentOutOfRangeException exception) // Handle the invalid Repeat count
        {
            Console.WriteLine("Repeat() failed because count cannot be negative."); // Explain why Repeat failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Materialize generated sequence

        IEnumerable<int> generatedSequence = Enumerable.Range(1, 5); // Define a generated sequence

        List<int> generatedSnapshot = generatedSequence.ToList(); // Materialize the generated sequence as a list

        generatedSnapshot.Add(100); // Add another value only to the materialized list

        Console.WriteLine("\nOriginal generated Range sequence:"); // Display the original-generated heading

        DisplayNumbers(generatedSequence); // Display the unchanged Range sequence

        Console.WriteLine("\nMaterialized list after adding 100:"); // Display the modified-list heading

        DisplayNumbers(generatedSnapshot); // Display the list containing the additional value

        // Final message

        Console.WriteLine("\nAll LINQ method-syntax generation-operator examples completed successfully."); // Display the completion message
    }
}