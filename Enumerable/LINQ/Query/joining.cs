/*
LINQ Joining Using Query Expression - Brief Summary

Joining combines related records from two or more collections using
a common key.

In LINQ query-expression syntax, joining is performed using:

join ... in ... on ... equals ...

Basic inner-join syntax:

var result =
    from employee in employees
    join department in departments
    on employee.DepartmentId equals department.Id
    select new
    {
        employee.Name,
        DepartmentName = department.Name
    };

Important:

The equals keyword is used inside a LINQ join.
Do not use == in the join condition.

Correct:

on employee.DepartmentId equals department.Id

Incorrect:

on employee.DepartmentId == department.Id

Types of joins demonstrated in this program:

1. Inner join:
   Returns only records having matching keys in both collections.

2. Multiple join:
   Combines information from more than two collections.

3. Composite-key join:
   Matches records using two or more properties.

4. Group join:
   Connects one parent record with a collection of matching child records.

5. Left outer join:
   Returns every record from the left collection, including records
   that do not have a matching record in the right collection.

6. Self join:
   Joins a collection with itself.

Inner-join syntax:

var result =
    from leftItem in leftCollection
    join rightItem in rightCollection
    on leftItem.Key equals rightItem.Key
    select new
    {
        LeftValue = leftItem.Value,
        RightValue = rightItem.Value
    };

Group-join syntax:

var result =
    from department in departments
    join employee in employees
    on department.Id equals employee.DepartmentId
    into employeeGroup
    select new
    {
        department.Name,
        Employees = employeeGroup
    };

Left-outer-join syntax:

var result =
    from department in departments
    join employee in employees
    on department.Id equals employee.DepartmentId
    into employeeGroup
    from employee in employeeGroup.DefaultIfEmpty()
    select new
    {
        DepartmentName = department.Name,
        EmployeeName = employee == null ? "No employee" : employee.Name
    };

Important points:

1. A query expression begins with the from clause.
2. The join clause reads records from the second collection.
3. The on clause specifies the key from the left collection.
4. The equals clause specifies the key from the right collection.
5. The key types on both sides must be compatible.
6. An inner join excludes records that do not have matching keys.
7. The into keyword creates a group join.
8. DefaultIfEmpty() converts a group join into a left outer join.
9. Multiple join clauses can be used in one query.
10. Anonymous objects are commonly used to return joined information.
11. The original collections are not modified.
12. LINQ queries normally use deferred execution.

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ query-expression and joining support

class Department // Define a class representing a department
{
    public int Id { get; set; } // Store the department identifier

    public string Name { get; set; } = ""; // Store the department name
}

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public int DepartmentId { get; set; } // Store the related department identifier

    public string City { get; set; } = ""; // Store the employee city

    public decimal Salary { get; set; } // Store the employee salary

    public int? ManagerId { get; set; } // Store the manager identifier or null
}

class Project // Define a class representing a project
{
    public int Id { get; set; } // Store the project identifier

    public string Name { get; set; } = ""; // Store the project name

    public string Technology { get; set; } = ""; // Store the primary project technology
}

class Assignment // Define a class connecting an employee with a project
{
    public int EmployeeId { get; set; } // Store the assigned employee identifier

    public int ProjectId { get; set; } // Store the assigned project identifier

    public string Role { get; set; } = ""; // Store the employee role in the project

    public int Hours { get; set; } // Store the number of assigned hours
}

class DepartmentOffice // Define a class representing an office for a department and city
{
    public int DepartmentId { get; set; } // Store the related department identifier

    public string City { get; set; } = ""; // Store the office city

    public string OfficeName { get; set; } = ""; // Store the office name
}

class JoiningProgram // Define the main program class
{
    // Display departments

    static void DisplayDepartments(IEnumerable<Department> departments) // Define a method that accepts a department sequence
    {
        foreach (Department department in departments) // Visit every department in the sequence
        {
            Console.WriteLine($"{department.Id} | {department.Name}"); // Display the current department details
        }
    }

    // Display employees

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | Department ID: {employee.DepartmentId} | {employee.City} | Rs. {employee.Salary:F2}"); // Display the current employee details
        }
    }

    // Display projects

    static void DisplayProjects(IEnumerable<Project> projects) // Define a method that accepts a project sequence
    {
        foreach (Project project in projects) // Visit every project in the sequence
        {
            Console.WriteLine($"{project.Id} | {project.Name} | {project.Technology}"); // Display the current project details
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create department collection

        List<Department> departments = new List<Department>() // Create a collection of departments
        {
            new Department { Id = 1, Name = "Development" }, // Add the Development department
            new Department { Id = 2, Name = "Testing" }, // Add the Testing department
            new Department { Id = 3, Name = "Data Engineering" }, // Add the Data Engineering department
            new Department { Id = 4, Name = "Human Resources" }, // Add the Human Resources department
            new Department { Id = 5, Name = "Support" } // Add the Support department
        };

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of employees
        {
            new Employee { Id = 101, Name = "Saad", DepartmentId = 1, City = "Pune", Salary = 65000m, ManagerId = 103 }, // Add the first employee
            new Employee { Id = 102, Name = "Aman", DepartmentId = 2, City = "Delhi", Salary = 48000m, ManagerId = 108 }, // Add the second employee
            new Employee { Id = 103, Name = "Neha", DepartmentId = 1, City = "Pune", Salary = 75000m, ManagerId = null }, // Add the third employee
            new Employee { Id = 104, Name = "Rahul", DepartmentId = 5, City = "Bengaluru", Salary = 38000m, ManagerId = 109 }, // Add the fourth employee
            new Employee { Id = 105, Name = "Priya", DepartmentId = 3, City = "Hyderabad", Salary = 82000m, ManagerId = 110 }, // Add the fifth employee
            new Employee { Id = 106, Name = "Arjun", DepartmentId = 1, City = "Delhi", Salary = 55000m, ManagerId = 103 }, // Add the sixth employee
            new Employee { Id = 107, Name = "Zoya", DepartmentId = 3, City = "Pune", Salary = 70000m, ManagerId = 110 }, // Add the seventh employee
            new Employee { Id = 108, Name = "Karan", DepartmentId = 2, City = "Pune", Salary = 52000m, ManagerId = null }, // Add the eighth employee
            new Employee { Id = 109, Name = "Meera", DepartmentId = 5, City = "Delhi", Salary = 45000m, ManagerId = null }, // Add the ninth employee
            new Employee { Id = 110, Name = "Ananya", DepartmentId = 3, City = "Hyderabad", Salary = 90000m, ManagerId = null }, // Add the tenth employee
            new Employee { Id = 111, Name = "Kabir", DepartmentId = 99, City = "Mumbai", Salary = 42000m, ManagerId = null } // Add an employee having no matching department
        };

        // Create project collection

        List<Project> projects = new List<Project>() // Create a collection of projects
        {
            new Project { Id = 201, Name = "Banking Platform", Technology = "C#" }, // Add the Banking Platform project
            new Project { Id = 202, Name = "Enterprise Data Lake", Technology = "PySpark" }, // Add the Enterprise Data Lake project
            new Project { Id = 203, Name = "Automation Suite", Technology = "Selenium" }, // Add the Automation Suite project
            new Project { Id = 204, Name = "Internal Portal", Technology = "ASP.NET" }, // Add the Internal Portal project
            new Project { Id = 205, Name = "Unused Research Project", Technology = "Python" } // Add a project having no assignment
        };

        // Create assignment collection

        List<Assignment> assignments = new List<Assignment>() // Create a collection of employee-project assignments
        {
            new Assignment { EmployeeId = 101, ProjectId = 201, Role = "Backend Developer", Hours = 120 }, // Assign Saad to the Banking Platform
            new Assignment { EmployeeId = 103, ProjectId = 201, Role = "Technical Lead", Hours = 80 }, // Assign Neha to the Banking Platform
            new Assignment { EmployeeId = 105, ProjectId = 202, Role = "Data Engineer", Hours = 160 }, // Assign Priya to the Enterprise Data Lake
            new Assignment { EmployeeId = 107, ProjectId = 202, Role = "Data Analyst", Hours = 100 }, // Assign Zoya to the Enterprise Data Lake
            new Assignment { EmployeeId = 102, ProjectId = 203, Role = "QA Engineer", Hours = 90 }, // Assign Aman to the Automation Suite
            new Assignment { EmployeeId = 108, ProjectId = 203, Role = "QA Lead", Hours = 110 }, // Assign Karan to the Automation Suite
            new Assignment { EmployeeId = 106, ProjectId = 204, Role = "Developer", Hours = 70 } // Assign Arjun to the Internal Portal
        };

        // Create department-office collection

        List<DepartmentOffice> offices = new List<DepartmentOffice>() // Create a collection of department offices
        {
            new DepartmentOffice { DepartmentId = 1, City = "Pune", OfficeName = "Development Pune Office" }, // Add the Development Pune office
            new DepartmentOffice { DepartmentId = 1, City = "Delhi", OfficeName = "Development Delhi Office" }, // Add the Development Delhi office
            new DepartmentOffice { DepartmentId = 2, City = "Delhi", OfficeName = "Testing Delhi Office" }, // Add the Testing Delhi office
            new DepartmentOffice { DepartmentId = 2, City = "Pune", OfficeName = "Testing Pune Office" }, // Add the Testing Pune office
            new DepartmentOffice { DepartmentId = 3, City = "Hyderabad", OfficeName = "Data Engineering Hyderabad Office" }, // Add the Data Engineering Hyderabad office
            new DepartmentOffice { DepartmentId = 3, City = "Pune", OfficeName = "Data Engineering Pune Office" }, // Add the Data Engineering Pune office
            new DepartmentOffice { DepartmentId = 5, City = "Delhi", OfficeName = "Support Delhi Office" } // Add the Support Delhi office
        };

        // Display original collections

        Console.WriteLine("Departments:"); // Display the department-collection heading

        DisplayDepartments(departments); // Display all departments

        Console.WriteLine("\nEmployees:"); // Display the employee-collection heading

        DisplayEmployees(employees); // Display all employees

        Console.WriteLine("\nProjects:"); // Display the project-collection heading

        DisplayProjects(projects); // Display all projects

        // Simple inner join

        var employeeDepartmentJoin = // Declare a query that joins employees with departments
            from employee in employees // Read every employee from the employee collection
            join department in departments // Read matching departments from the department collection
            on employee.DepartmentId equals department.Id // Match the employee department ID with the department ID
            select new // Create an anonymous result object
            {
                EmployeeId = employee.Id, // Store the employee identifier
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department.Name, // Store the matching department name
                EmployeeCity = employee.City, // Store the employee city
                EmployeeSalary = employee.Salary // Store the employee salary
            };

        Console.WriteLine("\nSimple inner join between employees and departments:"); // Display the inner-join heading

        foreach (var record in employeeDepartmentJoin) // Visit every joined result
        {
            Console.WriteLine($"{record.EmployeeId} | {record.EmployeeName} | {record.DepartmentName} | {record.EmployeeCity} | Rs. {record.EmployeeSalary:F2}"); // Display the joined information
        }

        // Understand inner-join behaviour

        Console.WriteLine("\nKabir is not displayed because Department ID 99 has no matching department."); // Explain why the unmatched employee is excluded

        Console.WriteLine("Human Resources is not displayed because it has no matching employee."); // Explain why the unmatched department is excluded

        // Inner join with filtering

        var highSalaryEmployeeJoin = // Declare a query that joins and filters employees
            from employee in employees // Read every employee from the collection
            join department in departments // Join the department collection
            on employee.DepartmentId equals department.Id // Match related department identifiers
            where employee.Salary >= 60000m // Keep joined employees earning at least sixty thousand
            select new // Create an anonymous filtered result object
            {
                employee.Name, // Store the employee name
                Department = department.Name, // Store the department name
                employee.Salary // Store the employee salary
            };

        Console.WriteLine("\nJoined employees earning at least Rs. 60000:"); // Display the filtered-join heading

        foreach (var record in highSalaryEmployeeJoin) // Visit every filtered joined record
        {
            Console.WriteLine($"{record.Name} | {record.Department} | Rs. {record.Salary:F2}"); // Display the filtered joined information
        }

        // Inner join with ordering

        var orderedJoinResult = // Declare a query that joins and orders employees
            from employee in employees // Read every employee from the collection
            join department in departments // Join the department collection
            on employee.DepartmentId equals department.Id // Match related department identifiers
            orderby department.Name ascending, employee.Salary descending // Sort by department and then salary
            select new // Create an anonymous ordered result object
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department.Name, // Store the department name
                employee.Salary // Store the employee salary
            };

        Console.WriteLine("\nJoined records ordered by department and salary:"); // Display the ordered-join heading

        foreach (var record in orderedJoinResult) // Visit every ordered joined record
        {
            Console.WriteLine($"{record.DepartmentName} | {record.EmployeeName} | Rs. {record.Salary:F2}"); // Display the ordered joined information
        }

        // Join and select specific properties

        var employeeDepartmentNames = // Declare a query that selects only required joined properties
            from employee in employees // Read every employee from the collection
            join department in departments // Join the department collection
            on employee.DepartmentId equals department.Id // Match related department identifiers
            select $"{employee.Name} works in {department.Name}"; // Create and select a formatted string

        Console.WriteLine("\nFormatted employee-department information:"); // Display the formatted-result heading

        foreach (string information in employeeDepartmentNames) // Visit every formatted joined result
        {
            Console.WriteLine(information); // Display the current formatted result
        }

        // Multiple joins

        var employeeProjectJoin = // Declare a query that joins four collections
            from employee in employees // Read every employee from the employee collection
            join department in departments // Join the department collection
            on employee.DepartmentId equals department.Id // Match employees with departments
            join assignment in assignments // Join the assignment collection
            on employee.Id equals assignment.EmployeeId // Match employees with their assignments
            join project in projects // Join the project collection
            on assignment.ProjectId equals project.Id // Match assignments with projects
            select new // Create an anonymous multiple-join result
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department.Name, // Store the department name
                ProjectName = project.Name, // Store the project name
                project.Technology, // Store the project technology
                assignment.Role, // Store the employee project role
                assignment.Hours // Store the assigned working hours
            };

        Console.WriteLine("\nEmployees joined with departments, assignments and projects:"); // Display the multiple-join heading

        foreach (var record in employeeProjectJoin) // Visit every multiple-join result
        {
            Console.WriteLine($"{record.EmployeeName} | {record.DepartmentName} | {record.ProjectName} | {record.Technology} | {record.Role} | {record.Hours} hours"); // Display the complete joined information
        }

        // Filter multiple join

        var dataProjectEmployees = // Declare a filtered multiple-join query
            from employee in employees // Read every employee from the collection
            join assignment in assignments // Join the assignment collection
            on employee.Id equals assignment.EmployeeId // Match employees with assignments
            join project in projects // Join the project collection
            on assignment.ProjectId equals project.Id // Match assignments with projects
            where project.Technology == "PySpark" // Keep assignments belonging to PySpark projects
            select new // Create an anonymous filtered project result
            {
                EmployeeName = employee.Name, // Store the employee name
                ProjectName = project.Name, // Store the project name
                project.Technology, // Store the project technology
                assignment.Role // Store the project role
            };

        Console.WriteLine("\nEmployees working on PySpark projects:"); // Display the filtered-multiple-join heading

        foreach (var record in dataProjectEmployees) // Visit every matching project assignment
        {
            Console.WriteLine($"{record.EmployeeName} | {record.ProjectName} | {record.Technology} | {record.Role}"); // Display the matching project details
        }

        // Composite-key join

        var employeeOfficeJoin = // Declare a query that joins using multiple keys
            from employee in employees // Read every employee from the employee collection
            join office in offices // Join the department-office collection
            on new // Create the employee-side composite key
            {
                employee.DepartmentId, // Include the employee department identifier
                employee.City // Include the employee city
            }
            equals new // Create the office-side composite key
            {
                office.DepartmentId, // Include the office department identifier
                office.City // Include the office city
            }
            select new // Create an anonymous composite-join result
            {
                EmployeeName = employee.Name, // Store the employee name
                employee.City, // Store the employee city
                office.OfficeName // Store the matching office name
            };

        Console.WriteLine("\nComposite-key join using DepartmentId and City:"); // Display the composite-key-join heading

        foreach (var record in employeeOfficeJoin) // Visit every composite-key join result
        {
            Console.WriteLine($"{record.EmployeeName} | {record.City} | {record.OfficeName}"); // Display the matching employee and office
        }

        // Group join

        var departmentEmployeeGroupJoin = // Declare a query that creates employee groups for departments
            from department in departments // Read every department from the department collection
            join employee in employees // Join the employee collection
            on department.Id equals employee.DepartmentId // Match departments with employees
            into employeeGroup // Store all matching employees inside a group
            select new // Create an anonymous group-join result
            {
                DepartmentName = department.Name, // Store the department name
                Employees = employeeGroup // Store the matching employee collection
            };

        Console.WriteLine("\nGroup join between departments and employees:"); // Display the group-join heading

        foreach (var department in departmentEmployeeGroupJoin) // Visit every department group
        {
            Console.WriteLine("\nDepartment: " + department.DepartmentName); // Display the current department name

            if (department.Employees.Any()) // Check whether the department has matching employees
            {
                foreach (Employee employee in department.Employees) // Visit every employee in the current group
                {
                    Console.WriteLine(employee.Name); // Display the current employee name
                }
            }
            else // Execute when the department has no employees
            {
                Console.WriteLine("No employees"); // Display the empty-group message
            }
        }

        // Group join with calculations

        var departmentSummaryJoin = // Declare a query that summarizes matching employees
            from department in departments // Read every department from the collection
            join employee in employees // Join the employee collection
            on department.Id equals employee.DepartmentId // Match departments with employees
            into employeeGroup // Store matching employees in a group
            orderby department.Name // Arrange departments alphabetically
            select new // Create an anonymous department summary
            {
                DepartmentName = department.Name, // Store the department name
                EmployeeCount = employeeGroup.Count(), // Count matching employees
                TotalSalary = employeeGroup.Sum(employee => employee.Salary), // Calculate the total matching salary
                AverageSalary = employeeGroup.Any() // Check whether the group contains employees
                    ? employeeGroup.Average(employee => employee.Salary) // Calculate the average when employees exist
                    : 0m // Use zero when the department has no employees
            };

        Console.WriteLine("\nDepartment summary using group join:"); // Display the group-join-summary heading

        foreach (var department in departmentSummaryJoin) // Visit every department summary
        {
            Console.WriteLine($"{department.DepartmentName} | Employees: {department.EmployeeCount} | Total salary: Rs. {department.TotalSalary:F2} | Average salary: Rs. {department.AverageSalary:F2}"); // Display the department summary
        }

        // Left outer join from departments

        var departmentEmployeeLeftJoin = // Declare a left outer join from departments to employees
            from department in departments // Read every department from the left collection
            join employee in employees // Join employees from the right collection
            on department.Id equals employee.DepartmentId // Match departments with employees
            into employeeGroup // Store matching employees in a group
            from employee in employeeGroup.DefaultIfEmpty() // Return one default value when no employee exists
            select new // Create an anonymous left-join result
            {
                DepartmentName = department.Name, // Store the department name
                EmployeeName = employee == null ? "No employee" : employee.Name, // Store the employee name or a default message
                EmployeeSalary = employee == null ? 0m : employee.Salary // Store the salary or zero
            };

        Console.WriteLine("\nLeft outer join showing every department:"); // Display the department-left-join heading

        foreach (var record in departmentEmployeeLeftJoin) // Visit every left-join result
        {
            Console.WriteLine($"{record.DepartmentName} | {record.EmployeeName} | Rs. {record.EmployeeSalary:F2}"); // Display the department and matching employee
        }

        // Left outer join from employees

        var employeeDepartmentLeftJoin = // Declare a left outer join from employees to departments
            from employee in employees // Read every employee from the left collection
            join department in departments // Join departments from the right collection
            on employee.DepartmentId equals department.Id // Match employees with departments
            into departmentGroup // Store matching departments in a group
            from department in departmentGroup.DefaultIfEmpty() // Return a default value when no department exists
            select new // Create an anonymous employee-left-join result
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department == null ? "Department not found" : department.Name // Store the department name or a default message
            };

        Console.WriteLine("\nLeft outer join showing every employee:"); // Display the employee-left-join heading

        foreach (var record in employeeDepartmentLeftJoin) // Visit every employee-left-join result
        {
            Console.WriteLine($"{record.EmployeeName} | {record.DepartmentName}"); // Display the employee and matching department
        }

        // Left outer join between projects and assignments

        var projectAssignmentLeftJoin = // Declare a left outer join from projects to assignments
            from project in projects // Read every project from the left collection
            join assignment in assignments // Join assignments from the right collection
            on project.Id equals assignment.ProjectId // Match projects with assignments
            into assignmentGroup // Store matching assignments in a group
            from assignment in assignmentGroup.DefaultIfEmpty() // Return a default assignment when no match exists
            join employee in employees // Join the employee collection
            on assignment == null ? -1 : assignment.EmployeeId equals employee.Id // Match assignment employees or use an invalid key
            into employeeGroup // Store matching employees in a group
            from employee in employeeGroup.DefaultIfEmpty() // Return a default employee when no match exists
            select new // Create an anonymous project-left-join result
            {
                ProjectName = project.Name, // Store the project name
                EmployeeName = employee == null ? "No employee assigned" : employee.Name, // Store the employee name or a default message
                Role = assignment == null ? "No role" : assignment.Role // Store the assignment role or a default message
            };

        Console.WriteLine("\nLeft outer join showing every project:"); // Display the project-left-join heading

        foreach (var record in projectAssignmentLeftJoin) // Visit every project-left-join result
        {
            Console.WriteLine($"{record.ProjectName} | {record.EmployeeName} | {record.Role}"); // Display the project and assignment details
        }

        // Self join

        var employeeManagerJoin = // Declare a query that joins the employee collection with itself
            from employee in employees // Read every employee from the first employee reference
            join manager in employees // Join the same collection using a manager reference
            on employee.ManagerId equals (int?)manager.Id // Match the employee manager ID with another employee ID
            into managerGroup // Store matching managers in a group
            from manager in managerGroup.DefaultIfEmpty() // Return a default manager when no manager exists
            select new // Create an anonymous self-join result
            {
                EmployeeName = employee.Name, // Store the employee name
                ManagerName = manager == null ? "No manager" : manager.Name // Store the manager name or a default message
            };

        Console.WriteLine("\nSelf join showing employees and managers:"); // Display the self-join heading

        foreach (var record in employeeManagerJoin) // Visit every employee-manager result
        {
            Console.WriteLine($"{record.EmployeeName} -> {record.ManagerName}"); // Display the employee and manager
        }

        // Join with aggregation

        var projectWorkSummary = // Declare a query that joins projects with assignment groups
            from project in projects // Read every project from the collection
            join assignment in assignments // Join the assignment collection
            on project.Id equals assignment.ProjectId // Match projects with assignments
            into assignmentGroup // Store matching assignments in a group
            select new // Create an anonymous work-summary result
            {
                ProjectName = project.Name, // Store the project name
                AssignedEmployees = assignmentGroup.Count(), // Count the matching assignments
                TotalAssignedHours = assignmentGroup.Sum(assignment => assignment.Hours) // Calculate the total assigned hours
            };

        Console.WriteLine("\nProject work summary using group join:"); // Display the project-summary heading

        foreach (var project in projectWorkSummary) // Visit every project work summary
        {
            Console.WriteLine($"{project.ProjectName} | Employees: {project.AssignedEmployees} | Total hours: {project.TotalAssignedHours}"); // Display the project summary
        }

        // Join after filtering

        var puneEmployeeDepartmentJoin = // Declare a query that filters before returning the joined result
            from employee in employees // Read every employee from the collection
            where employee.City == "Pune" // Keep employees located in Pune
            join department in departments // Join the department collection
            on employee.DepartmentId equals department.Id // Match related department identifiers
            select new // Create an anonymous filtered-join result
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = department.Name, // Store the department name
                employee.City // Store the employee city
            };

        Console.WriteLine("\nPune employees with their departments:"); // Display the filter-before-join heading

        foreach (var record in puneEmployeeDepartmentJoin) // Visit every matching Pune employee
        {
            Console.WriteLine($"{record.EmployeeName} | {record.DepartmentName} | {record.City}"); // Display the joined Pune employee details
        }

        // Demonstrate deferred execution

        List<Employee> deferredEmployees = new List<Employee>() // Create an employee collection for deferred execution
        {
            new Employee { Id = 301, Name = "Ali", DepartmentId = 1, City = "Pune", Salary = 50000m }, // Add the first deferred employee
            new Employee { Id = 302, Name = "Riya", DepartmentId = 2, City = "Delhi", Salary = 47000m } // Add the second deferred employee
        };

        var deferredJoinQuery = // Declare a join query without immediately executing it
            from employee in deferredEmployees // Read employees when the query is traversed
            join department in departments // Join departments during query execution
            on employee.DepartmentId equals department.Id // Match employee and department identifiers
            select new // Create an anonymous deferred result
            {
                employee.Name, // Store the employee name
                DepartmentName = department.Name // Store the matching department name
            };

        deferredEmployees.Add(new Employee { Id = 303, Name = "Farhan", DepartmentId = 3, City = "Hyderabad", Salary = 60000m }); // Add an employee after defining the query

        Console.WriteLine("\nDeferred join result after adding Farhan:"); // Display the deferred-execution heading

        foreach (var record in deferredJoinQuery) // Execute and traverse the deferred join query
        {
            Console.WriteLine($"{record.Name} | {record.DepartmentName}"); // Display the joined result including the new employee
        }

        // Final message

        Console.WriteLine("\nAll LINQ query-expression joining examples completed successfully."); // Display the completion message
    }
}