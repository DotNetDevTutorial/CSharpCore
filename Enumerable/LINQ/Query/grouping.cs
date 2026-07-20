/*
LINQ Grouping Using Query Expression - Brief Summary

Grouping means arranging collection elements into separate groups
based on a common key.

In LINQ query-expression syntax, grouping is performed using:

group element by key;

Basic syntax:

var result =
    from item in collection
    group item by item.Property;

Example:

var departmentGroups =
    from employee in employees
    group employee by employee.Department;

Each group contains:

1. Key:
   The common value used to create the group.

2. Elements:
   All records having that key.

Accessing grouped results:

foreach (var group in result)
{
    Console.WriteLine(group.Key);

    foreach (var item in group)
    {
        Console.WriteLine(item);
    }
}

Grouping with into:

var result =
    from employee in employees
    group employee by employee.Department into employeeGroup
    select employeeGroup;

The into keyword stores the created group in a new range variable
and allows the query to continue.

Grouping with calculations:

var result =
    from employee in employees
    group employee by employee.Department into employeeGroup
    select new
    {
        Department = employeeGroup.Key,
        EmployeeCount = employeeGroup.Count(),
        TotalSalary = employeeGroup.Sum(employee => employee.Salary),
        AverageSalary = employeeGroup.Average(employee => employee.Salary)
    };

Grouping by multiple properties:

var result =
    from employee in employees
    group employee by new
    {
        employee.Department,
        employee.City
    };

Important points:

1. The group clause creates groups based on a common key.
2. Every group implements IGrouping<TKey, TElement>.
3. The Key property identifies the group.
4. A group can contain one or many elements.
5. The into keyword allows the query to continue after grouping.
6. where can filter the groups after into.
7. orderby can arrange groups according to their keys.
8. Aggregation methods can calculate values for every group.
9. Anonymous objects can be used as multiple-property group keys.
10. The original collection is not modified.
11. Query execution is normally deferred until traversal.
12. Grouping is useful for reports, summaries, categories, and totals.

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ query-expression and grouping support

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string City { get; set; } = ""; // Store the employee city

    public decimal Salary { get; set; } // Store the employee salary

    public int Experience { get; set; } // Store employee experience in years

    public bool IsPermanent { get; set; } // Store whether the employee is permanent
}

class GroupingProgram // Define the main program class
{
    // Display employee

    static void DisplayEmployee(Employee employee) // Define a method that accepts one employee
    {
        Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City} | Rs. {employee.Salary:F2} | Experience: {employee.Experience} years | Permanent: {employee.IsPermanent}"); // Display the employee details
    }

    // Display employee collection

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            DisplayEmployee(employee); // Display the current employee
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
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
            new Employee { Id = 110, Name = "Ananya", Department = "Data Engineering", City = "Hyderabad", Salary = 90000m, Experience = 6, IsPermanent = true } // Add the tenth employee
        };

        Console.WriteLine("Original employee collection:"); // Display the original-collection heading

        DisplayEmployees(employees); // Display all employees

        // Group by department

        var employeesByDepartment = // Declare a query that groups employees by department
            from employee in employees // Read every employee from the collection
            group employee by employee.Department; // Group employees having the same department

        Console.WriteLine("\nEmployees grouped by department:"); // Display the department-grouping heading

        foreach (var departmentGroup in employeesByDepartment) // Visit every department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the key of the current group

            foreach (Employee employee in departmentGroup) // Visit every employee in the current group
            {
                DisplayEmployee(employee); // Display the current employee
            }
        }

        // Understand group key and elements

        Console.WriteLine("\nDepartment group details:"); // Display the group-details heading

        foreach (var departmentGroup in employeesByDepartment) // Visit every department group
        {
            string departmentName = departmentGroup.Key; // Store the key of the current group

            int employeeCount = departmentGroup.Count(); // Count the employees in the current group

            Console.WriteLine(departmentName + " contains " + employeeCount + " employee(s)."); // Display the group key and element count
        }

        // Group by city

        var employeesByCity = // Declare a query that groups employees by city
            from employee in employees // Read every employee from the collection
            group employee by employee.City; // Group employees having the same city

        Console.WriteLine("\nEmployees grouped by city:"); // Display the city-grouping heading

        foreach (var cityGroup in employeesByCity) // Visit every city group
        {
            Console.WriteLine("\nCity: " + cityGroup.Key); // Display the current city key

            foreach (Employee employee in cityGroup) // Visit every employee in the current city group
            {
                Console.WriteLine(employee.Name); // Display the current employee name
            }
        }

        // Group using into

        var departmentGroupsUsingInto = // Declare a query that continues after grouping
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees and store each group in departmentGroup
            select departmentGroup; // Select every created department group

        Console.WriteLine("\nGrouping using the into keyword:"); // Display the into-clause heading

        foreach (var departmentGroup in departmentGroupsUsingInto) // Visit every selected department group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count() + " employee(s)"); // Display the group key and number of elements
        }

        // Group and order groups

        var orderedDepartmentGroups = // Declare a query that groups and orders departments
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by their department
            orderby departmentGroup.Key ascending // Arrange groups alphabetically by department
            select departmentGroup; // Select each ordered group

        Console.WriteLine("\nDepartment groups in alphabetical order:"); // Display the ordered-group heading

        foreach (var departmentGroup in orderedDepartmentGroups) // Visit every ordered department group
        {
            Console.WriteLine(departmentGroup.Key); // Display the current department key
        }

        // Group and order by group size

        var groupsOrderedBySize = // Declare a query that arranges groups by their element count
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            orderby departmentGroup.Count() descending // Arrange groups from largest to smallest
            select departmentGroup; // Select each ordered group

        Console.WriteLine("\nDepartments ordered by employee count:"); // Display the group-size-ordering heading

        foreach (var departmentGroup in groupsOrderedBySize) // Visit every ordered department group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the department and employee count
        }

        // Filter groups after grouping

        var departmentsHavingMultipleEmployees = // Declare a query that filters groups
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            where departmentGroup.Count() > 2 // Keep groups containing more than two employees
            select departmentGroup; // Select the remaining groups

        Console.WriteLine("\nDepartments having more than 2 employees:"); // Display the filtered-group heading

        foreach (var departmentGroup in departmentsHavingMultipleEmployees) // Visit every matching department group
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the matching department and count
        }

        // Group with employee count

        var departmentCountSummary = // Declare a query that produces a department-count summary
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            orderby departmentGroup.Key // Arrange the groups alphabetically
            select new // Create an anonymous summary object
            {
                Department = departmentGroup.Key, // Store the group key
                EmployeeCount = departmentGroup.Count() // Store the number of employees in the group
            };

        Console.WriteLine("\nEmployee count by department:"); // Display the department-count heading

        foreach (var department in departmentCountSummary) // Visit every department summary
        {
            Console.WriteLine(department.Department + " -> " + department.EmployeeCount); // Display the department and employee count
        }

        // Group with salary aggregations

        var departmentSalarySummary = // Declare a query that calculates salary information for each department
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            let totalSalary = departmentGroup.Sum(employee => employee.Salary) // Calculate the total salary of the group
            let averageSalary = departmentGroup.Average(employee => employee.Salary) // Calculate the average salary of the group
            let minimumSalary = departmentGroup.Min(employee => employee.Salary) // Find the minimum salary in the group
            let maximumSalary = departmentGroup.Max(employee => employee.Salary) // Find the maximum salary in the group
            orderby averageSalary descending // Arrange groups from highest to lowest average salary
            select new // Create an anonymous salary-summary object
            {
                Department = departmentGroup.Key, // Store the department name
                EmployeeCount = departmentGroup.Count(), // Store the employee count
                TotalSalary = totalSalary, // Store the total salary
                AverageSalary = averageSalary, // Store the average salary
                MinimumSalary = minimumSalary, // Store the minimum salary
                MaximumSalary = maximumSalary // Store the maximum salary
            };

        Console.WriteLine("\nSalary summary by department:"); // Display the salary-summary heading

        foreach (var department in departmentSalarySummary) // Visit every department salary summary
        {
            Console.WriteLine("\nDepartment: " + department.Department); // Display the department name

            Console.WriteLine("Employee count: " + department.EmployeeCount); // Display the employee count

            Console.WriteLine("Total salary: Rs. " + department.TotalSalary.ToString("F2")); // Display the total department salary

            Console.WriteLine("Average salary: Rs. " + department.AverageSalary.ToString("F2")); // Display the average department salary

            Console.WriteLine("Minimum salary: Rs. " + department.MinimumSalary.ToString("F2")); // Display the minimum department salary

            Console.WriteLine("Maximum salary: Rs. " + department.MaximumSalary.ToString("F2")); // Display the maximum department salary
        }

        // Group by multiple properties

        var employeesByDepartmentAndCity = // Declare a query that groups by department and city
            from employee in employees // Read every employee from the collection
            group employee by new // Create a composite grouping key
            {
                employee.Department, // Include the employee department in the key
                employee.City // Include the employee city in the key
            }
            into employeeGroup // Store every created group in employeeGroup
            orderby employeeGroup.Key.Department, employeeGroup.Key.City // Arrange groups by department and then city
            select employeeGroup; // Select each composite-key group

        Console.WriteLine("\nEmployees grouped by department and city:"); // Display the multiple-property-grouping heading

        foreach (var employeeGroup in employeesByDepartmentAndCity) // Visit every composite-key group
        {
            Console.WriteLine($"\nDepartment: {employeeGroup.Key.Department}, City: {employeeGroup.Key.City}"); // Display both parts of the group key

            foreach (Employee employee in employeeGroup) // Visit every employee in the current group
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        // Multiple-key grouping summary

        var departmentCitySummary = // Declare a query that summarizes department and city groups
            from employee in employees // Read every employee from the collection
            group employee by new // Create a composite grouping key
            {
                employee.Department, // Store department in the grouping key
                employee.City // Store city in the grouping key
            }
            into employeeGroup // Continue the query using the grouped elements
            select new // Create an anonymous result object
            {
                Department = employeeGroup.Key.Department, // Store the department from the composite key
                City = employeeGroup.Key.City, // Store the city from the composite key
                EmployeeCount = employeeGroup.Count(), // Count the employees in the group
                TotalSalary = employeeGroup.Sum(employee => employee.Salary) // Calculate the total salary of the group
            };

        Console.WriteLine("\nDepartment and city summary:"); // Display the composite-summary heading

        foreach (var group in departmentCitySummary) // Visit every department-city summary
        {
            Console.WriteLine($"{group.Department} | {group.City} | Employees: {group.EmployeeCount} | Total salary: Rs. {group.TotalSalary:F2}"); // Display the summary details
        }

        // Group by Boolean property

        var employeesByEmploymentType = // Declare a query that groups employees by permanent status
            from employee in employees // Read every employee from the collection
            group employee by employee.IsPermanent; // Group employees by their Boolean permanent value

        Console.WriteLine("\nEmployees grouped by employment type:"); // Display the Boolean-grouping heading

        foreach (var employmentGroup in employeesByEmploymentType) // Visit every employment-status group
        {
            string employmentType = employmentGroup.Key ? "Permanent" : "Temporary"; // Convert the Boolean key into readable text

            Console.WriteLine("\nEmployment type: " + employmentType); // Display the employment-type heading

            foreach (Employee employee in employmentGroup) // Visit every employee in the current group
            {
                Console.WriteLine(employee.Name); // Display the current employee name
            }
        }

        // Group by first character

        var employeesByFirstLetter = // Declare a query that groups names by their first character
            from employee in employees // Read every employee from the collection
            group employee by employee.Name[0] into letterGroup // Group employees by the first character of their names
            orderby letterGroup.Key // Arrange the letter groups alphabetically
            select letterGroup; // Select every ordered letter group

        Console.WriteLine("\nEmployees grouped by first letter of name:"); // Display the first-letter-grouping heading

        foreach (var letterGroup in employeesByFirstLetter) // Visit every first-letter group
        {
            Console.WriteLine("\nLetter: " + letterGroup.Key); // Display the first-letter key

            foreach (Employee employee in letterGroup) // Visit every employee whose name starts with the letter
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        // Group by calculated salary range

        var employeesBySalaryRange = // Declare a query that groups employees by salary category
            from employee in employees // Read every employee from the collection
            let salaryRange = employee.Salary < 50000m // Begin determining the salary category
                ? "Low Salary" // Use Low Salary when salary is below fifty thousand
                : employee.Salary < 75000m // Check whether salary is below seventy-five thousand
                    ? "Medium Salary" // Use Medium Salary for the middle range
                    : "High Salary" // Use High Salary for the remaining salaries
            group employee by salaryRange into salaryGroup // Group employees using the calculated salary category
            select salaryGroup; // Select each salary-category group

        Console.WriteLine("\nEmployees grouped by salary range:"); // Display the calculated-grouping heading

        foreach (var salaryGroup in employeesBySalaryRange) // Visit every salary-range group
        {
            Console.WriteLine("\nSalary range: " + salaryGroup.Key); // Display the calculated group key

            foreach (Employee employee in salaryGroup) // Visit every employee in the salary group
            {
                Console.WriteLine(employee.Name + " -> Rs. " + employee.Salary.ToString("F2")); // Display the employee name and salary
            }
        }

        // Group by experience range

        var employeesByExperienceLevel = // Declare a query that groups employees by experience level
            from employee in employees // Read every employee from the collection
            let experienceLevel = employee.Experience <= 2 // Begin determining the experience category
                ? "Beginner" // Use Beginner for two or fewer years
                : employee.Experience <= 4 // Check whether experience is four years or fewer
                    ? "Intermediate" // Use Intermediate for three to four years
                    : "Experienced" // Use Experienced for more than four years
            group employee by experienceLevel into experienceGroup // Group employees using the calculated experience level
            select new // Create an anonymous experience summary
            {
                ExperienceLevel = experienceGroup.Key, // Store the experience-level key
                EmployeeCount = experienceGroup.Count(), // Store the number of employees
                EmployeeNames = experienceGroup.Select(employee => employee.Name) // Select the names from the group
            };

        Console.WriteLine("\nEmployees grouped by experience level:"); // Display the experience-grouping heading

        foreach (var experienceGroup in employeesByExperienceLevel) // Visit every experience summary
        {
            Console.WriteLine("\nExperience level: " + experienceGroup.ExperienceLevel); // Display the experience-level key

            Console.WriteLine("Employee count: " + experienceGroup.EmployeeCount); // Display the number of employees

            foreach (string employeeName in experienceGroup.EmployeeNames) // Visit every name in the current group
            {
                Console.WriteLine(employeeName); // Display the employee name
            }
        }

        // Filter before grouping

        var permanentEmployeesByDepartment = // Declare a query that filters before grouping
            from employee in employees // Read every employee from the collection
            where employee.IsPermanent // Keep only permanent employees
            group employee by employee.Department into departmentGroup // Group the filtered employees by department
            select departmentGroup; // Select every department group

        Console.WriteLine("\nPermanent employees grouped by department:"); // Display the filter-before-grouping heading

        foreach (var departmentGroup in permanentEmployeesByDepartment) // Visit every permanent-employee department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department key

            foreach (Employee employee in departmentGroup) // Visit every permanent employee in the group
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        // Filter before and after grouping

        var selectedDepartmentSummary = // Declare a query that filters elements and groups
            from employee in employees // Read every employee from the collection
            where employee.Salary >= 50000m // Keep employees earning at least fifty thousand
            group employee by employee.Department into departmentGroup // Group the filtered employees by department
            where departmentGroup.Count() >= 2 // Keep groups containing at least two matching employees
            orderby departmentGroup.Key // Arrange the remaining groups alphabetically
            select new // Create an anonymous group summary
            {
                Department = departmentGroup.Key, // Store the department name
                MatchingEmployees = departmentGroup.Count(), // Store the matching employee count
                AverageSalary = departmentGroup.Average(employee => employee.Salary) // Store the average salary
            };

        Console.WriteLine("\nDepartments having at least 2 employees earning Rs. 50000 or more:"); // Display the combined-filter heading

        foreach (var department in selectedDepartmentSummary) // Visit every matching department summary
        {
            Console.WriteLine($"{department.Department} | Employees: {department.MatchingEmployees} | Average salary: Rs. {department.AverageSalary:F2}"); // Display the summary information
        }

        // Group selected properties

        var namesGroupedByDepartment = // Declare a query that groups only employee names
            from employee in employees // Read every employee from the collection
            group employee.Name by employee.Department into nameGroup // Group employee names according to department
            orderby nameGroup.Key // Arrange the groups alphabetically
            select nameGroup; // Select every name group

        Console.WriteLine("\nEmployee names grouped by department:"); // Display the selected-element-grouping heading

        foreach (var nameGroup in namesGroupedByDepartment) // Visit every department name group
        {
            Console.WriteLine("\nDepartment: " + nameGroup.Key); // Display the department key

            foreach (string employeeName in nameGroup) // Visit every employee name in the current group
            {
                Console.WriteLine(employeeName); // Display the employee name
            }
        }

        // Create number collection

        List<int> numbers = new List<int>() // Create an integer collection for number grouping
        {
            10, // Add 10 to the collection
            15, // Add 15 to the collection
            20, // Add 20 to the collection
            25, // Add 25 to the collection
            30, // Add 30 to the collection
            35, // Add 35 to the collection
            40 // Add 40 to the collection
        };

        // Group numbers as even and odd

        var numbersByType = // Declare a query that groups numbers as even or odd
            from number in numbers // Read every number from the collection
            group number by number % 2 == 0 ? "Even" : "Odd" into numberGroup // Group numbers using their divisibility by two
            select numberGroup; // Select each number group

        Console.WriteLine("\nNumbers grouped as even and odd:"); // Display the number-grouping heading

        foreach (var numberGroup in numbersByType) // Visit every number group
        {
            Console.Write(numberGroup.Key + ": "); // Display the even-or-odd group key

            foreach (int number in numberGroup) // Visit every number in the current group
            {
                Console.Write(number + " "); // Display the current number
            }

            Console.WriteLine(); // Move the cursor to the next line
        }

        // Number group summary

        var numberGroupSummary = // Declare a query that calculates information for even and odd groups
            from number in numbers // Read every number from the collection
            group number by number % 2 == 0 ? "Even" : "Odd" into numberGroup // Group numbers as even or odd
            select new // Create an anonymous number-group summary
            {
                GroupName = numberGroup.Key, // Store the group key
                Count = numberGroup.Count(), // Count numbers in the group
                Sum = numberGroup.Sum(), // Calculate the sum of the group
                Average = numberGroup.Average(), // Calculate the average of the group
                Minimum = numberGroup.Min(), // Find the smallest group value
                Maximum = numberGroup.Max() // Find the largest group value
            };

        Console.WriteLine("\nEven and odd number summary:"); // Display the number-summary heading

        foreach (var numberGroup in numberGroupSummary) // Visit every number-group summary
        {
            Console.WriteLine($"{numberGroup.GroupName} | Count: {numberGroup.Count} | Sum: {numberGroup.Sum} | Average: {numberGroup.Average:F2} | Minimum: {numberGroup.Minimum} | Maximum: {numberGroup.Maximum}"); // Display the complete number summary
        }

        // Demonstrate deferred execution

        List<Employee> deferredEmployees = new List<Employee>() // Create an employee collection for deferred execution
        {
            new Employee { Id = 201, Name = "Ali", Department = "Development", City = "Pune", Salary = 50000m, Experience = 2, IsPermanent = true }, // Add the first deferred employee
            new Employee { Id = 202, Name = "Riya", Department = "Testing", City = "Delhi", Salary = 45000m, Experience = 2, IsPermanent = true } // Add the second deferred employee
        };

        var deferredGroupingQuery = // Declare a grouping query without executing it immediately
            from employee in deferredEmployees // Read employees when the query is traversed
            group employee by employee.Department; // Group employees by department during execution

        deferredEmployees.Add(new Employee { Id = 203, Name = "Kabir", Department = "Development", City = "Pune", Salary = 55000m, Experience = 3, IsPermanent = false }); // Add another employee after defining the query

        Console.WriteLine("\nDeferred grouping result after adding another employee:"); // Display the deferred-execution heading

        foreach (var departmentGroup in deferredGroupingQuery) // Execute and visit the grouping query
        {
            Console.WriteLine(departmentGroup.Key + " -> " + departmentGroup.Count()); // Display the department and updated employee count
        }

        // Final message

        Console.WriteLine("\nAll LINQ query-expression grouping examples completed successfully."); // Display the completion message
    }
}