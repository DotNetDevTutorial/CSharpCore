/*
LINQ Joining Using Method Syntax - Concept Summary

Joining combines related elements from two collections by matching
a common key.

Main joining methods:

1. Join()
   Performs an inner join.
   Returns only records having matching keys in both collections.

Syntax:

var result = firstCollection.Join(
    secondCollection,
    firstItem => firstItem.Key,
    secondItem => secondItem.Key,
    (firstItem, secondItem) => new
    {
        // Selected result
    }
);

2. GroupJoin()
   Connects one element from the first collection with all matching
   elements from the second collection.

Syntax:

var result = firstCollection.GroupJoin(
    secondCollection,
    firstItem => firstItem.Key,
    secondItem => secondItem.Key,
    (firstItem, matchingItems) => new
    {
        FirstItem = firstItem,
        MatchingItems = matchingItems
    }
);

3. Left Outer Join
   Created using:

   GroupJoin()
   SelectMany()
   DefaultIfEmpty()

A left outer join includes every element from the left collection,
even when no matching element exists in the right collection.

Important points:

1. Join() compares keys using equality.
2. The first collection is called the outer collection.
3. The second collection is called the inner collection.
4. Join() produces one result for each matching pair.
5. GroupJoin() produces one result containing a group of matches.
6. Join() and GroupJoin() normally use deferred execution.
7. The original collections are not modified.
8. Both key selectors must return compatible data types.
9. Join() is similar to SQL INNER JOIN.
10. GroupJoin() with DefaultIfEmpty() can create a SQL-like LEFT JOIN.

Required namespace:

using System.Linq;
*/

using System; // Import Console
using System.Collections.Generic; // Import List<T>
using System.Linq; // Import LINQ joining methods

class Department // Define a department class
{
    public int Id { get; set; } // Store the department identifier

    public string Name { get; set; } = ""; // Store the department name
}

class Employee // Define an employee class
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public int DepartmentId { get; set; } // Store the related department identifier
}

class JoiningProgram // Define the main program class
{
    static void Main() // Define the program entry point
    {
        // Create departments

        List<Department> departments = new List<Department>() // Create the department collection
        {
            new Department { Id = 1, Name = "Development" }, // Add Development
            new Department { Id = 2, Name = "Testing" }, // Add Testing
            new Department { Id = 3, Name = "Support" }, // Add Support
            new Department { Id = 4, Name = "HR" } // Add HR without any employee
        };

        // Create employees

        List<Employee> employees = new List<Employee>() // Create the employee collection
        {
            new Employee { Id = 101, Name = "Saad", DepartmentId = 1 }, // Add an employee in Development
            new Employee { Id = 102, Name = "Neha", DepartmentId = 1 }, // Add another employee in Development
            new Employee { Id = 103, Name = "Aman", DepartmentId = 2 }, // Add an employee in Testing
            new Employee { Id = 104, Name = "Rahul", DepartmentId = 3 }, // Add an employee in Support
            new Employee { Id = 105, Name = "Zoya", DepartmentId = 5 } // Add an employee with no matching department
        };

        // Inner join

        var innerJoinResult = departments.Join( // Join departments with employees
            employees, // Specify the inner collection
            department => department.Id, // Select the department key
            employee => employee.DepartmentId, // Select the employee key
            (department, employee) => new // Create a result for every matching pair
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department.Name // Store the department name
            });

        Console.WriteLine("INNER JOIN RESULT:"); // Display the inner-join heading

        foreach (var item in innerJoinResult) // Visit every matching result
        {
            Console.WriteLine($"{item.EmployeeName} -> {item.DepartmentName}"); // Display the employee and department
        }

        // Group join

        var groupJoinResult = departments.GroupJoin( // Group employees under their departments
            employees, // Specify the employee collection
            department => department.Id, // Select the department key
            employee => employee.DepartmentId, // Select the employee key
            (department, matchingEmployees) => new // Create one result for every department
            {
                DepartmentName = department.Name, // Store the department name
                Employees = matchingEmployees // Store all matching employees
            });

        Console.WriteLine("\nGROUP JOIN RESULT:"); // Display the group-join heading

        foreach (var departmentGroup in groupJoinResult) // Visit every department group
        {
            Console.WriteLine(departmentGroup.DepartmentName + ":"); // Display the department name

            if (!departmentGroup.Employees.Any()) // Check whether the department has no employees
            {
                Console.WriteLine("  No employees"); // Display the empty-group message
            }

            foreach (Employee employee in departmentGroup.Employees) // Visit every employee in the current department
            {
                Console.WriteLine("  " + employee.Name); // Display the employee name
            }
        }

        // Left outer join

        var leftJoinResult = departments // Begin with every department
            .GroupJoin( // Group matching employees under each department
                employees, // Specify the employee collection
                department => department.Id, // Select the department key
                employee => employee.DepartmentId, // Select the employee key
                (department, matchingEmployees) => new // Create an intermediate grouped result
                {
                    Department = department, // Preserve the department
                    Employees = matchingEmployees // Preserve matching employees
                })
            .SelectMany( // Convert every employee group into individual result rows
                group => group.Employees.DefaultIfEmpty(), // Supply a null employee when the group is empty
                (group, employee) => new // Create the final left-join result
                {
                    DepartmentName = group.Department.Name, // Store the department name
                    EmployeeName = employee?.Name ?? "No employee" // Store the employee name or default text
                });

        Console.WriteLine("\nLEFT OUTER JOIN RESULT:"); // Display the left-join heading

        foreach (var item in leftJoinResult) // Visit every left-join result
        {
            Console.WriteLine($"{item.DepartmentName} -> {item.EmployeeName}"); // Display the department and employee
        }

        // Join and filter

        var developmentEmployees = departments.Join( // Join departments and employees
            employees, // Specify the employee collection
            department => department.Id, // Select the department key
            employee => employee.DepartmentId, // Select the employee key
            (department, employee) => new // Create a combined result
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department.Name // Store the department name
            })
            .Where(item => item.DepartmentName == "Development"); // Keep only Development employees

        Console.WriteLine("\nDEVELOPMENT EMPLOYEES:"); // Display the filtered-join heading

        foreach (var item in developmentEmployees) // Visit every filtered result
        {
            Console.WriteLine(item.EmployeeName); // Display the employee name
        }
    }
}