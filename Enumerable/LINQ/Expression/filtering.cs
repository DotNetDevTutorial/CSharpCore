/*
LINQ Filtering Operators Using Method Syntax - Complete Concept Summary

Filtering means selecting only those elements from a collection that
satisfy a given condition.

The main LINQ filtering operators are:

1. Where()
2. OfType<T>()

--------------------------------------------------
1. Where()
--------------------------------------------------

Where() returns only those elements for which the supplied condition
evaluates to true.

Basic syntax:

IEnumerable<T> result =
    collection.Where(item => condition);

Example:

IEnumerable<int> evenNumbers =
    numbers.Where(number => number % 2 == 0);

Result:

10 20 30 40

The expression:

number => number % 2 == 0

is a lambda expression.

Here:

number:
Represents the current element being checked.

=>:
Separates the lambda parameter from its condition.

number % 2 == 0:
Returns true when the number is even.

--------------------------------------------------
Filtering Objects
--------------------------------------------------

Objects can be filtered using their properties.

Example:

IEnumerable<Employee> highSalaryEmployees =
    employees.Where(employee => employee.Salary >= 60000m);

Multiple properties can be checked:

IEnumerable<Employee> result =
    employees.Where(employee =>
        employee.Department == "Development" &&
        employee.Salary >= 60000m
    );

--------------------------------------------------
Logical Operators
--------------------------------------------------

&&:
Both conditions must be true.

||:
At least one condition must be true.

!:
Reverses a Boolean value.

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

Examples:

numbers.Where(number => number >= 20 && number <= 50);

numbers.Where(number => number < 20 || number > 50);

employees.Where(employee => !employee.IsPermanent);

--------------------------------------------------
Chaining Multiple Where() Methods
--------------------------------------------------

More than one Where() method can be chained.

Syntax:

IEnumerable<int> result = numbers
    .Where(number => number >= 20)
    .Where(number => number <= 50)
    .Where(number => number % 2 == 0);

This is similar to writing:

IEnumerable<int> result = numbers.Where(number =>
    number >= 20 &&
    number <= 50 &&
    number % 2 == 0
);

Each Where() filters the result produced by the previous Where().

--------------------------------------------------
Where() with Index
--------------------------------------------------

Where() has an overload that also provides the zero-based index.

Syntax:

IEnumerable<T> result =
    collection.Where((item, index) => condition);

Example:

IEnumerable<int> result =
    numbers.Where((number, index) => index % 2 == 0);

This returns elements located at indexes:

0, 2, 4, 6, ...

Important:

The index represents the element's position in the sequence being
processed by that particular Where() operation.

--------------------------------------------------
Filtering Strings
--------------------------------------------------

Useful string members include:

StartsWith():
Checks whether text starts with specified characters.

EndsWith():
Checks whether text ends with specified characters.

Contains():
Checks whether text contains specified characters.

Length:
Returns the number of characters.

string.Equals():
Can perform case-insensitive equality comparison.

Examples:

technologies.Where(value => value.StartsWith("P"));

technologies.Where(value => value.EndsWith("Script"));

technologies.Where(value => value.Contains("Java"));

technologies.Where(value => value.Length > 5);

Case-insensitive comparison:

technologies.Where(value =>
    string.Equals(
        value,
        searchText,
        StringComparison.OrdinalIgnoreCase
    )
);

--------------------------------------------------
Filtering Null Values
--------------------------------------------------

Select null values:

values.Where(value => value == null);

Remove null values:

values.Where(value => value != null);

For nullable strings:

employees.Where(employee =>
    !string.IsNullOrWhiteSpace(employee.City)
);

--------------------------------------------------
Using an External Variable
--------------------------------------------------

A condition can use a variable declared outside the lambda.

Example:

decimal minimumSalary = 60000m;

IEnumerable<Employee> result =
    employees.Where(employee =>
        employee.Salary >= minimumSalary
    );

The external variable is captured by the lambda expression.

--------------------------------------------------
Using a Predicate Variable
--------------------------------------------------

A filtering condition can be stored in a Func<T, bool> variable.

Syntax:

Func<int, bool> condition =
    number => number % 2 == 0;

IEnumerable<int> result =
    numbers.Where(condition);

For employees:

Func<Employee, bool> condition =
    employee => employee.Salary >= 60000m;

IEnumerable<Employee> result =
    employees.Where(condition);

--------------------------------------------------
Using a Named Method
--------------------------------------------------

A named method returning bool can be supplied to Where().

Example:

static bool IsHighSalary(Employee employee)
{
    return employee.Salary >= 60000m;
}

IEnumerable<Employee> result =
    employees.Where(IsHighSalary);

--------------------------------------------------
Filtering and Projection
--------------------------------------------------

Where() can be followed by Select().

Example:

IEnumerable<string> names = employees
    .Where(employee => employee.Salary >= 60000m)
    .Select(employee => employee.Name);

Where():
Chooses which source elements are included.

Select():
Transforms the selected elements.

--------------------------------------------------
Filtering and Ordering
--------------------------------------------------

Where() can be followed by OrderBy() or OrderByDescending().

Example:

IEnumerable<Employee> result = employees
    .Where(employee => employee.Salary >= 60000m)
    .OrderByDescending(employee => employee.Salary);

--------------------------------------------------
Filtering Nested Collections
--------------------------------------------------

Any() can be used inside Where() to filter parent objects according
to their nested collections.

Example:

IEnumerable<Student> result = students.Where(student =>
    student.Marks.Any(mark => mark >= 90)
);

This selects students having at least one mark of 90 or above.

All() can also be used:

IEnumerable<Student> result = students.Where(student =>
    student.Marks.Count > 0 &&
    student.Marks.All(mark => mark >= 40)
);

This selects students whose marks all satisfy the condition.

--------------------------------------------------
2. OfType<T>()
--------------------------------------------------

OfType<T>() filters a non-generic or mixed-type collection and returns
only elements compatible with the specified type.

Syntax:

IEnumerable<T> result =
    collection.OfType<T>();

Example:

ArrayList values = new ArrayList()
{
    10,
    "C#",
    20,
    true,
    "LINQ"
};

IEnumerable<int> numbers =
    values.OfType<int>();

Result:

10
20

OfType<T>():

1. Keeps only compatible values.
2. Ignores incompatible values.
3. Ignores null values.
4. Does not throw for incompatible elements.
5. Normally uses deferred execution.

Difference between OfType<T>() and Cast<T>():

OfType<T>():
Skips incompatible values.

Cast<T>():
Attempts to cast every element and throws InvalidCastException when
an incompatible value is found.

--------------------------------------------------
Deferred Execution
--------------------------------------------------

Where() and OfType<T>() normally use deferred execution.

Example:

IEnumerable<int> result =
    numbers.Where(number => number >= 20);

The query is defined but is not immediately executed.

It executes when traversed using:

foreach
ToList()
ToArray()
Count()
First()
Sum()
or another terminal operation.

Values added before traversal may appear in the result.

--------------------------------------------------
Immediate Materialization
--------------------------------------------------

ToList() and ToArray() execute the filtering query immediately.

Example:

List<int> snapshot = numbers
    .Where(number => number >= 20)
    .ToList();

The created list is a snapshot.

Later changes to the original collection do not automatically change
the snapshot.

--------------------------------------------------
Where() and List<T>.FindAll() Difference
--------------------------------------------------

Where():

- Is a LINQ extension method.
- Works with IEnumerable<T>.
- Returns IEnumerable<T>.
- Normally uses deferred execution.

FindAll():

- Is a List<T> method.
- Works only with List<T>.
- Returns List<T>.
- Executes immediately.

--------------------------------------------------
Time Complexity
--------------------------------------------------

Where():
O(n) for complete traversal.

OfType<T>():
O(n) for complete traversal.

Where().ToList():
O(n) time and O(k) additional memory.

Here:

n = total number of source elements
k = number of elements satisfying the condition

--------------------------------------------------
Important Points
--------------------------------------------------

1. Where() does not modify the original collection.
2. It returns a filtered sequence.
3. The predicate must return bool.
4. true keeps the current element.
5. false removes the current element from the result.
6. Multiple conditions can use && and ||.
7. Multiple Where() calls can be chained.
8. The index-aware overload provides element positions.
9. Where() normally uses deferred execution.
10. ToList() or ToArray() creates an immediate snapshot.
11. OfType<T>() filters elements according to runtime type.
12. Filtering can be combined with projection, ordering, grouping,
    aggregation and other LINQ operations.

Required namespaces:

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
*/

