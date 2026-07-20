/*
LINQ Aggregation Operators in C# - Brief Summary

Aggregation operators process multiple elements of a collection and
produce a single result.

This program uses LINQ method syntax, also called method-expression syntax.

Basic syntax:

collection.AggregationMethod();

Example:

int total = numbers.Sum();

Aggregation with a condition or selector:

int evenCount = numbers.Count(number => number % 2 == 0);

decimal totalPrice = products.Sum(product => product.Price);

Important aggregation operators:

Count():
Returns the number of elements as an int value.

Count(condition):
Returns the number of elements satisfying a condition.

LongCount():
Returns the number of elements as a long value.
It is useful when the collection may contain more than int.MaxValue elements.

Sum():
Returns the sum of numeric elements.

Sum(selector):
Selects a numeric property from every object and returns its sum.

Min():
Returns the smallest value.

Min(selector):
Returns the smallest selected property value.

Max():
Returns the largest value.

Max(selector):
Returns the largest selected property value.

Average():
Returns the arithmetic average of numeric elements.

Average(selector):
Returns the average of a selected numeric property.

Aggregate():
Performs a custom accumulation operation on all elements.

Aggregate without seed:

collection.Aggregate((result, current) => operation);

Aggregate with seed:

collection.Aggregate(initialValue, (result, current) => operation);

Important points:

1. LINQ aggregation methods are available through System.Linq.
2. Count() returns int, whereas LongCount() returns long.
3. Sum() returns zero for an empty numeric collection.
4. Average() normally throws an exception for an empty non-nullable collection.
5. Min() and Max() normally throw an exception for an empty value-type collection.
6. Aggregate() without a seed throws an exception for an empty collection.
7. Aggregate() with a seed returns the seed when the collection is empty.
8. A lambda expression can select a property or apply a condition.
9. Aggregation methods execute immediately and return a result.
10. Method syntax does not use from, where, select, or other query keywords.

Required namespaces:

using System.Collections.Generic;
using System.Linq;
*/

using System; // Import basic classes such as Console
using System.Collections.Generic; // Import generic collections such as List<T>
using System.Linq; // Import LINQ extension methods

class Product // Define a class representing a product
{
    public int Id { get; set; } // Store the product identifier

    public string Name { get; set; } = ""; // Store the product name

    public string Category { get; set; } = ""; // Store the product category

    public decimal Price { get; set; } // Store the price of the product

    public int Stock { get; set; } // Store the available product quantity
}

class AggregationProgram // Define the main program class
{
    // Display number collection

