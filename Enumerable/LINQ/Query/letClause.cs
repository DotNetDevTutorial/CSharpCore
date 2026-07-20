/*
LINQ let Clause Using Query Expression - Brief Summary

The let clause creates a temporary range variable inside a LINQ
query expression.

It is used when a value must be calculated once and reused in other
parts of the same query.

Basic syntax:

var result =
    from item in collection
    let temporaryVariable = expression
    where condition
    select temporaryVariable;

Example:

var result =
    from number in numbers
    let square = number * number
    where square > 100
    select new
    {
        Number = number,
        Square = square
    };

Without let:

var result =
    from number in numbers
    where number * number > 100
    select new
    {
        Number = number,
        Square = number * number
    };

With let, the calculated expression is stored in a temporary variable
and can be reused without writing the expression repeatedly.

Multiple let clauses:

var result =
    from product in products
    let discount = product.Price * product.DiscountPercentage / 100
    let finalPrice = product.Price - discount
    select new
    {
        product.Name,
        Discount = discount,
        FinalPrice = finalPrice
    };

The let variable can be used in:

1. where clause
2. orderby clause
3. select clause
4. group clause
5. another let clause
6. nested query
7. aggregation calculation

Important points:

1. let is available in LINQ query-expression syntax.
2. It creates a new temporary range variable.
3. The temporary variable is available only inside that query.
4. It does not modify the original object or collection.
5. More than one let clause can be used.
6. One let variable can depend on another let variable.
7. let improves readability by avoiding repeated calculations.
8. It can store calculated numbers, strings, collections, or objects.
9. It is useful for null handling and intermediate calculations.
10. The query normally uses deferred execution.

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

    public decimal Salary { get; set; } // Store the employee monthly salary

    public decimal BonusPercentage { get; set; } // Store the employee bonus percentage

    public string? City { get; set; } // Store the employee city or null
}

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public List<int> Marks { get; set; } = new List<int>(); // Store the marks obtained by the student
}

class LetClauseProgram // Define the main program class
{
    // Display integer collection

    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method that accepts an integer sequence
    {
        foreach (int number in numbers) // Visit every number in the sequence
        {
            Console.Write(number + " "); // Display the current number on the same line
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display product collection

    static void DisplayProducts(IEnumerable<Product> products) // Define a method that accepts a product sequence
    {
        foreach (Product product in products) // Visit every product in the sequence
        {
            Console.WriteLine($"{product.Id} | {product.Name} | {product.Category} | Rs. {product.Price:F2} | Discount: {product.DiscountPercentage}% | Stock: {product.Stock}"); // Display the current product details
        }
    }

    // Display employee collection

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | Rs. {employee.Salary:F2} | Bonus: {employee.BonusPercentage}% | City: {employee.City ?? "Not available"}"); // Display the current employee details
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a collection of integer values
        {
            5, // Add 5 to the number collection
            10, // Add 10 to the number collection
            15, // Add 15 to the number collection
            20, // Add 20 to the number collection
            25, // Add 25 to the number collection
            30 // Add 30 to the number collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all numbers

        // Calculate square using let

        var numberSquareQuery = // Declare a query that calculates the square of every number
            from number in numbers // Read every number from the collection
            let square = number * number // Calculate and store the square in a temporary variable
            select new // Create an anonymous result object
            {
                Number = number, // Store the original number
                Square = square // Store the calculated square
            };

        Console.WriteLine("\nNumbers and their squares:"); // Display the square-query heading

        foreach (var item in numberSquareQuery) // Visit every number-square result
        {
            Console.WriteLine(item.Number + " -> " + item.Square); // Display the number and its square
        }

        // Filter using let variable

        var largeSquareQuery = // Declare a query that filters using a calculated square
            from number in numbers // Read every number from the collection
            let square = number * number // Calculate the square once
            where square > 300 // Keep values whose square is greater than three hundred
            select new // Create an anonymous result object
            {
                Number = number, // Store the original number
                Square = square // Store the calculated square
            };

        Console.WriteLine("\nNumbers whose square is greater than 300:"); // Display the filtered-square heading

        foreach (var item in largeSquareQuery) // Visit every matching number-square result
        {
            Console.WriteLine(item.Number + " -> " + item.Square); // Display the number and its square
        }

        // Order using let variable

        var orderedSquareQuery = // Declare a query that orders values using their calculated squares
            from number in numbers // Read every number from the collection
            let square = number * number // Calculate the square of the current number
            orderby square descending // Arrange results from largest to smallest square
            select new // Create an anonymous ordered result
            {
                Number = number, // Store the original number
                Square = square // Store the calculated square
            };

        Console.WriteLine("\nNumbers ordered by square in descending order:"); // Display the square-ordering heading

        foreach (var item in orderedSquareQuery) // Visit every ordered result
        {
            Console.WriteLine(item.Number + " -> " + item.Square); // Display the number and its square
        }

        // Use multiple let clauses

        var numberCalculationQuery = // Declare a query containing multiple temporary variables
            from number in numbers // Read every number from the collection
            let square = number * number // Calculate the square of the current number
            let cube = number * number * number // Calculate the cube of the current number
            let doubledValue = number * 2 // Calculate double the current number
            select new // Create an anonymous calculation result
            {
                Number = number, // Store the original number
                Square = square, // Store the square
                Cube = cube, // Store the cube
                DoubledValue = doubledValue // Store the doubled value
            };

        Console.WriteLine("\nMultiple calculations using let:"); // Display the multiple-let heading

        foreach (var item in numberCalculationQuery) // Visit every calculated result
        {
            Console.WriteLine($"{item.Number} | Square: {item.Square} | Cube: {item.Cube} | Double: {item.DoubledValue}"); // Display all calculated values
        }

        // Use one let variable in another let clause

        var dependentLetQuery = // Declare a query containing dependent temporary variables
            from number in numbers // Read every number from the collection
            let square = number * number // Calculate the square of the number
            let squarePlusHundred = square + 100 // Use the square variable in another calculation
            select new // Create an anonymous result object
            {
                Number = number, // Store the original number
                Square = square, // Store the square
                FinalValue = squarePlusHundred // Store the square increased by one hundred
            };

        Console.WriteLine("\nOne let variable used by another let variable:"); // Display the dependent-let heading

        foreach (var item in dependentLetQuery) // Visit every dependent-let result
        {
            Console.WriteLine($"{item.Number} | Square: {item.Square} | Square + 100: {item.FinalValue}"); // Display all values
        }

        // Classify values using let

        var numberTypeQuery = // Declare a query that calculates the number type
            from number in numbers // Read every number from the collection
            let numberType = number % 2 == 0 ? "Even" : "Odd" // Determine whether the number is even or odd
            select new // Create an anonymous classification result
            {
                Number = number, // Store the original number
                Type = numberType // Store the calculated number type
            };

        Console.WriteLine("\nNumbers classified using let:"); // Display the classification heading

        foreach (var item in numberTypeQuery) // Visit every classification result
        {
            Console.WriteLine(item.Number + " -> " + item.Type); // Display the number and its type
        }

        // Create string collection

        List<string> technologies = new List<string>() // Create a collection of technology names
        {
            "C#", // Add C# to the collection
            "Python", // Add Python to the collection
            "Java", // Add Java to the collection
            "JavaScript", // Add JavaScript to the collection
            "PySpark", // Add PySpark to the collection
            "MongoDB", // Add MongoDB to the collection
            "Azure Databricks" // Add Azure Databricks to the collection
        };

        // Calculate string length using let

        var technologyLengthQuery = // Declare a query that calculates the length of every technology name
            from technology in technologies // Read every technology from the collection
            let nameLength = technology.Length // Calculate and store the string length
            select new // Create an anonymous result object
            {
                Technology = technology, // Store the original technology name
                Length = nameLength // Store the calculated string length
            };

        Console.WriteLine("\nTechnology names and their lengths:"); // Display the string-length heading

        foreach (var item in technologyLengthQuery) // Visit every technology-length result
        {
            Console.WriteLine(item.Technology + " -> " + item.Length); // Display the technology name and its length
        }

        // Filter strings using calculated value

        var longTechnologyQuery = // Declare a query that filters using a temporary string length
            from technology in technologies // Read every technology from the collection
            let nameLength = technology.Length // Calculate the length of the technology name
            where nameLength > 6 // Keep names longer than six characters
            select new // Create an anonymous filtered result
            {
                Technology = technology, // Store the technology name
                Length = nameLength // Store its calculated length
            };

        Console.WriteLine("\nTechnology names longer than 6 characters:"); // Display the string-filter heading

        foreach (var item in longTechnologyQuery) // Visit every matching technology
        {
            Console.WriteLine(item.Technology + " -> " + item.Length); // Display the technology name and its length
        }

        // Normalize strings using let

        string searchText = "PYTHON"; // Store the text that must be searched

        var caseInsensitiveQuery = // Declare a query that performs case-insensitive comparison
            from technology in technologies // Read every technology from the collection
            let normalizedTechnology = technology.ToLower() // Convert the current technology to lowercase
            let normalizedSearchText = searchText.ToLower() // Convert the search text to lowercase
            where normalizedTechnology == normalizedSearchText // Compare both normalized values
            select technology; // Select the matching original technology name

        Console.WriteLine("\nCase-insensitive search result:"); // Display the case-insensitive-search heading

        foreach (string technology in caseInsensitiveQuery) // Visit every matching technology
        {
            Console.WriteLine(technology); // Display the original technology name
        }

        // Split sentence using let

        List<string> sentences = new List<string>() // Create a collection of sentences
        {
            "LINQ makes collection processing easier", // Add the first sentence
            "C sharp is an object oriented language", // Add the second sentence
            "Query expressions improve readability" // Add the third sentence
        };

        var sentenceWordQuery = // Declare a query that calculates words in every sentence
            from sentence in sentences // Read every sentence from the collection
            let words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries) // Split the sentence into an array of words
            let wordCount = words.Length // Count the words in the created array
            select new // Create an anonymous sentence summary
            {
                Sentence = sentence, // Store the original sentence
                Words = words, // Store the generated word array
                WordCount = wordCount // Store the calculated word count
            };

        Console.WriteLine("\nSentence word information:"); // Display the sentence-query heading

        foreach (var item in sentenceWordQuery) // Visit every sentence summary
        {
            Console.WriteLine("\nSentence: " + item.Sentence); // Display the original sentence

            Console.WriteLine("Word count: " + item.WordCount); // Display the number of words

            Console.WriteLine("Words: " + string.Join(", ", item.Words)); // Display all words separated by commas
        }

        // Create product collection

        List<Product> products = new List<Product>() // Create a collection of product objects
        {
            new Product { Id = 101, Name = "Laptop", Category = "Electronics", Price = 65000m, DiscountPercentage = 10m, Stock = 5 }, // Add the Laptop product
            new Product { Id = 102, Name = "Mouse", Category = "Electronics", Price = 800m, DiscountPercentage = 5m, Stock = 20 }, // Add the Mouse product
            new Product { Id = 103, Name = "Chair", Category = "Furniture", Price = 6000m, DiscountPercentage = 15m, Stock = 7 }, // Add the Chair product
            new Product { Id = 104, Name = "Notebook", Category = "Stationery", Price = 100m, DiscountPercentage = 0m, Stock = 0 }, // Add the Notebook product
            new Product { Id = 105, Name = "Monitor", Category = "Electronics", Price = 18000m, DiscountPercentage = 8m, Stock = 8 } // Add the Monitor product
        };

        Console.WriteLine("\nOriginal product collection:"); // Display the product-collection heading

        DisplayProducts(products); // Display all products

        // Calculate product discount using let

        var productDiscountQuery = // Declare a query that calculates product discount information
            from product in products // Read every product from the collection
            let discountAmount = product.Price * product.DiscountPercentage / 100m // Calculate the product discount amount
            let finalPrice = product.Price - discountAmount // Calculate the price after discount
            select new // Create an anonymous discount result
            {
                ProductName = product.Name, // Store the product name
                OriginalPrice = product.Price, // Store the original product price
                DiscountAmount = discountAmount, // Store the calculated discount amount
                FinalPrice = finalPrice // Store the calculated final price
            };

        Console.WriteLine("\nProduct discount calculations:"); // Display the discount-calculation heading

        foreach (var item in productDiscountQuery) // Visit every product discount result
        {
            Console.WriteLine($"{item.ProductName} | Original: Rs. {item.OriginalPrice:F2} | Discount: Rs. {item.DiscountAmount:F2} | Final: Rs. {item.FinalPrice:F2}"); // Display the product discount details
        }

        // Filter using calculated final price

        var expensiveDiscountedProducts = // Declare a query that filters products using final price
            from product in products // Read every product from the collection
            let discountAmount = product.Price * product.DiscountPercentage / 100m // Calculate the discount amount
            let finalPrice = product.Price - discountAmount // Calculate the final product price
            where finalPrice >= 5000m // Keep products whose final price is at least five thousand
            orderby finalPrice descending // Arrange products from highest to lowest final price
            select new // Create an anonymous filtered product result
            {
                ProductName = product.Name, // Store the product name
                FinalPrice = finalPrice // Store the final price
            };

        Console.WriteLine("\nProducts having final price of at least Rs. 5000:"); // Display the final-price-filter heading

        foreach (var item in expensiveDiscountedProducts) // Visit every matching discounted product
        {
            Console.WriteLine(item.ProductName + " -> Rs. " + item.FinalPrice.ToString("F2")); // Display the product and final price
        }

        // Calculate inventory value using let

        var inventoryValueQuery = // Declare a query that calculates product inventory value
            from product in products // Read every product from the collection
            let inventoryValue = product.Price * product.Stock // Calculate price multiplied by stock
            let stockStatus = product.Stock > 0 ? "Available" : "Out of stock" // Calculate the product stock status
            select new // Create an anonymous inventory result
            {
                ProductName = product.Name, // Store the product name
                InventoryValue = inventoryValue, // Store the calculated inventory value
                StockStatus = stockStatus // Store the calculated stock status
            };

        Console.WriteLine("\nProduct inventory information:"); // Display the inventory-value heading

        foreach (var item in inventoryValueQuery) // Visit every inventory result
        {
            Console.WriteLine($"{item.ProductName} | Inventory value: Rs. {item.InventoryValue:F2} | {item.StockStatus}"); // Display the inventory information
        }

        // Group using let variable

        var productPriceGroups = // Declare a query that groups products by a calculated price category
            from product in products // Read every product from the collection
            let priceCategory = product.Price < 1000m // Begin calculating the price category
                ? "Low Price" // Use Low Price when the product costs less than one thousand
                : product.Price < 10000m // Check whether the product costs less than ten thousand
                    ? "Medium Price" // Use Medium Price for the middle range
                    : "High Price" // Use High Price for the remaining products
            group product by priceCategory into priceGroup // Group products using the calculated category
            select priceGroup; // Select every price-category group

        Console.WriteLine("\nProducts grouped using a let variable:"); // Display the let-grouping heading

        foreach (var priceGroup in productPriceGroups) // Visit every calculated price group
        {
            Console.WriteLine("\nPrice category: " + priceGroup.Key); // Display the calculated group key

            foreach (Product product in priceGroup) // Visit every product in the current group
            {
                Console.WriteLine(product.Name + " -> Rs. " + product.Price.ToString("F2")); // Display the product name and price
            }
        }

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of employee objects
        {
            new Employee { Id = 201, Name = "Saad", Department = "Development", Salary = 65000m, BonusPercentage = 10m, City = "Pune" }, // Add the first employee
            new Employee { Id = 202, Name = "Aman", Department = "Testing", Salary = 48000m, BonusPercentage = 8m, City = "Delhi" }, // Add the second employee
            new Employee { Id = 203, Name = "Neha", Department = "Development", Salary = 75000m, BonusPercentage = 12m, City = "Pune" }, // Add the third employee
            new Employee { Id = 204, Name = "Rahul", Department = "Support", Salary = 38000m, BonusPercentage = 5m, City = null }, // Add the fourth employee
            new Employee { Id = 205, Name = "Priya", Department = "Data Engineering", Salary = 82000m, BonusPercentage = 15m, City = "Hyderabad" }, // Add the fifth employee
            new Employee { Id = 206, Name = "Zoya", Department = "Data Engineering", Salary = 70000m, BonusPercentage = 10m, City = "Pune" } // Add the sixth employee
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the employee-collection heading

        DisplayEmployees(employees); // Display all employees

        // Calculate bonus using let

        var employeeBonusQuery = // Declare a query that calculates employee bonus information
            from employee in employees // Read every employee from the collection
            let bonusAmount = employee.Salary * employee.BonusPercentage / 100m // Calculate the employee bonus amount
            let totalEarning = employee.Salary + bonusAmount // Calculate salary plus bonus
            select new // Create an anonymous employee earning result
            {
                EmployeeName = employee.Name, // Store the employee name
                BasicSalary = employee.Salary, // Store the basic salary
                BonusAmount = bonusAmount, // Store the calculated bonus amount
                TotalEarning = totalEarning // Store the total earning
            };

        Console.WriteLine("\nEmployee bonus calculations:"); // Display the employee-bonus heading

        foreach (var item in employeeBonusQuery) // Visit every employee earning result
        {
            Console.WriteLine($"{item.EmployeeName} | Salary: Rs. {item.BasicSalary:F2} | Bonus: Rs. {item.BonusAmount:F2} | Total: Rs. {item.TotalEarning:F2}"); // Display the calculated employee earnings
        }

        // Handle null values using let

        var employeeCityQuery = // Declare a query that handles missing city information
            from employee in employees // Read every employee from the collection
            let employeeCity = employee.City ?? "Not available" // Replace a null city with readable text
            let cityStatus = employee.City == null ? "City missing" : "City available" // Calculate the city-information status
            select new // Create an anonymous city result
            {
                EmployeeName = employee.Name, // Store the employee name
                City = employeeCity, // Store the actual or default city
                Status = cityStatus // Store the calculated city status
            };

        Console.WriteLine("\nEmployee city information using let:"); // Display the null-handling heading

        foreach (var item in employeeCityQuery) // Visit every employee city result
        {
            Console.WriteLine($"{item.EmployeeName} | {item.City} | {item.Status}"); // Display the employee city information
        }

        // Group and calculate using let

        var departmentSummaryQuery = // Declare a query that creates department summaries
            from employee in employees // Read every employee from the collection
            group employee by employee.Department into departmentGroup // Group employees by department
            let employeeCount = departmentGroup.Count() // Count employees in the current department
            let totalSalary = departmentGroup.Sum(employee => employee.Salary) // Calculate the total salary of the department
            let averageSalary = departmentGroup.Average(employee => employee.Salary) // Calculate the average department salary
            orderby averageSalary descending // Arrange departments by average salary
            select new // Create an anonymous department summary
            {
                Department = departmentGroup.Key, // Store the department name
                EmployeeCount = employeeCount, // Store the employee count
                TotalSalary = totalSalary, // Store the total salary
                AverageSalary = averageSalary // Store the average salary
            };

        Console.WriteLine("\nDepartment summary using let after grouping:"); // Display the grouped-let heading

        foreach (var department in departmentSummaryQuery) // Visit every department summary
        {
            Console.WriteLine($"{department.Department} | Employees: {department.EmployeeCount} | Total: Rs. {department.TotalSalary:F2} | Average: Rs. {department.AverageSalary:F2}"); // Display the department summary
        }

        // Create student collection

        List<Student> students = new List<Student>() // Create a collection of student objects
        {
            new Student { Id = 301, Name = "Ali", Marks = new List<int>() { 80, 75, 90 } }, // Add the first student
            new Student { Id = 302, Name = "Riya", Marks = new List<int>() { 60, 65, 70 } }, // Add the second student
            new Student { Id = 303, Name = "Kabir", Marks = new List<int>() { 40, 35, 45 } }, // Add the third student
            new Student { Id = 304, Name = "Meera", Marks = new List<int>() { 95, 88, 92 } }, // Add the fourth student
            new Student { Id = 305, Name = "Arjun", Marks = new List<int>() } // Add a student having no marks
        };

        // Calculate student result using let

        var studentResultQuery = // Declare a query that calculates student result information
            from student in students // Read every student from the collection
            let totalMarks = student.Marks.Sum() // Calculate the total marks
            let subjectCount = student.Marks.Count // Count the number of subjects
            let averageMarks = subjectCount > 0 ? (double)totalMarks / subjectCount : 0 // Calculate the average safely
            let resultStatus = averageMarks >= 40 ? "Pass" : "Fail" // Calculate the pass-or-fail status
            let grade = averageMarks >= 80 // Begin calculating the student grade
                ? "A" // Assign grade A for an average of eighty or more
                : averageMarks >= 60 // Check whether the average is at least sixty
                    ? "B" // Assign grade B for the middle-high range
                    : averageMarks >= 40 // Check whether the average is at least forty
                        ? "C" // Assign grade C for the passing lower range
                        : "F" // Assign grade F for a failing average
            select new // Create an anonymous student-result object
            {
                StudentName = student.Name, // Store the student name
                TotalMarks = totalMarks, // Store the total marks
                AverageMarks = averageMarks, // Store the average marks
                ResultStatus = resultStatus, // Store the pass-or-fail result
                Grade = grade // Store the calculated grade
            };

        Console.WriteLine("\nStudent results calculated using let:"); // Display the student-result heading

        foreach (var student in studentResultQuery) // Visit every calculated student result
        {
            Console.WriteLine($"{student.StudentName} | Total: {student.TotalMarks} | Average: {student.AverageMarks:F2} | Result: {student.ResultStatus} | Grade: {student.Grade}"); // Display the complete student result
        }

        // Filter students using calculated average

        var highScoringStudentQuery = // Declare a query that filters using calculated average marks
            from student in students // Read every student from the collection
            let totalMarks = student.Marks.Sum() // Calculate the total marks
            let averageMarks = student.Marks.Count > 0 // Check whether marks are available
                ? (double)totalMarks / student.Marks.Count // Calculate the average when marks exist
                : 0 // Use zero when the marks collection is empty
            where averageMarks >= 75 // Keep students having an average of at least seventy-five
            orderby averageMarks descending // Arrange students from highest to lowest average
            select new // Create an anonymous filtered result
            {
                StudentName = student.Name, // Store the student name
                AverageMarks = averageMarks // Store the calculated average marks
            };

        Console.WriteLine("\nStudents having average marks of at least 75:"); // Display the high-scoring-student heading

        foreach (var student in highScoringStudentQuery) // Visit every high-scoring student
        {
            Console.WriteLine(student.StudentName + " -> " + student.AverageMarks.ToString("F2")); // Display the student name and average
        }

        // Demonstrate deferred execution

        List<int> deferredNumbers = new List<int>() // Create a collection for deferred execution
        {
            10, // Add 10 to the deferred collection
            20, // Add 20 to the deferred collection
            30 // Add 30 to the deferred collection
        };

        var deferredLetQuery = // Declare a let query without executing it immediately
            from number in deferredNumbers // Read numbers when the query is traversed
            let square = number * number // Calculate the square during query execution
            select new // Create an anonymous deferred result
            {
                Number = number, // Store the original number
                Square = square // Store the calculated square
            };

        deferredNumbers.Add(40); // Add 40 after defining the query

        Console.WriteLine("\nDeferred let query result after adding 40:"); // Display the deferred-execution heading

        foreach (var item in deferredLetQuery) // Execute and traverse the deferred query
        {
            Console.WriteLine(item.Number + " -> " + item.Square); // Display the number and calculated square
        }

        // Final message

        Console.WriteLine("\nAll LINQ query-expression let-clause examples completed successfully."); // Display the completion message
    }
}