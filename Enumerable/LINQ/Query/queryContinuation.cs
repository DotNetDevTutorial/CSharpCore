/*
LINQ Query Continuation Using into - Brief Summary

Query continuation allows a LINQ query to continue after a select
or group clause.

Normally, select and group end a query expression. The into keyword
stores the result in a new range variable so that additional query
operations can be performed.

Basic syntax after select:

var result =
    from item in collection
    select expression into temporaryResult
    where condition
    orderby temporaryResult
    select temporaryResult;

Example:

var result =
    from number in numbers
    select number * number into square
    where square > 100
    orderby square descending
    select square;

Basic syntax after group:

var result =
    from employee in employees
    group employee by employee.Department into departmentGroup
    where departmentGroup.Count() > 1
    orderby departmentGroup.Key
    select departmentGroup;

Important behaviour:

After into, a new query range begins.

The previous range variables are no longer directly available unless
they were included in the value passed into the continuation.

Example:

from product in products
select new
{
    Product = product,
    FinalPrice = product.Price * 0.90m
}
into result
where result.FinalPrice > 1000
select result;

Here, the original product remains available through result.Product.

The continuation variable can be used with:

1. where
2. orderby
3. let
4. select
5. group
6. another into continuation

Important points:

1. Query continuation uses the into keyword.
2. It commonly follows select or group.
3. It creates a new range variable.
4. The previous range variables go out of scope.
5. Required original values must be projected before into.
6. More than one continuation can be used.
7. Filtering can be applied after projection.
8. Groups can be filtered after grouping.
9. Calculated results can be ordered after projection.
10. Query continuation normally uses deferred execution.
11. It does not modify the original collection.
12. Query continuation improves readability in multi-stage queries.

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ query-expression support

class Product // Define a class representing a product
{
    public int Id { get; set; } // Store the product identifier

    public string Name { get; set; } = ""; // Store the product name

    public string Category { get; set; } = ""; // Store the product category

    public decimal Price { get; set; } // Store the original product price

    public decimal DiscountPercentage { get; set; } // Store the discount percentage

    public int Stock { get; set; } // Store the available product quantity
}

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string City { get; set; } = ""; // Store the employee city

    public decimal Salary { get; set; } // Store the monthly employee salary

    public int Experience { get; set; } // Store the employee experience in years
}

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public string Course { get; set; } = ""; // Store the student course

    public List<int> Marks { get; set; } = new List<int>(); // Store the marks obtained by the student
}

class QueryContinuationProgram // Define the main program class
{
    // Display number collection

    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method that accepts an integer sequence
    {
        bool valueFound = false; // Track whether any number is available

        foreach (int number in numbers) // Visit every number in the sequence
        {
            Console.Write(number + " "); // Display the current number

            valueFound = true; // Record that a number was found
        }

        if (!valueFound) // Check whether the sequence was empty
        {
            Console.Write("No matching values"); // Display the no-result message
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display products

    static void DisplayProducts(IEnumerable<Product> products) // Define a method that accepts a product sequence
    {
        foreach (Product product in products) // Visit every product in the sequence
        {
            Console.WriteLine($"{product.Id} | {product.Name} | {product.Category} | Rs. {product.Price:F2} | Discount: {product.DiscountPercentage}% | Stock: {product.Stock}"); // Display the product information
        }
    }

    // Display employees

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City} | Rs. {employee.Salary:F2} | Experience: {employee.Experience} years"); // Display the employee information
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
            30 // Add 30 to the collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all original numbers

        // Continue query after select

        var squareContinuationQuery = // Declare a query that continues after projecting squares
            from number in numbers // Read every number from the collection
            select number * number into square // Calculate the square and continue using square
            where square > 200 // Keep squared values greater than two hundred
            orderby square descending // Arrange the remaining squares from largest to smallest
            select square; // Select the final squared value

        Console.WriteLine("\nSquares greater than 200 using query continuation:"); // Display the square-continuation heading

        DisplayNumbers(squareContinuationQuery); // Display the continued query result

        // Continue after anonymous projection

        var numberDetailsQuery = // Declare a query that continues after creating anonymous objects
            from number in numbers // Read every number from the collection
            select new // Create the first projected object
            {
                Number = number, // Store the original number
                Square = number * number, // Store the square of the number
                Cube = number * number * number // Store the cube of the number
            }
            into numberDetails // Continue the query using the projected object
            where numberDetails.Square >= 100 // Keep objects whose square is at least one hundred
            orderby numberDetails.Cube descending // Arrange results by descending cube
            select numberDetails; // Select the complete projected object

        Console.WriteLine("\nNumber details after continuation:"); // Display the anonymous-continuation heading

        foreach (var item in numberDetailsQuery) // Visit every continued number result
        {
            Console.WriteLine($"{item.Number} | Square: {item.Square} | Cube: {item.Cube}"); // Display the number calculations
        }

        // Use let after continuation

        var percentageQuery = // Declare a query that uses let after continuation
            from number in numbers // Read every number from the collection
            select number into selectedNumber // Continue using the selected number
            let percentage = selectedNumber / 30.0 * 100.0 // Calculate the number as a percentage of thirty
            where percentage >= 50.0 // Keep percentages greater than or equal to fifty
            orderby percentage descending // Arrange results from highest to lowest percentage
            select new // Create the final projected object
            {
                Number = selectedNumber, // Store the continued number
                Percentage = percentage // Store the calculated percentage
            };

        Console.WriteLine("\nNumbers representing at least 50% of 30:"); // Display the let-after-continuation heading

        foreach (var item in percentageQuery) // Visit every percentage result
        {
            Console.WriteLine($"{item.Number} -> {item.Percentage:F2}%"); // Display the number and percentage
        }

        // Use multiple continuations

        var multipleContinuationQuery = // Declare a query containing more than one continuation
            from number in numbers // Read every number from the collection
            select number * 2 into doubledNumber // Double the number and continue using doubledNumber
            where doubledNumber >= 20 // Keep doubled values greater than or equal to twenty
            select doubledNumber * doubledNumber into doubledSquare // Square the doubled value and continue again
            where doubledSquare <= 2500 // Keep squared values not exceeding two thousand five hundred
            orderby doubledSquare ascending // Arrange the results from smallest to largest
            select doubledSquare; // Select the final result

        Console.WriteLine("\nResults using multiple query continuations:"); // Display the multiple-continuation heading

        DisplayNumbers(multipleContinuationQuery); // Display the final continued values

        // Continue and classify values

        var classificationContinuationQuery = // Declare a query that classifies projected values
            from number in numbers // Read every number from the collection
            select new // Create an initial projection
            {
                Number = number, // Store the original number
                Type = number % 2 == 0 ? "Even" : "Odd" // Classify the number as even or odd
            }
            into classifiedNumber // Continue using the classification result
            where classifiedNumber.Type == "Even" // Keep only even-number objects
            orderby classifiedNumber.Number descending // Arrange even numbers from largest to smallest
            select classifiedNumber; // Select the final classification object

        Console.WriteLine("\nEven numbers after projection and continuation:"); // Display the classification-continuation heading

        foreach (var item in classificationContinuationQuery) // Visit every matching classified number
        {
            Console.WriteLine(item.Number + " -> " + item.Type); // Display the number and its classification
        }

        // Create product collection

        List<Product> products = new List<Product>() // Create a collection of product objects
        {
            new Product { Id = 101, Name = "Laptop", Category = "Electronics", Price = 65000m, DiscountPercentage = 10m, Stock = 5 }, // Add the Laptop product
            new Product { Id = 102, Name = "Mouse", Category = "Electronics", Price = 800m, DiscountPercentage = 5m, Stock = 20 }, // Add the Mouse product
            new Product { Id = 103, Name = "Chair", Category = "Furniture", Price = 6000m, DiscountPercentage = 15m, Stock = 7 }, // Add the Chair product
            new Product { Id = 104, Name = "Notebook", Category = "Stationery", Price = 100m, DiscountPercentage = 0m, Stock = 0 }, // Add the Notebook product
            new Product { Id = 105, Name = "Monitor", Category = "Electronics", Price = 18000m, DiscountPercentage = 8m, Stock = 8 }, // Add the Monitor product
            new Product { Id = 106, Name = "Table", Category = "Furniture", Price = 9000m, DiscountPercentage = 12m, Stock = 4 } // Add the Table product
        };

        Console.WriteLine("\nOriginal product collection:"); // Display the original-product heading

        DisplayProducts(products); // Display all products

        // Continue after product projection

        var discountedProductQuery = // Declare a query that continues after calculating discounted prices
            from product in products // Read every product from the collection
            let discountAmount = product.Price * product.DiscountPercentage / 100m // Calculate the product discount
            select new // Create an initial discounted-product object
            {
                Product = product, // Preserve the complete original product
                DiscountAmount = discountAmount, // Store the calculated discount
                FinalPrice = product.Price - discountAmount // Store the final product price
            }
            into discountedProduct // Continue using the projected discounted-product object
            where discountedProduct.FinalPrice >= 5000m // Keep products whose final price is at least five thousand
            orderby discountedProduct.FinalPrice descending // Arrange products from highest to lowest final price
            select discountedProduct; // Select the continued product result

        Console.WriteLine("\nDiscounted products having final price of at least Rs. 5000:"); // Display the product-continuation heading

        foreach (var item in discountedProductQuery) // Visit every matching discounted product
        {
            Console.WriteLine($"{item.Product.Name} | Original: Rs. {item.Product.Price:F2} | Discount: Rs. {item.DiscountAmount:F2} | Final: Rs. {item.FinalPrice:F2}"); // Display the discounted product information
        }

        // Preserve original source before into

        var availableProductQuery = // Declare a query that preserves the original product before continuation
            from product in products // Read every product from the collection
            select new // Create an object containing the required original values
            {
                OriginalProduct = product, // Preserve the complete original product
                InventoryValue = product.Price * product.Stock // Calculate the inventory value
            }
            into productResult // Continue using the projected product result
            where productResult.OriginalProduct.Stock > 0 // Keep products having available stock
            orderby productResult.InventoryValue descending // Arrange products by descending inventory value
            select new // Create the final result
            {
                ProductName = productResult.OriginalProduct.Name, // Select the preserved product name
                Quantity = productResult.OriginalProduct.Stock, // Select the preserved product stock
                InventoryValue = productResult.InventoryValue // Select the calculated inventory value
            };

        Console.WriteLine("\nAvailable products ordered by inventory value:"); // Display the preserved-source heading

        foreach (var item in availableProductQuery) // Visit every available-product result
        {
            Console.WriteLine($"{item.ProductName} | Quantity: {item.Quantity} | Inventory value: Rs. {item.InventoryValue:F2}"); // Display the inventory information
        }

        // Continue after selecting product category

        var categoryNameQuery = // Declare a query that continues after selecting category names
            from product in products // Read every product from the collection
            select product.Category into categoryName // Select and continue using the category name
            where categoryName.StartsWith("E") || categoryName.StartsWith("F") // Keep selected category names starting with E or F
            orderby categoryName ascending // Arrange category names alphabetically
            select categoryName; // Select the filtered category name

        IEnumerable<string> uniqueCategories = categoryNameQuery.Distinct(); // Remove duplicate category values

        Console.WriteLine("\nSelected unique product categories:"); // Display the category-continuation heading

        foreach (string category in uniqueCategories) // Visit every unique category
        {
            Console.WriteLine(category); // Display the category name
        }

        // Continue after grouping products

        var productCategoryGroups = // Declare a query that continues after grouping products
            from product in products // Read every product from the collection
            group product by product.Category into categoryGroup // Group products by category and continue using the group
            where categoryGroup.Count() >= 2 // Keep categories containing at least two products
            orderby categoryGroup.Key ascending // Arrange groups alphabetically
            select categoryGroup; // Select each matching category group

        Console.WriteLine("\nProduct categories containing at least 2 products:"); // Display the group-continuation heading

        foreach (var categoryGroup in productCategoryGroups) // Visit every matching category group
        {
            Console.WriteLine("\nCategory: " + categoryGroup.Key); // Display the category key

            foreach (Product product in categoryGroup) // Visit every product in the current group
            {
                Console.WriteLine(product.Name); // Display the product name
            }
        }

        // Group and create summary after continuation

        var categorySummaryQuery = // Declare a query that summarizes product groups
            from product in products // Read every product from the collection
            group product by product.Category into categoryGroup // Group products and continue using categoryGroup
            let productCount = categoryGroup.Count() // Count products in the current category
            let totalPrice = categoryGroup.Sum(product => product.Price) // Calculate the category price total
            let averagePrice = categoryGroup.Average(product => product.Price) // Calculate the category average price
            select new // Create an initial category summary
            {
                Category = categoryGroup.Key, // Store the category name
                ProductCount = productCount, // Store the product count
                TotalPrice = totalPrice, // Store the total category price
                AveragePrice = averagePrice // Store the average category price
            }
            into categorySummary // Continue using the created category summary
            where categorySummary.TotalPrice > 10000m // Keep categories whose total price exceeds ten thousand
            orderby categorySummary.TotalPrice descending // Arrange summaries by descending total price
            select categorySummary; // Select the final category summary

        Console.WriteLine("\nCategory summaries having total price above Rs. 10000:"); // Display the summary-continuation heading

        foreach (var category in categorySummaryQuery) // Visit every matching category summary
        {
            Console.WriteLine($"{category.Category} | Products: {category.ProductCount} | Total: Rs. {category.TotalPrice:F2} | Average: Rs. {category.AveragePrice:F2}"); // Display the category summary
        }

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of employee objects
        {
            new Employee { Id = 201, Name = "Saad", Department = "Development", City = "Pune", Salary = 65000m, Experience = 2 }, // Add the first employee
            new Employee { Id = 202, Name = "Aman", Department = "Testing", City = "Delhi", Salary = 48000m, Experience = 3 }, // Add the second employee
            new Employee { Id = 203, Name = "Neha", Department = "Development", City = "Pune", Salary = 75000m, Experience = 5 }, // Add the third employee
            new Employee { Id = 204, Name = "Rahul", Department = "Support", City = "Bengaluru", Salary = 38000m, Experience = 1 }, // Add the fourth employee
            new Employee { Id = 205, Name = "Priya", Department = "Data Engineering", City = "Hyderabad", Salary = 82000m, Experience = 4 }, // Add the fifth employee
            new Employee { Id = 206, Name = "Arjun", Department = "Development", City = "Delhi", Salary = 55000m, Experience = 2 }, // Add the sixth employee
            new Employee { Id = 207, Name = "Zoya", Department = "Data Engineering", City = "Pune", Salary = 70000m, Experience = 3 }, // Add the seventh employee
            new Employee { Id = 208, Name = "Karan", Department = "Testing", City = "Pune", Salary = 52000m, Experience = 4 } // Add the eighth employee
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the original-employee heading

        DisplayEmployees(employees); // Display all employees

        // Continue after employee salary projection

        var annualSalaryQuery = // Declare a query that continues after calculating annual salaries
            from employee in employees // Read every employee from the collection
            select new // Create an annual-salary result
            {
                Employee = employee, // Preserve the complete employee object
                AnnualSalary = employee.Salary * 12m // Calculate the annual salary
            }
            into employeeSalary // Continue using the annual-salary result
            where employeeSalary.AnnualSalary >= 700000m // Keep employees earning at least seven lakh annually
            orderby employeeSalary.AnnualSalary descending // Arrange employees by descending annual salary
            select employeeSalary; // Select the final salary result

        Console.WriteLine("\nEmployees having annual salary of at least Rs. 700000:"); // Display the annual-salary-continuation heading

        foreach (var item in annualSalaryQuery) // Visit every matching salary result
        {
            Console.WriteLine($"{item.Employee.Name} | {item.Employee.Department} | Annual salary: Rs. {item.AnnualSalary:F2}"); // Display the employee and annual salary
        }

        // Continue after grouping employees

        var departmentEmployeeQuery = // Declare a query that continues after grouping employees
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees and continue using departmentGroup
            where departmentGroup.Count() > 1 // Keep departments containing more than one employee
            orderby departmentGroup.Count() descending, departmentGroup.Key ascending // Arrange groups by count and name
            select new // Create the final department result
            {
                Department = departmentGroup.Key, // Store the department name
                EmployeeCount = departmentGroup.Count(), // Store the employee count
                Employees = departmentGroup // Store the grouped employees
            };

        Console.WriteLine("\nDepartments containing more than one employee:"); // Display the employee-group-continuation heading

        foreach (var department in departmentEmployeeQuery) // Visit every matching department
        {
            Console.WriteLine($"\n{department.Department} -> {department.EmployeeCount} employee(s)"); // Display the department name and count

            foreach (Employee employee in department.Employees) // Visit every employee in the department
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        // Continue group summary again

        var departmentSalaryQuery = // Declare a query containing grouping and another continuation
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            select new // Create an initial department salary summary
            {
                Department = departmentGroup.Key, // Store the department name
                EmployeeCount = departmentGroup.Count(), // Store the employee count
                AverageSalary = departmentGroup.Average(employee => employee.Salary), // Calculate the average salary
                MaximumSalary = departmentGroup.Max(employee => employee.Salary) // Calculate the maximum salary
            }
            into salarySummary // Continue using the salary summary
            where salarySummary.AverageSalary >= 50000m // Keep departments having an average salary of at least fifty thousand
            orderby salarySummary.AverageSalary descending // Arrange summaries by average salary
            select salarySummary; // Select the final salary summary

        Console.WriteLine("\nDepartments having average salary of at least Rs. 50000:"); // Display the department-salary heading

        foreach (var department in departmentSalaryQuery) // Visit every department salary summary
        {
            Console.WriteLine($"{department.Department} | Employees: {department.EmployeeCount} | Average: Rs. {department.AverageSalary:F2} | Maximum: Rs. {department.MaximumSalary:F2}"); // Display the salary summary
        }

        // Create student collection

        List<Student> students = new List<Student>() // Create a collection of student objects
        {
            new Student { Id = 301, Name = "Ali", Course = "Data Engineering", Marks = new List<int>() { 85, 90, 88 } }, // Add the first student
            new Student { Id = 302, Name = "Riya", Course = "Development", Marks = new List<int>() { 70, 75, 80 } }, // Add the second student
            new Student { Id = 303, Name = "Kabir", Course = "Testing", Marks = new List<int>() { 35, 45, 40 } }, // Add the third student
            new Student { Id = 304, Name = "Meera", Course = "Data Engineering", Marks = new List<int>() { 95, 92, 89 } }, // Add the fourth student
            new Student { Id = 305, Name = "Arjun", Course = "Development", Marks = new List<int>() } // Add a student having no marks
        };

        // Continue after student-result projection

        var passedStudentQuery = // Declare a query that continues after calculating student results
            from student in students // Read every student from the collection
            let totalMarks = student.Marks.Sum() // Calculate the total marks
            let subjectCount = student.Marks.Count // Count the student's subjects
            let averageMarks = subjectCount > 0 ? (double)totalMarks / subjectCount : 0 // Calculate the average safely
            select new // Create an initial student-result object
            {
                Student = student, // Preserve the complete student object
                TotalMarks = totalMarks, // Store the total marks
                AverageMarks = averageMarks, // Store the average marks
                Result = averageMarks >= 40 ? "Pass" : "Fail" // Calculate the result status
            }
            into studentResult // Continue using the calculated student result
            where studentResult.Result == "Pass" // Keep only students who passed
            orderby studentResult.AverageMarks descending // Arrange students by descending average marks
            select studentResult; // Select the final student result

        Console.WriteLine("\nPassed students ordered by average marks:"); // Display the student-continuation heading

        foreach (var student in passedStudentQuery) // Visit every passed-student result
        {
            Console.WriteLine($"{student.Student.Name} | {student.Student.Course} | Total: {student.TotalMarks} | Average: {student.AverageMarks:F2} | {student.Result}"); // Display the student result
        }

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a collection for deferred execution
        {
            10, // Add 10 to the collection
            20, // Add 20 to the collection
            30 // Add 30 to the collection
        };

        var deferredContinuationQuery = // Declare a continuation query without executing it immediately
            from number in deferredNumbers // Read numbers when the query is traversed
            select number * number into square // Calculate squares during query execution
            where square >= 400 // Keep squares greater than or equal to four hundred
            select square; // Select the matching square

        deferredNumbers.Add(40); // Add 40 after defining the query

        deferredNumbers.Add(50); // Add 50 after defining the query

        Console.WriteLine("\nDeferred continuation result after adding 40 and 50:"); // Display the deferred-execution heading

        DisplayNumbers(deferredContinuationQuery); // Execute and display the updated query result

        // Final message

        Console.WriteLine("\nAll LINQ query-continuation examples completed successfully."); // Display the completion message
    }
}