    static void DisplayNumbers(List<int> numbers) // Define a method that accepts a list of integers
    {
        foreach (int number in numbers) // Visit every number in the collection
        {
            Console.Write(number + " "); // Display the current number on the same line
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Display product collection

    static void DisplayProducts(List<Product> products) // Define a method that accepts a list of products
    {
        foreach (Product product in products) // Visit every product in the collection
        {
            Console.WriteLine($"{product.Id} | {product.Name} | {product.Category} | Rs. {product.Price} | Stock: {product.Stock}"); // Display the current product information
        }
    }

    // Main method

    static void Main() // Define the entry point of the program
    {
        // Create number collection

        List<int> numbers = new List<int>() // Create a list of integer values
        {
            10, // Add 10 to the list
            15, // Add 15 to the list
            20, // Add 20 to the list
            25, // Add 25 to the list
            30 // Add 30 to the list
        };

        Console.WriteLine("Number collection:"); // Display the number-collection heading

        DisplayNumbers(numbers); // Display all numbers

        // Count all elements

        int totalNumbers = numbers.Count(); // Count all elements using the Count aggregation operator

        Console.WriteLine("\nTotal numbers using Count(): " + totalNumbers); // Display the total number of elements

        // Count elements using condition

        int evenNumberCount = numbers.Count(number => number % 2 == 0); // Count numbers that are divisible by two

        Console.WriteLine("Total even numbers: " + evenNumberCount); // Display the number of even elements

        int numbersGreaterThanTwenty = numbers.Count(number => number > 20); // Count numbers greater than twenty

        Console.WriteLine("Numbers greater than 20: " + numbersGreaterThanTwenty); // Display the conditional count

        // LongCount operation

        long totalUsingLongCount = numbers.LongCount(); // Count all elements and return the result as long

        Console.WriteLine("\nTotal numbers using LongCount(): " + totalUsingLongCount); // Display the long count

        long longConditionalCount = numbers.LongCount(number => number >= 20); // Count numbers greater than or equal to twenty

        Console.WriteLine("Numbers greater than or equal to 20: " + longConditionalCount); // Display the conditional long count

        // Sum operation

        int totalSum = numbers.Sum(); // Calculate the sum of all numbers

        Console.WriteLine("\nSum of all numbers: " + totalSum); // Display the total sum

        // Sum using selector

        int doubledNumberSum = numbers.Sum(number => number * 2); // Double every number and calculate the resulting sum

        Console.WriteLine("Sum after doubling each number: " + doubledNumberSum); // Display the sum of doubled values

        // Minimum operation

        int minimumNumber = numbers.Min(); // Obtain the smallest number

        Console.WriteLine("\nMinimum number: " + minimumNumber); // Display the smallest number

        // Minimum using selector

        int minimumSquaredValue = numbers.Min(number => number * number); // Square every number and obtain the smallest result

        Console.WriteLine("Minimum squared value: " + minimumSquaredValue); // Display the minimum selected value

        // Maximum operation

        int maximumNumber = numbers.Max(); // Obtain the largest number

        Console.WriteLine("\nMaximum number: " + maximumNumber); // Display the largest number

        // Maximum using selector

        int maximumSquaredValue = numbers.Max(number => number * number); // Square every number and obtain the largest result

        Console.WriteLine("Maximum squared value: " + maximumSquaredValue); // Display the maximum selected value

        // Average operation

        double averageNumber = numbers.Average(); // Calculate the average of all numbers

        Console.WriteLine("\nAverage of all numbers: " + averageNumber); // Display the average value

        // Average using selector

        double averageAfterDoubling = numbers.Average(number => number * 2); // Double every number and calculate the average

        Console.WriteLine("Average after doubling each number: " + averageAfterDoubling); // Display the selected average

        // Aggregate for addition

        int aggregateSum = numbers.Aggregate((result, currentNumber) => result + currentNumber); // Add all numbers using Aggregate without a seed

        Console.WriteLine("\nSum using Aggregate(): " + aggregateSum); // Display the accumulated sum

        // Aggregate with seed

        int aggregateWithSeed = numbers.Aggregate(100, (result, currentNumber) => result + currentNumber); // Begin with 100 and add every number

        Console.WriteLine("Aggregate sum with seed 100: " + aggregateWithSeed); // Display the result containing the seed

        // Aggregate for multiplication

        int multipliedResult = numbers.Aggregate(1, (result, currentNumber) => result * currentNumber); // Multiply all numbers beginning with seed one

        Console.WriteLine("Multiplication using Aggregate(): " + multipliedResult); // Display the multiplication result

        // Aggregate with result selector

        string formattedAggregateResult = numbers.Aggregate(0, (result, currentNumber) => result + currentNumber, result => "Final total = " + result); // Add numbers and format the final result

        Console.WriteLine("Aggregate with result selector: " + formattedAggregateResult); // Display the formatted aggregation result

        // Create word collection

        List<string> words = new List<string>() // Create a list of string values
        {
            "C#", // Add C# to the word list
            "LINQ", // Add LINQ to the word list
            "Method", // Add Method to the word list
            "Syntax" // Add Syntax to the word list
        };

        // Aggregate string values

        string joinedWords = words.Aggregate((currentResult, nextWord) => currentResult + " -> " + nextWord); // Join all words using an arrow separator

        Console.WriteLine("\nWords joined using Aggregate():"); // Display the string-aggregation heading

        Console.WriteLine(joinedWords); // Display the combined string

        // Create product collection

        List<Product> products = new List<Product>() // Create a list of Product objects
        {
            new Product { Id = 101, Name = "Laptop", Category = "Electronics", Price = 65000m, Stock = 5 }, // Add the Laptop product
            new Product { Id = 102, Name = "Mouse", Category = "Electronics", Price = 800m, Stock = 20 }, // Add the Mouse product
            new Product { Id = 103, Name = "Chair", Category = "Furniture", Price = 6000m, Stock = 7 }, // Add the Chair product
            new Product { Id = 104, Name = "Notebook", Category = "Stationery", Price = 100m, Stock = 0 }, // Add the Notebook product
            new Product { Id = 105, Name = "Monitor", Category = "Electronics", Price = 18000m, Stock = 8 } // Add the Monitor product
        };

        Console.WriteLine("\nProduct collection:"); // Display the product-collection heading

        DisplayProducts(products); // Display all product records

        // Count product objects

        int totalProducts = products.Count(); // Count all products

        Console.WriteLine("\nTotal products: " + totalProducts); // Display the total number of products

        // Count products using condition

        int availableProducts = products.Count(product => product.Stock > 0); // Count products having available stock

        Console.WriteLine("Products currently in stock: " + availableProducts); // Display the number of available products

        int electronicProducts = products.Count(product => product.Category == "Electronics"); // Count products belonging to Electronics

        Console.WriteLine("Electronic products: " + electronicProducts); // Display the number of electronic products

        // Sum product property

        decimal totalProductPrices = products.Sum(product => product.Price); // Calculate the sum of all product prices

        Console.WriteLine("\nSum of product prices: Rs. " + totalProductPrices); // Display the total of product prices

        int totalStock = products.Sum(product => product.Stock); // Calculate the total available stock

        Console.WriteLine("Total stock quantity: " + totalStock); // Display the total stock quantity

        // Minimum product property

        decimal minimumProductPrice = products.Min(product => product.Price); // Obtain the smallest product price

        Console.WriteLine("\nMinimum product price: Rs. " + minimumProductPrice); // Display the smallest price

        // Maximum product property

        decimal maximumProductPrice = products.Max(product => product.Price); // Obtain the largest product price

        Console.WriteLine("Maximum product price: Rs. " + maximumProductPrice); // Display the largest price

        // Average product property

        decimal averageProductPrice = products.Average(product => product.Price); // Calculate the average product price

        Console.WriteLine("Average product price: Rs. " + averageProductPrice); // Display the average price

        // Aggregate product inventory value

        decimal totalInventoryValue = products.Aggregate(0m, (result, product) => result + product.Price * product.Stock); // Calculate total price multiplied by stock for all products

        Console.WriteLine("\nTotal inventory value: Rs. " + totalInventoryValue); // Display the total inventory value

        // Aggregate to find most expensive product

        Product mostExpensiveProduct = products.Aggregate((currentMaximum, currentProduct) => currentProduct.Price > currentMaximum.Price ? currentProduct : currentMaximum); // Compare products and retain the one with the highest price

        Console.WriteLine("Most expensive product: " + mostExpensiveProduct.Name); // Display the most expensive product name

        Console.WriteLine("Most expensive product price: Rs. " + mostExpensiveProduct.Price); // Display the most expensive product price

        // Aggregate to find cheapest product

        Product cheapestProduct = products.Aggregate((currentMinimum, currentProduct) => currentProduct.Price < currentMinimum.Price ? currentProduct : currentMinimum); // Compare products and retain the one with the lowest price

        Console.WriteLine("Cheapest product: " + cheapestProduct.Name); // Display the cheapest product name

        Console.WriteLine("Cheapest product price: Rs. " + cheapestProduct.Price); // Display the cheapest product price

        // Work with empty collection safely

        List<int> emptyNumbers = new List<int>(); // Create an empty integer collection

        int emptyCount = emptyNumbers.Count(); // Count elements in the empty collection

        int emptySum = emptyNumbers.Sum(); // Calculate the sum of the empty collection

        int aggregateSeedResult = emptyNumbers.Aggregate(100, (result, number) => result + number); // Aggregate the empty collection using a seed

        Console.WriteLine("\nEmpty collection examples:"); // Display the empty-collection heading

        Console.WriteLine("Count of empty collection: " + emptyCount); // Display zero because the collection is empty

        Console.WriteLine("Sum of empty collection: " + emptySum); // Display zero because Sum supports an empty numeric collection

        Console.WriteLine("Aggregate result with seed 100: " + aggregateSeedResult); // Display the unchanged seed value

        // Safe average for empty collection

        double? safeEmptyAverage = emptyNumbers.Select(number => (double?)number).Average(); // Convert values to nullable doubles before calculating the average

        Console.WriteLine("Average of empty nullable collection: " + (safeEmptyAverage?.ToString() ?? "null")); // Display null instead of throwing an exception

        // Final message

        Console.WriteLine("\nAll LINQ aggregation operations completed successfully."); // Display the completion message
    }
}