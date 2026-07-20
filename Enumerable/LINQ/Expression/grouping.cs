/*
LINQ Grouping Using Method Syntax - Complete Concept Summary

Grouping means arranging collection elements into groups based on a
common key.

The main LINQ grouping method is:

GroupBy()

Basic syntax:

IEnumerable<IGrouping<TKey, TSource>> result =
    collection.GroupBy(item => item.Key);

Example:

IEnumerable<IGrouping<string, Employee>> employeesByDepartment =
    employees.GroupBy(employee => employee.Department);

Each group contains:

1. Key:
   The common value used to form the group.

2. Elements:
   All source elements having that key.

Accessing groups:

foreach (IGrouping<string, Employee> group in employeesByDepartment)
{
    Console.WriteLine(group.Key);

    foreach (Employee employee in group)
    {
        Console.WriteLine(employee.Name);
    }
}

--------------------------------------------------
IGrouping<TKey, TElement>
--------------------------------------------------

Every group returned by GroupBy() implements:

IGrouping<TKey, TElement>

TKey:
The data type of the grouping key.

TElement:
The data type of the elements stored in the group.

Example:

IGrouping<string, Employee>

Here:

string:
The department key type.

Employee:
The type of elements stored in each group.

The group key is accessed through:

group.Key

The group elements are traversed using foreach.

--------------------------------------------------
GroupBy() Overloads
--------------------------------------------------

1. Group complete source elements:

collection.GroupBy(item => item.Key);

2. Group selected values:

collection.GroupBy(
    item => item.Key,
    item => item.SelectedValue
);

3. Create a result directly from each group:

collection.GroupBy(
    item => item.Key,
    (key, group) => new
    {
        Key = key,
        Count = group.Count()
    }
);

4. Select elements and create a result:

collection.GroupBy(
    item => item.Key,
    item => item.Value,
    (key, values) => new
    {
        Key = key,
        Values = values
    }
);

5. Use a custom equality comparer:

collection.GroupBy(
    item => item.Key,
    StringComparer.OrdinalIgnoreCase
);

--------------------------------------------------
Basic Grouping
--------------------------------------------------

IEnumerable<IGrouping<string, Employee>> groups =
    employees.GroupBy(employee => employee.Department);

The result contains one group for each unique department.

Example:

Development:
Saad
Neha
Arjun

Testing:
Aman
Karan

--------------------------------------------------
Grouping Selected Elements
--------------------------------------------------

Instead of storing complete objects, GroupBy() can store one selected
property.

Example:

IEnumerable<IGrouping<string, string>> namesByDepartment =
    employees.GroupBy(
        employee => employee.Department,
        employee => employee.Name
    );

Here:

Key:
Department name.

Element:
Employee name.

--------------------------------------------------
Grouping by Multiple Properties
--------------------------------------------------

An anonymous object can be used as a composite key.

Example:

var result = employees.GroupBy(employee => new
{
    employee.Department,
    employee.City
});

The combination of Department and City becomes the grouping key.

Accessing the key:

group.Key.Department
group.Key.City

--------------------------------------------------
Grouping by Calculated Key
--------------------------------------------------

Elements can be grouped according to a calculated category.

Example:

var result = employees.GroupBy(employee =>
    employee.Salary < 50000m
        ? "Low Salary"
        : employee.Salary < 75000m
            ? "Medium Salary"
            : "High Salary"
);

The grouping key does not have to be an existing property.

--------------------------------------------------
Aggregations Inside Groups
--------------------------------------------------

Common aggregation methods used with groups:

Count():
Counts elements in a group.

Sum():
Calculates a total.

Average():
Calculates an average.

Min():
Finds the minimum value.

Max():
Finds the maximum value.

First():
Returns the first element.

Example:

var result = employees
    .GroupBy(employee => employee.Department)
    .Select(group => new
    {
        Department = group.Key,
        EmployeeCount = group.Count(),
        TotalSalary = group.Sum(employee => employee.Salary),
        AverageSalary = group.Average(employee => employee.Salary),
        MinimumSalary = group.Min(employee => employee.Salary),
        MaximumSalary = group.Max(employee => employee.Salary)
    });

--------------------------------------------------
Filtering Before Grouping
--------------------------------------------------

Where() before GroupBy() filters individual source elements.

Example:

var result = employees
    .Where(employee => employee.Salary >= 60000m)
    .GroupBy(employee => employee.Department);

Only employees earning at least 60000 are included in the groups.

--------------------------------------------------
Filtering After Grouping
--------------------------------------------------

Where() after GroupBy() filters complete groups.

Example:

var result = employees
    .GroupBy(employee => employee.Department)
    .Where(group => group.Count() >= 2);

Only groups containing at least two employees are returned.

--------------------------------------------------
Ordering Groups
--------------------------------------------------

Groups can be ordered using their keys.

Example:

var result = employees
    .GroupBy(employee => employee.Department)
    .OrderBy(group => group.Key);

Groups can also be ordered using calculations:

var result = employees
    .GroupBy(employee => employee.Department)
    .OrderByDescending(group => group.Count());

--------------------------------------------------
Ordering Elements Within Each Group
--------------------------------------------------

The elements inside every group can also be ordered.

Example:

var result = employees
    .GroupBy(employee => employee.Department)
    .Select(group => new
    {
        Department = group.Key,
        Employees = group.OrderByDescending(
            employee => employee.Salary
        )
    });

--------------------------------------------------
Nested Grouping
--------------------------------------------------

A group can contain another grouping operation.

Example:

var result = employees
    .GroupBy(employee => employee.Department)
    .Select(departmentGroup => new
    {
        Department = departmentGroup.Key,
        CityGroups = departmentGroup.GroupBy(
            employee => employee.City
        )
    });

This first groups employees by department and then groups employees
inside each department by city.

--------------------------------------------------
GroupBy() and ToLookup() Difference
--------------------------------------------------

GroupBy():

1. Normally uses deferred execution.
2. Groups are created when the result is traversed.
3. Changes made before traversal may appear.
4. Returns IEnumerable<IGrouping<TKey, TElement>>.

ToLookup():

1. Executes immediately.
2. Creates a lookup snapshot.
3. Later source changes do not appear.
4. Returns ILookup<TKey, TElement>.
5. Can be accessed using lookup[key].
6. Missing keys return an empty sequence.

--------------------------------------------------
GroupBy() and ToDictionary() Difference
--------------------------------------------------

GroupBy():

One key can contain multiple elements.

ToDictionary():

Each key must be unique.

To create a dictionary of groups:

Dictionary<string, List<Employee>> result = employees
    .GroupBy(employee => employee.Department)
    .ToDictionary(
        group => group.Key,
        group => group.ToList()
    );

--------------------------------------------------
Case-Insensitive Grouping
--------------------------------------------------

By default, string grouping is case-sensitive.

These may form separate groups:

Development
development
DEVELOPMENT

Case-insensitive grouping:

var result = employees.GroupBy(
    employee => employee.Department,
    StringComparer.OrdinalIgnoreCase
);

--------------------------------------------------
Deferred Execution
--------------------------------------------------

GroupBy() normally uses deferred execution.

Example:

IEnumerable<IGrouping<string, Employee>> query =
    employees.GroupBy(employee => employee.Department);

employees.Add(newEmployee);

foreach (var group in query)
{
    // The newly added employee can appear here.
}

Calling ToList(), ToArray(), ToDictionary() or ToLookup() materializes
the result immediately.

--------------------------------------------------
Time Complexity
--------------------------------------------------

GroupBy():

Time:
O(n) average for creating all groups.

Additional memory:
O(n), because elements must be stored in groups.

Here:

n = number of source elements.

Additional operations such as sorting groups can require:

O(g log g)

Here:

g = number of groups.

--------------------------------------------------
Important Points
--------------------------------------------------

1. GroupBy() creates groups using a key selector.
2. Each group has a Key property.
3. Each group can contain one or many elements.
4. Duplicate keys are expected and allowed.
5. The original collection is not modified.
6. GroupBy() normally uses deferred execution.
7. Groups can be filtered, ordered and projected.
8. Aggregations can be calculated separately for every group.
9. Composite keys can group by multiple properties.
10. Calculated keys can create categories or ranges.
11. An element selector can store only selected values.
12. A result selector can directly create group summaries.
13. Nested GroupBy() operations can create hierarchical groups.
14. A comparer can control key equality.
15. ToDictionary() can convert groups into a dictionary.
16. ToLookup() creates an immediately materialized one-to-many lookup.

Required namespaces:

using System;
using System.Collections.Generic;
using System.Linq;
*/

