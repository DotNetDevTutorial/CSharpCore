/*
LINQ Concat() Using Method Syntax - Complete Concept Summary

Concat() combines two sequences of the same or compatible data type
into one continuous sequence.

Basic syntax:

IEnumerable<T> result = firstCollection.Concat(secondCollection);

Example:

List<int> firstNumbers = new List<int>() { 10, 20, 30 };
List<int> secondNumbers = new List<int>() { 40, 50, 60 };

IEnumerable<int> combinedNumbers =
    firstNumbers.Concat(secondNumbers);

Result:

10 20 30 40 50 60

Important behaviour:

1. Elements from the first collection are returned first.
2. Elements from the second collection are returned afterward.
3. The original order of both collections is preserved.
4. Duplicate values are not removed.
5. The original collections are not modified.
6. Both collections must contain the same or compatible element type.
7. Concat() returns IEnumerable<T>.
8. Concat() normally uses deferred execution.
9. The query executes when it is traversed using foreach, ToList(),
   ToArray(), Count(), or another terminal operation.
10. More than two collections can be combined by chaining Concat().

Chaining syntax:

IEnumerable<int> result = firstCollection
    .Concat(secondCollection)
    .Concat(thirdCollection);

Concat() with filtering:

IEnumerable<int> result = firstCollection
    .Concat(secondCollection)
    .Where(number => number > 20);

Concat() with ordering:

IEnumerable<int> result = firstCollection
    .Concat(secondCollection)
    .OrderBy(number => number);

Concat() with projection:

IEnumerable<string> result = firstCollection
    .Concat(secondCollection)
    .Select(number => $"Value: {number}");

Concat() and duplicate values:

First collection:  10, 20, 30
Second collection: 20, 30, 40

Concat result:

10, 20, 30, 20, 30, 40

Concat() preserves duplicates.

To remove duplicates after concatenation:

IEnumerable<int> result = firstCollection
    .Concat(secondCollection)
    .Distinct();

Difference between Concat() and Union():

Concat():
- Combines both collections.
- Preserves duplicate values.
- Preserves the order of the two source sequences.

Union():
- Combines both collections.
- Removes duplicate values.

Example:

first.Concat(second);

Result:
10, 20, 30, 20, 30, 40

first.Union(second);

Result:
10, 20, 30, 40

Difference between Concat(), Append(), and Prepend():

Concat():
Combines an entire second collection.

Append():
Adds one value at the end.

Prepend():
Adds one value at the beginning.

Examples:

numbers.Concat(otherNumbers);
numbers.Append(100);
numbers.Prepend(0);

Type compatibility:

Correct:

IEnumerable<int> result = integerList.Concat(integerArray);

Both collections provide integer values.

Incorrect:

integerList.Concat(stringList);

An integer sequence cannot directly be concatenated with a string
sequence.

Different source types can be converted into one common result type:

IEnumerable<string> result = integerList
    .Select(number => number.ToString())
    .Concat(stringList);

Null collections:

Calling Concat() with a null source causes an ArgumentNullException.

A nullable collection can be safely replaced with:

nullableCollection ?? Enumerable.Empty<T>()

Time complexity:

Concat traversal: O(n + m)

Here:

n = number of elements in the first collection
m = number of elements in the second collection

Concat() streams the source sequences and does not normally copy every
element into a new collection unless ToList() or ToArray() is used.

Required namespace:

using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ extension methods such as Concat()

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public decimal Salary { get; set; } // Store the employee salary
}

class ConcatenateProgram // Define the main program class
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
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | Rs. {employee.Salary:F2}"); // Display the current employee details

            employeeFound = true; // Record that at least one employee was found
        }

        if (!employeeFound) // Check whether the sequence was empty
        {
            Console.WriteLine("No employees"); // Display a message for an empty employee sequence
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create first number collection

        List<int> firstNumbers = new List<int>() // Create the first integer collection
        {
            10, // Add 10 to the first collection
            20, // Add 20 to the first collection
            30, // Add 30 to the first collection
            40 // Add 40 to the first collection
        };

        // Create second number collection

        List<int> secondNumbers = new List<int>() // Create the second integer collection
        {
            50, // Add 50 to the second collection
            60, // Add 60 to the second collection
            70, // Add 70 to the second collection
            80 // Add 80 to the second collection
        };

        Console.WriteLine("First number collection:"); // Display the first-collection heading

        DisplayNumbers(firstNumbers); // Display the first number collection

        Console.WriteLine("\nSecond number collection:"); // Display the second-collection heading

        DisplayNumbers(secondNumbers); // Display the second number collection

        // Basic Concat

        IEnumerable<int> combinedNumbers = firstNumbers.Concat(secondNumbers); // Combine the first and second number collections

        Console.WriteLine("\nNumbers after using Concat():"); // Display the basic-concatenation heading

        DisplayNumbers(combinedNumbers); // Display the combined number sequence

        // Confirm original collections are unchanged

        Console.WriteLine("\nFirst collection after Concat():"); // Display the original first-collection heading

        DisplayNumbers(firstNumbers); // Display the unchanged first collection

        Console.WriteLine("\nSecond collection after Concat():"); // Display the original second-collection heading

        DisplayNumbers(secondNumbers); // Display the unchanged second collection

        // Convert concatenated result to list

        List<int> combinedNumberList = firstNumbers.Concat(secondNumbers).ToList(); // Combine both sequences and materialize the result as a list

        Console.WriteLine("\nConcatenated result converted to List<int>:"); // Display the ToList heading

        DisplayNumbers(combinedNumberList); // Display the materialized concatenated list

        // Convert concatenated result to array

        int[] combinedNumberArray = firstNumbers.Concat(secondNumbers).ToArray(); // Combine both sequences and materialize the result as an array

        Console.WriteLine("\nConcatenated result converted to an array:"); // Display the ToArray heading

        DisplayNumbers(combinedNumberArray); // Display the materialized concatenated array

        // Concat preserves duplicates

        List<int> duplicateFirstNumbers = new List<int>() // Create a collection containing values that also occur in another collection
        {
            10, // Add 10 to the first duplicate collection
            20, // Add 20 to the first duplicate collection
            30 // Add 30 to the first duplicate collection
        };

        List<int> duplicateSecondNumbers = new List<int>() // Create another collection containing repeated values
        {
            20, // Add another 20
            30, // Add another 30
            40 // Add 40 to the second duplicate collection
        };

        IEnumerable<int> concatenatedDuplicates = duplicateFirstNumbers.Concat(duplicateSecondNumbers); // Combine both collections without removing duplicates

        Console.WriteLine("\nConcat() result containing duplicate values:"); // Display the duplicate-preservation heading

        DisplayNumbers(concatenatedDuplicates); // Display all values including duplicates

        // Remove duplicates after Concat

        IEnumerable<int> uniqueConcatenatedNumbers = duplicateFirstNumbers // Begin with the first duplicate collection
            .Concat(duplicateSecondNumbers) // Combine the second duplicate collection
            .Distinct(); // Remove duplicate values from the combined sequence

        Console.WriteLine("\nConcat() followed by Distinct():"); // Display the distinct-result heading

        DisplayNumbers(uniqueConcatenatedNumbers); // Display the unique concatenated values

        // Compare Concat and Union

        IEnumerable<int> concatResult = duplicateFirstNumbers.Concat(duplicateSecondNumbers); // Combine both collections while preserving duplicates

        IEnumerable<int> unionResult = duplicateFirstNumbers.Union(duplicateSecondNumbers); // Combine both collections while removing duplicates

        Console.WriteLine("\nConcat() result:"); // Display the Concat comparison heading

        DisplayNumbers(concatResult); // Display the result containing duplicate values

        Console.WriteLine("\nUnion() result:"); // Display the Union comparison heading

        DisplayNumbers(unionResult); // Display the result without duplicate values

        // Chain multiple Concat calls

        List<int> thirdNumbers = new List<int>() // Create a third integer collection
        {
            90, // Add 90 to the third collection
            100 // Add 100 to the third collection
        };

        List<int> fourthNumbers = new List<int>() // Create a fourth integer collection
        {
            110, // Add 110 to the fourth collection
            120 // Add 120 to the fourth collection
        };

        IEnumerable<int> multipleCollectionResult = firstNumbers // Begin with the first collection
            .Concat(secondNumbers) // Add the second collection
            .Concat(thirdNumbers) // Add the third collection
            .Concat(fourthNumbers); // Add the fourth collection

        Console.WriteLine("\nFour collections combined using chained Concat():"); // Display the chained-concatenation heading

        DisplayNumbers(multipleCollectionResult); // Display values from all four collections

        // Concat a list and an array

        int[] arrayNumbers = new int[] // Create an integer array
        {
            130, // Add 130 to the array
            140, // Add 140 to the array
            150 // Add 150 to the array
        };

        IEnumerable<int> listAndArrayResult = firstNumbers.Concat(arrayNumbers); // Combine a List<int> with an int array

        Console.WriteLine("\nList<int> concatenated with an int array:"); // Display the list-and-array heading

        DisplayNumbers(listAndArrayResult); // Display the combined list and array values

        // Filter before Concat

        IEnumerable<int> filteredBeforeConcat = firstNumbers // Begin with the first number collection
            .Where(number => number >= 20) // Keep values of at least twenty from the first collection
            .Concat(secondNumbers.Where(number => number <= 60)); // Add values of at most sixty from the second collection

        Console.WriteLine("\nFiltering each collection before Concat():"); // Display the filter-before-concat heading

        DisplayNumbers(filteredBeforeConcat); // Display the concatenated filtered values

        // Filter after Concat

        IEnumerable<int> filteredAfterConcat = firstNumbers // Begin with the first number collection
            .Concat(secondNumbers) // Combine the second number collection
            .Where(number => number >= 30 && number <= 70); // Keep combined values from thirty through seventy

        Console.WriteLine("\nFiltering after Concat():"); // Display the filter-after-concat heading

        DisplayNumbers(filteredAfterConcat); // Display the filtered combined sequence

        // Order after Concat

        List<int> unorderedFirstNumbers = new List<int>() // Create an unordered first sequence
        {
            50, // Add 50 to the unordered sequence
            10, // Add 10 to the unordered sequence
            30 // Add 30 to the unordered sequence
        };

        List<int> unorderedSecondNumbers = new List<int>() // Create an unordered second sequence
        {
            60, // Add 60 to the unordered sequence
            20, // Add 20 to the unordered sequence
            40 // Add 40 to the unordered sequence
        };

        IEnumerable<int> orderedConcatenatedNumbers = unorderedFirstNumbers // Begin with the first unordered sequence
            .Concat(unorderedSecondNumbers) // Combine the second unordered sequence
            .OrderBy(number => number); // Arrange all combined values in ascending order

        Console.WriteLine("\nConcatenated numbers ordered in ascending order:"); // Display the ascending-order heading

        DisplayNumbers(orderedConcatenatedNumbers); // Display the ordered combined values

        IEnumerable<int> descendingConcatenatedNumbers = unorderedFirstNumbers // Begin with the first unordered sequence
            .Concat(unorderedSecondNumbers) // Combine the second unordered sequence
            .OrderByDescending(number => number); // Arrange all combined values in descending order

        Console.WriteLine("\nConcatenated numbers ordered in descending order:"); // Display the descending-order heading

        DisplayNumbers(descendingConcatenatedNumbers); // Display the descending combined values

        // Project after Concat

        IEnumerable<string> projectedNumbers = firstNumbers // Begin with the first number collection
            .Concat(secondNumbers) // Combine the second number collection
            .Select(number => $"Number: {number}, Square: {number * number}"); // Convert every combined number into descriptive text

        Console.WriteLine("\nProjection after Concat():"); // Display the projection heading

        DisplayStrings(projectedNumbers); // Display the projected number information

        // Calculate values after Concat

        int combinedCount = firstNumbers.Concat(secondNumbers).Count(); // Count all elements in both collections

        int combinedSum = firstNumbers.Concat(secondNumbers).Sum(); // Calculate the sum of all combined numbers

        double combinedAverage = firstNumbers.Concat(secondNumbers).Average(); // Calculate the average of all combined numbers

        int combinedMinimum = firstNumbers.Concat(secondNumbers).Min(); // Find the smallest combined number

        int combinedMaximum = firstNumbers.Concat(secondNumbers).Max(); // Find the largest combined number

        Console.WriteLine("\nAggregations after Concat():"); // Display the aggregation heading

        Console.WriteLine("Count: " + combinedCount); // Display the combined element count

        Console.WriteLine("Sum: " + combinedSum); // Display the combined sum

        Console.WriteLine("Average: " + combinedAverage.ToString("F2")); // Display the combined average

        Console.WriteLine("Minimum: " + combinedMinimum); // Display the smallest combined number

        Console.WriteLine("Maximum: " + combinedMaximum); // Display the largest combined number

        // Concat empty collection

        List<int> emptyNumbers = new List<int>(); // Create an empty integer collection

        IEnumerable<int> collectionWithEmptyResult = firstNumbers.Concat(emptyNumbers); // Combine the first collection with an empty collection

        Console.WriteLine("\nCollection concatenated with an empty collection:"); // Display the empty-collection heading

        DisplayNumbers(collectionWithEmptyResult); // Display the unchanged first sequence

        // Append and Prepend comparison

        IEnumerable<int> appendedNumbers = firstNumbers.Append(999); // Add one value to the end of the sequence

        IEnumerable<int> prependedNumbers = firstNumbers.Prepend(0); // Add one value to the beginning of the sequence

        IEnumerable<int> concatenatedSingleCollection = firstNumbers.Concat(new int[] { 999 }); // Add a one-element collection using Concat()

        Console.WriteLine("\nAppend() result:"); // Display the Append heading

        DisplayNumbers(appendedNumbers); // Display the sequence with a value added at the end

        Console.WriteLine("\nPrepend() result:"); // Display the Prepend heading

        DisplayNumbers(prependedNumbers); // Display the sequence with a value added at the beginning

        Console.WriteLine("\nConcat() with a one-element collection:"); // Display the one-element Concat heading

        DisplayNumbers(concatenatedSingleCollection); // Display the sequence combined with one additional element

        // Create string collections

        List<string> frontendTechnologies = new List<string>() // Create a collection of frontend technologies
        {
            "HTML", // Add HTML to the frontend collection
            "CSS", // Add CSS to the frontend collection
            "JavaScript", // Add JavaScript to the frontend collection
            "React" // Add React to the frontend collection
        };

        List<string> backendTechnologies = new List<string>() // Create a collection of backend technologies
        {
            "C#", // Add C# to the backend collection
            "ASP.NET", // Add ASP.NET to the backend collection
            "Python", // Add Python to the backend collection
            "Java" // Add Java to the backend collection
        };

        IEnumerable<string> allTechnologies = frontendTechnologies.Concat(backendTechnologies); // Combine frontend and backend technology names

        Console.WriteLine("\nFrontend and backend technologies combined:"); // Display the string-concatenation heading

        DisplayStrings(allTechnologies); // Display all combined technology names

        // Concat string collections containing duplicates

        List<string> firstLanguages = new List<string>() // Create the first programming-language collection
        {
            "C#", // Add C# to the first language collection
            "Python", // Add Python to the first language collection
            "Java" // Add Java to the first language collection
        };

        List<string> secondLanguages = new List<string>() // Create the second programming-language collection
        {
            "Python", // Add another Python value
            "JavaScript", // Add JavaScript to the second collection
            "C#" // Add another C# value
        };

        IEnumerable<string> concatenatedLanguages = firstLanguages.Concat(secondLanguages); // Combine both language collections while preserving duplicates

        Console.WriteLine("\nProgramming languages combined with duplicates:"); // Display the duplicate-string heading

        DisplayStrings(concatenatedLanguages); // Display all language values including duplicates

        IEnumerable<string> uniqueLanguages = firstLanguages // Begin with the first language collection
            .Concat(secondLanguages) // Combine the second language collection
            .Distinct(); // Remove duplicate language names

        Console.WriteLine("\nUnique programming languages after Concat():"); // Display the unique-language heading

        DisplayStrings(uniqueLanguages); // Display the unique language names

        // Case-insensitive duplicate removal

        List<string> mixedCaseFirstValues = new List<string>() // Create the first mixed-case collection
        {
            "Python", // Add title-case Python
            "JAVA", // Add uppercase JAVA
            "C#" // Add C#
        };

        List<string> mixedCaseSecondValues = new List<string>() // Create the second mixed-case collection
        {
            "python", // Add lowercase python
            "Java", // Add title-case Java
            "SQL" // Add SQL
        };

        IEnumerable<string> caseInsensitiveUniqueValues = mixedCaseFirstValues // Begin with the first mixed-case collection
            .Concat(mixedCaseSecondValues) // Combine the second mixed-case collection
            .Distinct(StringComparer.OrdinalIgnoreCase); // Remove duplicates without considering letter case

        Console.WriteLine("\nCase-insensitive unique values after Concat():"); // Display the case-insensitive heading

        DisplayStrings(caseInsensitiveUniqueValues); // Display the case-insensitively unique values

        // Convert different source types to common type

        List<int> numericValues = new List<int>() // Create a collection of integer values
        {
            100, // Add 100 to the numeric collection
            200, // Add 200 to the numeric collection
            300 // Add 300 to the numeric collection
        };

        List<string> textValues = new List<string>() // Create a collection of string values
        {
            "Four Hundred", // Add Four Hundred to the text collection
            "Five Hundred" // Add Five Hundred to the text collection
        };

        IEnumerable<string> commonTypeResult = numericValues // Begin with the integer collection
            .Select(number => number.ToString()) // Convert every integer into a string
            .Concat(textValues); // Combine the converted numbers with the original strings

        Console.WriteLine("\nDifferent source types converted to a common string type:"); // Display the common-type heading

        DisplayStrings(commonTypeResult); // Display the combined string sequence

        // Create first employee collection

        List<Employee> developmentEmployees = new List<Employee>() // Create a collection of Development employees
        {
            new Employee { Id = 101, Name = "Saad", Department = "Development", Salary = 65000m }, // Add the first Development employee
            new Employee { Id = 102, Name = "Neha", Department = "Development", Salary = 75000m }, // Add the second Development employee
            new Employee { Id = 103, Name = "Arjun", Department = "Development", Salary = 55000m } // Add the third Development employee
        };

        // Create second employee collection

        List<Employee> dataEmployees = new List<Employee>() // Create a collection of Data Engineering employees
        {
            new Employee { Id = 201, Name = "Priya", Department = "Data Engineering", Salary = 82000m }, // Add the first Data Engineering employee
            new Employee { Id = 202, Name = "Zoya", Department = "Data Engineering", Salary = 70000m }, // Add the second Data Engineering employee
            new Employee { Id = 203, Name = "Ananya", Department = "Data Engineering", Salary = 90000m } // Add the third Data Engineering employee
        };

        // Concat object collections

        IEnumerable<Employee> allEmployees = developmentEmployees.Concat(dataEmployees); // Combine both employee collections

        Console.WriteLine("\nEmployee collections combined using Concat():"); // Display the employee-concatenation heading

        DisplayEmployees(allEmployees); // Display every combined employee

        // Filter concatenated objects

        IEnumerable<Employee> highSalaryEmployees = developmentEmployees // Begin with the Development employee collection
            .Concat(dataEmployees) // Combine the Data Engineering employee collection
            .Where(employee => employee.Salary >= 70000m) // Keep employees earning at least seventy thousand
            .OrderByDescending(employee => employee.Salary); // Arrange matching employees from highest to lowest salary

        Console.WriteLine("\nCombined employees earning at least Rs. 70000:"); // Display the filtered-employee heading

        DisplayEmployees(highSalaryEmployees); // Display the matching combined employees

        // Project concatenated objects

        IEnumerable<string> employeeSummaries = developmentEmployees // Begin with the Development employee collection
            .Concat(dataEmployees) // Combine the Data Engineering employee collection
            .Select(employee => $"{employee.Name} works in {employee.Department} and earns Rs. {employee.Salary:F2}."); // Project every employee into formatted text

        Console.WriteLine("\nEmployee summaries after Concat():"); // Display the employee-projection heading

        DisplayStrings(employeeSummaries); // Display every projected employee summary

        // Group concatenated objects

        var employeesByDepartment = developmentEmployees // Begin with the Development employee collection
            .Concat(dataEmployees) // Combine the Data Engineering employee collection
            .GroupBy(employee => employee.Department) // Group the combined employees by department
            .OrderBy(group => group.Key); // Arrange the department groups alphabetically

        Console.WriteLine("\nCombined employees grouped by department:"); // Display the employee-grouping heading

        foreach (var departmentGroup in employeesByDepartment) // Visit every department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department name

            foreach (Employee employee in departmentGroup) // Visit every employee in the current group
            {
                Console.WriteLine(employee.Name); // Display the current employee name
            }
        }

        // Remove duplicate objects using a key

        List<Employee> firstEmployeeBatch = new List<Employee>() // Create the first employee batch
        {
            new Employee { Id = 301, Name = "Ali", Department = "Testing", Salary = 50000m }, // Add Ali to the first batch
            new Employee { Id = 302, Name = "Riya", Department = "Support", Salary = 48000m } // Add Riya to the first batch
        };

        List<Employee> secondEmployeeBatch = new List<Employee>() // Create the second employee batch
        {
            new Employee { Id = 302, Name = "Riya", Department = "Support", Salary = 48000m }, // Add another employee record having ID 302
            new Employee { Id = 303, Name = "Kabir", Department = "Testing", Salary = 52000m } // Add Kabir to the second batch
        };

        IEnumerable<Employee> uniqueEmployeesById = firstEmployeeBatch // Begin with the first employee batch
            .Concat(secondEmployeeBatch) // Combine the second employee batch
            .GroupBy(employee => employee.Id) // Group records having the same employee identifier
            .Select(group => group.First()); // Select the first employee from each identifier group

        Console.WriteLine("\nUnique employees after concatenation based on employee ID:"); // Display the unique-object heading

        DisplayEmployees(uniqueEmployeesById); // Display one employee record for each identifier

        // Safely concatenate nullable collection

        List<int>? nullableNumbers = null; // Create a nullable collection containing no object

        IEnumerable<int> safeNullableSequence = nullableNumbers ?? Enumerable.Empty<int>(); // Replace the null collection with an empty sequence

        IEnumerable<int> safeConcatResult = firstNumbers.Concat(safeNullableSequence); // Safely concatenate the first collection with the empty replacement

        Console.WriteLine("\nSafe concatenation with a nullable collection:"); // Display the null-safe heading

        DisplayNumbers(safeConcatResult); // Display the safely concatenated result

        // Demonstrate deferred execution

        List<int> deferredFirstNumbers = new List<int>() // Create the first collection for deferred execution
        {
            10, // Add 10 to the deferred first collection
            20 // Add 20 to the deferred first collection
        };

        List<int> deferredSecondNumbers = new List<int>() // Create the second collection for deferred execution
        {
            30, // Add 30 to the deferred second collection
            40 // Add 40 to the deferred second collection
        };

        IEnumerable<int> deferredConcatQuery = deferredFirstNumbers.Concat(deferredSecondNumbers); // Define the Concat query without immediately executing it

        deferredFirstNumbers.Add(25); // Add 25 after defining the query

        deferredSecondNumbers.Add(50); // Add 50 after defining the query

        Console.WriteLine("\nDeferred Concat() result after modifying both collections:"); // Display the deferred-execution heading

        DisplayNumbers(deferredConcatQuery); // Execute the query and include the newly added values

        // Demonstrate immediate materialization

        List<int> immediateConcatSnapshot = deferredFirstNumbers // Begin with the current first deferred collection
            .Concat(deferredSecondNumbers) // Combine the current second deferred collection
            .ToList(); // Execute the query immediately and store a snapshot

        deferredFirstNumbers.Add(60); // Add 60 after creating the snapshot

        deferredSecondNumbers.Add(70); // Add 70 after creating the snapshot

        Console.WriteLine("\nMaterialized Concat() snapshot:"); // Display the materialized-snapshot heading

        DisplayNumbers(immediateConcatSnapshot); // Display the snapshot without the later values

        Console.WriteLine("\nDeferred query after adding 60 and 70:"); // Display the updated deferred-query heading

        DisplayNumbers(deferredConcatQuery); // Execute the deferred query and include all later values

        // Final message

        Console.WriteLine("\nAll LINQ method-syntax Concat() examples completed successfully."); // Display the completion message
    }
}