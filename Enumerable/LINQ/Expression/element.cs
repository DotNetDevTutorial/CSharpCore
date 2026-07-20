/*
LINQ Element Operators Using Method Syntax - Complete Concept Summary

Element operators retrieve one particular element from a sequence.

Main LINQ element operators:

1. First()
2. FirstOrDefault()
3. Last()
4. LastOrDefault()
5. Single()
6. SingleOrDefault()
7. ElementAt()
8. ElementAtOrDefault()
9. DefaultIfEmpty()

--------------------------------------------------
1. First()
--------------------------------------------------

First() returns the first element of a sequence.

Syntax:

T result = collection.First();

With a condition:

T result = collection.First(item => condition);

Example:

int firstNumber = numbers.First();

int firstEvenNumber =
    numbers.First(number => number % 2 == 0);

Exception:

First() throws InvalidOperationException when:

1. The collection is empty.
2. No element satisfies the supplied condition.

--------------------------------------------------
2. FirstOrDefault()
--------------------------------------------------

FirstOrDefault() returns the first element when one exists.

When no matching element exists, it returns the default value of the
element type.

Syntax:

T result = collection.FirstOrDefault();

With a condition:

T result = collection.FirstOrDefault(item => condition);

Default values:

int      -> 0
double   -> 0.0
decimal  -> 0
bool     -> false
char     -> '\0'
class    -> null

Example:

int result =
    numbers.FirstOrDefault(number => number > 100);

When no value is greater than 100, result becomes 0.

Important:

A returned zero may mean either:

1. Zero was the actual first matching value.
2. No matching value was found.

For reference types, check the result against null.

--------------------------------------------------
3. Last()
--------------------------------------------------

Last() returns the final element of a sequence.

Syntax:

T result = collection.Last();

With a condition:

T result = collection.Last(item => condition);

Example:

int lastNumber = numbers.Last();

int lastEvenNumber =
    numbers.Last(number => number % 2 == 0);

Exception:

Last() throws InvalidOperationException when:

1. The collection is empty.
2. No element satisfies the condition.

--------------------------------------------------
4. LastOrDefault()
--------------------------------------------------

LastOrDefault() returns the final matching element.

When no matching element exists, it returns the default value.

Syntax:

T result = collection.LastOrDefault();

With a condition:

T result = collection.LastOrDefault(item => condition);

Example:

int result =
    numbers.LastOrDefault(number => number > 100);

When no match exists, result becomes 0.

--------------------------------------------------
5. Single()
--------------------------------------------------

Single() expects exactly one element.

Syntax:

T result = collection.Single();

With a condition:

T result = collection.Single(item => condition);

Single() succeeds only when exactly one element exists or exactly one
element satisfies the condition.

It throws InvalidOperationException when:

1. No element exists.
2. More than one element exists.
3. No element satisfies the condition.
4. More than one element satisfies the condition.

Example:

Employee employee =
    employees.Single(employee => employee.Id == 101);

Single() is useful when duplicate or missing data should be treated as
an error.

--------------------------------------------------
6. SingleOrDefault()
--------------------------------------------------

SingleOrDefault() expects zero or one matching element.

Syntax:

T result = collection.SingleOrDefault();

With a condition:

T result = collection.SingleOrDefault(item => condition);

Behaviour:

Zero matches:
Returns the default value.

Exactly one match:
Returns that element.

More than one match:
Throws InvalidOperationException.

Important:

SingleOrDefault() does not silently select one element when multiple
matches exist.

--------------------------------------------------
7. ElementAt()
--------------------------------------------------

ElementAt() returns the element at a specified zero-based position.

Syntax:

T result = collection.ElementAt(index);

Example:

int thirdNumber = numbers.ElementAt(2);

Index positions:

First element  -> index 0
Second element -> index 1
Third element  -> index 2

Exception:

ElementAt() throws ArgumentOutOfRangeException when the index is
negative or outside the sequence.

--------------------------------------------------
8. ElementAtOrDefault()
--------------------------------------------------

ElementAtOrDefault() returns the element at the requested position.

When the index is invalid, it returns the default value instead of
throwing an exception.

Syntax:

T result = collection.ElementAtOrDefault(index);

Example:

int result = numbers.ElementAtOrDefault(100);

When index 100 does not exist, result becomes 0.

--------------------------------------------------
9. DefaultIfEmpty()
--------------------------------------------------

DefaultIfEmpty() returns the original sequence when it contains
elements.

When the sequence is empty, it returns a sequence containing one
default value.

Syntax:

IEnumerable<T> result =
    collection.DefaultIfEmpty();

Custom default value:

IEnumerable<T> result =
    collection.DefaultIfEmpty(customDefaultValue);

Example:

IEnumerable<int> result =
    emptyNumbers.DefaultIfEmpty();

Result:

0

Custom example:

IEnumerable<int> result =
    emptyNumbers.DefaultIfEmpty(-1);

Result:

-1

Important distinction:

FirstOrDefault():
Returns one element.

DefaultIfEmpty():
Returns a sequence.

--------------------------------------------------
FirstOrDefault() and SingleOrDefault() Difference
--------------------------------------------------

FirstOrDefault():

- Returns the first matching element.
- Does not care whether additional matches exist.
- Returns default when no match exists.

SingleOrDefault():

- Requires zero or one matching element.
- Throws when multiple matches exist.
- Returns default when no match exists.

--------------------------------------------------
First() and Single() Difference
--------------------------------------------------

First():

Returns the first element and ignores additional matching elements.

Single():

Requires exactly one matching element and throws when duplicates exist.

--------------------------------------------------
Immediate Execution
--------------------------------------------------

Element operators normally execute immediately because they must
produce one value.

Immediate operators include:

First()
FirstOrDefault()
Last()
LastOrDefault()
Single()
SingleOrDefault()
ElementAt()
ElementAtOrDefault()

DefaultIfEmpty() returns a sequence and normally remains deferred until
the returned sequence is traversed.

--------------------------------------------------
Time Complexity
--------------------------------------------------

First():
O(1) without a condition in many collections.

First(predicate):
O(n) in the worst case.

Last():
O(1) for collections supporting direct indexing.
O(n) for general IEnumerable<T> sequences.

Last(predicate):
O(n).

Single():
O(n), because LINQ must confirm that no second element exists.

Single(predicate):
O(n).

ElementAt():
O(1) for indexed collections such as List<T> and arrays.
O(n) for general sequences.

DefaultIfEmpty():
O(1) setup and O(n) during complete traversal.

Required namespaces:

using System;
using System.Collections.Generic;
using System.Linq;
*/

