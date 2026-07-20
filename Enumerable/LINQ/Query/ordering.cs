/*
LINQ Ordering Using Query Expression - Brief Summary

Ordering arranges collection elements according to one or more values.

In LINQ query-expression syntax, ordering is performed using the
orderby clause.

Ascending-order syntax:

var result =
    from item in collection
    orderby item
    select item;

Descending-order syntax:

var result =
    from item in collection
    orderby item descending
    select item;

The ascending keyword is optional because ascending order is the
default order.

These two queries are equivalent:

orderby item
orderby item ascending

Ordering objects by a property:

var result =
    from employee in employees
    orderby employee.Salary descending
    select employee;

Ordering by multiple properties:

var result =
    from employee in employees
    orderby employee.Department ascending,
            employee.Salary descending
    select employee;

The first ordering key is the primary key. When two elements have
the same primary key, the next ordering key is used.

Query-expression and method-syntax equivalents:

orderby value ascending
OrderBy(value => value)

orderby value descending
OrderByDescending(value => value)

orderby firstValue, secondValue
OrderBy(item => firstValue).ThenBy(item => secondValue)

orderby firstValue descending, secondValue descending
OrderByDescending(item => firstValue)
    .ThenByDescending(item => secondValue)

Important points:

1. orderby arranges query results.
2. ascending is the default direction.
3. descending reverses the ordering direction.
4. Multiple ordering keys are separated using commas.
5. Ordering can be applied after filtering.
6. A calculated value can be used as an ordering key.
7. Strings are normally arranged alphabetically.
8. Numbers are normally arranged from smallest to largest.
9. The original collection is not modified.
10. Ordered query results implement IOrderedEnumerable<T>.
11. Query execution is normally deferred until traversal.
12. OrderBy creates primary ordering.
13. ThenBy creates secondary ordering in method syntax.
14. Query syntax represents secondary ordering using another expression
    after a comma in the same orderby clause.

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ query-expression and ordering support

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string? City { get; set; } // Store the employee city or null

    public decimal Salary { get; set; } // Store the employee salary

    public int Experience { get; set; } // Store the employee experience in years

    public bool IsPermanent { get; set; } // Store whether the employee is permanent
}

class OrderingProgram // Define the main program class
{
    // Display integer sequence

    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method that accepts an integer sequence
    {
        foreach (int number in numbers) // Visit every number in the sequence
        {
            Console.Write(number + " "); // Display the current number on the same line
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display string sequence

    static void DisplayStrings(IEnumerable<string> values) // Define a method that accepts a string sequence
    {
        foreach (string value in values) // Visit every string in the sequence
        {
            Console.WriteLine(value); // Display the current string
        }
    }

    // Display employee sequence

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City ?? "Not available"} | Rs. {employee.Salary:F2} | Experience: {employee.Experience} years | Permanent: {employee.IsPermanent}"); // Display the current employee details
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create an unordered collection of integers
        {
            40, // Add 40 to the number collection
            10, // Add 10 to the number collection
            50, // Add 50 to the number collection
            20, // Add 20 to the number collection
            30, // Add 30 to the number collection
            15, // Add 15 to the number collection
            45, // Add 45 to the number collection
            25, // Add 25 to the number collection
            35, // Add 35 to the number collection
            5 // Add 5 to the number collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display the numbers in their original order

        // Order numbers in ascending order

        var ascendingNumbers = // Declare a query that arranges numbers in ascending order
            from number in numbers // Read every number from the collection
            orderby number ascending // Arrange numbers from smallest to largest
            select number; // Select the ordered number

        Console.WriteLine("\nNumbers in ascending order:"); // Display the ascending-order heading

        DisplayNumbers(ascendingNumbers); // Display numbers from smallest to largest

        // Use default ascending order

        var defaultAscendingNumbers = // Declare another ascending-order query
            from number in numbers // Read every number from the collection
            orderby number // Arrange numbers in default ascending order
            select number; // Select the ordered number

        Console.WriteLine("\nNumbers using default orderby direction:"); // Display the default-order heading

        DisplayNumbers(defaultAscendingNumbers); // Display the ascending query result

        // Order numbers in descending order

        var descendingNumbers = // Declare a query that arranges numbers in descending order
            from number in numbers // Read every number from the collection
            orderby number descending // Arrange numbers from largest to smallest
            select number; // Select the ordered number

        Console.WriteLine("\nNumbers in descending order:"); // Display the descending-order heading

        DisplayNumbers(descendingNumbers); // Display numbers from largest to smallest

        // Filter before ordering

        var filteredOrderedNumbers = // Declare a query that filters and then orders numbers
            from number in numbers // Read every number from the collection
            where number >= 20 // Keep numbers greater than or equal to twenty
            orderby number descending // Arrange the filtered numbers from largest to smallest
            select number; // Select the filtered and ordered number

        Console.WriteLine("\nNumbers greater than or equal to 20 in descending order:"); // Display the filter-and-order heading

        DisplayNumbers(filteredOrderedNumbers); // Display the filtered and ordered numbers

        // Order using calculated value

        var numbersOrderedBySquare = // Declare a query that orders numbers using their squares
            from number in numbers // Read every number from the collection
            let square = number * number // Calculate the square of the current number
            orderby square descending // Arrange results from largest to smallest square
            select new // Create an anonymous result object
            {
                Number = number, // Store the original number
                Square = square // Store the calculated square
            };

        Console.WriteLine("\nNumbers ordered by their squares:"); // Display the calculated-ordering heading

        foreach (var item in numbersOrderedBySquare) // Visit every ordered calculation result
        {
            Console.WriteLine(item.Number + " -> " + item.Square); // Display the number and its square
        }

        // Order by remainder

        var numbersOrderedByRemainder = // Declare a query that orders numbers using division remainder
            from number in numbers // Read every number from the collection
            let remainder = number % 10 // Calculate the remainder after division by ten
            orderby remainder ascending, number ascending // Arrange by remainder and then actual number
            select new // Create an anonymous result object
            {
                Number = number, // Store the original number
                Remainder = remainder // Store the calculated remainder
            };

        Console.WriteLine("\nNumbers ordered by remainder after division by 10:"); // Display the remainder-ordering heading

        foreach (var item in numbersOrderedByRemainder) // Visit every ordered remainder result
        {
            Console.WriteLine(item.Number + " -> Remainder: " + item.Remainder); // Display the number and remainder
        }

        // Order even and odd numbers

        var numbersOrderedByType = // Declare a query that arranges even and odd numbers
            from number in numbers // Read every number from the collection
            let numberType = number % 2 == 0 ? "Even" : "Odd" // Determine whether the current number is even or odd
            orderby numberType ascending, number ascending // Arrange by type and then numerical value
            select new // Create an anonymous classification result
            {
                Number = number, // Store the number
                Type = numberType // Store the calculated number type
            };

        Console.WriteLine("\nNumbers ordered by even or odd type:"); // Display the number-type-ordering heading

        foreach (var item in numbersOrderedByType) // Visit every classified and ordered result
        {
            Console.WriteLine(item.Type + " -> " + item.Number); // Display the type and number
        }

        // Create string collection

        List<string> technologies = new List<string>() // Create an unordered collection of technology names
        {
            "Python", // Add Python to the collection
            "C#", // Add C# to the collection
            "MongoDB", // Add MongoDB to the collection
            "Java", // Add Java to the collection
            "PySpark", // Add PySpark to the collection
            "SQL", // Add SQL to the collection
            "Azure Databricks", // Add Azure Databricks to the collection
            "JavaScript" // Add JavaScript to the collection
        };

        Console.WriteLine("\nOriginal technology collection:"); // Display the original-string heading

        DisplayStrings(technologies); // Display strings in their original order

        // Order strings alphabetically

        var technologiesAscending = // Declare a query that arranges technology names alphabetically
            from technology in technologies // Read every technology name from the collection
            orderby technology ascending // Arrange strings in ascending alphabetical order
            select technology; // Select the ordered technology name

        Console.WriteLine("\nTechnologies in ascending alphabetical order:"); // Display the alphabetical-order heading

        DisplayStrings(technologiesAscending); // Display technologies alphabetically

        // Order strings in reverse alphabetical order

        var technologiesDescending = // Declare a query that arranges technology names in reverse order
            from technology in technologies // Read every technology name from the collection
            orderby technology descending // Arrange strings in descending alphabetical order
            select technology; // Select the ordered technology name

        Console.WriteLine("\nTechnologies in descending alphabetical order:"); // Display the reverse-alphabetical heading

        DisplayStrings(technologiesDescending); // Display technologies in reverse alphabetical order

        // Order strings by length

        var technologiesByLength = // Declare a query that orders technology names by their length
            from technology in technologies // Read every technology name from the collection
            orderby technology.Length ascending // Arrange strings from shortest to longest
            select technology; // Select the ordered technology name

        Console.WriteLine("\nTechnologies ordered by name length:"); // Display the length-ordering heading

        foreach (string technology in technologiesByLength) // Visit every technology in length order
        {
            Console.WriteLine(technology + " -> Length: " + technology.Length); // Display the technology and its length
        }

        // Order strings by length and alphabetically

        var technologiesByLengthAndName = // Declare a query that uses two ordering keys
            from technology in technologies // Read every technology name from the collection
            orderby technology.Length ascending, technology ascending // Arrange by length and then alphabetically
            select technology; // Select the ordered technology name

        Console.WriteLine("\nTechnologies ordered by length and then name:"); // Display the multiple-string-ordering heading

        foreach (string technology in technologiesByLengthAndName) // Visit every ordered technology name
        {
            Console.WriteLine(technology.Length + " -> " + technology); // Display the string length and name
        }

        // Order strings by length descending

        var technologiesByLengthDescending = // Declare a query that orders strings from longest to shortest
            from technology in technologies // Read every technology name from the collection
            orderby technology.Length descending, technology ascending // Arrange by descending length and ascending name
            select technology; // Select the ordered technology name

        Console.WriteLine("\nTechnologies ordered from longest to shortest:"); // Display the descending-length heading

        foreach (string technology in technologiesByLengthDescending) // Visit every ordered technology name
        {
            Console.WriteLine(technology.Length + " -> " + technology); // Display the length and technology name
        }

        // Case-insensitive string ordering

        List<string> mixedCaseNames = new List<string>() // Create a collection containing different letter cases
        {
            "banana", // Add lowercase banana
            "Apple", // Add uppercase Apple
            "mango", // Add lowercase mango
            "apple", // Add lowercase apple
            "Banana", // Add uppercase Banana
            "Mango" // Add uppercase Mango
        };

        var caseInsensitiveOrdering = // Declare a query that ignores casing while ordering
            from name in mixedCaseNames // Read every name from the collection
            orderby name.ToLower() ascending, name ascending // Arrange using lowercase text and then original text
            select name; // Select the ordered original name

        Console.WriteLine("\nCase-insensitive string ordering:"); // Display the case-insensitive heading

        DisplayStrings(caseInsensitiveOrdering); // Display the case-insensitively ordered strings

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create an unordered collection of employees
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

        Console.WriteLine("\nOriginal employee collection:"); // Display the original-employee heading

        DisplayEmployees(employees); // Display employees in their original order

        // Order employees by identifier

        var employeesById = // Declare a query that orders employees by identifier
            from employee in employees // Read every employee from the collection
            orderby employee.Id ascending // Arrange employees from smallest to largest identifier
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by ID:"); // Display the identifier-ordering heading

        DisplayEmployees(employeesById); // Display employees in identifier order

        // Order employees by name

        var employeesByName = // Declare a query that orders employees alphabetically by name
            from employee in employees // Read every employee from the collection
            orderby employee.Name ascending // Arrange employees alphabetically by name
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by name:"); // Display the name-ordering heading

        DisplayEmployees(employeesByName); // Display employees alphabetically

        // Order employees by salary ascending

        var employeesBySalaryAscending = // Declare a query that orders employees by salary
            from employee in employees // Read every employee from the collection
            orderby employee.Salary ascending // Arrange employees from lowest to highest salary
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by salary in ascending order:"); // Display the ascending-salary heading

        DisplayEmployees(employeesBySalaryAscending); // Display employees from lowest to highest salary

        // Order employees by salary descending

        var employeesBySalaryDescending = // Declare a query that orders employees by descending salary
            from employee in employees // Read every employee from the collection
            orderby employee.Salary descending // Arrange employees from highest to lowest salary
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by salary in descending order:"); // Display the descending-salary heading

        DisplayEmployees(employeesBySalaryDescending); // Display employees from highest to lowest salary

        // Order employees by experience

        var employeesByExperience = // Declare a query that orders employees by experience
            from employee in employees // Read every employee from the collection
            orderby employee.Experience descending // Arrange employees from most to least experience
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by experience:"); // Display the experience-ordering heading

        DisplayEmployees(employeesByExperience); // Display employees according to experience

        // Order employees by department

        var employeesByDepartment = // Declare a query that orders employees by department
            from employee in employees // Read every employee from the collection
            orderby employee.Department ascending // Arrange departments alphabetically
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by department:"); // Display the department-ordering heading

        DisplayEmployees(employeesByDepartment); // Display employees according to department

        // Order by department and salary

        var employeesByDepartmentAndSalary = // Declare a query that uses department and salary ordering
            from employee in employees // Read every employee from the collection
            orderby employee.Department ascending, employee.Salary descending // Arrange by department and then highest salary
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by department and descending salary:"); // Display the multiple-property-ordering heading

        DisplayEmployees(employeesByDepartmentAndSalary); // Display employees using both ordering keys

        // Order by department, city and name

        var employeesByDepartmentCityAndName = // Declare a query that uses three ordering keys
            from employee in employees // Read every employee from the collection
            orderby employee.Department ascending, employee.City ascending, employee.Name ascending // Arrange by department, city and name
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by department, city and name:"); // Display the three-key-ordering heading

        DisplayEmployees(employeesByDepartmentCityAndName); // Display employees using three ordering keys

        // Filter and order employees

        var orderedHighSalaryEmployees = // Declare a query that filters and orders employees
            from employee in employees // Read every employee from the collection
            where employee.Salary >= 60000m // Keep employees earning at least sixty thousand
            orderby employee.Salary descending, employee.Name ascending // Arrange by salary and then name
            select employee; // Select the filtered and ordered employee

        Console.WriteLine("\nEmployees earning at least Rs. 60000 ordered by salary:"); // Display the filtered-employee-ordering heading

        DisplayEmployees(orderedHighSalaryEmployees); // Display the filtered and ordered employees

        // Order by Boolean property

        var employeesByPermanentStatus = // Declare a query that orders employees by permanent status
            from employee in employees // Read every employee from the collection
            orderby employee.IsPermanent descending, employee.Name ascending // Place permanent employees first and then order by name
            select employee; // Select the ordered employee

        Console.WriteLine("\nPermanent employees followed by temporary employees:"); // Display the Boolean-ordering heading

        DisplayEmployees(employeesByPermanentStatus); // Display employees according to permanent status

        // Order null values last

        var employeesByCityWithNullLast = // Declare a query that places missing cities after available cities
            from employee in employees // Read every employee from the collection
            orderby employee.City == null ascending, employee.City ascending, employee.Name ascending // Arrange non-null cities first and null cities last
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by city with missing cities last:"); // Display the null-last heading

        DisplayEmployees(employeesByCityWithNullLast); // Display employees with null city values at the end

        // Order null values first

        var employeesByCityWithNullFirst = // Declare a query that places missing cities first
            from employee in employees // Read every employee from the collection
            orderby employee.City == null descending, employee.City ascending, employee.Name ascending // Arrange null cities before available cities
            select employee; // Select the ordered employee

        Console.WriteLine("\nEmployees ordered by city with missing cities first:"); // Display the null-first heading

        DisplayEmployees(employeesByCityWithNullFirst); // Display employees with null city values first

        // Order calculated annual salary

        var employeesByAnnualSalary = // Declare a query that orders employees by calculated annual salary
            from employee in employees // Read every employee from the collection
            let annualSalary = employee.Salary * 12m // Calculate the annual salary
            orderby annualSalary descending // Arrange employees from highest to lowest annual salary
            select new // Create an anonymous annual-salary result
            {
                EmployeeName = employee.Name, // Store the employee name
                MonthlySalary = employee.Salary, // Store the monthly salary
                AnnualSalary = annualSalary // Store the calculated annual salary
            };

        Console.WriteLine("\nEmployees ordered by annual salary:"); // Display the annual-salary-ordering heading

        foreach (var employee in employeesByAnnualSalary) // Visit every annual-salary result
        {
            Console.WriteLine($"{employee.EmployeeName} | Monthly: Rs. {employee.MonthlySalary:F2} | Annual: Rs. {employee.AnnualSalary:F2}"); // Display monthly and annual salary
        }

        // Order calculated salary category

        var employeesBySalaryCategory = // Declare a query that orders employees using a calculated category
            from employee in employees // Read every employee from the collection
            let salaryCategory = employee.Salary < 50000m // Begin calculating the salary category
                ? "Low" // Use Low for salary below fifty thousand
                : employee.Salary < 75000m // Check whether salary is below seventy-five thousand
                    ? "Medium" // Use Medium for the middle salary range
                    : "High" // Use High for the remaining salaries
            let categoryOrder = salaryCategory == "High" // Begin assigning a numerical category order
                ? 1 // Assign one to the High category
                : salaryCategory == "Medium" // Check whether the category is Medium
                    ? 2 // Assign two to the Medium category
                    : 3 // Assign three to the Low category
            orderby categoryOrder ascending, employee.Salary descending // Arrange categories and then salary
            select new // Create an anonymous salary-category result
            {
                EmployeeName = employee.Name, // Store the employee name
                Salary = employee.Salary, // Store the employee salary
                Category = salaryCategory // Store the calculated salary category
            };

        Console.WriteLine("\nEmployees ordered by High, Medium and Low salary categories:"); // Display the category-ordering heading

        foreach (var employee in employeesBySalaryCategory) // Visit every category-ordering result
        {
            Console.WriteLine($"{employee.Category} | {employee.EmployeeName} | Rs. {employee.Salary:F2}"); // Display the category, employee and salary
        }

        // Order and project selected properties

        var employeeSummaryQuery = // Declare a query that orders and projects employee properties
            from employee in employees // Read every employee from the collection
            orderby employee.Department ascending, employee.Name ascending // Arrange employees by department and name
            select new // Create an anonymous employee summary
            {
                EmployeeName = employee.Name, // Store the employee name
                DepartmentName = employee.Department, // Store the department name
                EmployeeSalary = employee.Salary // Store the employee salary
            };

        Console.WriteLine("\nOrdered employee summary:"); // Display the ordered-projection heading

        foreach (var employee in employeeSummaryQuery) // Visit every projected employee summary
        {
            Console.WriteLine($"{employee.DepartmentName} | {employee.EmployeeName} | Rs. {employee.EmployeeSalary:F2}"); // Display the ordered projected information
        }

        // Order groups by key

        var orderedDepartmentGroups = // Declare a query that groups employees and orders the groups
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees according to department
            orderby departmentGroup.Key ascending // Arrange department groups alphabetically
            select departmentGroup; // Select each ordered department group

        Console.WriteLine("\nDepartment groups ordered alphabetically:"); // Display the ordered-group heading

        foreach (var departmentGroup in orderedDepartmentGroups) // Visit every ordered department group
        {
            Console.WriteLine("\nDepartment: " + departmentGroup.Key); // Display the department-group key

            foreach (Employee employee in departmentGroup) // Visit every employee in the current group
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        // Order groups by count

        var departmentsOrderedByEmployeeCount = // Declare a query that orders groups using their element count
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            orderby departmentGroup.Count() descending, departmentGroup.Key ascending // Arrange by employee count and then department name
            select new // Create an anonymous department-count summary
            {
                Department = departmentGroup.Key, // Store the department name
                EmployeeCount = departmentGroup.Count() // Store the number of employees
            };

        Console.WriteLine("\nDepartments ordered by employee count:"); // Display the ordered-group-count heading

        foreach (var department in departmentsOrderedByEmployeeCount) // Visit every department-count summary
        {
            Console.WriteLine(department.Department + " -> " + department.EmployeeCount); // Display the department and employee count
        }

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a collection for deferred-execution demonstration
        {
            30, // Add 30 to the deferred collection
            10, // Add 10 to the deferred collection
            20 // Add 20 to the deferred collection
        };

        var deferredOrderingQuery = // Declare an ordering query without executing it immediately
            from number in deferredNumbers // Read numbers when the query is traversed
            orderby number ascending // Arrange values during query execution
            select number; // Select the ordered number

        deferredNumbers.Add(5); // Add 5 after defining the ordering query

        deferredNumbers.Add(40); // Add 40 after defining the ordering query

        Console.WriteLine("\nDeferred ordering result after adding 5 and 40:"); // Display the deferred-execution heading

        DisplayNumbers(deferredOrderingQuery); // Execute the query and display the updated sorted result

        // Final message

        Console.WriteLine("\nAll LINQ query-expression ordering examples completed successfully."); // Display the completion message
    }
}