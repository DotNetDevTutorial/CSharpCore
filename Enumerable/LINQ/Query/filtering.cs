/*
LINQ Filtering Using Query Expression - Brief Summary

Filtering means selecting only those elements from a collection that
satisfy a specified condition.

In LINQ query-expression syntax, filtering is performed using the
where clause.

Basic syntax:

var result =
    from item in collection
    where condition
    select item;

Example:

var evenNumbers =
    from number in numbers
    where number % 2 == 0
    select number;

The query checks every element and returns only those elements for
which the condition evaluates to true.

Multiple conditions:

var result =
    from number in numbers
    where number >= 20 && number <= 50
    select number;

Logical operators commonly used in filtering:

&&:
Both conditions must be true.

||:
At least one condition must be true.

!:
Reverses a Boolean condition.

==:
Checks equality.

!=:
Checks inequality.

>:
Checks whether the left value is greater.

<:
Checks whether the left value is smaller.

>=:
Checks whether the left value is greater than or equal.

<=:
Checks whether the left value is smaller than or equal.

String methods useful in filtering:

StartsWith():
Checks whether a string starts with specified text.

EndsWith():
Checks whether a string ends with specified text.

Contains():
Checks whether a string contains specified text.

ToLower():
Converts text to lowercase for case-insensitive comparison.

Important points:

1. A query expression begins with the from clause.
2. The where clause specifies the filtering condition.
3. The select clause specifies the returned value.
4. More than one where clause can be used.
5. Multiple conditions can be joined using && and ||.
6. The original collection is not modified.
7. Query execution is normally deferred until the result is traversed.
8. Objects can be filtered using their properties.
9. Filtering can be combined with ordering and projection.
10. The result type is usually IEnumerable<T>.

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ query-expression support

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the unique employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public decimal Salary { get; set; } // Store the employee salary

    public int Experience { get; set; } // Store employee experience in years

    public bool IsPermanent { get; set; } // Store whether the employee is permanent

    public string? City { get; set; } // Store the employee city or null
}

class FilteringProgram // Define the main program class
{
    // Display integer sequence

    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method that accepts an integer sequence
    {
        bool valueFound = false; // Track whether the sequence contains an element

        foreach (int number in numbers) // Visit every number in the sequence
        {
            Console.Write(number + " "); // Display the current number on the same line

            valueFound = true; // Record that at least one value was found
        }

        if (!valueFound) // Check whether the sequence contained no values
        {
            Console.Write("No matching values"); // Display the no-result message
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display string sequence

    static void DisplayStrings(IEnumerable<string> values) // Define a method that accepts a string sequence
    {
        bool valueFound = false; // Track whether the sequence contains an element

        foreach (string value in values) // Visit every string in the sequence
        {
            Console.WriteLine(value); // Display the current string

            valueFound = true; // Record that at least one value was found
        }

        if (!valueFound) // Check whether the sequence contained no strings
        {
            Console.WriteLine("No matching values."); // Display the no-result message
        }
    }

    // Display employee sequence

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        bool employeeFound = false; // Track whether the sequence contains an employee

        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | Rs. {employee.Salary:F2} | Experience: {employee.Experience} years | Permanent: {employee.IsPermanent} | City: {employee.City ?? "Not available"}"); // Display the current employee details

            employeeFound = true; // Record that at least one employee was found
        }

        if (!employeeFound) // Check whether no employee matched the condition
        {
            Console.WriteLine("No matching employees."); // Display the no-result message
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a list of integer values
        {
            5, // Add 5 to the number collection
            10, // Add 10 to the number collection
            15, // Add 15 to the number collection
            20, // Add 20 to the number collection
            25, // Add 25 to the number collection
            30, // Add 30 to the number collection
            35, // Add 35 to the number collection
            40, // Add 40 to the number collection
            45, // Add 45 to the number collection
            50 // Add 50 to the number collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all numbers in the collection

        // Filter even numbers

        var evenNumbers = // Declare a query for even numbers
            from number in numbers // Read every number from the collection
            where number % 2 == 0 // Keep numbers that are divisible by two
            select number; // Select the filtered number

        Console.WriteLine("\nEven numbers:"); // Display the even-number heading

        DisplayNumbers(evenNumbers); // Display the filtered even numbers

        // Filter odd numbers

        var oddNumbers = // Declare a query for odd numbers
            from number in numbers // Read every number from the collection
            where number % 2 != 0 // Keep numbers that are not divisible by two
            select number; // Select the filtered number

        Console.WriteLine("\nOdd numbers:"); // Display the odd-number heading

        DisplayNumbers(oddNumbers); // Display the filtered odd numbers

        // Filter numbers greater than value

        var numbersGreaterThanTwenty = // Declare a query for numbers greater than twenty
            from number in numbers // Read every number from the collection
            where number > 20 // Keep numbers greater than twenty
            select number; // Select the filtered number

        Console.WriteLine("\nNumbers greater than 20:"); // Display the greater-than heading

        DisplayNumbers(numbersGreaterThanTwenty); // Display numbers greater than twenty

        // Filter numbers smaller than value

        var numbersSmallerThanThirty = // Declare a query for numbers smaller than thirty
            from number in numbers // Read every number from the collection
            where number < 30 // Keep numbers smaller than thirty
            select number; // Select the filtered number

        Console.WriteLine("\nNumbers smaller than 30:"); // Display the smaller-than heading

        DisplayNumbers(numbersSmallerThanThirty); // Display numbers smaller than thirty

        // Filter numbers within range

        var numbersWithinRange = // Declare a query for numbers within a range
            from number in numbers // Read every number from the collection
            where number >= 20 && number <= 40 // Keep numbers from twenty through forty
            select number; // Select the filtered number

        Console.WriteLine("\nNumbers between 20 and 40:"); // Display the range-filter heading

        DisplayNumbers(numbersWithinRange); // Display numbers within the inclusive range

        // Filter using OR condition

        var smallOrLargeNumbers = // Declare a query using an OR condition
            from number in numbers // Read every number from the collection
            where number <= 10 || number >= 45 // Keep numbers that are small or large
            select number; // Select the filtered number

        Console.WriteLine("\nNumbers less than or equal to 10 or greater than or equal to 45:"); // Display the OR-condition heading

        DisplayNumbers(smallOrLargeNumbers); // Display numbers satisfying either condition

        // Filter using multiple conditions

        var divisibleNumbers = // Declare a query using multiple conditions
            from number in numbers // Read every number from the collection
            where number % 2 == 0 && number % 5 == 0 // Keep numbers divisible by both two and five
            select number; // Select the filtered number

        Console.WriteLine("\nNumbers divisible by both 2 and 5:"); // Display the multiple-condition heading

        DisplayNumbers(divisibleNumbers); // Display numbers satisfying both conditions

        // Filter using multiple where clauses

        var multipleWhereResult = // Declare a query containing multiple where clauses
            from number in numbers // Read every number from the collection
            where number >= 15 // Keep numbers greater than or equal to fifteen
            where number <= 40 // Keep the remaining numbers smaller than or equal to forty
            where number % 2 == 0 // Keep the remaining even numbers
            select number; // Select the final filtered number

        Console.WriteLine("\nEven numbers between 15 and 40 using multiple where clauses:"); // Display the multiple-where heading

        DisplayNumbers(multipleWhereResult); // Display the final filtered numbers

        // Filter after calculation

        var squareGreaterThanFiveHundred = // Declare a query that filters using a calculation
            from number in numbers // Read every number from the collection
            where number * number > 500 // Keep numbers whose square is greater than five hundred
            select number; // Select the original number

        Console.WriteLine("\nNumbers whose square is greater than 500:"); // Display the calculation-filter heading

        DisplayNumbers(squareGreaterThanFiveHundred); // Display numbers satisfying the calculated condition

        // Filter and project calculated value

        var filteredSquares = // Declare a query that filters and projects squared values
            from number in numbers // Read every number from the collection
            where number >= 20 // Keep numbers greater than or equal to twenty
            select number * number; // Select the square of the filtered number

        Console.WriteLine("\nSquares of numbers greater than or equal to 20:"); // Display the filtered-projection heading

        DisplayNumbers(filteredSquares); // Display the calculated query results

        // Filter using external variable

        int minimumRequiredValue = 25; // Store the minimum value required by the query

        var dynamicFilterResult = // Declare a query that uses an external variable
            from number in numbers // Read every number from the collection
            where number >= minimumRequiredValue // Keep numbers greater than or equal to the external value
            select number; // Select the filtered number

        Console.WriteLine("\nNumbers greater than or equal to " + minimumRequiredValue + ":"); // Display the dynamic-filter heading

        DisplayNumbers(dynamicFilterResult); // Display numbers satisfying the external condition

        // Create string collection

        List<string> technologies = new List<string>() // Create a list of technology names
        {
            "C#", // Add C# to the collection
            "Python", // Add Python to the collection
            "Java", // Add Java to the collection
            "JavaScript", // Add JavaScript to the collection
            "SQL", // Add SQL to the collection
            "MongoDB", // Add MongoDB to the collection
            "PySpark", // Add PySpark to the collection
            "Azure" // Add Azure to the collection
        };

        Console.WriteLine("\nOriginal technology collection:"); // Display the technology heading

        DisplayStrings(technologies); // Display all technology names

        // Filter strings by length

        var longTechnologyNames = // Declare a query for strings longer than five characters
            from technology in technologies // Read every technology from the collection
            where technology.Length > 5 // Keep technology names longer than five characters
            select technology; // Select the filtered technology name

        Console.WriteLine("\nTechnology names longer than 5 characters:"); // Display the length-filter heading

        DisplayStrings(longTechnologyNames); // Display the filtered technology names

        // Filter strings using StartsWith

        var technologiesStartingWithP = // Declare a query for strings starting with P
            from technology in technologies // Read every technology from the collection
            where technology.StartsWith("P") // Keep names beginning with uppercase P
            select technology; // Select the filtered technology name

        Console.WriteLine("\nTechnology names starting with P:"); // Display the StartsWith heading

        DisplayStrings(technologiesStartingWithP); // Display matching technology names

        // Filter strings using EndsWith

        var technologiesEndingWithScript = // Declare a query for strings ending with Script
            from technology in technologies // Read every technology from the collection
            where technology.EndsWith("Script") // Keep names ending with Script
            select technology; // Select the filtered technology name

        Console.WriteLine("\nTechnology names ending with Script:"); // Display the EndsWith heading

        DisplayStrings(technologiesEndingWithScript); // Display matching technology names

        // Filter strings using Contains

        var technologiesContainingJava = // Declare a query for strings containing Java
            from technology in technologies // Read every technology from the collection
            where technology.Contains("Java") // Keep names containing the text Java
            select technology; // Select the filtered technology name

        Console.WriteLine("\nTechnology names containing Java:"); // Display the Contains heading

        DisplayStrings(technologiesContainingJava); // Display matching technology names

        // Case-insensitive string filtering

        string searchText = "sql"; // Store lowercase search text

        var caseInsensitiveResult = // Declare a case-insensitive string query
            from technology in technologies // Read every technology from the collection
            where technology.ToLower() == searchText.ToLower() // Compare both strings after converting them to lowercase
            select technology; // Select the matching technology name

        Console.WriteLine("\nCase-insensitive search for sql:"); // Display the case-insensitive-search heading

        DisplayStrings(caseInsensitiveResult); // Display the matching technology name

        // Filter strings using multiple conditions

        var technologyNameFilter = // Declare a query using multiple string conditions
            from technology in technologies // Read every technology from the collection
            where technology.Length >= 4 && technology.Contains("a") // Keep names having at least four characters and containing lowercase a
            select technology; // Select the filtered technology name

        Console.WriteLine("\nTechnology names having at least 4 characters and containing a:"); // Display the multiple-string-condition heading

        DisplayStrings(technologyNameFilter); // Display matching technology names

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of Employee objects
        {
            new Employee { Id = 101, Name = "Saad", Department = "Development", Salary = 65000m, Experience = 2, IsPermanent = true, City = "Pune" }, // Add the first employee
            new Employee { Id = 102, Name = "Aman", Department = "Testing", Salary = 48000m, Experience = 3, IsPermanent = true, City = "Delhi" }, // Add the second employee
            new Employee { Id = 103, Name = "Neha", Department = "Development", Salary = 75000m, Experience = 5, IsPermanent = true, City = "Pune" }, // Add the third employee
            new Employee { Id = 104, Name = "Rahul", Department = "Support", Salary = 38000m, Experience = 1, IsPermanent = false, City = "Bengaluru" }, // Add the fourth employee
            new Employee { Id = 105, Name = "Priya", Department = "Data Engineering", Salary = 82000m, Experience = 4, IsPermanent = true, City = "Hyderabad" }, // Add the fifth employee
            new Employee { Id = 106, Name = "Arjun", Department = "Development", Salary = 55000m, Experience = 2, IsPermanent = false, City = null }, // Add the sixth employee
            new Employee { Id = 107, Name = "Zoya", Department = "Data Engineering", Salary = 70000m, Experience = 3, IsPermanent = true, City = "Pune" } // Add the seventh employee
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the employee-collection heading

        DisplayEmployees(employees); // Display all employee records

        // Filter employees by department

        var developmentEmployees = // Declare a query for Development employees
            from employee in employees // Read every employee from the collection
            where employee.Department == "Development" // Keep employees belonging to Development
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees from Development department:"); // Display the department-filter heading

        DisplayEmployees(developmentEmployees); // Display Development employees

        // Filter employees by salary

        var highSalaryEmployees = // Declare a query for high-salary employees
            from employee in employees // Read every employee from the collection
            where employee.Salary >= 60000m // Keep employees earning at least sixty thousand
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees having salary greater than or equal to Rs. 60000:"); // Display the salary-filter heading

        DisplayEmployees(highSalaryEmployees); // Display high-salary employees

        // Filter employees by experience

        var experiencedEmployees = // Declare a query for experienced employees
            from employee in employees // Read every employee from the collection
            where employee.Experience >= 3 // Keep employees having at least three years of experience
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees having at least 3 years of experience:"); // Display the experience-filter heading

        DisplayEmployees(experiencedEmployees); // Display experienced employees

        // Filter employees using Boolean property

        var permanentEmployees = // Declare a query for permanent employees
            from employee in employees // Read every employee from the collection
            where employee.IsPermanent // Keep employees whose permanent status is true
            select employee; // Select the filtered employee

        Console.WriteLine("\nPermanent employees:"); // Display the Boolean-filter heading

        DisplayEmployees(permanentEmployees); // Display permanent employees

        // Filter employees using NOT operator

        var temporaryEmployees = // Declare a query for temporary employees
            from employee in employees // Read every employee from the collection
            where !employee.IsPermanent // Keep employees whose permanent status is false
            select employee; // Select the filtered employee

        Console.WriteLine("\nTemporary employees:"); // Display the NOT-condition heading

        DisplayEmployees(temporaryEmployees); // Display temporary employees

        // Filter employees using multiple object properties

        var experiencedHighSalaryEmployees = // Declare a query using salary and experience conditions
            from employee in employees // Read every employee from the collection
            where employee.Salary >= 60000m && employee.Experience >= 3 // Keep employees satisfying both conditions
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees earning at least Rs. 60000 with at least 3 years of experience:"); // Display the combined-condition heading

        DisplayEmployees(experiencedHighSalaryEmployees); // Display employees satisfying both conditions

        // Filter employees using OR condition

        var selectedDepartmentEmployees = // Declare a query for two departments
            from employee in employees // Read every employee from the collection
            where employee.Department == "Development" || employee.Department == "Data Engineering" // Keep employees belonging to either department
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees from Development or Data Engineering:"); // Display the department-OR heading

        DisplayEmployees(selectedDepartmentEmployees); // Display employees from either department

        // Filter employees by city

        var puneEmployees = // Declare a query for Pune employees
            from employee in employees // Read every employee from the collection
            where employee.City == "Pune" // Keep employees whose city is Pune
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees from Pune:"); // Display the city-filter heading

        DisplayEmployees(puneEmployees); // Display employees from Pune

        // Filter null property values

        var employeesWithoutCity = // Declare a query for employees without city information
            from employee in employees // Read every employee from the collection
            where employee.City == null // Keep employees whose city is null
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees without city information:"); // Display the null-filter heading

        DisplayEmployees(employeesWithoutCity); // Display employees having null city values

        // Filter non-null property values

        var employeesWithCity = // Declare a query for employees having city information
            from employee in employees // Read every employee from the collection
            where employee.City != null // Keep employees whose city is not null
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees having city information:"); // Display the non-null-filter heading

        DisplayEmployees(employeesWithCity); // Display employees having city information

        // Filter and select one property

        var highSalaryEmployeeNames = // Declare a query that filters employees and selects their names
            from employee in employees // Read every employee from the collection
            where employee.Salary > 60000m // Keep employees earning more than sixty thousand
            select employee.Name; // Select only the employee name

        Console.WriteLine("\nNames of employees earning more than Rs. 60000:"); // Display the filtered-property heading

        DisplayStrings(highSalaryEmployeeNames); // Display the filtered employee names

        // Filter and create anonymous objects

        var employeeSummaryQuery = // Declare a query that filters and projects employee information
            from employee in employees // Read every employee from the collection
            where employee.Department == "Data Engineering" // Keep Data Engineering employees
            select new // Create an anonymous object for every matching employee
            {
                EmployeeName = employee.Name, // Store the employee name
                EmployeeSalary = employee.Salary, // Store the employee salary
                EmployeeCity = employee.City ?? "Not available" // Store the employee city or a default value
            };

        Console.WriteLine("\nData Engineering employee summary:"); // Display the anonymous-projection heading

        foreach (var employee in employeeSummaryQuery) // Visit every anonymous result object
        {
            Console.WriteLine($"{employee.EmployeeName} | Rs. {employee.EmployeeSalary:F2} | {employee.EmployeeCity}"); // Display the projected employee information
        }

        // Combine filtering and ordering

        var orderedFilteredEmployees = // Declare a query that filters and orders employees
            from employee in employees // Read every employee from the collection
            where employee.Salary >= 50000m // Keep employees earning at least fifty thousand
            orderby employee.Salary descending // Arrange filtered employees from highest to lowest salary
            select employee; // Select the filtered and ordered employee

        Console.WriteLine("\nEmployees earning at least Rs. 50000 ordered by salary:"); // Display the filtering-and-ordering heading

        DisplayEmployees(orderedFilteredEmployees); // Display the ordered filtered employees

        // No matching result

        var noMatchingEmployees = // Declare a query that intentionally returns no employee
            from employee in employees // Read every employee from the collection
            where employee.Salary > 200000m // Keep employees earning more than two lakh
            select employee; // Select the filtered employee

        Console.WriteLine("\nEmployees earning more than Rs. 200000:"); // Display the no-result heading

        DisplayEmployees(noMatchingEmployees); // Display the no-matching-employees message

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a list for deferred-execution demonstration
        {
            10, // Add 10 to the deferred list
            20, // Add 20 to the deferred list
            30 // Add 30 to the deferred list
        };

        var deferredQuery = // Declare a query without executing it immediately
            from number in deferredNumbers // Read numbers when the query is traversed
            where number >= 20 // Keep numbers greater than or equal to twenty
            select number; // Select the filtered number

        deferredNumbers.Add(40); // Add 40 after defining the query but before executing it

        Console.WriteLine("\nDeferred query result after adding 40:"); // Display the deferred-execution heading

        DisplayNumbers(deferredQuery); // Execute the query and include the newly added value

        // Final message

        Console.WriteLine("\nAll LINQ query-expression filtering examples completed successfully."); // Display the completion message
    }
}