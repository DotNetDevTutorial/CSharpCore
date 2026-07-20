/*
LINQ Multiple from Clauses Using Query Expression - Brief Summary

Multiple from clauses are used when a query must read elements from
more than one collection or from a nested collection.

Basic syntax:

var result =
    from firstItem in firstCollection
    from secondItem in secondCollection
    select new
    {
        FirstValue = firstItem,
        SecondValue = secondItem
    };

When the collections are independent, multiple from clauses create
a Cartesian product.

Example collections:

Numbers: 1, 2
Letters: A, B

Result:

1 A
1 B
2 A
2 B

Multiple from clauses are also commonly used to flatten nested
collections.

Nested-collection syntax:

var result =
    from student in students
    from subject in student.Subjects
    select new
    {
        student.Name,
        Subject = subject
    };

The second from clause reads the inner collection belonging to the
current element selected by the first from clause.

Example:

Student       Subjects
Saad          C#, SQL
Aman          Python, MongoDB

Flattened result:

Saad          C#
Saad          SQL
Aman          Python
Aman          MongoDB

Multiple from clauses can be combined with:

1. where:
   Filters combinations or nested elements.

2. orderby:
   Sorts the flattened result.

3. select:
   Chooses the values to return.

4. let:
   Stores an intermediate calculated value.

5. group:
   Groups the flattened elements.

6. join:
   Combines the flattened data with another collection.

Important points:

1. Every query expression starts with a from clause.
2. More than one from clause can be used.
3. Independent collections produce every possible combination.
4. A nested collection can be flattened into one sequence.
5. The second range variable is available after its from clause.
6. where can filter the generated combinations.
7. select determines the shape of the final result.
8. The original collections are not modified.
9. The result normally uses deferred execution.
10. Multiple from clauses are translated internally to SelectMany().
11. Empty inner collections produce no flattened result for that item.
12. Null inner collections should be replaced with an empty collection
    before they are queried.

Equivalent method syntax:

students.SelectMany(
    student => student.Subjects,
    (student, subject) => new
    {
        student.Name,
        Subject = subject
    }
);

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ query-expression support

class Student // Define a class representing a student
{
    public int Id { get; set; } // Store the student identifier

    public string Name { get; set; } = ""; // Store the student name

    public string Department { get; set; } = ""; // Store the student department

    public List<string> Subjects { get; set; } = new List<string>(); // Store the subjects studied by the student

    public List<int> Marks { get; set; } = new List<int>(); // Store the marks obtained by the student
}

class OrderItem // Define a class representing one item inside an order
{
    public int ProductId { get; set; } // Store the product identifier

    public string ProductName { get; set; } = ""; // Store the product name

    public int Quantity { get; set; } // Store the ordered quantity

    public decimal UnitPrice { get; set; } // Store the price of one unit
}

class Order // Define a class representing a customer order
{
    public int OrderId { get; set; } // Store the order identifier

    public string CustomerName { get; set; } = ""; // Store the customer name

    public string City { get; set; } = ""; // Store the customer city

    public List<OrderItem> Items { get; set; } = new List<OrderItem>(); // Store all items belonging to the order
}

class MultipleFromProgram // Define the main program class
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

    // Display string collection

    static void DisplayStrings(IEnumerable<string> values) // Define a method that accepts a string sequence
    {
        foreach (string value in values) // Visit every string in the sequence
        {
            Console.Write(value + " "); // Display the current string on the same line
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display students

    static void DisplayStudents(IEnumerable<Student> students) // Define a method that accepts a student sequence
    {
        foreach (Student student in students) // Visit every student in the sequence
        {
            Console.WriteLine($"{student.Id} | {student.Name} | {student.Department} | Subjects: {student.Subjects.Count} | Marks: {student.Marks.Count}"); // Display the current student details
        }
    }

    // Display orders

    static void DisplayOrders(IEnumerable<Order> orders) // Define a method that accepts an order sequence
    {
        foreach (Order order in orders) // Visit every order in the sequence
        {
            Console.WriteLine($"{order.OrderId} | {order.CustomerName} | {order.City} | Items: {order.Items.Count}"); // Display the current order details
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create independent collections

        List<int> numbers = new List<int>() // Create a collection of integer values
        {
            1, // Add 1 to the number collection
            2, // Add 2 to the number collection
            3 // Add 3 to the number collection
        };

        List<string> letters = new List<string>() // Create a collection of letter values
        {
            "A", // Add A to the letter collection
            "B", // Add B to the letter collection
            "C" // Add C to the letter collection
        };

        Console.WriteLine("Number collection:"); // Display the number-collection heading

        DisplayNumbers(numbers); // Display all numbers

        Console.WriteLine("Letter collection:"); // Display the letter-collection heading

        DisplayStrings(letters); // Display all letters

        // Cartesian product

        var numberLetterCombinations = // Declare a query that creates all number-letter combinations
            from number in numbers // Read every number from the first collection
            from letter in letters // Read every letter for the current number
            select new // Create an anonymous result object
            {
                Number = number, // Store the current number
                Letter = letter // Store the current letter
            };

        Console.WriteLine("\nCartesian product of numbers and letters:"); // Display the Cartesian-product heading

        foreach (var combination in numberLetterCombinations) // Visit every generated combination
        {
            Console.WriteLine(combination.Number + " -> " + combination.Letter); // Display the current number-letter pair
        }

        // Count generated combinations

        int totalCombinations = numberLetterCombinations.Count(); // Count all generated number-letter combinations

        Console.WriteLine("Total combinations: " + totalCombinations); // Display the total number of combinations

        // Filter Cartesian product

        var filteredCombinations = // Declare a query that filters generated combinations
            from number in numbers // Read every number from the collection
            from letter in letters // Read every letter for the current number
            where number >= 2 && letter != "B" // Keep combinations satisfying both conditions
            select new // Create an anonymous filtered result
            {
                Number = number, // Store the filtered number
                Letter = letter // Store the filtered letter
            };

        Console.WriteLine("\nCombinations where number is at least 2 and letter is not B:"); // Display the filtered-combination heading

        foreach (var combination in filteredCombinations) // Visit every matching combination
        {
            Console.WriteLine(combination.Number + " -> " + combination.Letter); // Display the matching number-letter pair
        }

        // Calculate value using multiple from

        var calculatedCombinations = // Declare a query that performs a calculation on combinations
            from firstNumber in numbers // Read every number as the first value
            from secondNumber in numbers // Read every number as the second value
            let sum = firstNumber + secondNumber // Calculate the sum of the current pair
            select new // Create an anonymous calculated result
            {
                FirstNumber = firstNumber, // Store the first number
                SecondNumber = secondNumber, // Store the second number
                Sum = sum // Store the calculated sum
            };

        Console.WriteLine("\nNumber pairs and their sums:"); // Display the number-pair heading

        foreach (var pair in calculatedCombinations) // Visit every number-pair result
        {
            Console.WriteLine($"{pair.FirstNumber} + {pair.SecondNumber} = {pair.Sum}"); // Display both numbers and their sum
        }

        // Avoid duplicate number pairs

        var uniqueNumberPairs = // Declare a query that avoids reversed duplicate pairs
            from firstNumber in numbers // Read every number as the first value
            from secondNumber in numbers // Read every number as the second value
            where firstNumber < secondNumber // Keep only pairs where the first value is smaller
            select new // Create an anonymous unique-pair result
            {
                FirstNumber = firstNumber, // Store the smaller number
                SecondNumber = secondNumber // Store the larger number
            };

        Console.WriteLine("\nUnique number pairs:"); // Display the unique-pair heading

        foreach (var pair in uniqueNumberPairs) // Visit every unique number pair
        {
            Console.WriteLine(pair.FirstNumber + ", " + pair.SecondNumber); // Display the current pair
        }

        // Use three from clauses

        List<string> sizes = new List<string>() // Create a collection of size values
        {
            "Small", // Add Small to the size collection
            "Large" // Add Large to the size collection
        };

        var threeCollectionCombinations = // Declare a query that reads three independent collections
            from number in numbers // Read every number from the first collection
            from letter in letters // Read every letter from the second collection
            from size in sizes // Read every size from the third collection
            where number <= 2 && letter != "C" // Keep combinations satisfying the conditions
            select new // Create an anonymous three-value result
            {
                Number = number, // Store the current number
                Letter = letter, // Store the current letter
                Size = size // Store the current size
            };

        Console.WriteLine("\nCombinations using three from clauses:"); // Display the three-from heading

        foreach (var combination in threeCollectionCombinations) // Visit every generated three-value combination
        {
            Console.WriteLine($"{combination.Number} | {combination.Letter} | {combination.Size}"); // Display the current combination
        }

        // Create student collection

        List<Student> students = new List<Student>() // Create a collection of student objects
        {
            new Student // Create the first student
            {
                Id = 101, // Set the first student identifier
                Name = "Saad", // Set the first student name
                Department = "Data Engineering", // Set the first student department
                Subjects = new List<string>() { "C#", "SQL", "PySpark" }, // Add subjects for the first student
                Marks = new List<int>() { 82, 88, 91 } // Add marks for the first student
            },
            new Student // Create the second student
            {
                Id = 102, // Set the second student identifier
                Name = "Aman", // Set the second student name
                Department = "Development", // Set the second student department
                Subjects = new List<string>() { "Java", "Spring Boot" }, // Add subjects for the second student
                Marks = new List<int>() { 74, 79 } // Add marks for the second student
            },
            new Student // Create the third student
            {
                Id = 103, // Set the third student identifier
                Name = "Neha", // Set the third student name
                Department = "Data Engineering", // Set the third student department
                Subjects = new List<string>() { "Python", "MongoDB", "Azure" }, // Add subjects for the third student
                Marks = new List<int>() { 90, 84, 89 } // Add marks for the third student
            },
            new Student // Create the fourth student
            {
                Id = 104, // Set the fourth student identifier
                Name = "Rahul", // Set the fourth student name
                Department = "Testing", // Set the fourth student department
                Subjects = new List<string>() { "Selenium", "C#" }, // Add subjects for the fourth student
                Marks = new List<int>() { 65, 72 } // Add marks for the fourth student
            },
            new Student // Create the fifth student
            {
                Id = 105, // Set the fifth student identifier
                Name = "Zoya", // Set the fifth student name
                Department = "Development", // Set the fifth student department
                Subjects = new List<string>(), // Create an empty subject collection
                Marks = new List<int>() // Create an empty marks collection
            }
        };

        Console.WriteLine("\nOriginal student collection:"); // Display the student-collection heading

        DisplayStudents(students); // Display all students

        // Flatten student subjects

        var studentSubjectQuery = // Declare a query that flattens student subjects
            from student in students // Read every student from the outer collection
            from subject in student.Subjects // Read every subject belonging to the current student
            select new // Create an anonymous flattened result
            {
                StudentId = student.Id, // Store the student identifier
                StudentName = student.Name, // Store the student name
                Department = student.Department, // Store the student department
                Subject = subject // Store the current subject
            };

        Console.WriteLine("\nStudents and their subjects:"); // Display the flattened-subject heading

        foreach (var record in studentSubjectQuery) // Visit every flattened student-subject result
        {
            Console.WriteLine($"{record.StudentId} | {record.StudentName} | {record.Department} | {record.Subject}"); // Display the student and subject information
        }

        // Understand empty nested collection

        Console.WriteLine("\nZoya is not present because her Subjects collection is empty."); // Explain the effect of an empty inner collection

        // Filter nested elements

        var filteredStudentSubjects = // Declare a query that filters flattened student subjects
            from student in students // Read every student from the outer collection
            from subject in student.Subjects // Read every subject belonging to the current student
            where student.Department == "Data Engineering" // Keep students belonging to Data Engineering
            where subject.Contains("S") || subject.Contains("P") // Keep subjects containing uppercase S or P
            select new // Create an anonymous filtered result
            {
                StudentName = student.Name, // Store the student name
                Subject = subject // Store the matching subject
            };

        Console.WriteLine("\nSelected Data Engineering student subjects:"); // Display the filtered-subject heading

        foreach (var record in filteredStudentSubjects) // Visit every filtered subject result
        {
            Console.WriteLine(record.StudentName + " -> " + record.Subject); // Display the matching student and subject
        }

        // Order flattened elements

        var orderedStudentSubjects = // Declare a query that orders flattened student subjects
            from student in students // Read every student from the collection
            from subject in student.Subjects // Read every subject belonging to the student
            orderby subject ascending, student.Name ascending // Arrange by subject and then student name
            select new // Create an anonymous ordered result
            {
                StudentName = student.Name, // Store the student name
                Subject = subject // Store the subject name
            };

        Console.WriteLine("\nStudent subjects ordered alphabetically:"); // Display the ordered-subject heading

        foreach (var record in orderedStudentSubjects) // Visit every ordered student-subject result
        {
            Console.WriteLine(record.Subject + " -> " + record.StudentName); // Display the subject and student name
        }

        // Flatten marks collection

        var studentMarksQuery = // Declare a query that flattens student marks
            from student in students // Read every student from the outer collection
            from mark in student.Marks // Read every mark belonging to the current student
            select new // Create an anonymous student-mark result
            {
                StudentName = student.Name, // Store the student name
                Mark = mark // Store the current mark
            };

        Console.WriteLine("\nStudents and individual marks:"); // Display the flattened-marks heading

        foreach (var record in studentMarksQuery) // Visit every student-mark result
        {
            Console.WriteLine(record.StudentName + " -> " + record.Mark); // Display the student and individual mark
        }

        // Filter individual marks

        var highMarksQuery = // Declare a query that filters individual student marks
            from student in students // Read every student from the outer collection
            from mark in student.Marks // Read every mark belonging to the current student
            where mark >= 85 // Keep marks greater than or equal to eighty-five
            orderby mark descending // Arrange marks from highest to lowest
            select new // Create an anonymous high-mark result
            {
                StudentName = student.Name, // Store the student name
                Mark = mark // Store the matching mark
            };

        Console.WriteLine("\nIndividual marks greater than or equal to 85:"); // Display the high-mark heading

        foreach (var record in highMarksQuery) // Visit every high-mark result
        {
            Console.WriteLine(record.StudentName + " -> " + record.Mark); // Display the student and high mark
        }

        // Pair subjects with marks by position

        var subjectMarkQuery = // Declare a query that connects subjects and marks using their positions
            from student in students // Read every student from the outer collection
            from subjectWithIndex in student.Subjects.Select((subject, index) => new { subject, index }) // Read every subject together with its index
            where subjectWithIndex.index < student.Marks.Count // Keep positions having a corresponding mark
            select new // Create an anonymous subject-mark result
            {
                StudentName = student.Name, // Store the student name
                Subject = subjectWithIndex.subject, // Store the subject at the current position
                Mark = student.Marks[subjectWithIndex.index] // Store the mark at the same position
            };

        Console.WriteLine("\nSubjects paired with marks using their positions:"); // Display the subject-mark heading

        foreach (var record in subjectMarkQuery) // Visit every subject-mark result
        {
            Console.WriteLine($"{record.StudentName} | {record.Subject} | {record.Mark}"); // Display the student, subject and mark
        }

        // Group flattened subjects

        var subjectStudentCountQuery = // Declare a query that groups flattened subjects
            from student in students // Read every student from the collection
            from subject in student.Subjects // Read every subject belonging to the current student
            group student by subject into subjectGroup // Group students according to subject
            orderby subjectGroup.Key // Arrange subject groups alphabetically
            select new // Create an anonymous subject summary
            {
                Subject = subjectGroup.Key, // Store the subject name
                StudentCount = subjectGroup.Count(), // Count students studying the subject
                StudentNames = subjectGroup.Select(student => student.Name) // Select student names from the group
            };

        Console.WriteLine("\nStudents grouped by subject:"); // Display the subject-grouping heading

        foreach (var subjectGroup in subjectStudentCountQuery) // Visit every subject summary
        {
            Console.WriteLine("\nSubject: " + subjectGroup.Subject); // Display the subject name

            Console.WriteLine("Student count: " + subjectGroup.StudentCount); // Display the student count

            foreach (string studentName in subjectGroup.StudentNames) // Visit every student name in the subject group
            {
                Console.WriteLine(studentName); // Display the current student name
            }
        }

        // Create order collection

        List<Order> orders = new List<Order>() // Create a collection of customer orders
        {
            new Order // Create the first order
            {
                OrderId = 1001, // Set the first order identifier
                CustomerName = "Saad", // Set the first customer name
                City = "Pune", // Set the first customer city
                Items = new List<OrderItem>() // Create the first order-item collection
                {
                    new OrderItem { ProductId = 201, ProductName = "Laptop", Quantity = 1, UnitPrice = 65000m }, // Add Laptop to the first order
                    new OrderItem { ProductId = 202, ProductName = "Mouse", Quantity = 2, UnitPrice = 800m } // Add Mouse to the first order
                }
            },
            new Order // Create the second order
            {
                OrderId = 1002, // Set the second order identifier
                CustomerName = "Aman", // Set the second customer name
                City = "Delhi", // Set the second customer city
                Items = new List<OrderItem>() // Create the second order-item collection
                {
                    new OrderItem { ProductId = 203, ProductName = "Chair", Quantity = 2, UnitPrice = 6000m }, // Add Chair to the second order
                    new OrderItem { ProductId = 204, ProductName = "Notebook", Quantity = 5, UnitPrice = 100m } // Add Notebook to the second order
                }
            },
            new Order // Create the third order
            {
                OrderId = 1003, // Set the third order identifier
                CustomerName = "Neha", // Set the third customer name
                City = "Pune", // Set the third customer city
                Items = new List<OrderItem>() // Create the third order-item collection
                {
                    new OrderItem { ProductId = 205, ProductName = "Monitor", Quantity = 2, UnitPrice = 18000m } // Add Monitor to the third order
                }
            },
            new Order // Create the fourth order
            {
                OrderId = 1004, // Set the fourth order identifier
                CustomerName = "Zoya", // Set the fourth customer name
                City = "Hyderabad", // Set the fourth customer city
                Items = new List<OrderItem>() // Create an empty order-item collection
            }
        };

        Console.WriteLine("\nOriginal order collection:"); // Display the order-collection heading

        DisplayOrders(orders); // Display all orders

        // Flatten order items

        var orderItemQuery = // Declare a query that flattens items from all orders
            from order in orders // Read every order from the outer collection
            from item in order.Items // Read every item belonging to the current order
            select new // Create an anonymous flattened order result
            {
                OrderId = order.OrderId, // Store the order identifier
                CustomerName = order.CustomerName, // Store the customer name
                City = order.City, // Store the customer city
                ProductName = item.ProductName, // Store the product name
                Quantity = item.Quantity, // Store the ordered quantity
                UnitPrice = item.UnitPrice // Store the unit price
            };

        Console.WriteLine("\nFlattened order-item records:"); // Display the flattened-order heading

        foreach (var record in orderItemQuery) // Visit every flattened order-item result
        {
            Console.WriteLine($"{record.OrderId} | {record.CustomerName} | {record.City} | {record.ProductName} | Quantity: {record.Quantity} | Rs. {record.UnitPrice:F2}"); // Display the order and item information
        }

        // Calculate item total using let

        var orderAmountQuery = // Declare a query that calculates the total for every order item
            from order in orders // Read every order from the outer collection
            from item in order.Items // Read every item belonging to the current order
            let itemTotal = item.Quantity * item.UnitPrice // Calculate the amount for the current item
            select new // Create an anonymous item-total result
            {
                OrderId = order.OrderId, // Store the order identifier
                CustomerName = order.CustomerName, // Store the customer name
                ProductName = item.ProductName, // Store the product name
                Quantity = item.Quantity, // Store the ordered quantity
                ItemTotal = itemTotal // Store the calculated item total
            };

        Console.WriteLine("\nOrder-item amount calculations:"); // Display the item-total heading

        foreach (var record in orderAmountQuery) // Visit every calculated order-item result
        {
            Console.WriteLine($"{record.OrderId} | {record.CustomerName} | {record.ProductName} | Quantity: {record.Quantity} | Total: Rs. {record.ItemTotal:F2}"); // Display the calculated item amount
        }

        // Filter flattened order items

        var expensiveOrderItems = // Declare a query that filters flattened order items
            from order in orders // Read every order from the collection
            from item in order.Items // Read every item belonging to the current order
            let itemTotal = item.Quantity * item.UnitPrice // Calculate the total amount for the item
            where itemTotal >= 10000m // Keep items having a total amount of at least ten thousand
            orderby itemTotal descending // Arrange results from highest to lowest amount
            select new // Create an anonymous filtered order-item result
            {
                order.CustomerName, // Store the customer name
                item.ProductName, // Store the product name
                ItemTotal = itemTotal // Store the calculated item amount
            };

        Console.WriteLine("\nOrder items having total amount of at least Rs. 10000:"); // Display the expensive-item heading

        foreach (var record in expensiveOrderItems) // Visit every expensive order-item result
        {
            Console.WriteLine($"{record.CustomerName} | {record.ProductName} | Rs. {record.ItemTotal:F2}"); // Display the matching order-item details
        }

        // Group flattened items by customer

        var customerOrderSummary = // Declare a query that groups flattened items by customer
            from order in orders // Read every order from the collection
            from item in order.Items // Read every item belonging to the current order
            let itemTotal = item.Quantity * item.UnitPrice // Calculate the current item amount
            group new // Create the element that will be stored in the group
            {
                Item = item, // Store the current order item
                ItemTotal = itemTotal // Store the calculated item amount
            }
            by order.CustomerName into customerGroup // Group the created elements by customer name
            select new // Create an anonymous customer summary
            {
                CustomerName = customerGroup.Key, // Store the customer name
                ItemCount = customerGroup.Count(), // Count different order-item records
                TotalQuantity = customerGroup.Sum(record => record.Item.Quantity), // Calculate the total ordered quantity
                TotalAmount = customerGroup.Sum(record => record.ItemTotal) // Calculate the total customer amount
            };

        Console.WriteLine("\nCustomer order summary:"); // Display the customer-summary heading

        foreach (var customer in customerOrderSummary) // Visit every customer order summary
        {
            Console.WriteLine($"{customer.CustomerName} | Items: {customer.ItemCount} | Quantity: {customer.TotalQuantity} | Total: Rs. {customer.TotalAmount:F2}"); // Display the complete customer summary
        }

        // Flatten characters from words

        List<string> words = new List<string>() // Create a collection of words
        {
            "LINQ", // Add LINQ to the word collection
            "QUERY", // Add QUERY to the word collection
            "CSHARP" // Add CSHARP to the word collection
        };

        var characterQuery = // Declare a query that flattens characters from all words
            from word in words // Read every word from the outer collection
            from character in word // Read every character belonging to the current word
            select new // Create an anonymous word-character result
            {
                Word = word, // Store the original word
                Character = character // Store the current character
            };

        Console.WriteLine("\nCharacters flattened from words:"); // Display the character-flattening heading

        foreach (var record in characterQuery) // Visit every word-character result
        {
            Console.WriteLine(record.Word + " -> " + record.Character); // Display the word and current character
        }

        // Filter characters

        char[] vowels = { 'A', 'E', 'I', 'O', 'U' }; // Create an array containing uppercase vowels

        var vowelQuery = // Declare a query that selects vowels from all words
            from word in words // Read every word from the outer collection
            from character in word // Read every character belonging to the current word
            where vowels.Contains(character) // Keep characters that exist in the vowel array
            select new // Create an anonymous vowel result
            {
                Word = word, // Store the original word
                Vowel = character // Store the matching vowel
            };

        Console.WriteLine("\nVowels found inside the words:"); // Display the vowel-query heading

        foreach (var record in vowelQuery) // Visit every matching vowel result
        {
            Console.WriteLine(record.Word + " -> " + record.Vowel); // Display the word and matching vowel
        }

        // Demonstrate deferred execution

        List<Student> deferredStudents = new List<Student>() // Create a collection for deferred-execution demonstration
        {
            new Student { Id = 201, Name = "Ali", Department = "Development", Subjects = new List<string>() { "C#" } }, // Add the first deferred student
            new Student { Id = 202, Name = "Riya", Department = "Testing", Subjects = new List<string>() { "Selenium" } } // Add the second deferred student
        };

        var deferredMultipleFromQuery = // Declare a multiple-from query without executing it immediately
            from student in deferredStudents // Read students when the query is traversed
            from subject in student.Subjects // Read subjects when the query is traversed
            select new // Create an anonymous deferred result
            {
                StudentName = student.Name, // Store the student name
                Subject = subject // Store the subject name
            };

        deferredStudents[0].Subjects.Add("SQL"); // Add a new subject after defining the query

        deferredStudents.Add(new Student { Id = 203, Name = "Kabir", Department = "Data Engineering", Subjects = new List<string>() { "PySpark" } }); // Add a new student after defining the query

        Console.WriteLine("\nDeferred query result after modifying the collection:"); // Display the deferred-execution heading

        foreach (var record in deferredMultipleFromQuery) // Execute and traverse the deferred query
        {
            Console.WriteLine(record.StudentName + " -> " + record.Subject); // Display the updated flattened result
        }

        // Final message

        Console.WriteLine("\nAll LINQ query-expression multiple-from examples completed successfully."); // Display the completion message
    }
}