#nullable enable // Enable nullable-reference-type analysis

using System; // Import basic classes such as Console and StringComparer
using System.Collections.Generic; // Import generic collections such as List<T> and Dictionary<TKey, TValue>
using System.Linq; // Import LINQ methods such as GroupBy(), Select() and OrderBy()

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string? City { get; set; } // Store the employee city or null

    public decimal Salary { get; set; } // Store the employee monthly salary

    public int Experience { get; set; } // Store the employee experience in years

    public bool IsPermanent { get; set; } // Store whether the employee is permanent
}

class Product // Define a class representing a product
{
    public int Id { get; set; } // Store the product identifier

    public string Name { get; set; } = ""; // Store the product name

    public string Category { get; set; } = ""; // Store the product category

    public decimal Price { get; set; } // Store the product price

    public int Stock { get; set; } // Store the available product quantity
}

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public string Course { get; set; } = ""; // Store the student course

    public List<int> Marks { get; set; } = new List<int>(); // Store the marks obtained by the student
}

class GroupingProgram // Define the main program class
{
    // Display numbers

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

    // Display employee

    static void DisplayEmployee(Employee employee) // Define a method that accepts one employee
    {
        Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City ?? "Not available"} | Rs. {employee.Salary:F2} | Experience: {employee.Experience} years | Permanent: {employee.IsPermanent}"); // Display the employee details
    }

    // Display employees

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        bool employeeFound = false; // Track whether the sequence contains an employee

        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            DisplayEmployee(employee); // Display the current employee

            employeeFound = true; // Record that at least one employee was found
        }

        if (!employeeFound) // Check whether the employee sequence was empty
        {
            Console.WriteLine("No employees"); // Display a message for an empty employee sequence
        }
    }

    // Display products

    static void DisplayProducts(IEnumerable<Product> products) // Define a method that accepts a product sequence
    {
        bool productFound = false; // Track whether the sequence contains a product

        foreach (Product product in products) // Visit every product in the sequence
        {
            Console.WriteLine($"{product.Id} | {product.Name} | {product.Category} | Rs. {product.Price:F2} | Stock: {product.Stock}"); // Display the product details

            productFound = true; // Record that at least one product was found
        }

        if (!productFound) // Check whether the product sequence was empty
        {
            Console.WriteLine("No products"); // Display a message for an empty product sequence
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a collection of integer values
        {
            10, // Add the first 10
            15, // Add 15
            20, // Add 20
            25, // Add 25
            30, // Add 30
            35, // Add 35
            40, // Add 40
            45, // Add 45
            50, // Add 50
            55, // Add 55
            60 // Add 60
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all numbers

        // Group numbers as even and odd

        IEnumerable<IGrouping<string, int>> numbersByType = numbers // Begin with the number collection
            .GroupBy(number => number % 2 == 0 ? "Even" : "Odd"); // Group numbers according to divisibility by two

        Console.WriteLine("\nNumbers grouped as even and odd:"); // Display the even-and-odd grouping heading

        foreach (IGrouping<string, int> numberGroup in numbersByType) // Visit every number group
        {
            Console.Write(numberGroup.Key + ": "); // Display the group key

            DisplayNumbers(numberGroup); // Display numbers belonging to the current group
        }

        // Group numbers by remainder

        IEnumerable<IGrouping<int, int>> numbersByRemainder = numbers // Begin with the number collection
            .GroupBy(number => number % 3); // Group numbers according to the remainder after division by three

        Console.WriteLine("\nNumbers grouped by remainder after division by 3:"); // Display the remainder-grouping heading

        foreach (IGrouping<int, int> remainderGroup in numbersByRemainder) // Visit every remainder group
        {
            Console.Write("Remainder " + remainderGroup.Key + ": "); // Display the remainder key

            DisplayNumbers(remainderGroup); // Display numbers belonging to the current remainder group
        }

        // Order number groups

        IEnumerable<IGrouping<int, int>> orderedRemainderGroups = numbers // Begin with the number collection
            .GroupBy(number => number % 3) // Group numbers by remainder
            .OrderBy(group => group.Key); // Arrange the groups by ascending remainder key

        Console.WriteLine("\nRemainder groups ordered by key:"); // Display the ordered-group heading

        foreach (IGrouping<int, int> remainderGroup in orderedRemainderGroups) // Visit every ordered group
        {
            Console.Write("Remainder " + remainderGroup.Key + ": "); // Display the ordered group key

            DisplayNumbers(remainderGroup); // Display the current group's numbers
        }

        // Group numbers by range

        IEnumerable<IGrouping<string, int>> numbersByRange = numbers // Begin with the number collection
            .GroupBy(number => // Calculate the grouping category
                number < 25 // Check whether the number is below twenty-five
                    ? "Low" // Use Low for numbers below twenty-five
                    : number < 45 // Check whether the number is below forty-five
                        ? "Medium" // Use Medium for numbers from twenty-five through forty
                        : "High"); // Use High for numbers of at least forty-five

        Console.WriteLine("\nNumbers grouped by calculated range:"); // Display the range-grouping heading

        foreach (IGrouping<string, int> rangeGroup in numbersByRange) // Visit every range group
        {
            Console.Write(rangeGroup.Key + ": "); // Display the calculated range key

            DisplayNumbers(rangeGroup); // Display numbers in the current range
        }

        // Group number squares by type

        IEnumerable<IGrouping<string, int>> squaresByNumberType = numbers // Begin with the number collection
            .GroupBy( // Group the numbers using a key selector and element selector
                number => number % 2 == 0 ? "Even" : "Odd", // Use Even or Odd as the group key
                number => number * number // Store the square instead of the original number
            );

        Console.WriteLine("\nNumber squares grouped by original number type:"); // Display the element-selector heading

        foreach (IGrouping<string, int> squareGroup in squaresByNumberType) // Visit every square group
        {
            Console.Write(squareGroup.Key + " squares: "); // Display the group key

            DisplayNumbers(squareGroup); // Display the square values stored in the group
        }

        // Create number summaries directly

        var numberGroupSummaries = numbers // Begin with the number collection
            .GroupBy( // Create summaries directly using the result-selector overload
                number => number % 2 == 0 ? "Even" : "Odd", // Use Even or Odd as the key
                (groupKey, groupedNumbers) => new // Create one anonymous result for each group
                {
                    GroupName = groupKey, // Store the group key
                    Count = groupedNumbers.Count(), // Count numbers in the group
                    Sum = groupedNumbers.Sum(), // Calculate the sum of the group
                    Average = groupedNumbers.Average(), // Calculate the group average
                    Minimum = groupedNumbers.Min(), // Find the minimum group value
                    Maximum = groupedNumbers.Max() // Find the maximum group value
                });

        Console.WriteLine("\nEven and odd number summaries:"); // Display the number-summary heading

        foreach (var summary in numberGroupSummaries) // Visit every number-group summary
        {
            Console.WriteLine($"{summary.GroupName} | Count: {summary.Count} | Sum: {summary.Sum} | Average: {summary.Average:F2} | Minimum: {summary.Minimum} | Maximum: {summary.Maximum}"); // Display the complete group summary
        }

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
            new Employee { Id = 109, Name = "Meera", Department = "Support", City = "Delhi", Salary = 45000m, Experience = 2, IsPermanent = true }, // Add the ninth employee
            new Employee { Id = 110, Name = "Ananya", Department = "Data Engineering", City = "Hyderabad", Salary = 90000m, Experience = 6, IsPermanent = true }, // Add the tenth employee
            new Employee { Id = 111, Name = "Kabir", Department = "development", City = null, Salary = 58000m, Experience = 2, IsPermanent = false } // Add an employee with different department casing and no city
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the employee-collection heading

        DisplayEmployees(employees); // Display all employees

        // Group employees by department

        IEnumerable<IGrouping<string, Employee>> employeesByDepartment = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department); // Group employees having the same department

        Console.WriteLine("\nEmployees grouped by department:"); // Display the department-grouping heading

        foreach (IGrouping<string, Employee> departmentGroup in employeesByDepartment) // Visit every department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department key

            DisplayEmployees(departmentGroup); // Display employees in the current department
        }

        // Display group key and count

        Console.WriteLine("\nDepartment group keys and employee counts:"); // Display the group-information heading

        foreach (IGrouping<string, Employee> departmentGroup in employeesByDepartment) // Visit every department group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count() + " employee(s)"); // Display the group key and element count
        }

        // Group employees by city

        IEnumerable<IGrouping<string, Employee>> employeesByCity = employees // Begin with the employee collection
            .GroupBy(employee => employee.City ?? "Not available"); // Group employees using their city or a replacement key

        Console.WriteLine("\nEmployees grouped by city:"); // Display the city-grouping heading

        foreach (IGrouping<string, Employee> cityGroup in employeesByCity) // Visit every city group
        {
            Console.WriteLine("\nCity: " + cityGroup.Key); // Display the city key

            DisplayEmployees(cityGroup); // Display employees in the current city
        }

        // Group only employee names

        IEnumerable<IGrouping<string, string>> employeeNamesByDepartment = employees // Begin with the employee collection
            .GroupBy( // Group selected employee values
                employee => employee.Department, // Use department as the group key
                employee => employee.Name // Store only the employee name in each group
            );

        Console.WriteLine("\nEmployee names grouped by department:"); // Display the element-selector heading

        foreach (IGrouping<string, string> nameGroup in employeeNamesByDepartment) // Visit every department-name group
        {
            Console.WriteLine("\nDepartment: " + nameGroup.Key); // Display the department key

            foreach (string employeeName in nameGroup) // Visit every employee name in the current group
            {
                Console.WriteLine(employeeName); // Display the employee name
            }
        }

        // Group by Boolean property

        IEnumerable<IGrouping<bool, Employee>> employeesByPermanentStatus = employees // Begin with the employee collection
            .GroupBy(employee => employee.IsPermanent); // Group employees by their permanent status

        Console.WriteLine("\nEmployees grouped by permanent status:"); // Display the Boolean-grouping heading

        foreach (IGrouping<bool, Employee> statusGroup in employeesByPermanentStatus) // Visit every permanent-status group
        {
            string statusText = statusGroup.Key ? "Permanent" : "Temporary"; // Convert the Boolean key into readable text

            Console.WriteLine("\nEmployment type: " + statusText); // Display the readable status key

            DisplayEmployees(statusGroup); // Display employees in the current status group
        }

        // Group by first letter

        IEnumerable<IGrouping<char, Employee>> employeesByFirstLetter = employees // Begin with the employee collection
            .GroupBy(employee => employee.Name[0]) // Group employees by the first character of their names
            .OrderBy(group => group.Key); // Arrange the groups alphabetically

        Console.WriteLine("\nEmployees grouped by first letter of name:"); // Display the first-letter grouping heading

        foreach (IGrouping<char, Employee> letterGroup in employeesByFirstLetter) // Visit every first-letter group
        {
            Console.WriteLine("\nLetter: " + letterGroup.Key); // Display the character key

            DisplayEmployees(letterGroup); // Display employees whose names start with the character
        }

        // Group by salary category

        IEnumerable<IGrouping<string, Employee>> employeesBySalaryCategory = employees // Begin with the employee collection
            .GroupBy(employee => // Calculate a salary-category key
                employee.Salary < 50000m // Check whether salary is below fifty thousand
                    ? "Low Salary" // Use Low Salary for the first category
                    : employee.Salary < 75000m // Check whether salary is below seventy-five thousand
                        ? "Medium Salary" // Use Medium Salary for the middle category
                        : "High Salary"); // Use High Salary for the remaining employees

        Console.WriteLine("\nEmployees grouped by salary category:"); // Display the salary-category heading

        foreach (IGrouping<string, Employee> salaryGroup in employeesBySalaryCategory) // Visit every salary-category group
        {
            Console.WriteLine("\nSalary category: " + salaryGroup.Key); // Display the calculated category key

            DisplayEmployees(salaryGroup); // Display employees in the current salary category
        }

        // Group by experience level

        IEnumerable<IGrouping<string, Employee>> employeesByExperienceLevel = employees // Begin with the employee collection
            .GroupBy(employee => // Calculate the experience-level key
                employee.Experience <= 2 // Check whether experience is at most two years
                    ? "Junior" // Use Junior for the first level
                    : employee.Experience <= 4 // Check whether experience is at most four years
                        ? "Intermediate" // Use Intermediate for the middle level
                        : "Senior"); // Use Senior for the remaining employees

        Console.WriteLine("\nEmployees grouped by experience level:"); // Display the experience-grouping heading

        foreach (IGrouping<string, Employee> experienceGroup in employeesByExperienceLevel) // Visit every experience group
        {
            Console.WriteLine("\nExperience level: " + experienceGroup.Key); // Display the calculated experience key

            DisplayEmployees(experienceGroup); // Display employees in the current experience level
        }

        // Group by multiple properties

        var employeesByDepartmentAndCity = employees // Begin with the employee collection
            .GroupBy(employee => new // Create a composite grouping key
            {
                employee.Department, // Include the department in the key
                City = employee.City ?? "Not available" // Include the actual or replacement city in the key
            })
            .OrderBy(group => group.Key.Department) // Arrange groups by department
            .ThenBy(group => group.Key.City); // Arrange equal departments by city

        Console.WriteLine("\nEmployees grouped by department and city:"); // Display the composite-key heading

        foreach (var employeeGroup in employeesByDepartmentAndCity) // Visit every composite-key group
        {
            Console.WriteLine($"\nDepartment: {employeeGroup.Key.Department} | City: {employeeGroup.Key.City}"); // Display both parts of the composite key

            DisplayEmployees(employeeGroup); // Display employees in the current composite group
        }

        // Filter before grouping

        IEnumerable<IGrouping<string, Employee>> highSalaryEmployeesByDepartment = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 60000m) // Keep employees earning at least sixty thousand
            .GroupBy(employee => employee.Department); // Group the filtered employees by department

        Console.WriteLine("\nEmployees earning at least Rs. 60000 grouped by department:"); // Display the filter-before-grouping heading

        foreach (IGrouping<string, Employee> departmentGroup in highSalaryEmployeesByDepartment) // Visit every filtered department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department key

            DisplayEmployees(departmentGroup); // Display matching employees in the group
        }

        // Filter groups after grouping

        IEnumerable<IGrouping<string, Employee>> departmentsHavingMultipleEmployees = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .Where(group => group.Count() >= 2); // Keep groups containing at least two employees

        Console.WriteLine("\nDepartments containing at least 2 employees:"); // Display the filter-after-grouping heading

        foreach (IGrouping<string, Employee> departmentGroup in departmentsHavingMultipleEmployees) // Visit every matching department group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count() + " employee(s)"); // Display the department and count
        }

        // Filter before and after grouping

        IEnumerable<IGrouping<string, Employee>> filteredDepartmentGroups = employees // Begin with the employee collection
            .Where(employee => employee.Salary >= 50000m) // Keep employees earning at least fifty thousand
            .GroupBy(employee => employee.Department) // Group the filtered employees by department
            .Where(group => group.Count() >= 2); // Keep groups containing at least two filtered employees

        Console.WriteLine("\nDepartments having at least 2 employees earning Rs. 50000 or more:"); // Display the combined-filter heading

        foreach (IGrouping<string, Employee> departmentGroup in filteredDepartmentGroups) // Visit every matching group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department key

            DisplayEmployees(departmentGroup); // Display the filtered employees in the group
        }

        // Order groups by key

        IEnumerable<IGrouping<string, Employee>> alphabeticallyOrderedGroups = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .OrderBy(group => group.Key); // Arrange groups alphabetically by key

        Console.WriteLine("\nDepartment groups ordered alphabetically:"); // Display the group-key-ordering heading

        foreach (IGrouping<string, Employee> departmentGroup in alphabeticallyOrderedGroups) // Visit every ordered department group
        {
            Console.WriteLine(departmentGroup.Key); // Display the ordered department key
        }

        // Order groups by count

        IEnumerable<IGrouping<string, Employee>> groupsOrderedByEmployeeCount = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .OrderByDescending(group => group.Count()) // Arrange groups from largest to smallest
            .ThenBy(group => group.Key); // Arrange equal-sized groups alphabetically

        Console.WriteLine("\nDepartments ordered by employee count:"); // Display the count-ordering heading

        foreach (IGrouping<string, Employee> departmentGroup in groupsOrderedByEmployeeCount) // Visit every ordered group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the department and group size
        }

        // Order elements within every group

        var orderedEmployeesInsideGroups = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .OrderBy(group => group.Key) // Arrange department groups alphabetically
            .Select(group => new // Project every group into an anonymous result
            {
                Department = group.Key, // Store the department key
                Employees = group // Begin with employees in the current group
                    .OrderByDescending(employee => employee.Salary) // Arrange employees from highest to lowest salary
                    .ThenBy(employee => employee.Name) // Arrange equal salaries alphabetically
            });

        Console.WriteLine("\nEmployees ordered by salary within every department:"); // Display the inner-ordering heading

        foreach (var department in orderedEmployeesInsideGroups) // Visit every projected department result
        {
            Console.WriteLine("\nDepartment: " + department.Department); // Display the department name

            DisplayEmployees(department.Employees); // Display ordered employees in the department
        }

        // Create detailed department summaries

        var departmentSalarySummaries = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .Select(group => new // Create one summary for every department
            {
                Department = group.Key, // Store the department key
                EmployeeCount = group.Count(), // Count employees in the department
                TotalSalary = group.Sum(employee => employee.Salary), // Calculate the total department salary
                AverageSalary = group.Average(employee => employee.Salary), // Calculate the average department salary
                MinimumSalary = group.Min(employee => employee.Salary), // Find the minimum department salary
                MaximumSalary = group.Max(employee => employee.Salary), // Find the maximum department salary
                MostExperiencedEmployee = group // Begin with employees in the current group
                    .OrderByDescending(employee => employee.Experience) // Arrange employees from most to least experienced
                    .First() // Retrieve the most experienced employee
            })
            .OrderByDescending(summary => summary.AverageSalary); // Arrange summaries from highest to lowest average salary

        Console.WriteLine("\nDepartment salary summaries:"); // Display the salary-summary heading

        foreach (var department in departmentSalarySummaries) // Visit every department summary
        {
            Console.WriteLine($"\nDepartment: {department.Department}"); // Display the department name

            Console.WriteLine("Employee count: " + department.EmployeeCount); // Display the employee count

            Console.WriteLine("Total salary: Rs. " + department.TotalSalary.ToString("F2")); // Display the total salary

            Console.WriteLine("Average salary: Rs. " + department.AverageSalary.ToString("F2")); // Display the average salary

            Console.WriteLine("Minimum salary: Rs. " + department.MinimumSalary.ToString("F2")); // Display the minimum salary

            Console.WriteLine("Maximum salary: Rs. " + department.MaximumSalary.ToString("F2")); // Display the maximum salary

            Console.WriteLine("Most experienced employee: " + department.MostExperiencedEmployee.Name); // Display the most experienced employee name
        }

        // Use GroupBy result selector

        var directDepartmentSummaries = employees // Begin with the employee collection
            .GroupBy( // Group employees and directly create results
                employee => employee.Department, // Use department as the group key
                (department, departmentEmployees) => new // Create one summary from each key and group
                {
                    Department = department, // Store the department key
                    EmployeeCount = departmentEmployees.Count(), // Count department employees
                    TotalSalary = departmentEmployees.Sum(employee => employee.Salary), // Calculate the total salary
                    EmployeeNames = departmentEmployees // Begin with employees in the group
                        .Select(employee => employee.Name) // Select employee names
                        .OrderBy(name => name) // Arrange employee names alphabetically
                });

        Console.WriteLine("\nDepartment summaries using the GroupBy() result-selector overload:"); // Display the result-selector heading

        foreach (var department in directDepartmentSummaries) // Visit every direct summary
        {
            Console.WriteLine($"\n{department.Department} | Employees: {department.EmployeeCount} | Total salary: Rs. {department.TotalSalary:F2}"); // Display the department summary

            foreach (string employeeName in department.EmployeeNames) // Visit every employee name in the summary
            {
                Console.WriteLine(employeeName); // Display the employee name
            }
        }

        // Use key, element and result selectors

        var departmentNameResults = employees // Begin with the employee collection
            .GroupBy( // Use key, element and result selectors
                employee => employee.Department, // Use department as the key
                employee => employee.Name, // Store only employee names as group elements
                (department, employeeNames) => new // Create one result from each key and name sequence
                {
                    Department = department, // Store the department key
                    Names = employeeNames.OrderBy(name => name), // Arrange and store employee names
                    NameCount = employeeNames.Count() // Count employee names
                });

        Console.WriteLine("\nEmployee names using all major GroupBy() selectors:"); // Display the full-overload heading

        foreach (var department in departmentNameResults) // Visit every department-name result
        {
            Console.WriteLine($"\n{department.Department} -> {department.NameCount} name(s)"); // Display the department and name count

            foreach (string employeeName in department.Names) // Visit every employee name
            {
                Console.WriteLine(employeeName); // Display the current employee name
            }
        }

        // Case-sensitive grouping

        IEnumerable<IGrouping<string, Employee>> caseSensitiveDepartmentGroups = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department); // Group departments using default case-sensitive comparison

        Console.WriteLine("\nCase-sensitive department groups:"); // Display the case-sensitive heading

        foreach (IGrouping<string, Employee> departmentGroup in caseSensitiveDepartmentGroups) // Visit every case-sensitive group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the key and count
        }

        // Case-insensitive grouping

        IEnumerable<IGrouping<string, Employee>> caseInsensitiveDepartmentGroups = employees // Begin with the employee collection
            .GroupBy( // Group departments using a custom comparer
                employee => employee.Department, // Use department as the key
                StringComparer.OrdinalIgnoreCase // Compare department keys without considering letter case
            );

        Console.WriteLine("\nCase-insensitive department groups:"); // Display the case-insensitive heading

        foreach (IGrouping<string, Employee> departmentGroup in caseInsensitiveDepartmentGroups) // Visit every case-insensitive group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the key and combined count
        }

        // Nested grouping

        var departmentAndCityHierarchy = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department) // First group employees by department
            .Select(departmentGroup => new // Create one hierarchical result for each department
            {
                Department = departmentGroup.Key, // Store the department key
                CityGroups = departmentGroup // Begin with employees in the department
                    .GroupBy(employee => employee.City ?? "Not available") // Group department employees by city
                    .OrderBy(cityGroup => cityGroup.Key) // Arrange city groups alphabetically
            })
            .OrderBy(result => result.Department); // Arrange department results alphabetically

        Console.WriteLine("\nNested grouping by department and then city:"); // Display the nested-grouping heading

        foreach (var department in departmentAndCityHierarchy) // Visit every department result
        {
            Console.WriteLine("\nDepartment: " + department.Department); // Display the department name

            foreach (IGrouping<string, Employee> cityGroup in department.CityGroups) // Visit every city group inside the department
            {
                Console.WriteLine("  City: " + cityGroup.Key); // Display the nested city key

                foreach (Employee employee in cityGroup) // Visit every employee in the city group
                {
                    Console.WriteLine("    " + employee.Name); // Display the nested employee name
                }
            }
        }

        // Convert groups to dictionary

        Dictionary<string, List<Employee>> departmentDictionary = employees // Begin with the employee collection
            .GroupBy( // Group employees using case-insensitive department comparison
                employee => employee.Department, // Use department as the key
                StringComparer.OrdinalIgnoreCase // Ignore differences in department letter case
            )
            .ToDictionary( // Convert every department group into a dictionary entry
                group => group.Key, // Use the department key as the dictionary key
                group => group.ToList(), // Convert grouped employees into a list value
                StringComparer.OrdinalIgnoreCase // Make dictionary key comparison case-insensitive
            );

        Console.WriteLine("\nDepartment groups converted to a dictionary:"); // Display the group-dictionary heading

        foreach (KeyValuePair<string, List<Employee>> departmentEntry in departmentDictionary) // Visit every dictionary entry
        {
            Console.WriteLine("\nDepartment: " + departmentEntry.Key); // Display the dictionary key

            DisplayEmployees(departmentEntry.Value); // Display employees stored in the dictionary value
        }

        // Compare GroupBy and ToLookup

        IEnumerable<IGrouping<string, Employee>> deferredGroupByQuery = employees // Begin with the employee collection
            .GroupBy(employee => employee.Department); // Define a deferred grouping query

        ILookup<string, Employee> immediateLookup = employees // Begin with the employee collection
            .ToLookup(employee => employee.Department); // Immediately create a department lookup

        employees.Add(new Employee { Id = 112, Name = "Ishita", Department = "Testing", City = "Mumbai", Salary = 60000m, Experience = 3, IsPermanent = true }); // Add another employee after defining both operations

        Console.WriteLine("\nGroupBy() result after adding Ishita:"); // Display the deferred-GroupBy heading

        foreach (IGrouping<string, Employee> departmentGroup in deferredGroupByQuery) // Execute and visit the deferred grouping query
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the updated group counts
        }

        Console.WriteLine("\nToLookup() snapshot after adding Ishita:"); // Display the immediate-lookup heading

        foreach (IGrouping<string, Employee> departmentGroup in immediateLookup) // Visit the previously created lookup groups
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the unchanged lookup counts
        }

        Console.WriteLine("\nEmployees accessed using lookup key Testing:"); // Display the lookup-key-access heading

        DisplayEmployees(immediateLookup["Testing"]); // Display Testing employees captured when the lookup was created

        Console.WriteLine("\nEmployees accessed using missing lookup key Finance:"); // Display the missing-lookup-key heading

        DisplayEmployees(immediateLookup["Finance"]); // Display the empty sequence returned for a missing key

        // Create product collection

        List<Product> products = new List<Product>() // Create a collection of product objects
        {
            new Product { Id = 201, Name = "Laptop", Category = "Electronics", Price = 65000m, Stock = 5 }, // Add the Laptop product
            new Product { Id = 202, Name = "Mouse", Category = "Electronics", Price = 800m, Stock = 20 }, // Add the Mouse product
            new Product { Id = 203, Name = "Chair", Category = "Furniture", Price = 6000m, Stock = 7 }, // Add the Chair product
            new Product { Id = 204, Name = "Table", Category = "Furniture", Price = 9000m, Stock = 4 }, // Add the Table product
            new Product { Id = 205, Name = "Notebook", Category = "Stationery", Price = 100m, Stock = 0 }, // Add the Notebook product
            new Product { Id = 206, Name = "Monitor", Category = "Electronics", Price = 18000m, Stock = 8 } // Add the Monitor product
        };

        Console.WriteLine("\nOriginal product collection:"); // Display the product-collection heading

        DisplayProducts(products); // Display all products

        // Group products by category

        IEnumerable<IGrouping<string, Product>> productsByCategory = products // Begin with the product collection
            .GroupBy(product => product.Category); // Group products by category

        Console.WriteLine("\nProducts grouped by category:"); // Display the product-category heading

        foreach (IGrouping<string, Product> categoryGroup in productsByCategory) // Visit every category group
        {
            Console.WriteLine("\nCategory: " + categoryGroup.Key); // Display the category key

            DisplayProducts(categoryGroup); // Display products in the current category
        }

        // Product category summaries

        var productCategorySummaries = products // Begin with the product collection
            .GroupBy(product => product.Category) // Group products by category
            .Select(group => new // Create one summary for every category
            {
                Category = group.Key, // Store the category key
                ProductCount = group.Count(), // Count products in the category
                TotalStock = group.Sum(product => product.Stock), // Calculate the total category stock
                TotalInventoryValue = group.Sum(product => product.Price * product.Stock), // Calculate the complete category inventory value
                AveragePrice = group.Average(product => product.Price), // Calculate the average category price
                MostExpensiveProduct = group // Begin with products in the category
                    .OrderByDescending(product => product.Price) // Arrange products from highest to lowest price
                    .First() // Retrieve the most expensive product
            })
            .OrderByDescending(summary => summary.TotalInventoryValue); // Arrange summaries by inventory value

        Console.WriteLine("\nProduct category summaries:"); // Display the product-summary heading

        foreach (var category in productCategorySummaries) // Visit every category summary
        {
            Console.WriteLine($"\nCategory: {category.Category}"); // Display the category name

            Console.WriteLine("Product count: " + category.ProductCount); // Display the number of products

            Console.WriteLine("Total stock: " + category.TotalStock); // Display the total stock

            Console.WriteLine("Total inventory value: Rs. " + category.TotalInventoryValue.ToString("F2")); // Display the inventory value

            Console.WriteLine("Average price: Rs. " + category.AveragePrice.ToString("F2")); // Display the average price

            Console.WriteLine("Most expensive product: " + category.MostExpensiveProduct.Name); // Display the most expensive product
        }

        // Create student collection

        List<Student> students = new List<Student>() // Create a collection of student objects
        {
            new Student { Id = 301, Name = "Ali", Course = "Data Engineering", Marks = new List<int>() { 85, 90, 88 } }, // Add the first student
            new Student { Id = 302, Name = "Riya", Course = "Development", Marks = new List<int>() { 70, 75, 80 } }, // Add the second student
            new Student { Id = 303, Name = "Kabir", Course = "Testing", Marks = new List<int>() { 35, 45, 40 } }, // Add the third student
            new Student { Id = 304, Name = "Meera", Course = "Data Engineering", Marks = new List<int>() { 95, 92, 89 } }, // Add the fourth student
            new Student { Id = 305, Name = "Arjun", Course = "Development", Marks = new List<int>() { 55, 60, 58 } }, // Add the fifth student
            new Student { Id = 306, Name = "Zoya", Course = "Testing", Marks = new List<int>() } // Add a student having no marks
        };

        // Group students by course

        IEnumerable<IGrouping<string, Student>> studentsByCourse = students // Begin with the student collection
            .GroupBy(student => student.Course); // Group students by course

        Console.WriteLine("\nStudents grouped by course:"); // Display the student-course heading

        foreach (IGrouping<string, Student> courseGroup in studentsByCourse) // Visit every course group
        {
            Console.WriteLine("\nCourse: " + courseGroup.Key); // Display the course key

            foreach (Student student in courseGroup) // Visit every student in the course
            {
                Console.WriteLine(student.Name); // Display the student name
            }
        }

        // Group students by result

        IEnumerable<IGrouping<string, Student>> studentsByResult = students // Begin with the student collection
            .GroupBy(student => // Calculate the result grouping key
                student.Marks.Count > 0 && student.Marks.Average() >= 40 // Check whether marks exist and the average is passing
                    ? "Pass" // Use Pass for passing students
                    : "Fail"); // Use Fail for remaining students

        Console.WriteLine("\nStudents grouped by result:"); // Display the student-result heading

        foreach (IGrouping<string, Student> resultGroup in studentsByResult) // Visit every result group
        {
            Console.WriteLine("\nResult: " + resultGroup.Key); // Display the result key

            foreach (Student student in resultGroup) // Visit every student in the result group
            {
                double average = student.Marks.Count > 0 ? student.Marks.Average() : 0; // Calculate the student's average safely

                Console.WriteLine($"{student.Name} -> Average: {average:F2}"); // Display the student name and average
            }
        }

        // Group students by grade

        var studentsByGrade = students // Begin with the student collection
            .GroupBy(student => // Calculate the grade key
            {
                double average = student.Marks.Count > 0 ? student.Marks.Average() : 0; // Calculate the student average safely

                return average >= 80 // Check whether the average is at least eighty
                    ? "Grade A" // Use Grade A for the highest category
                    : average >= 60 // Check whether the average is at least sixty
                        ? "Grade B" // Use Grade B for the middle category
                        : average >= 40 // Check whether the average is at least forty
                            ? "Grade C" // Use Grade C for the passing lower category
                            : "Grade F"; // Use Grade F for failing students
            })
            .OrderBy(group => group.Key); // Arrange grade groups alphabetically

        Console.WriteLine("\nStudents grouped by grade:"); // Display the grade-grouping heading

        foreach (IGrouping<string, Student> gradeGroup in studentsByGrade) // Visit every grade group
        {
            Console.WriteLine("\n" + gradeGroup.Key); // Display the grade key

            foreach (Student student in gradeGroup) // Visit every student in the grade group
            {
                Console.WriteLine(student.Name); // Display the student name
            }
        }

        // Group empty collection

        List<Employee> emptyEmployees = new List<Employee>(); // Create an empty employee collection

        IEnumerable<IGrouping<string, Employee>> emptyGroupingResult = emptyEmployees // Begin with the empty collection
            .GroupBy(employee => employee.Department); // Group the empty sequence by department

        Console.WriteLine("\nGrouping an empty employee collection:"); // Display the empty-grouping heading

        Console.WriteLine("Number of groups: " + emptyGroupingResult.Count()); // Display zero because no groups were created

        // Materialize groups

        List<IGrouping<string, Employee>> materializedGroups = employees // Begin with the current employee collection
            .GroupBy(employee => employee.Department) // Group employees by department
            .ToList(); // Execute the grouping query and store the group snapshot

        employees.Add(new Employee { Id = 113, Name = "Farhan", Department = "Support", City = "Mumbai", Salary = 50000m, Experience = 3, IsPermanent = true }); // Add an employee after materializing the groups

        Console.WriteLine("\nMaterialized department groups after adding Farhan to the source:"); // Display the materialized-group heading

        foreach (IGrouping<string, Employee> departmentGroup in materializedGroups) // Visit every previously materialized group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display group counts from the snapshot
        }

        Console.WriteLine("\nNew GroupBy() execution after adding Farhan:"); // Display the new-grouping heading

        foreach (IGrouping<string, Employee> departmentGroup in employees.GroupBy(employee => employee.Department)) // Create and traverse a new grouping operation
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display updated group counts
        }

        // Final message

        Console.WriteLine("\nAll LINQ method-syntax grouping examples completed successfully."); // Display the completion message
    }
}