/*
LINQ Conversion Operators Using Method Syntax - Complete Concept Summary

LINQ conversion operators convert a sequence into another collection
type or expose the sequence through another interface.

Main LINQ conversion methods:

1. ToArray()
2. ToList()
3. ToDictionary()
4. ToLookup()
5. ToHashSet()
6. Cast<T>()
7. OfType<T>()
8. AsEnumerable()
9. AsQueryable()

--------------------------------------------------
1. ToArray()
--------------------------------------------------

Converts a sequence into an array.

Syntax:

T[] result = collection.ToArray();

Example:

int[] numberArray = numbers
    .Where(number => number > 20)
    .ToArray();

Important:

ToArray() immediately executes the query and creates a separate array.

--------------------------------------------------
2. ToList()
--------------------------------------------------

Converts a sequence into List<T>.

Syntax:

List<T> result = collection.ToList();

Example:

List<int> numberList = numbers
    .Where(number => number > 20)
    .ToList();

Important:

ToList() immediately executes the query and creates a separate list.

--------------------------------------------------
3. ToDictionary()
--------------------------------------------------

Converts a sequence into Dictionary<TKey, TValue>.

Syntax:

Dictionary<TKey, TSource> result =
    collection.ToDictionary(item => item.Key);

Selecting both key and value:

Dictionary<TKey, TValue> result =
    collection.ToDictionary(
        item => item.Key,
        item => item.Value
    );

Example:

Dictionary<int, string> employeeDictionary =
    employees.ToDictionary(
        employee => employee.Id,
        employee => employee.Name
    );

Important:

1. Dictionary keys must be unique.
2. Duplicate keys cause ArgumentException.
3. Null reference-type keys are not permitted.
4. ToDictionary() immediately executes the sequence.

--------------------------------------------------
4. ToLookup()
--------------------------------------------------

Converts a sequence into ILookup<TKey, TElement>.

Syntax:

ILookup<TKey, TSource> result =
    collection.ToLookup(item => item.Key);

Selecting a particular element:

ILookup<TKey, TElement> result =
    collection.ToLookup(
        item => item.Key,
        item => item.Value
    );

Example:

ILookup<string, Employee> employeesByDepartment =
    employees.ToLookup(employee => employee.Department);

Important:

1. A lookup allows multiple elements for the same key.
2. It is useful for one-to-many relationships.
3. Accessing a missing key returns an empty sequence.
4. ToLookup() immediately executes the sequence.
5. A lookup cannot be directly modified after creation.

--------------------------------------------------
5. ToHashSet()
--------------------------------------------------

Converts a sequence into HashSet<T>.

Syntax:

HashSet<T> result = collection.ToHashSet();

Important:

1. Duplicate values are removed.
2. Membership checking is normally fast.
3. The order of elements should not be relied upon.
4. ToHashSet() immediately executes the sequence.

--------------------------------------------------
6. Cast<T>()
--------------------------------------------------

Converts every element of a non-generic or loosely typed collection
into the specified type.

Syntax:

IEnumerable<T> result = collection.Cast<T>();

Example:

ArrayList values = new ArrayList()
{
    10,
    20,
    30
};

IEnumerable<int> numbers = values.Cast<int>();

Important:

1. Every element must be compatible with T.
2. An incompatible element causes InvalidCastException.
3. Cast<T>() normally uses deferred execution.
4. The exception occurs when the result is traversed.

--------------------------------------------------
7. OfType<T>()
--------------------------------------------------

Returns only those elements that are compatible with the specified
type.

Syntax:

IEnumerable<T> result = collection.OfType<T>();

Example:

ArrayList values = new ArrayList()
{
    10,
    "C#",
    20,
    "LINQ"
};

IEnumerable<int> numbers = values.OfType<int>();

Result:

10
20

Important:

1. Incompatible values are ignored.
2. Null values are also ignored.
3. OfType<T>() does not throw for incompatible values.
4. OfType<T>() normally uses deferred execution.

Difference between Cast<T>() and OfType<T>():

Cast<T>():
Attempts to cast every element.
Throws InvalidCastException when an element is incompatible.

OfType<T>():
Returns only compatible elements.
Silently skips incompatible elements.

--------------------------------------------------
8. AsEnumerable()
--------------------------------------------------

Exposes a sequence as IEnumerable<T>.

Syntax:

IEnumerable<T> result = collection.AsEnumerable();

It does not normally create a new collection.

It is commonly used to switch from a provider-specific query, such as
IQueryable<T>, to LINQ-to-Objects operations.

Important:

1. AsEnumerable() does not call ToList().
2. It does not create a snapshot.
3. It normally preserves deferred execution.
4. Changes made before traversal may appear in the result.

--------------------------------------------------
9. AsQueryable()
--------------------------------------------------

Exposes a sequence as IQueryable<T>.

Syntax:

IQueryable<T> result = collection.AsQueryable();

Important:

1. Query operators build expression trees when supported by a provider.
2. Database providers can translate those expressions into SQL.
3. For an in-memory List<T>, the query still runs in memory.
4. AsQueryable() does not materialize the sequence.
5. Execution normally remains deferred.

--------------------------------------------------
Immediate and Deferred Execution
--------------------------------------------------

Immediate conversion methods:

ToArray()
ToList()
ToDictionary()
ToLookup()
ToHashSet()

These methods traverse the source immediately and create a result.

Normally deferred conversion methods:

Cast<T>()
OfType<T>()
AsEnumerable()
AsQueryable()

These methods normally execute when their results are traversed.

--------------------------------------------------
Original Collection and Snapshot
--------------------------------------------------

List<int> snapshot = numbers.ToList();

The new list is a snapshot of the sequence at that moment.

Adding another value to numbers afterward does not add that value to
snapshot.

However:

IEnumerable<int> query = numbers.Where(number => number > 10);

The query is deferred. Values added before its traversal may appear in
the result.

--------------------------------------------------
Time Complexity
--------------------------------------------------

ToArray():       O(n)
ToList():        O(n)
ToDictionary():  O(n) average
ToLookup():      O(n) average
ToHashSet():     O(n) average
Cast<T>():       O(n) during traversal
OfType<T>():     O(n) during traversal

Required namespaces:

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections; // Import non-generic collections such as ArrayList
using System.Collections.Generic; // Import generic collections such as List<T> and Dictionary<TKey, TValue>
using System.Linq; // Import LINQ conversion and query methods

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string City { get; set; } = ""; // Store the employee city

    public decimal Salary { get; set; } // Store the monthly employee salary
}

class Product // Define a class representing a product
{
    public int Id { get; set; } // Store the product identifier

    public string Name { get; set; } = ""; // Store the product name

    public string Category { get; set; } = ""; // Store the product category

    public decimal Price { get; set; } // Store the product price
}

class ConversionProgram // Define the main program class
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
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City} | Rs. {employee.Salary:F2}"); // Display the current employee details

            employeeFound = true; // Record that at least one employee was found
        }

        if (!employeeFound) // Check whether the sequence was empty
        {
            Console.WriteLine("No employees"); // Display a message for an empty employee sequence
        }
    }

    // Format employee information

    static string FormatEmployee(Employee employee) // Define a custom method used after AsEnumerable()
    {
        return $"{employee.Name.ToUpper()} - {employee.Department} - Rs. {employee.Salary:F2}"; // Return formatted employee information
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a collection of integer values
        {
            10, // Add 10 to the number collection
            20, // Add 20 to the number collection
            30, // Add 30 to the number collection
            40, // Add 40 to the number collection
            50, // Add 50 to the number collection
            60 // Add 60 to the number collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all original numbers

        // Convert to array

        int[] numberArray = numbers.ToArray(); // Convert the complete number collection into an array

        Console.WriteLine("\nNumbers converted to int[] using ToArray():"); // Display the ToArray heading

        DisplayNumbers(numberArray); // Display the converted number array

        Console.WriteLine("Runtime type: " + numberArray.GetType()); // Display the runtime type of the converted array

        Console.WriteLine("Array length: " + numberArray.Length); // Display the number of elements in the array

        // Filter and convert to array

        int[] filteredNumberArray = numbers // Begin with the original number collection
            .Where(number => number >= 30) // Keep numbers greater than or equal to thirty
            .OrderByDescending(number => number) // Arrange the matching numbers from largest to smallest
            .ToArray(); // Execute the query and convert the result into an array

        Console.WriteLine("\nFiltered and ordered numbers converted to an array:"); // Display the filtered-array heading

        DisplayNumbers(filteredNumberArray); // Display the filtered number array

        // Convert to list

        List<int> numberList = numbers.ToList(); // Convert the number sequence into a new List<int>

        Console.WriteLine("\nNumbers converted to List<int> using ToList():"); // Display the ToList heading

        DisplayNumbers(numberList); // Display the converted number list

        Console.WriteLine("Runtime type: " + numberList.GetType()); // Display the runtime type of the converted list

        Console.WriteLine("List count: " + numberList.Count); // Display the number of elements in the list

        // Filter and convert to list

        List<int> evenNumberList = numbers // Begin with the number collection
            .Where(number => number % 2 == 0) // Keep numbers divisible by two
            .Select(number => number * number) // Calculate the square of every matching number
            .ToList(); // Execute the query and convert the results into a list

        Console.WriteLine("\nSquares of even numbers converted to a list:"); // Display the filtered-list heading

        DisplayNumbers(evenNumberList); // Display the materialized squared values

        // Demonstrate ToList snapshot

        IEnumerable<int> deferredNumberQuery = numbers.Where(number => number >= 30); // Create a deferred query for numbers of at least thirty

        List<int> numberSnapshot = deferredNumberQuery.ToList(); // Execute the query immediately and create a list snapshot

        numbers.Add(70); // Add 70 to the original collection after creating the snapshot

        numbers.Add(80); // Add 80 to the original collection after creating the snapshot

        Console.WriteLine("\nOriginal numbers after adding 70 and 80:"); // Display the modified-source heading

        DisplayNumbers(numbers); // Display the modified original collection

        Console.WriteLine("\nToList() snapshot created before adding 70 and 80:"); // Display the snapshot heading

        DisplayNumbers(numberSnapshot); // Display the snapshot without the later values

        Console.WriteLine("\nDeferred query executed after adding 70 and 80:"); // Display the deferred-query heading

        DisplayNumbers(deferredNumberQuery); // Execute the query and include the later matching values

        // Convert to HashSet

        List<int> numbersWithDuplicates = new List<int>() // Create a number collection containing duplicate values
        {
            10, // Add the first 10
            20, // Add the first 20
            20, // Add another 20
            30, // Add the first 30
            30, // Add another 30
            30, // Add another 30
            40 // Add 40
        };

        HashSet<int> uniqueNumberSet = numbersWithDuplicates.ToHashSet(); // Convert the sequence into a HashSet and remove duplicates

        Console.WriteLine("\nOriginal collection containing duplicates:"); // Display the duplicate-source heading

        DisplayNumbers(numbersWithDuplicates); // Display all duplicate values

        Console.WriteLine("\nValues converted to HashSet<int>:"); // Display the ToHashSet heading

        DisplayNumbers(uniqueNumberSet); // Display the unique values

        Console.WriteLine("HashSet count: " + uniqueNumberSet.Count); // Display the number of unique values

        Console.WriteLine("HashSet contains 30: " + uniqueNumberSet.Contains(30)); // Check whether the hash set contains thirty

        Console.WriteLine("HashSet contains 100: " + uniqueNumberSet.Contains(100)); // Check whether the hash set contains one hundred

        // Convert numbers to dictionary

        Dictionary<int, int> numberSquareDictionary = numbers // Begin with the number collection
            .ToDictionary( // Convert the sequence into a dictionary
                number => number, // Use the number itself as the dictionary key
                number => number * number // Use the square as the dictionary value
            );

        Console.WriteLine("\nNumber-to-square dictionary:"); // Display the number-dictionary heading

        foreach (KeyValuePair<int, int> item in numberSquareDictionary) // Visit every dictionary entry
        {
            Console.WriteLine(item.Key + " -> " + item.Value); // Display the dictionary key and value
        }

        // Access dictionary value

        int squareOfForty = numberSquareDictionary[40]; // Access the value associated with key forty

        Console.WriteLine("\nSquare stored for 40: " + squareOfForty); // Display the retrieved dictionary value

        // Safely access dictionary value

        bool keyFound = numberSquareDictionary.TryGetValue(50, out int squareOfFifty); // Try to retrieve the value associated with key fifty

        if (keyFound) // Check whether the dictionary key was found
        {
            Console.WriteLine("Square stored for 50: " + squareOfFifty); // Display the retrieved square
        }

        // Convert strings to dictionary

        List<string> technologies = new List<string>() // Create a collection of unique technology names
        {
            "C#", // Add C# to the collection
            "Python", // Add Python to the collection
            "Java", // Add Java to the collection
            "MongoDB", // Add MongoDB to the collection
            "PySpark" // Add PySpark to the collection
        };

        Dictionary<string, int> technologyLengthDictionary = technologies // Begin with the technology collection
            .ToDictionary( // Convert technology names into dictionary entries
                technology => technology, // Use the technology name as the key
                technology => technology.Length // Use the string length as the value
            );

        Console.WriteLine("\nTechnology-name-to-length dictionary:"); // Display the string-dictionary heading

        foreach (KeyValuePair<string, int> item in technologyLengthDictionary) // Visit every technology dictionary entry
        {
            Console.WriteLine(item.Key + " -> " + item.Value); // Display the technology and its length
        }

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of employee objects
        {
            new Employee { Id = 101, Name = "Saad", Department = "Development", City = "Pune", Salary = 65000m }, // Add the first employee
            new Employee { Id = 102, Name = "Aman", Department = "Testing", City = "Delhi", Salary = 48000m }, // Add the second employee
            new Employee { Id = 103, Name = "Neha", Department = "Development", City = "Pune", Salary = 75000m }, // Add the third employee
            new Employee { Id = 104, Name = "Rahul", Department = "Support", City = "Bengaluru", Salary = 38000m }, // Add the fourth employee
            new Employee { Id = 105, Name = "Priya", Department = "Data Engineering", City = "Hyderabad", Salary = 82000m }, // Add the fifth employee
            new Employee { Id = 106, Name = "Arjun", Department = "Development", City = "Delhi", Salary = 55000m }, // Add the sixth employee
            new Employee { Id = 107, Name = "Zoya", Department = "Data Engineering", City = "Pune", Salary = 70000m }, // Add the seventh employee
            new Employee { Id = 108, Name = "Karan", Department = "Testing", City = "Pune", Salary = 52000m } // Add the eighth employee
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the employee-collection heading

        DisplayEmployees(employees); // Display all employees

        // Convert employees to array

        Employee[] employeeArray = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 60000m) // Keep employees earning at least sixty thousand
            .OrderByDescending(employee => employee.Salary) // Arrange employees from highest to lowest salary
            .ToArray(); // Execute the query and convert the result into an array

        Console.WriteLine("\nHigh-salary employees converted to Employee[]:"); // Display the employee-array heading

        DisplayEmployees(employeeArray); // Display employees stored in the array

        // Convert employees to list

        List<Employee> puneEmployeeList = employees // Begin with the employee collection
            .Where(employee => employee.City == "Pune") // Keep employees from Pune
            .OrderBy(employee => employee.Name) // Arrange employees alphabetically
            .ToList(); // Execute the query and convert it into a list

        Console.WriteLine("\nPune employees converted to List<Employee>:"); // Display the employee-list heading

        DisplayEmployees(puneEmployeeList); // Display the converted Pune employee list

        // Convert employees to dictionary using complete objects

        Dictionary<int, Employee> employeeByIdDictionary = employees // Begin with the employee collection
            .ToDictionary(employee => employee.Id); // Use employee ID as key and the complete employee as value

        Console.WriteLine("\nDictionary<int, Employee> using employee ID:"); // Display the complete-object-dictionary heading

        foreach (KeyValuePair<int, Employee> item in employeeByIdDictionary) // Visit every employee dictionary entry
        {
            Console.WriteLine($"{item.Key} -> {item.Value.Name} | {item.Value.Department} | Rs. {item.Value.Salary:F2}"); // Display the key and employee information
        }

        // Convert employees to dictionary using selected values

        Dictionary<int, string> employeeNameDictionary = employees // Begin with the employee collection
            .ToDictionary( // Convert employees into identifier-name entries
                employee => employee.Id, // Use the employee ID as the key
                employee => employee.Name // Use the employee name as the value
            );

        Console.WriteLine("\nDictionary<int, string> containing employee names:"); // Display the selected-value-dictionary heading

        foreach (KeyValuePair<int, string> item in employeeNameDictionary) // Visit every employee-name entry
        {
            Console.WriteLine(item.Key + " -> " + item.Value); // Display the employee ID and name
        }

        // Convert employees to salary dictionary

        Dictionary<string, decimal> salaryByEmployeeName = employees // Begin with the employee collection
            .ToDictionary( // Convert employees into name-salary entries
                employee => employee.Name, // Use the employee name as the key
                employee => employee.Salary // Use the employee salary as the value
            );

        Console.WriteLine("\nEmployee-name-to-salary dictionary:"); // Display the salary-dictionary heading

        foreach (KeyValuePair<string, decimal> item in salaryByEmployeeName) // Visit every salary dictionary entry
        {
            Console.WriteLine($"{item.Key} -> Rs. {item.Value:F2}"); // Display the employee name and salary
        }

        // Demonstrate duplicate dictionary key error

        Console.WriteLine("\nAttempting to use Department as a dictionary key:"); // Display the duplicate-key demonstration heading

        try // Begin protected code that may throw an exception
        {
            Dictionary<string, Employee> invalidDepartmentDictionary = employees // Begin with the employee collection
                .ToDictionary(employee => employee.Department); // Attempt to use repeated department names as unique keys

            Console.WriteLine("Dictionary created with " + invalidDepartmentDictionary.Count + " entries."); // Display the count if no duplicate exists
        }
        catch (ArgumentException exception) // Handle the duplicate-key exception
        {
            Console.WriteLine("ToDictionary() failed because department names are not unique."); // Explain why dictionary creation failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Safely create dictionary from duplicate keys

        Dictionary<string, List<Employee>> employeesGroupedDictionary = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees having the same department
            .ToDictionary( // Convert each unique department group into a dictionary entry
                group => group.Key, // Use the unique department name as the key
                group => group.ToList() // Convert matching employees into a list value
            );

        Console.WriteLine("\nSafe department dictionary created using GroupBy() and ToDictionary():"); // Display the safe-dictionary heading

        foreach (KeyValuePair<string, List<Employee>> item in employeesGroupedDictionary) // Visit every department dictionary entry
        {
            Console.WriteLine("\nDepartment: " + item.Key); // Display the department key

            DisplayEmployees(item.Value); // Display employees stored in the department list
        }

        // Convert employees to lookup

        ILookup<string, Employee> employeesByDepartmentLookup = employees // Begin with the employee collection
            .ToLookup(employee => employee.Department); // Create a lookup using department as the key

        Console.WriteLine("\nEmployees converted to a department lookup:"); // Display the ToLookup heading

        foreach (IGrouping<string, Employee> departmentGroup in employeesByDepartmentLookup) // Visit every lookup group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the current lookup key

            foreach (Employee employee in departmentGroup) // Visit every employee associated with the key
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        // Access one lookup key

        IEnumerable<Employee> developmentEmployees = employeesByDepartmentLookup["Development"]; // Retrieve all employees associated with Development

        Console.WriteLine("\nEmployees accessed using lookup key Development:"); // Display the lookup-access heading

        DisplayEmployees(developmentEmployees); // Display Development employees

        // Access missing lookup key

        IEnumerable<Employee> financeEmployees = employeesByDepartmentLookup["Finance"]; // Access a key that does not exist

        Console.WriteLine("\nEmployees accessed using missing lookup key Finance:"); // Display the missing-lookup-key heading

        DisplayEmployees(financeEmployees); // Display the empty sequence returned for the missing key

        // Convert employees to lookup with selected elements

        ILookup<string, string> employeeNamesByCityLookup = employees // Begin with the employee collection
            .ToLookup( // Create a city-to-name lookup
                employee => employee.City, // Use employee city as the lookup key
                employee => employee.Name // Store only employee names as lookup elements
            );

        Console.WriteLine("\nEmployee names grouped by city using ToLookup():"); // Display the selected-element-lookup heading

        foreach (IGrouping<string, string> cityGroup in employeeNamesByCityLookup) // Visit every city lookup group
        {
            Console.WriteLine("\nCity: " + cityGroup.Key); // Display the current city key

            foreach (string employeeName in cityGroup) // Visit every employee name associated with the city
            {
                Console.WriteLine(employeeName); // Display the employee name
            }
        }

        // Compare dictionary and lookup

        Console.WriteLine("\nDictionary and Lookup comparison:"); // Display the comparison heading

        Console.WriteLine("Dictionary keys must be unique."); // Explain dictionary key behaviour

        Console.WriteLine("Lookup keys may have multiple associated elements."); // Explain lookup key behaviour

        Console.WriteLine("Dictionary missing key access normally throws KeyNotFoundException."); // Explain dictionary missing-key behaviour

        Console.WriteLine("Lookup missing key access returns an empty sequence."); // Explain lookup missing-key behaviour

        // Create product collection

        List<Product> products = new List<Product>() // Create a collection of product objects
        {
            new Product { Id = 201, Name = "Laptop", Category = "Electronics", Price = 65000m }, // Add the Laptop product
            new Product { Id = 202, Name = "Mouse", Category = "Electronics", Price = 800m }, // Add the Mouse product
            new Product { Id = 203, Name = "Chair", Category = "Furniture", Price = 6000m }, // Add the Chair product
            new Product { Id = 204, Name = "Table", Category = "Furniture", Price = 9000m }, // Add the Table product
            new Product { Id = 205, Name = "Notebook", Category = "Stationery", Price = 100m } // Add the Notebook product
        };

        // Convert products to lookup

        ILookup<string, Product> productsByCategoryLookup = products // Begin with the product collection
            .ToLookup(product => product.Category); // Create a lookup using product category

        Console.WriteLine("\nProducts converted to a category lookup:"); // Display the product-lookup heading

        foreach (IGrouping<string, Product> categoryGroup in productsByCategoryLookup) // Visit every category lookup group
        {
            Console.WriteLine("\nCategory: " + categoryGroup.Key); // Display the category key

            foreach (Product product in categoryGroup) // Visit every product associated with the category
            {
                Console.WriteLine($"{product.Name} | Rs. {product.Price:F2}"); // Display the product name and price
            }
        }

        // Create mixed non-generic collection

        ArrayList mixedValues = new ArrayList() // Create a non-generic collection containing different data types
        {
            10, // Add an integer value
            "C#", // Add a string value
            20, // Add another integer value
            "LINQ", // Add another string value
            30, // Add another integer value
            45.5, // Add a double value
            true, // Add a Boolean value
            "Method Syntax" // Add another string value
        };

        Console.WriteLine("\nOriginal mixed ArrayList values:"); // Display the mixed-collection heading

        foreach (object value in mixedValues) // Visit every object in the non-generic collection
        {
            Console.WriteLine($"{value} | Type: {value.GetType().Name}"); // Display the value and its runtime type
        }

        // Use OfType<int>

        IEnumerable<int> integerValues = mixedValues.OfType<int>(); // Select only integer elements from the mixed collection

        Console.WriteLine("\nInteger values selected using OfType<int>():"); // Display the OfType-integer heading

        DisplayNumbers(integerValues); // Display only compatible integer elements

        // Use OfType<string>

        IEnumerable<string> stringValues = mixedValues.OfType<string>(); // Select only string elements from the mixed collection

        Console.WriteLine("\nString values selected using OfType<string>():"); // Display the OfType-string heading

        DisplayStrings(stringValues); // Display only compatible string elements

        // Use OfType<double>

        IEnumerable<double> doubleValues = mixedValues.OfType<double>(); // Select only double elements from the mixed collection

        Console.WriteLine("\nDouble values selected using OfType<double>():"); // Display the OfType-double heading

        foreach (double value in doubleValues) // Visit every selected double value
        {
            Console.WriteLine(value); // Display the double value
        }

        // Filter and process OfType result

        List<int> processedIntegerValues = mixedValues // Begin with the mixed collection
            .OfType<int>() // Keep only integer values
            .Where(number => number >= 20) // Keep integers greater than or equal to twenty
            .Select(number => number * number) // Calculate the square of every matching integer
            .ToList(); // Execute the query and convert the result into a list

        Console.WriteLine("\nProcessed integers selected using OfType<int>():"); // Display the processed-OfType heading

        DisplayNumbers(processedIntegerValues); // Display the squared matching integers

        // Create compatible ArrayList for Cast

        ArrayList compatibleIntegerValues = new ArrayList() // Create a non-generic collection containing only integers
        {
            100, // Add 100 to the collection
            200, // Add 200 to the collection
            300, // Add 300 to the collection
            400 // Add 400 to the collection
        };

        IEnumerable<int> castIntegerValues = compatibleIntegerValues.Cast<int>(); // Cast every element in the collection to int

        Console.WriteLine("\nCompatible ArrayList converted using Cast<int>():"); // Display the successful-Cast heading

        DisplayNumbers(castIntegerValues); // Display all successfully cast integers

        // Demonstrate Cast failure

        Console.WriteLine("\nAttempting Cast<int>() on the mixed ArrayList:"); // Display the Cast-failure heading

        try // Begin protected code that may throw an invalid-cast exception
        {
            IEnumerable<int> invalidCastResult = mixedValues.Cast<int>(); // Define a query that attempts to cast every mixed element to int

            foreach (int number in invalidCastResult) // Traverse the deferred Cast query
            {
                Console.WriteLine(number); // Display values until an incompatible value is encountered
            }
        }
        catch (InvalidCastException exception) // Handle the incompatible-element exception
        {
            Console.WriteLine("Cast<int>() failed because the collection contains non-integer values."); // Explain why the cast failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Compare Cast and OfType

        Console.WriteLine("\nCast<T>() and OfType<T>() comparison:"); // Display the Cast-versus-OfType heading

        Console.WriteLine("Cast<T>() attempts to convert every element."); // Explain Cast behaviour

        Console.WriteLine("Cast<T>() throws InvalidCastException for an incompatible element."); // Explain the Cast failure condition

        Console.WriteLine("OfType<T>() returns only compatible elements."); // Explain OfType behaviour

        Console.WriteLine("OfType<T>() skips incompatible values."); // Explain how OfType handles incompatible values

        // Demonstrate deferred OfType execution

        ArrayList deferredMixedValues = new ArrayList() // Create a collection for deferred OfType execution
        {
            10, // Add an integer value
            "Hello", // Add a string value
            20 // Add another integer value
        };

        IEnumerable<int> deferredOfTypeQuery = deferredMixedValues.OfType<int>(); // Define an OfType query without immediately traversing it

        deferredMixedValues.Add(30); // Add another integer after defining the query

        deferredMixedValues.Add("World"); // Add another string after defining the query

        Console.WriteLine("\nDeferred OfType<int>() result after modifying the collection:"); // Display the deferred-OfType heading

        DisplayNumbers(deferredOfTypeQuery); // Execute the query and include the newly added integer

        // Use AsEnumerable

        IEnumerable<Employee> enumerableEmployees = employees.AsEnumerable(); // Expose the employee collection through IEnumerable<Employee>

        Console.WriteLine("\nEmployees exposed through AsEnumerable():"); // Display the AsEnumerable heading

        DisplayEmployees(enumerableEmployees); // Display the employee sequence

        Console.WriteLine("AsEnumerable result type: " + enumerableEmployees.GetType()); // Display the underlying runtime type

        // AsEnumerable with method chain

        IEnumerable<string> formattedHighSalaryEmployees = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 60000m) // Keep employees earning at least sixty thousand
            .AsEnumerable() // Expose the sequence as IEnumerable<Employee>
            .Select(employee => FormatEmployee(employee)); // Use a custom .NET method to format every employee

        Console.WriteLine("\nFormatted employees after AsEnumerable():"); // Display the AsEnumerable-processing heading

        DisplayStrings(formattedHighSalaryEmployees); // Display the formatted employee information

        // Demonstrate AsEnumerable does not create snapshot

        List<int> enumerableSource = new List<int>() // Create a source collection for AsEnumerable demonstration
        {
            10, // Add 10 to the source
            20, // Add 20 to the source
            30 // Add 30 to the source
        };

        IEnumerable<int> enumerableView = enumerableSource.AsEnumerable(); // Expose the list as an enumerable sequence without materializing it

        enumerableSource.Add(40); // Add 40 after creating the enumerable view

        Console.WriteLine("\nAsEnumerable() result after adding 40 to the source:"); // Display the AsEnumerable-deferred heading

        DisplayNumbers(enumerableView); // Display the result including the newly added value

        // Use AsQueryable

        IQueryable<Employee> queryableEmployees = employees.AsQueryable(); // Expose the in-memory employee sequence through IQueryable<Employee>

        Console.WriteLine("\nEmployees exposed through AsQueryable():"); // Display the AsQueryable heading

        Console.WriteLine("Queryable runtime type: " + queryableEmployees.GetType()); // Display the runtime type of the queryable sequence

        IQueryable<Employee> highSalaryQueryable = queryableEmployees // Begin with the queryable employee sequence
            .Where(employee => employee.Salary >= 60000m) // Add a salary-filter expression
            .OrderByDescending(employee => employee.Salary); // Add a descending salary-order expression

        Console.WriteLine("\nAsQueryable() employees earning at least Rs. 60000:"); // Display the queryable-result heading

        DisplayEmployees(highSalaryQueryable); // Execute and display the queryable sequence

        // Switch from IQueryable to IEnumerable

        IEnumerable<string> queryableToEnumerableResult = queryableEmployees // Begin with the queryable employee sequence
            .Where(employee => employee.Department == "Development") // Filter Development employees as an IQueryable operation
            .AsEnumerable() // Switch the remaining processing to IEnumerable<Employee>
            .Select(employee => FormatEmployee(employee)); // Apply a custom in-memory formatting method

        Console.WriteLine("\nAsQueryable() switched to AsEnumerable():"); // Display the queryable-to-enumerable heading

        DisplayStrings(queryableToEnumerableResult); // Display the final formatted results

        // Materialize IQueryable result

        List<Employee> queryableEmployeeList = queryableEmployees // Begin with the queryable employee sequence
            .Where(employee => employee.City == "Pune") // Keep employees from Pune
            .OrderBy(employee => employee.Name) // Arrange matching employees alphabetically
            .ToList(); // Execute the query and materialize it as a list

        Console.WriteLine("\nAsQueryable() result materialized using ToList():"); // Display the queryable-materialization heading

        DisplayEmployees(queryableEmployeeList); // Display the materialized query result

        // Convert projected values to array

        string[] employeeDescriptionArray = employees // Begin with the employee collection
            .OrderBy(employee => employee.Name) // Arrange employees alphabetically
            .Select(employee => $"{employee.Name} works in {employee.Department}") // Project employees into descriptive strings
            .ToArray(); // Execute the query and convert descriptions into an array

        Console.WriteLine("\nProjected employee descriptions converted to string[]:"); // Display the projected-array heading

        DisplayStrings(employeeDescriptionArray); // Display the description array

        // Convert grouped results to dictionary

        Dictionary<string, decimal> averageSalaryByDepartment = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .ToDictionary( // Convert each department group into a dictionary entry
                group => group.Key, // Use the department name as the key
                group => group.Average(employee => employee.Salary) // Use the average department salary as the value
            );

        Console.WriteLine("\nAverage salary by department dictionary:"); // Display the aggregate-dictionary heading

        foreach (KeyValuePair<string, decimal> item in averageSalaryByDepartment) // Visit every department-average entry
        {
            Console.WriteLine($"{item.Key} -> Rs. {item.Value:F2}"); // Display the department and average salary
        }

        // Convert grouped results to summary dictionary

        Dictionary<string, string> departmentSummaryDictionary = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .ToDictionary( // Convert department groups into summary entries
                group => group.Key, // Use department name as the dictionary key
                group => $"Employees: {group.Count()}, Total salary: Rs. {group.Sum(employee => employee.Salary):F2}" // Create a formatted summary as the value
            );

        Console.WriteLine("\nDepartment summary dictionary:"); // Display the summary-dictionary heading

        foreach (KeyValuePair<string, string> item in departmentSummaryDictionary) // Visit every department summary entry
        {
            Console.WriteLine(item.Key + " -> " + item.Value); // Display the department and summary
        }

        // Convert empty sequence

        List<int> emptyNumbers = new List<int>(); // Create an empty integer collection

        int[] emptyArray = emptyNumbers.ToArray(); // Convert the empty sequence into an empty array

        List<int> emptyList = emptyNumbers.ToList(); // Convert the empty sequence into an empty list

        HashSet<int> emptyHashSet = emptyNumbers.ToHashSet(); // Convert the empty sequence into an empty hash set

        Dictionary<int, int> emptyDictionary = emptyNumbers.ToDictionary(number => number); // Convert the empty sequence into an empty dictionary

        ILookup<int, int> emptyLookup = emptyNumbers.ToLookup(number => number); // Convert the empty sequence into an empty lookup

        Console.WriteLine("\nEmpty conversion result counts:"); // Display the empty-conversion heading

        Console.WriteLine("Array length: " + emptyArray.Length); // Display the empty array length

        Console.WriteLine("List count: " + emptyList.Count); // Display the empty list count

        Console.WriteLine("HashSet count: " + emptyHashSet.Count); // Display the empty hash-set count

        Console.WriteLine("Dictionary count: " + emptyDictionary.Count); // Display the empty dictionary count

        Console.WriteLine("Lookup count: " + emptyLookup.Count); // Display the empty lookup group count

        // Final message

        Console.WriteLine("\nAll LINQ method-syntax conversion examples completed successfully."); // Display the completion message
    }
}