#nullable enable // Enable nullable-reference-type analysis

using System; // Import basic classes such as Console and StringComparison
using System.Collections; // Import non-generic collections such as ArrayList
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ methods such as Where() and OfType<T>()

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string? City { get; set; } // Store the employee city or null

    public decimal Salary { get; set; } // Store the monthly employee salary

    public int Experience { get; set; } // Store the employee experience in years

    public bool IsPermanent { get; set; } // Store whether the employee is permanent
}

class Product // Define a class representing a product
{
    public int Id { get; set; } // Store the product identifier

    public string Name { get; set; } = ""; // Store the product name

    public string Category { get; set; } = ""; // Store the product category

    public decimal Price { get; set; } // Store the product price

    public int Stock { get; set; } // Store the available quantity

    public bool IsAvailable { get; set; } // Store whether the product is available
}

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public string Course { get; set; } = ""; // Store the student course

    public List<int> Marks { get; set; } = new List<int>(); // Store the marks obtained by the student
}

class FilteringProgram // Define the main program class
{
    // Check high-salary employee

    static bool IsHighSalaryEmployee(Employee employee) // Define a named predicate method
    {
        return employee.Salary >= 60000m; // Return true when the employee earns at least sixty thousand
    }

    // Check prime number

    static bool IsPrime(int number) // Define a method that checks whether a number is prime
    {
        if (number < 2) // Check whether the number is smaller than two
        {
            return false; // Return false because numbers below two are not prime
        }

        for (int divisor = 2; divisor * divisor <= number; divisor++) // Test possible divisors up to the square root
        {
            if (number % divisor == 0) // Check whether the number is exactly divisible
            {
                return false; // Return false because a divisor was found
            }
        }

        return true; // Return true because no divisor was found
    }

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
            Console.Write("No matching values"); // Display an empty-result message
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
            Console.WriteLine("No matching values"); // Display an empty-result message
        }
    }

    // Display employees

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        bool employeeFound = false; // Track whether the sequence contains any employee

        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City ?? "Not available"} | Rs. {employee.Salary:F2} | Experience: {employee.Experience} years | Permanent: {employee.IsPermanent}"); // Display the employee details

            employeeFound = true; // Record that at least one employee was found
        }

        if (!employeeFound) // Check whether the employee sequence was empty
        {
            Console.WriteLine("No matching employees"); // Display an empty-result message
        }
    }

    // Display products

    static void DisplayProducts(IEnumerable<Product> products) // Define a method that accepts a product sequence
    {
        bool productFound = false; // Track whether the sequence contains any product

        foreach (Product product in products) // Visit every product in the sequence
        {
            Console.WriteLine($"{product.Id} | {product.Name} | {product.Category} | Rs. {product.Price:F2} | Stock: {product.Stock} | Available: {product.IsAvailable}"); // Display the product details

            productFound = true; // Record that at least one product was found
        }

        if (!productFound) // Check whether the product sequence was empty
        {
            Console.WriteLine("No matching products"); // Display an empty-result message
        }
    }

    // Display students

    static void DisplayStudents(IEnumerable<Student> students) // Define a method that accepts a student sequence
    {
        bool studentFound = false; // Track whether the sequence contains any student

        foreach (Student student in students) // Visit every student in the sequence
        {
            string marksText = student.Marks.Count == 0 ? "No marks" : string.Join(", ", student.Marks); // Create readable marks text

            Console.WriteLine($"{student.Id} | {student.Name} | {student.Course} | Marks: {marksText}"); // Display the student details

            studentFound = true; // Record that at least one student was found
        }

        if (!studentFound) // Check whether the student sequence was empty
        {
            Console.WriteLine("No matching students"); // Display an empty-result message
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a collection of integer values
        {
            5, // Add 5 to the collection
            10, // Add 10 to the collection
            15, // Add 15 to the collection
            20, // Add 20 to the collection
            25, // Add 25 to the collection
            30, // Add 30 to the collection
            35, // Add 35 to the collection
            40, // Add 40 to the collection
            45, // Add 45 to the collection
            50, // Add 50 to the collection
            55, // Add 55 to the collection
            60 // Add 60 to the collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all original numbers

        // Filter even numbers

        IEnumerable<int> evenNumbers = numbers.Where(number => number % 2 == 0); // Keep numbers divisible by two

        Console.WriteLine("\nEven numbers:"); // Display the even-number heading

        DisplayNumbers(evenNumbers); // Display the filtered even numbers

        // Filter odd numbers

        IEnumerable<int> oddNumbers = numbers.Where(number => number % 2 != 0); // Keep numbers not divisible by two

        Console.WriteLine("\nOdd numbers:"); // Display the odd-number heading

        DisplayNumbers(oddNumbers); // Display the filtered odd numbers

        // Filter greater values

        IEnumerable<int> numbersGreaterThanThirty = numbers.Where(number => number > 30); // Keep numbers greater than thirty

        Console.WriteLine("\nNumbers greater than 30:"); // Display the greater-than heading

        DisplayNumbers(numbersGreaterThanThirty); // Display matching numbers

        // Filter smaller values

        IEnumerable<int> numbersBelowThirty = numbers.Where(number => number < 30); // Keep numbers smaller than thirty

        Console.WriteLine("\nNumbers below 30:"); // Display the smaller-than heading

        DisplayNumbers(numbersBelowThirty); // Display matching numbers

        // Filter an inclusive range

        IEnumerable<int> numbersWithinRange = numbers.Where(number => number >= 20 && number <= 45); // Keep numbers from twenty through forty-five

        Console.WriteLine("\nNumbers between 20 and 45:"); // Display the range heading

        DisplayNumbers(numbersWithinRange); // Display numbers within the inclusive range

        // Filter an exclusive range

        IEnumerable<int> exclusiveRangeNumbers = numbers.Where(number => number > 20 && number < 45); // Keep numbers strictly between twenty and forty-five

        Console.WriteLine("\nNumbers strictly between 20 and 45:"); // Display the exclusive-range heading

        DisplayNumbers(exclusiveRangeNumbers); // Display numbers inside the exclusive range

        // Filter using OR

        IEnumerable<int> smallOrLargeNumbers = numbers.Where(number => number <= 15 || number >= 50); // Keep small or large numbers

        Console.WriteLine("\nNumbers less than or equal to 15 or greater than or equal to 50:"); // Display the OR-condition heading

        DisplayNumbers(smallOrLargeNumbers); // Display values satisfying either condition

        // Filter using several conditions

        IEnumerable<int> divisibleByTwoAndFive = numbers.Where(number => number % 2 == 0 && number % 5 == 0); // Keep numbers divisible by both two and five

        Console.WriteLine("\nNumbers divisible by both 2 and 5:"); // Display the multiple-condition heading

        DisplayNumbers(divisibleByTwoAndFive); // Display matching values

        // Filter using chained Where methods

        IEnumerable<int> chainedWhereResult = numbers // Begin with the number collection
            .Where(number => number >= 15) // Keep numbers greater than or equal to fifteen
            .Where(number => number <= 50) // Keep remaining numbers smaller than or equal to fifty
            .Where(number => number % 2 == 0); // Keep remaining even numbers

        Console.WriteLine("\nEven numbers from 15 through 50 using chained Where():"); // Display the chained-Where heading

        DisplayNumbers(chainedWhereResult); // Display the final filtered sequence

        // Filter using calculated condition

        IEnumerable<int> numbersWithLargeSquares = numbers.Where(number => number * number > 1000); // Keep numbers whose square exceeds one thousand

        Console.WriteLine("\nNumbers whose square is greater than 1000:"); // Display the calculated-condition heading

        DisplayNumbers(numbersWithLargeSquares); // Display matching numbers

        // Filter prime numbers

        IEnumerable<int> primeNumbers = numbers.Where(IsPrime); // Keep numbers for which the named prime-checking method returns true

        Console.WriteLine("\nPrime numbers:"); // Display the prime-number heading

        DisplayNumbers(primeNumbers); // Display the prime values

        // Filter using external variable

        int minimumValue = 25; // Store the minimum accepted value

        IEnumerable<int> dynamicMinimumResult = numbers.Where(number => number >= minimumValue); // Use the external value inside the lambda expression

        Console.WriteLine("\nNumbers greater than or equal to " + minimumValue + ":"); // Display the external-variable heading

        DisplayNumbers(dynamicMinimumResult); // Display matching numbers

        // Change captured external variable

        minimumValue = 45; // Change the captured minimum before query traversal

        Console.WriteLine("\nSame deferred query after changing minimumValue to 45:"); // Display the captured-variable heading

        DisplayNumbers(dynamicMinimumResult); // Execute the query using the changed variable value

        // Use predicate variable

        Func<int, bool> divisibleByThreeCondition = number => number % 3 == 0; // Store a filtering condition in a delegate variable

        IEnumerable<int> divisibleByThreeNumbers = numbers.Where(divisibleByThreeCondition); // Supply the predicate variable to Where()

        Console.WriteLine("\nNumbers divisible by 3 using Func<int, bool>:"); // Display the predicate-variable heading

        DisplayNumbers(divisibleByThreeNumbers); // Display numbers divisible by three

        // Filter using index-aware Where

        IEnumerable<int> valuesAtEvenIndexes = numbers.Where((number, index) => index % 2 == 0); // Keep elements located at even indexes

        Console.WriteLine("\nValues located at even indexes:"); // Display the index-filter heading

        DisplayNumbers(valuesAtEvenIndexes); // Display values from indexes zero, two, four and so on

        // Filter using value and index

        IEnumerable<int> indexAndValueResult = numbers.Where((number, index) => index >= 3 && number >= 30); // Keep elements satisfying both index and value conditions

        Console.WriteLine("\nNumbers of at least 30 located from index 3 onward:"); // Display the value-and-index heading

        DisplayNumbers(indexAndValueResult); // Display matching values

        // Filter then project

        IEnumerable<int> filteredSquares = numbers // Begin with the number collection
            .Where(number => number >= 30) // Keep numbers of at least thirty
            .Select(number => number * number); // Project each matching number into its square

        Console.WriteLine("\nSquares of numbers greater than or equal to 30:"); // Display the filter-and-projection heading

        DisplayNumbers(filteredSquares); // Display the projected square values

        // Filter then order

        IEnumerable<int> descendingFilteredNumbers = numbers // Begin with the number collection
            .Where(number => number >= 20 && number <= 50) // Keep numbers within the selected range
            .OrderByDescending(number => number); // Arrange matching values from largest to smallest

        Console.WriteLine("\nNumbers from 20 through 50 in descending order:"); // Display the filter-and-order heading

        DisplayNumbers(descendingFilteredNumbers); // Display the ordered filtered values

        // Filter with no result

        IEnumerable<int> noMatchingNumbers = numbers.Where(number => number > 1000); // Create a sequence with no matching values

        Console.WriteLine("\nNumbers greater than 1000:"); // Display the empty-filter heading

        DisplayNumbers(noMatchingNumbers); // Display the no-matching-values message

        // Create string collection

        List<string> technologies = new List<string>() // Create a collection of technology names
        {
            "C#", // Add C# to the collection
            "Python", // Add Python to the collection
            "Java", // Add Java to the collection
            "JavaScript", // Add JavaScript to the collection
            "SQL", // Add SQL to the collection
            "MongoDB", // Add MongoDB to the collection
            "PySpark", // Add PySpark to the collection
            "Azure", // Add Azure to the collection
            "Databricks" // Add Databricks to the collection
        };

        Console.WriteLine("\nOriginal technology collection:"); // Display the technology heading

        DisplayStrings(technologies); // Display all technologies

        // Filter by string length

        IEnumerable<string> longTechnologyNames = technologies.Where(technology => technology.Length > 5); // Keep names longer than five characters

        Console.WriteLine("\nTechnology names longer than 5 characters:"); // Display the length-filter heading

        DisplayStrings(longTechnologyNames); // Display matching technology names

        // Filter using StartsWith

        IEnumerable<string> technologiesStartingWithP = technologies.Where(technology => technology.StartsWith("P")); // Keep names beginning with uppercase P

        Console.WriteLine("\nTechnology names starting with P:"); // Display the StartsWith heading

        DisplayStrings(technologiesStartingWithP); // Display matching names

        // Filter using EndsWith

        IEnumerable<string> technologiesEndingWithScript = technologies.Where(technology => technology.EndsWith("Script")); // Keep names ending with Script

        Console.WriteLine("\nTechnology names ending with Script:"); // Display the EndsWith heading

        DisplayStrings(technologiesEndingWithScript); // Display matching names

        // Filter using Contains

        IEnumerable<string> technologiesContainingJava = technologies.Where(technology => technology.Contains("Java")); // Keep names containing Java

        Console.WriteLine("\nTechnology names containing Java:"); // Display the Contains heading

        DisplayStrings(technologiesContainingJava); // Display matching names

        // Case-insensitive string filtering

        string searchTechnology = "python"; // Store lowercase search text

        IEnumerable<string> caseInsensitiveTechnologyResult = technologies.Where(technology => // Filter technology names
            string.Equals(technology, searchTechnology, StringComparison.OrdinalIgnoreCase)); // Compare names without considering letter case

        Console.WriteLine("\nCase-insensitive search for python:"); // Display the case-insensitive heading

        DisplayStrings(caseInsensitiveTechnologyResult); // Display the matching original value

        // Filter using several string conditions

        IEnumerable<string> selectedTechnologyNames = technologies.Where(technology => // Begin filtering technology names
            technology.Length >= 4 && // Require at least four characters
            technology.Contains("a", StringComparison.OrdinalIgnoreCase)); // Require the letter a without considering case

        Console.WriteLine("\nTechnology names having at least 4 characters and containing a:"); // Display the multiple-string-condition heading

        DisplayStrings(selectedTechnologyNames); // Display matching technologies

        // Create nullable string collection

        List<string?> nullableValues = new List<string?>() // Create a collection containing valid, null and blank strings
        {
            "C#", // Add a valid string
            null, // Add a null value
            "Python", // Add another valid string
            "", // Add an empty string
            "   ", // Add a whitespace-only string
            "LINQ" // Add another valid string
        };

        // Remove null and blank strings

        IEnumerable<string> validTextValues = nullableValues // Begin with the nullable string collection
            .Where(value => !string.IsNullOrWhiteSpace(value)) // Keep only non-null and non-blank values
            .Select(value => value!); // Inform the compiler that remaining values are non-null

        Console.WriteLine("\nNon-null and non-blank text values:"); // Display the null-filter heading

        DisplayStrings(validTextValues); // Display valid text values

        // Select only null values

        IEnumerable<string?> nullTextValues = nullableValues.Where(value => value == null); // Keep only null elements

        int nullValueCount = nullTextValues.Count(); // Count the null elements

        Console.WriteLine("\nNumber of null string values: " + nullValueCount); // Display the null-value count

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of employee objects
        {
            new Employee { Id = 101, Name = "Saad", Department = "Development", City = "Pune", Salary = 65000m, Experience = 2, IsPermanent = true }, // Add the first employee
            new Employee { Id = 102, Name = "Aman", Department = "Testing", City = "Delhi", Salary = 48000m, Experience = 3, IsPermanent = true }, // Add the second employee
            new Employee { Id = 103, Name = "Neha", Department = "Development", City = "Pune", Salary = 75000m, Experience = 5, IsPermanent = true }, // Add the third employee
            new Employee { Id = 104, Name = "Rahul", Department = "Support", City = "Bengaluru", Salary = 38000m, Experience = 1, IsPermanent = false }, // Add the fourth employee
            new Employee { Id = 105, Name = "Priya", Department = "Data Engineering", City = "Hyderabad", Salary = 82000m, Experience = 4, IsPermanent = true }, // Add the fifth employee
            new Employee { Id = 106, Name = "Arjun", Department = "Development", City = "Delhi", Salary = 55000m, Experience = 2, IsPermanent = false }, // Add the sixth employee
            new Employee { Id = 107, Name = "Zoya", Department = "Data Engineering", City = "Pune", Salary = 70000m, Experience = 3, IsPermanent = true }, // Add the seventh employee
            new Employee { Id = 108, Name = "Karan", Department = "Testing", City = "Pune", Salary = 52000m, Experience = 4, IsPermanent = false }, // Add the eighth employee
            new Employee { Id = 109, Name = "Meera", Department = "Support", City = null, Salary = 45000m, Experience = 2, IsPermanent = true }, // Add an employee without city information
            new Employee { Id = 110, Name = "Ananya", Department = "Data Engineering", City = "Hyderabad", Salary = 90000m, Experience = 6, IsPermanent = true } // Add the tenth employee
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the employee heading

        DisplayEmployees(employees); // Display all employees

        // Filter by department

        IEnumerable<Employee> developmentEmployees = employees.Where(employee => employee.Department == "Development"); // Keep Development employees

        Console.WriteLine("\nDevelopment employees:"); // Display the department-filter heading

        DisplayEmployees(developmentEmployees); // Display Development employees

        // Filter by salary

        IEnumerable<Employee> highSalaryEmployees = employees.Where(employee => employee.Salary >= 60000m); // Keep employees earning at least sixty thousand

        Console.WriteLine("\nEmployees earning at least Rs. 60000:"); // Display the salary-filter heading

        DisplayEmployees(highSalaryEmployees); // Display matching employees

        // Use named predicate method

        IEnumerable<Employee> employeesFromNamedPredicate = employees.Where(IsHighSalaryEmployee); // Filter employees using the named method

        Console.WriteLine("\nHigh-salary employees using a named predicate method:"); // Display the named-method heading

        DisplayEmployees(employeesFromNamedPredicate); // Display matching employees

        // Use predicate variable with objects

        Func<Employee, bool> experiencedEmployeeCondition = employee => employee.Experience >= 4; // Store an employee predicate in a delegate

        IEnumerable<Employee> experiencedEmployees = employees.Where(experiencedEmployeeCondition); // Keep employees having at least four years of experience

        Console.WriteLine("\nEmployees having at least 4 years of experience:"); // Display the experience-filter heading

        DisplayEmployees(experiencedEmployees); // Display experienced employees

        // Filter by Boolean property

        IEnumerable<Employee> permanentEmployees = employees.Where(employee => employee.IsPermanent); // Keep permanent employees

        Console.WriteLine("\nPermanent employees:"); // Display the Boolean-filter heading

        DisplayEmployees(permanentEmployees); // Display permanent employees

        // Filter using NOT

        IEnumerable<Employee> temporaryEmployees = employees.Where(employee => !employee.IsPermanent); // Keep employees whose permanent status is false

        Console.WriteLine("\nTemporary employees:"); // Display the NOT-filter heading

        DisplayEmployees(temporaryEmployees); // Display temporary employees

        // Filter using multiple object properties

        IEnumerable<Employee> experiencedHighSalaryEmployees = employees.Where(employee => // Begin filtering employees
            employee.Experience >= 3 && // Require at least three years of experience
            employee.Salary >= 60000m); // Require salary of at least sixty thousand

        Console.WriteLine("\nEmployees having at least 3 years of experience and salary of at least Rs. 60000:"); // Display the combined-filter heading

        DisplayEmployees(experiencedHighSalaryEmployees); // Display matching employees

        // Filter using OR on object properties

        IEnumerable<Employee> selectedDepartmentEmployees = employees.Where(employee => // Begin filtering employees
            employee.Department == "Development" || // Accept Development employees
            employee.Department == "Data Engineering"); // Accept Data Engineering employees

        Console.WriteLine("\nDevelopment or Data Engineering employees:"); // Display the department-OR heading

        DisplayEmployees(selectedDepartmentEmployees); // Display matching employees

        // Filter by salary range

        IEnumerable<Employee> middleSalaryEmployees = employees.Where(employee => // Begin filtering employees
            employee.Salary >= 50000m && // Require salary of at least fifty thousand
            employee.Salary <= 75000m); // Require salary not exceeding seventy-five thousand

        Console.WriteLine("\nEmployees earning between Rs. 50000 and Rs. 75000:"); // Display the salary-range heading

        DisplayEmployees(middleSalaryEmployees); // Display matching employees

        // Filter by city

        IEnumerable<Employee> puneEmployees = employees.Where(employee => employee.City == "Pune"); // Keep employees located in Pune

        Console.WriteLine("\nEmployees from Pune:"); // Display the city-filter heading

        DisplayEmployees(puneEmployees); // Display Pune employees

        // Filter null city values

        IEnumerable<Employee> employeesWithoutCity = employees.Where(employee => employee.City == null); // Keep employees whose city is null

        Console.WriteLine("\nEmployees without city information:"); // Display the null-city heading

        DisplayEmployees(employeesWithoutCity); // Display employees without city information

        // Filter non-null city values

        IEnumerable<Employee> employeesWithCity = employees.Where(employee => !string.IsNullOrWhiteSpace(employee.City)); // Keep employees having usable city information

        Console.WriteLine("\nEmployees having city information:"); // Display the non-null-city heading

        DisplayEmployees(employeesWithCity); // Display employees having city information

        // Case-insensitive department filter

        string requiredDepartment = "data engineering"; // Store lowercase department search text

        IEnumerable<Employee> caseInsensitiveDepartmentEmployees = employees.Where(employee => // Begin filtering employees
            string.Equals(employee.Department, requiredDepartment, StringComparison.OrdinalIgnoreCase)); // Compare departments without considering case

        Console.WriteLine("\nCase-insensitive Data Engineering department search:"); // Display the case-insensitive-object heading

        DisplayEmployees(caseInsensitiveDepartmentEmployees); // Display matching employees

        // Filter then order employees

        IEnumerable<Employee> orderedHighSalaryEmployees = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 55000m) // Keep employees earning at least fifty-five thousand
            .OrderByDescending(employee => employee.Salary) // Arrange employees by descending salary
            .ThenBy(employee => employee.Name); // Arrange equal salaries alphabetically

        Console.WriteLine("\nEmployees earning at least Rs. 55000 ordered by salary:"); // Display the filter-and-order heading

        DisplayEmployees(orderedHighSalaryEmployees); // Display ordered matching employees

        // Filter then project employee names

        IEnumerable<string> highSalaryEmployeeNames = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 70000m) // Keep employees earning at least seventy thousand
            .Select(employee => employee.Name); // Select only the employee name

        Console.WriteLine("\nNames of employees earning at least Rs. 70000:"); // Display the filter-and-projection heading

        DisplayStrings(highSalaryEmployeeNames); // Display projected names

        // Filter and create anonymous objects

        var employeeSummaryQuery = employees // Begin with the employee collection
            .Where(employee => employee.Department == "Data Engineering") // Keep Data Engineering employees
            .Select(employee => new // Create an anonymous summary object
            {
                employee.Name, // Store the employee name
                employee.Salary, // Store the employee salary
                City = employee.City ?? "Not available" // Store the actual city or a replacement value
            });

        Console.WriteLine("\nData Engineering employee summaries:"); // Display the anonymous-projection heading

        foreach (var employee in employeeSummaryQuery) // Visit every projected summary
        {
            Console.WriteLine($"{employee.Name} | Rs. {employee.Salary:F2} | {employee.City}"); // Display the summary information
        }

        // Dynamic optional filtering

        string? optionalDepartment = "Development"; // Store an optional department filter

        decimal? optionalMinimumSalary = 60000m; // Store an optional minimum-salary filter

        string? optionalCity = null; // Store an optional city filter that is currently disabled

        IEnumerable<Employee> dynamicEmployeeQuery = employees.AsEnumerable(); // Start with all employees as an enumerable sequence

        if (!string.IsNullOrWhiteSpace(optionalDepartment)) // Check whether a department filter was supplied
        {
            dynamicEmployeeQuery = dynamicEmployeeQuery.Where(employee => // Add another filtering stage
                string.Equals(employee.Department, optionalDepartment, StringComparison.OrdinalIgnoreCase)); // Keep the requested department
        }

        if (optionalMinimumSalary.HasValue) // Check whether a minimum salary was supplied
        {
            dynamicEmployeeQuery = dynamicEmployeeQuery.Where(employee => employee.Salary >= optionalMinimumSalary.Value); // Keep employees meeting the salary requirement
        }

        if (!string.IsNullOrWhiteSpace(optionalCity)) // Check whether a city filter was supplied
        {
            dynamicEmployeeQuery = dynamicEmployeeQuery.Where(employee => // Add the city filtering stage
                string.Equals(employee.City, optionalCity, StringComparison.OrdinalIgnoreCase)); // Keep employees from the requested city
        }

        Console.WriteLine("\nDynamic optional employee filtering result:"); // Display the dynamic-filter heading

        DisplayEmployees(dynamicEmployeeQuery); // Display employees satisfying enabled filters

        // Group after filtering

        var filteredDepartmentGroups = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 50000m) // Keep employees earning at least fifty thousand
            .GroupBy(employee => employee.Department) // Group the filtered employees by department
            .OrderBy(group => group.Key); // Arrange department groups alphabetically

        Console.WriteLine("\nEmployees earning at least Rs. 50000 grouped by department:"); // Display the filtering-and-grouping heading

        foreach (IGrouping<string, Employee> departmentGroup in filteredDepartmentGroups) // Visit every department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department key

            DisplayEmployees(departmentGroup); // Display employees in the current group
        }

        // Create product collection

        List<Product> products = new List<Product>() // Create a collection of product objects
        {
            new Product { Id = 201, Name = "Laptop", Category = "Electronics", Price = 65000m, Stock = 5, IsAvailable = true }, // Add the Laptop product
            new Product { Id = 202, Name = "Mouse", Category = "Electronics", Price = 800m, Stock = 20, IsAvailable = true }, // Add the Mouse product
            new Product { Id = 203, Name = "Chair", Category = "Furniture", Price = 6000m, Stock = 7, IsAvailable = true }, // Add the Chair product
            new Product { Id = 204, Name = "Notebook", Category = "Stationery", Price = 100m, Stock = 0, IsAvailable = false }, // Add the Notebook product
            new Product { Id = 205, Name = "Monitor", Category = "Electronics", Price = 18000m, Stock = 8, IsAvailable = true }, // Add the Monitor product
            new Product { Id = 206, Name = "Table", Category = "Furniture", Price = 9000m, Stock = 0, IsAvailable = false } // Add the Table product
        };

        Console.WriteLine("\nOriginal product collection:"); // Display the product heading

        DisplayProducts(products); // Display all products

        // Filter available products

        IEnumerable<Product> availableProducts = products.Where(product => product.IsAvailable); // Keep available products

        Console.WriteLine("\nAvailable products:"); // Display the available-product heading

        DisplayProducts(availableProducts); // Display available products

        // Filter out-of-stock products

        IEnumerable<Product> outOfStockProducts = products.Where(product => product.Stock == 0); // Keep products having zero stock

        Console.WriteLine("\nOut-of-stock products:"); // Display the stock-filter heading

        DisplayProducts(outOfStockProducts); // Display out-of-stock products

        // Filter by category and price

        IEnumerable<Product> affordableElectronics = products.Where(product => // Begin filtering products
            product.Category == "Electronics" && // Require the Electronics category
            product.Price <= 20000m); // Require a price not exceeding twenty thousand

        Console.WriteLine("\nElectronics costing at most Rs. 20000:"); // Display the product-condition heading

        DisplayProducts(affordableElectronics); // Display matching products

        // Filter products by inventory value

        IEnumerable<Product> highInventoryValueProducts = products.Where(product => product.Price * product.Stock >= 50000m); // Keep products whose total inventory value is at least fifty thousand

        Console.WriteLine("\nProducts having inventory value of at least Rs. 50000:"); // Display the calculated-product heading

        DisplayProducts(highInventoryValueProducts); // Display matching products

        // Create student collection

        List<Student> students = new List<Student>() // Create a collection of student objects
        {
            new Student { Id = 301, Name = "Ali", Course = "Data Engineering", Marks = new List<int>() { 85, 90, 88 } }, // Add the first student
            new Student { Id = 302, Name = "Riya", Course = "Development", Marks = new List<int>() { 70, 75, 80 } }, // Add the second student
            new Student { Id = 303, Name = "Kabir", Course = "Testing", Marks = new List<int>() { 35, 45, 40 } }, // Add the third student
            new Student { Id = 304, Name = "Meera", Course = "Data Engineering", Marks = new List<int>() { 95, 92, 89 } }, // Add the fourth student
            new Student { Id = 305, Name = "Arjun", Course = "Development", Marks = new List<int>() } // Add a student having no marks
        };

        Console.WriteLine("\nOriginal student collection:"); // Display the student heading

        DisplayStudents(students); // Display all students

        // Filter students using Any

        IEnumerable<Student> studentsHavingNinetyOrMore = students.Where(student => // Begin filtering students
            student.Marks.Any(mark => mark >= 90)); // Keep students having at least one mark of ninety or above

        Console.WriteLine("\nStudents having at least one mark of 90 or above:"); // Display the nested-Any heading

        DisplayStudents(studentsHavingNinetyOrMore); // Display matching students

        // Filter students using All

        IEnumerable<Student> studentsPassingEverySubject = students.Where(student => // Begin filtering students
            student.Marks.Count > 0 && // Require at least one mark
            student.Marks.All(mark => mark >= 40)); // Require every mark to be at least forty

        Console.WriteLine("\nStudents passing every subject:"); // Display the nested-All heading

        DisplayStudents(studentsPassingEverySubject); // Display matching students

        // Filter students using average

        IEnumerable<Student> highAverageStudents = students.Where(student => // Begin filtering students
            student.Marks.Count > 0 && // Avoid calculating Average() for an empty collection
            student.Marks.Average() >= 80); // Keep students having an average of at least eighty

        Console.WriteLine("\nStudents having an average of at least 80:"); // Display the average-filter heading

        DisplayStudents(highAverageStudents); // Display high-average students

        // Create mixed collection

        ArrayList mixedValues = new ArrayList() // Create a non-generic collection containing different runtime types
        {
            10, // Add an integer
            "C#", // Add a string
            20, // Add another integer
            true, // Add a Boolean value
            "LINQ", // Add another string
            45.5, // Add a double value
            null, // Add a null value
            30 // Add another integer
        };

        Console.WriteLine("\nOriginal mixed ArrayList values:"); // Display the mixed-collection heading

        foreach (object? value in mixedValues) // Visit every object in the mixed collection
        {
            Console.WriteLine(value == null ? "null" : $"{value} | Type: {value.GetType().Name}"); // Display the value and runtime type
        }

        // Filter integers using OfType

        IEnumerable<int> integerValues = mixedValues.OfType<int>(); // Keep only values compatible with int

        Console.WriteLine("\nInteger values selected using OfType<int>():"); // Display the integer-OfType heading

        DisplayNumbers(integerValues); // Display integer values

        // Filter strings using OfType

        IEnumerable<string> stringValues = mixedValues.OfType<string>(); // Keep only values compatible with string

        Console.WriteLine("\nString values selected using OfType<string>():"); // Display the string-OfType heading

        DisplayStrings(stringValues); // Display string values

        // Combine OfType and Where

        IEnumerable<int> filteredMixedIntegers = mixedValues // Begin with the mixed collection
            .OfType<int>() // Keep only integer values
            .Where(number => number >= 20); // Keep integers greater than or equal to twenty

        Console.WriteLine("\nIntegers of at least 20 selected using OfType() and Where():"); // Display the combined-filter heading

        DisplayNumbers(filteredMixedIntegers); // Display matching integers

        // Filter dictionary entries

        Dictionary<string, int> technologyExperience = new Dictionary<string, int>() // Create a dictionary of technology experience values
        {
            ["C#"] = 2, // Store two years for C#
            ["Python"] = 4, // Store four years for Python
            ["SQL"] = 3, // Store three years for SQL
            ["MongoDB"] = 1, // Store one year for MongoDB
            ["PySpark"] = 2 // Store two years for PySpark
        };

        IEnumerable<KeyValuePair<string, int>> experiencedTechnologies = technologyExperience // Begin with the dictionary entries
            .Where(entry => entry.Value >= 2) // Keep entries having at least two years
            .OrderByDescending(entry => entry.Value); // Arrange entries from highest to lowest experience

        Console.WriteLine("\nTechnologies having at least 2 years of experience:"); // Display the dictionary-filter heading

        foreach (KeyValuePair<string, int> entry in experiencedTechnologies) // Visit every matching dictionary entry
        {
            Console.WriteLine(entry.Key + " -> " + entry.Value + " year(s)"); // Display the technology and experience
        }

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a collection for deferred-execution demonstration
        {
            10, // Add 10 to the collection
            20, // Add 20 to the collection
            30 // Add 30 to the collection
        };

        IEnumerable<int> deferredFilteringQuery = deferredNumbers.Where(number => number >= 20); // Define a filtering query without executing it immediately

        deferredNumbers.Add(40); // Add a matching value after defining the query

        deferredNumbers.Add(5); // Add a non-matching value after defining the query

        Console.WriteLine("\nDeferred Where() result after adding 40 and 5:"); // Display the deferred-execution heading

        DisplayNumbers(deferredFilteringQuery); // Execute the query and include the newly added matching value

        // Demonstrate immediate materialization

        List<int> materializedFilteringResult = deferredNumbers // Begin with the current source collection
            .Where(number => number >= 20) // Keep numbers of at least twenty
            .ToList(); // Execute the query immediately and create a snapshot

        deferredNumbers.Add(50); // Add another matching value after creating the snapshot

        Console.WriteLine("\nToList() filtering snapshot created before adding 50:"); // Display the materialized-snapshot heading

        DisplayNumbers(materializedFilteringResult); // Display the snapshot without fifty

        Console.WriteLine("\nDeferred filtering query after adding 50:"); // Display the updated-deferred-query heading

        DisplayNumbers(deferredFilteringQuery); // Display the deferred result including fifty

        // Final message

        Console.WriteLine("\nAll LINQ method-syntax filtering examples completed successfully."); // Display the completion message
    }
}