#nullable enable // Enable nullable-reference-type analysis

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ element operators

class Employee // Define a class representing an employee
{
    public int Id { get; set; } // Store the employee identifier

    public string Name { get; set; } = ""; // Store the employee name

    public string Department { get; set; } = ""; // Store the employee department

    public string City { get; set; } = ""; // Store the employee city

    public decimal Salary { get; set; } // Store the employee salary
}

class ElementProgram // Define the main program class
{
    // Display numbers

    static void DisplayNumbers(IEnumerable<int> numbers) // Define a method that accepts an integer sequence
    {
        bool numberFound = false; // Track whether the sequence contains a number

        foreach (int number in numbers) // Visit every number in the sequence
        {
            Console.Write(number + " "); // Display the current number

            numberFound = true; // Record that at least one number was found
        }

        if (!numberFound) // Check whether the sequence was empty
        {
            Console.Write("No values"); // Display a message for an empty sequence
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display employees

    static void DisplayEmployees(IEnumerable<Employee> employees) // Define a method that accepts an employee sequence
    {
        bool employeeFound = false; // Track whether an employee was found

        foreach (Employee employee in employees) // Visit every employee in the sequence
        {
            DisplayEmployee(employee); // Display the current employee

            employeeFound = true; // Record that an employee was found
        }

        if (!employeeFound) // Check whether the employee sequence was empty
        {
            Console.WriteLine("No employees"); // Display the empty-sequence message
        }
    }

    // Display one employee

    static void DisplayEmployee(Employee employee) // Define a method that accepts one employee
    {
        Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.Department} | {employee.City} | Rs. {employee.Salary:F2}"); // Display the employee details
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a collection of integer values
        {
            10, // Add 10 to the collection
            20, // Add 20 to the collection
            30, // Add 30 to the collection
            40, // Add 40 to the collection
            50, // Add 50 to the collection
            60, // Add 60 to the collection
            70 // Add 70 to the collection
        };

        Console.WriteLine("Original number collection:"); // Display the original-number heading

        DisplayNumbers(numbers); // Display all numbers

        // First

        int firstNumber = numbers.First(); // Retrieve the first number from the collection

        Console.WriteLine("\nFirst number using First(): " + firstNumber); // Display the first number

        // First with condition

        int firstNumberGreaterThanThirty = numbers.First(number => number > 30); // Retrieve the first number greater than thirty

        Console.WriteLine("First number greater than 30: " + firstNumberGreaterThanThirty); // Display the first matching number

        // First even number

        int firstEvenNumber = numbers.First(number => number % 2 == 0); // Retrieve the first even number

        Console.WriteLine("First even number: " + firstEvenNumber); // Display the first even number

        // First number divisible by three

        int firstNumberDivisibleByThree = numbers.First(number => number % 3 == 0); // Retrieve the first number divisible by three

        Console.WriteLine("First number divisible by 3: " + firstNumberDivisibleByThree); // Display the matching number

        // First after filtering

        int firstFilteredNumber = numbers // Begin with the number collection
            .Where(number => number >= 30) // Keep numbers greater than or equal to thirty
            .OrderByDescending(number => number) // Arrange matching numbers from largest to smallest
            .First(); // Retrieve the first ordered value

        Console.WriteLine("First value after filtering and descending ordering: " + firstFilteredNumber); // Display the retrieved value

        // First exception on empty collection

        List<int> emptyNumbers = new List<int>(); // Create an empty integer collection

        Console.WriteLine("\nCalling First() on an empty collection:"); // Display the First exception heading

        try // Begin protected code that may throw an exception
        {
            int emptyFirstNumber = emptyNumbers.First(); // Attempt to retrieve the first element from an empty collection

            Console.WriteLine(emptyFirstNumber); // Display the result when no exception occurs
        }
        catch (InvalidOperationException exception) // Handle the empty-sequence exception
        {
            Console.WriteLine("First() failed because the collection is empty."); // Explain why First failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // First exception when condition has no match

        Console.WriteLine("\nCalling First() when no value satisfies the condition:"); // Display the no-match heading

        try // Begin protected code that may throw an exception
        {
            int firstLargeNumber = numbers.First(number => number > 500); // Attempt to retrieve the first number greater than five hundred

            Console.WriteLine(firstLargeNumber); // Display the result when a match exists
        }
        catch (InvalidOperationException exception) // Handle the no-matching-element exception
        {
            Console.WriteLine("First() failed because no number is greater than 500."); // Explain why the operation failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // FirstOrDefault

        int firstOrDefaultNumber = numbers.FirstOrDefault(); // Retrieve the first number or the default integer value

        Console.WriteLine("\nFirst number using FirstOrDefault(): " + firstOrDefaultNumber); // Display the first number

        // FirstOrDefault with condition

        int firstNumberGreaterThanForty = numbers.FirstOrDefault(number => number > 40); // Retrieve the first number greater than forty

        Console.WriteLine("FirstOrDefault() number greater than 40: " + firstNumberGreaterThanForty); // Display the matching value

        // FirstOrDefault with no match

        int firstMissingNumber = numbers.FirstOrDefault(number => number > 500); // Return zero because no matching number exists

        Console.WriteLine("FirstOrDefault() when no number is greater than 500: " + firstMissingNumber); // Display the default integer value

        // FirstOrDefault on empty collection

        int emptyFirstOrDefault = emptyNumbers.FirstOrDefault(); // Return zero because the collection is empty

        Console.WriteLine("FirstOrDefault() on an empty integer collection: " + emptyFirstOrDefault); // Display the default integer value

        // FirstOrDefault with custom default value

        int customFirstDefault = emptyNumbers.FirstOrDefault(-1); // Return minus one when the sequence is empty

        Console.WriteLine("FirstOrDefault() with custom default value: " + customFirstDefault); // Display the custom default value

        // Last

        int lastNumber = numbers.Last(); // Retrieve the final number in the collection

        Console.WriteLine("\nLast number using Last(): " + lastNumber); // Display the final number

        // Last with condition

        int lastNumberBelowFifty = numbers.Last(number => number < 50); // Retrieve the last number below fifty

        Console.WriteLine("Last number below 50: " + lastNumberBelowFifty); // Display the final matching number

        // Last number divisible by twenty

        int lastNumberDivisibleByTwenty = numbers.Last(number => number % 20 == 0); // Retrieve the last number divisible by twenty

        Console.WriteLine("Last number divisible by 20: " + lastNumberDivisibleByTwenty); // Display the final matching number

        // Last after filtering

        int lastFilteredNumber = numbers // Begin with the number collection
            .Where(number => number >= 30) // Keep numbers greater than or equal to thirty
            .OrderByDescending(number => number) // Arrange matching numbers from largest to smallest
            .Last(); // Retrieve the final value in the ordered sequence

        Console.WriteLine("Last value after filtering and descending ordering: " + lastFilteredNumber); // Display the retrieved value

        // Last exception on empty collection

        Console.WriteLine("\nCalling Last() on an empty collection:"); // Display the Last exception heading

        try // Begin protected code that may throw an exception
        {
            int emptyLastNumber = emptyNumbers.Last(); // Attempt to retrieve the last value from an empty collection

            Console.WriteLine(emptyLastNumber); // Display the value when no exception occurs
        }
        catch (InvalidOperationException exception) // Handle the empty-sequence exception
        {
            Console.WriteLine("Last() failed because the collection is empty."); // Explain why Last failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Last exception with no condition match

        Console.WriteLine("\nCalling Last() when no value satisfies the condition:"); // Display the no-match heading

        try // Begin protected code that may throw an exception
        {
            int lastLargeNumber = numbers.Last(number => number > 500); // Attempt to retrieve the last number greater than five hundred

            Console.WriteLine(lastLargeNumber); // Display the result when a match exists
        }
        catch (InvalidOperationException exception) // Handle the no-match exception
        {
            Console.WriteLine("Last() failed because no number is greater than 500."); // Explain why Last failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // LastOrDefault

        int lastOrDefaultNumber = numbers.LastOrDefault(); // Retrieve the last number or the default value

        Console.WriteLine("\nLast number using LastOrDefault(): " + lastOrDefaultNumber); // Display the final number

        // LastOrDefault with condition

        int lastNumberBelowSixty = numbers.LastOrDefault(number => number < 60); // Retrieve the last number below sixty

        Console.WriteLine("LastOrDefault() number below 60: " + lastNumberBelowSixty); // Display the matching value

        // LastOrDefault with no match

        int lastMissingNumber = numbers.LastOrDefault(number => number > 500); // Return zero because no matching number exists

        Console.WriteLine("LastOrDefault() when no number is greater than 500: " + lastMissingNumber); // Display the default value

        // LastOrDefault on empty sequence

        int emptyLastOrDefault = emptyNumbers.LastOrDefault(); // Return zero because the collection is empty

        Console.WriteLine("LastOrDefault() on an empty integer collection: " + emptyLastOrDefault); // Display the default integer value

        // LastOrDefault with custom default value

        int customLastDefault = emptyNumbers.LastOrDefault(-1); // Return minus one when the sequence is empty

        Console.WriteLine("LastOrDefault() with custom default value: " + customLastDefault); // Display the custom default value

        // ElementAt

        int firstElementByIndex = numbers.ElementAt(0); // Retrieve the element at index zero

        int thirdElementByIndex = numbers.ElementAt(2); // Retrieve the element at index two

        int sixthElementByIndex = numbers.ElementAt(5); // Retrieve the element at index five

        Console.WriteLine("\nElementAt(0): " + firstElementByIndex); // Display the first indexed element

        Console.WriteLine("ElementAt(2): " + thirdElementByIndex); // Display the third indexed element

        Console.WriteLine("ElementAt(5): " + sixthElementByIndex); // Display the sixth indexed element

        // ElementAt after filtering

        int secondFilteredElement = numbers // Begin with the number collection
            .Where(number => number >= 30) // Keep numbers greater than or equal to thirty
            .ElementAt(1); // Retrieve the second element from the filtered sequence

        Console.WriteLine("Second element after filtering numbers of at least 30: " + secondFilteredElement); // Display the indexed filtered value

        // ElementAt after ordering

        int secondLargestNumber = numbers // Begin with the number collection
            .OrderByDescending(number => number) // Arrange numbers from largest to smallest
            .ElementAt(1); // Retrieve the second element from the ordered sequence

        Console.WriteLine("Second-largest number using ElementAt(1): " + secondLargestNumber); // Display the second-largest number

        // ElementAt invalid index

        Console.WriteLine("\nCalling ElementAt() using an invalid index:"); // Display the invalid-index heading

        try // Begin protected code that may throw an exception
        {
            int invalidElement = numbers.ElementAt(100); // Attempt to retrieve an element outside the sequence

            Console.WriteLine(invalidElement); // Display the result when the index is valid
        }
        catch (ArgumentOutOfRangeException exception) // Handle the invalid-index exception
        {
            Console.WriteLine("ElementAt() failed because index 100 does not exist."); // Explain why the operation failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // ElementAt negative index

        Console.WriteLine("\nCalling ElementAt() using a negative index:"); // Display the negative-index heading

        try // Begin protected code that may throw an exception
        {
            int negativeIndexElement = numbers.ElementAt(-1); // Attempt to retrieve an element using a negative index

            Console.WriteLine(negativeIndexElement); // Display the result when the index is valid
        }
        catch (ArgumentOutOfRangeException exception) // Handle the negative-index exception
        {
            Console.WriteLine("ElementAt() failed because a negative index is invalid."); // Explain why the operation failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // ElementAtOrDefault

        int validElementOrDefault = numbers.ElementAtOrDefault(3); // Retrieve the value at index three

        int invalidElementOrDefault = numbers.ElementAtOrDefault(100); // Return zero because index one hundred does not exist

        int negativeElementOrDefault = numbers.ElementAtOrDefault(-1); // Return zero because the index is negative

        Console.WriteLine("\nElementAtOrDefault(3): " + validElementOrDefault); // Display the valid indexed value

        Console.WriteLine("ElementAtOrDefault(100): " + invalidElementOrDefault); // Display the default value for an invalid index

        Console.WriteLine("ElementAtOrDefault(-1): " + negativeElementOrDefault); // Display the default value for a negative index

        // Single-element collection

        List<int> oneNumber = new List<int>() // Create a collection containing exactly one value
        {
            500 // Add the single value
        };

        int singleNumber = oneNumber.Single(); // Retrieve the only element from the collection

        Console.WriteLine("\nSingle() on a one-element collection: " + singleNumber); // Display the single element

        // Single with condition

        int uniqueNumber = numbers.Single(number => number == 40); // Retrieve the only element equal to forty

        Console.WriteLine("Single() number equal to 40: " + uniqueNumber); // Display the uniquely matching number

        // Single after filtering

        int singleFilteredNumber = numbers // Begin with the number collection
            .Where(number => number > 60) // Keep numbers greater than sixty
            .Single(); // Require exactly one matching number

        Console.WriteLine("Single value greater than 60: " + singleFilteredNumber); // Display the single filtered number

        // Single on empty collection

        Console.WriteLine("\nCalling Single() on an empty collection:"); // Display the empty-Single heading

        try // Begin protected code that may throw an exception
        {
            int emptySingleNumber = emptyNumbers.Single(); // Attempt to retrieve exactly one element from an empty collection

            Console.WriteLine(emptySingleNumber); // Display the result when one element exists
        }
        catch (InvalidOperationException exception) // Handle the incorrect-element-count exception
        {
            Console.WriteLine("Single() failed because the collection contains no elements."); // Explain why Single failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Single on collection containing multiple elements

        Console.WriteLine("\nCalling Single() on a collection containing multiple values:"); // Display the multiple-element heading

        try // Begin protected code that may throw an exception
        {
            int invalidSingleNumber = numbers.Single(); // Attempt to retrieve one element from a multi-element sequence

            Console.WriteLine(invalidSingleNumber); // Display the result when exactly one element exists
        }
        catch (InvalidOperationException exception) // Handle the multiple-element exception
        {
            Console.WriteLine("Single() failed because the collection contains multiple elements."); // Explain why Single failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Single with multiple matching elements

        Console.WriteLine("\nCalling Single() when multiple values satisfy the condition:"); // Display the duplicate-match heading

        try // Begin protected code that may throw an exception
        {
            int invalidSingleEvenNumber = numbers.Single(number => number % 2 == 0); // Attempt to retrieve one value when many even values exist

            Console.WriteLine(invalidSingleEvenNumber); // Display the result when exactly one match exists
        }
        catch (InvalidOperationException exception) // Handle the multiple-match exception
        {
            Console.WriteLine("Single() failed because multiple even numbers exist."); // Explain why Single failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Single with no matching element

        Console.WriteLine("\nCalling Single() when no value satisfies the condition:"); // Display the no-match Single heading

        try // Begin protected code that may throw an exception
        {
            int missingSingleNumber = numbers.Single(number => number > 500); // Attempt to retrieve one number greater than five hundred

            Console.WriteLine(missingSingleNumber); // Display the result when exactly one match exists
        }
        catch (InvalidOperationException exception) // Handle the no-match exception
        {
            Console.WriteLine("Single() failed because no number is greater than 500."); // Explain why Single failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // SingleOrDefault with exactly one element

        int singleOrDefaultNumber = oneNumber.SingleOrDefault(); // Retrieve the only element from the collection

        Console.WriteLine("\nSingleOrDefault() on a one-element collection: " + singleOrDefaultNumber); // Display the single value

        // SingleOrDefault with one matching element

        int uniqueSingleOrDefault = numbers.SingleOrDefault(number => number == 50); // Retrieve the only number equal to fifty

        Console.WriteLine("SingleOrDefault() number equal to 50: " + uniqueSingleOrDefault); // Display the unique matching number

        // SingleOrDefault with no element

        int emptySingleOrDefault = emptyNumbers.SingleOrDefault(); // Return zero because the collection is empty

        Console.WriteLine("SingleOrDefault() on an empty integer collection: " + emptySingleOrDefault); // Display the default integer value

        // SingleOrDefault with no matching element

        int missingSingleOrDefault = numbers.SingleOrDefault(number => number > 500); // Return zero because no number matches

        Console.WriteLine("SingleOrDefault() when no number is greater than 500: " + missingSingleOrDefault); // Display the default integer value

        // SingleOrDefault with custom default value

        int customSingleDefault = emptyNumbers.SingleOrDefault(-1); // Return minus one when the sequence is empty

        Console.WriteLine("SingleOrDefault() with custom default value: " + customSingleDefault); // Display the custom default value

        // SingleOrDefault with multiple matches

        Console.WriteLine("\nCalling SingleOrDefault() when multiple values satisfy the condition:"); // Display the multiple-match heading

        try // Begin protected code that may throw an exception
        {
            int invalidSingleOrDefault = numbers.SingleOrDefault(number => number >= 30); // Attempt to retrieve one value when several values match

            Console.WriteLine(invalidSingleOrDefault); // Display the result when zero or one value matches
        }
        catch (InvalidOperationException exception) // Handle the multiple-match exception
        {
            Console.WriteLine("SingleOrDefault() failed because multiple matching numbers exist."); // Explain why the operation failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Compare FirstOrDefault and SingleOrDefault

        int firstEvenOrDefault = numbers.FirstOrDefault(number => number % 2 == 0); // Retrieve the first even number even though several even numbers exist

        Console.WriteLine("\nFirstOrDefault() with multiple even values: " + firstEvenOrDefault); // Display the first matching even number

        Console.WriteLine("SingleOrDefault() would throw because multiple even values exist."); // Explain the SingleOrDefault difference

        // DefaultIfEmpty on non-empty collection

        IEnumerable<int> nonEmptyDefaultResult = numbers.DefaultIfEmpty(); // Return the original number sequence because it is not empty

        Console.WriteLine("\nDefaultIfEmpty() on a non-empty collection:"); // Display the non-empty DefaultIfEmpty heading

        DisplayNumbers(nonEmptyDefaultResult); // Display the original sequence

        // DefaultIfEmpty on empty integer collection

        IEnumerable<int> emptyDefaultResult = emptyNumbers.DefaultIfEmpty(); // Return a one-element sequence containing zero

        Console.WriteLine("\nDefaultIfEmpty() on an empty integer collection:"); // Display the default-value heading

        DisplayNumbers(emptyDefaultResult); // Display the sequence containing zero

        // DefaultIfEmpty with custom value

        IEnumerable<int> customDefaultResult = emptyNumbers.DefaultIfEmpty(-1); // Return a one-element sequence containing minus one

        Console.WriteLine("\nDefaultIfEmpty(-1) on an empty integer collection:"); // Display the custom-default heading

        DisplayNumbers(customDefaultResult); // Display the custom default sequence

        // DefaultIfEmpty after filtering

        IEnumerable<int> filteredDefaultResult = numbers // Begin with the number collection
            .Where(number => number > 500) // Create an empty sequence because no number matches
            .DefaultIfEmpty(-999); // Supply minus nine hundred ninety-nine when the filtered sequence is empty

        Console.WriteLine("\nDefaultIfEmpty(-999) after filtering with no matches:"); // Display the filtered-default heading

        DisplayNumbers(filteredDefaultResult); // Display the supplied default value

        // Aggregate empty sequence safely

        double safeAverage = emptyNumbers // Begin with the empty integer collection
            .DefaultIfEmpty(0) // Supply zero when no element exists
            .Average(); // Calculate the average of the resulting sequence

        Console.WriteLine("\nAverage of an empty sequence after DefaultIfEmpty(0): " + safeAverage); // Display the safe average

        // Create employee collection

        List<Employee> employees = new List<Employee>() // Create a collection of employee objects
        {
            new Employee { Id = 101, Name = "Saad", Department = "Development", City = "Pune", Salary = 65000m }, // Add the first employee
            new Employee { Id = 102, Name = "Aman", Department = "Testing", City = "Delhi", Salary = 48000m }, // Add the second employee
            new Employee { Id = 103, Name = "Neha", Department = "Development", City = "Pune", Salary = 75000m }, // Add the third employee
            new Employee { Id = 104, Name = "Rahul", Department = "Support", City = "Bengaluru", Salary = 38000m }, // Add the fourth employee
            new Employee { Id = 105, Name = "Priya", Department = "Data Engineering", City = "Hyderabad", Salary = 82000m }, // Add the fifth employee
            new Employee { Id = 106, Name = "Arjun", Department = "Development", City = "Delhi", Salary = 55000m }, // Add the sixth employee
            new Employee { Id = 107, Name = "Zoya", Department = "Data Engineering", City = "Pune", Salary = 70000m } // Add the seventh employee
        };

        Console.WriteLine("\nOriginal employee collection:"); // Display the employee-collection heading

        DisplayEmployees(employees); // Display all employees

        // First employee

        Employee firstEmployee = employees.First(); // Retrieve the first employee

        Console.WriteLine("\nFirst employee:"); // Display the first-employee heading

        DisplayEmployee(firstEmployee); // Display the first employee

        // First employee by condition

        Employee firstDevelopmentEmployee = employees.First(employee => employee.Department == "Development"); // Retrieve the first Development employee

        Console.WriteLine("\nFirst Development employee:"); // Display the first-matching-employee heading

        DisplayEmployee(firstDevelopmentEmployee); // Display the first Development employee

        // First employee ordered by salary

        Employee highestSalaryEmployee = employees // Begin with the employee collection
            .OrderByDescending(employee => employee.Salary) // Arrange employees from highest to lowest salary
            .First(); // Retrieve the first ordered employee

        Console.WriteLine("\nHighest-salary employee using OrderByDescending() and First():"); // Display the highest-salary heading

        DisplayEmployee(highestSalaryEmployee); // Display the highest-salary employee

        // FirstOrDefault employee with no match

        Employee? missingFirstEmployee = employees.FirstOrDefault(employee => employee.Department == "Finance"); // Return null because no Finance employee exists

        Console.WriteLine("\nFirst Finance employee using FirstOrDefault():"); // Display the missing-employee heading

        if (missingFirstEmployee is null) // Check whether no employee was found
        {
            Console.WriteLine("No Finance employee was found."); // Display the no-match message
        }
        else // Execute when an employee was found
        {
            DisplayEmployee(missingFirstEmployee); // Display the matching employee
        }

        // Last employee

        Employee lastEmployee = employees.Last(); // Retrieve the final employee in the collection

        Console.WriteLine("\nLast employee:"); // Display the last-employee heading

        DisplayEmployee(lastEmployee); // Display the last employee

        // Last matching employee

        Employee lastPuneEmployee = employees.Last(employee => employee.City == "Pune"); // Retrieve the final Pune employee

        Console.WriteLine("\nLast Pune employee:"); // Display the last-matching-employee heading

        DisplayEmployee(lastPuneEmployee); // Display the final Pune employee

        // LastOrDefault employee with no match

        Employee? missingLastEmployee = employees.LastOrDefault(employee => employee.City == "Mumbai"); // Return null because no Mumbai employee exists

        Console.WriteLine("\nLast Mumbai employee using LastOrDefault():"); // Display the missing-last-employee heading

        if (missingLastEmployee is null) // Check whether no employee matched
        {
            Console.WriteLine("No Mumbai employee was found."); // Display the no-match message
        }
        else // Execute when an employee was found
        {
            DisplayEmployee(missingLastEmployee); // Display the matching employee
        }

        // Employee ElementAt

        Employee thirdEmployee = employees.ElementAt(2); // Retrieve the employee at index two

        Console.WriteLine("\nEmployee at index 2:"); // Display the employee-index heading

        DisplayEmployee(thirdEmployee); // Display the third employee

        // Employee ElementAtOrDefault

        Employee? missingIndexedEmployee = employees.ElementAtOrDefault(100); // Return null because index one hundred does not exist

        Console.WriteLine("\nEmployee at index 100 using ElementAtOrDefault():"); // Display the invalid-employee-index heading

        if (missingIndexedEmployee is null) // Check whether the requested employee did not exist
        {
            Console.WriteLine("No employee exists at index 100."); // Display the invalid-index message
        }
        else // Execute when an employee exists
        {
            DisplayEmployee(missingIndexedEmployee); // Display the indexed employee
        }

        // Single employee by unique identifier

        Employee employeeWithId105 = employees.Single(employee => employee.Id == 105); // Retrieve the only employee having ID 105

        Console.WriteLine("\nEmployee having ID 105:"); // Display the unique-employee heading

        DisplayEmployee(employeeWithId105); // Display the uniquely matching employee

        // SingleOrDefault employee with no match

        Employee? missingEmployee = employees.SingleOrDefault(employee => employee.Id == 999); // Return null because no employee has ID 999

        Console.WriteLine("\nEmployee having ID 999 using SingleOrDefault():"); // Display the missing-unique-employee heading

        if (missingEmployee is null) // Check whether no matching employee exists
        {
            Console.WriteLine("No employee has ID 999."); // Display the no-match message
        }
        else // Execute when an employee exists
        {
            DisplayEmployee(missingEmployee); // Display the matching employee
        }

        // SingleOrDefault duplicate employee condition

        Console.WriteLine("\nCalling SingleOrDefault() for the Development department:"); // Display the duplicate-employee heading

        try // Begin protected code that may throw an exception
        {
            Employee? developmentEmployee = employees.SingleOrDefault(employee => employee.Department == "Development"); // Attempt to retrieve one Development employee when several exist

            if (developmentEmployee is not null) // Check whether one matching employee was returned
            {
                DisplayEmployee(developmentEmployee); // Display the employee
            }
        }
        catch (InvalidOperationException exception) // Handle the multiple-match exception
        {
            Console.WriteLine("SingleOrDefault() failed because multiple Development employees exist."); // Explain why the operation failed

            Console.WriteLine("Exception type: " + exception.GetType().Name); // Display the exception type
        }

        // Empty employee collection

        List<Employee> emptyEmployees = new List<Employee>(); // Create an empty employee collection

        Employee defaultEmployee = new Employee // Create a custom default employee
        {
            Id = 0, // Set the default employee identifier
            Name = "No employee", // Set the default employee name
            Department = "Not assigned", // Set the default department
            City = "Not available", // Set the default city
            Salary = 0m // Set the default salary
        };

        IEnumerable<Employee> employeesWithDefault = emptyEmployees.DefaultIfEmpty(defaultEmployee); // Return the custom employee because the collection is empty

        Console.WriteLine("\nDefaultIfEmpty() with a custom Employee object:"); // Display the custom-object-default heading

        DisplayEmployees(employeesWithDefault); // Display the custom default employee

        // DefaultIfEmpty with non-empty employees

        IEnumerable<Employee> existingEmployeesWithDefault = employees.DefaultIfEmpty(defaultEmployee); // Return the original employees because the collection is not empty

        Console.WriteLine("\nDefaultIfEmpty() on the non-empty employee collection:"); // Display the non-empty-employee heading

        DisplayEmployees(existingEmployeesWithDefault); // Display the original employees

        // Retrieve custom default employee directly

        Employee safeEmployee = emptyEmployees // Begin with the empty employee collection
            .DefaultIfEmpty(defaultEmployee) // Supply the custom employee when the collection is empty
            .First(); // Retrieve the first element from the guaranteed non-empty sequence

        Console.WriteLine("\nSafely retrieved employee from an empty sequence:"); // Display the safe-retrieval heading

        DisplayEmployee(safeEmployee); // Display the custom default employee

        // Demonstrate immediate execution

        List<int> immediateNumbers = new List<int>() // Create a collection for immediate-execution demonstration
        {
            10, // Add 10 to the collection
            20, // Add 20 to the collection
            30 // Add 30 to the collection
        };

        int capturedFirstNumber = immediateNumbers.First(); // Execute First immediately and store the current first value

        immediateNumbers.Insert(0, 5); // Insert a new first value after First has already executed

        Console.WriteLine("\nImmediate execution demonstration:"); // Display the immediate-execution heading

        Console.WriteLine("Stored First() result: " + capturedFirstNumber); // Display the previously captured value

        Console.WriteLine("Current First() result: " + immediateNumbers.First()); // Execute First again and display the new first value

        // Demonstrate deferred DefaultIfEmpty

        List<int> deferredEmptyNumbers = new List<int>(); // Create an empty collection for deferred execution

        IEnumerable<int> deferredDefaultQuery = deferredEmptyNumbers.DefaultIfEmpty(-1); // Define a DefaultIfEmpty sequence without traversing it

        deferredEmptyNumbers.Add(100); // Add a real value before traversing the sequence

        Console.WriteLine("\nDeferred DefaultIfEmpty() result after adding 100:"); // Display the deferred-execution heading

        DisplayNumbers(deferredDefaultQuery); // Traverse the sequence and display 100 instead of the default value

        // Final message

        Console.WriteLine("\nAll LINQ method-syntax element-operator examples completed successfully."); // Display the completion message
    }
}