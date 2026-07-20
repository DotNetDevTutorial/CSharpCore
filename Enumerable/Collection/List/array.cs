/*
Array in C# - Brief Summary

An array stores multiple values of the same data type in a single variable.

Basic syntax:
dataType[] arrayName = new dataType[size];

Example:
int[] numbers = new int[5];

Declaration with values:
int[] numbers = { 10, 20, 30, 40, 50 };

Important points:
1. Array indexing starts from 0.
2. The size of an array is fixed after creation.
3. All elements must have the same data type.
4. Array elements are accessed using their index.
5. Length property returns the total number of elements.
6. One-dimensional arrays store values in a single row.
7. Multidimensional arrays store values in rows and columns.
8. Jagged arrays contain separate arrays as their elements.
9. The Array class provides methods such as Sort(), Reverse(),
   Copy(), IndexOf(), Clear(), and Resize().
*/

using System; // Import the System namespace

class ArrayProgram // Define the ArrayProgram class
{
    static void Main() // Define the main method
    {
        // Array declaration

        int[] numbers; // Declare an integer array variable

        numbers = new int[5]; // Create an integer array having five elements

        // Assigning values

        numbers[0] = 10; // Store 10 at index 0
        numbers[1] = 20; // Store 20 at index 1
        numbers[2] = 30; // Store 30 at index 2
        numbers[3] = 40; // Store 40 at index 3
        numbers[4] = 50; // Store 50 at index 4

        // Accessing array elements

        Console.WriteLine("First element: " + numbers[0]); // Display the first array element
        Console.WriteLine("Third element: " + numbers[2]); // Display the third array element
        Console.WriteLine("Last element: " + numbers[4]); // Display the last array element

        // Array initialization

        string[] fruits = { "Apple", "Mango", "Banana", "Orange" }; // Declare and initialize a string array

        Console.WriteLine("\nFruits:"); // Display the fruits heading

        // Traversing using for loop

        for (int index = 0; index < fruits.Length; index++) // Repeat once for each fruit
        {
            Console.WriteLine(index + " : " + fruits[index]); // Display the index and fruit value
        }

        // Array length

        int totalFruits = fruits.Length; // Store the number of elements in the fruits array

        Console.WriteLine("Total fruits: " + totalFruits); // Display the total number of fruits

        // Updating an array element

        fruits[1] = "Grapes"; // Replace Mango with Grapes

        Console.WriteLine("Updated value: " + fruits[1]); // Display the updated array element

        // Traversing using foreach loop

        Console.WriteLine("\nNumbers using foreach loop:"); // Display the foreach-loop heading

        foreach (int number in numbers) // Visit every element of the numbers array
        {
            Console.WriteLine(number); // Display the current number
        }

        // Finding sum and average

        int sum = 0; // Initialize the sum with zero

        foreach (int number in numbers) // Visit every number in the array
        {
            sum = sum + number; // Add the current number to the sum
        }

        double average = (double)sum / numbers.Length; // Calculate the average of the array values

        Console.WriteLine("\nSum: " + sum); // Display the sum of array elements
        Console.WriteLine("Average: " + average); // Display the average of array elements

        // Finding maximum and minimum

        int maximum = numbers[0]; // Assume the first element is the maximum
        int minimum = numbers[0]; // Assume the first element is the minimum

        foreach (int number in numbers) // Visit every number in the array
        {
            if (number > maximum) // Check whether the current number is greater than the maximum
            {
                maximum = number; // Update the maximum value
            }

            if (number < minimum) // Check whether the current number is smaller than the minimum
            {
                minimum = number; // Update the minimum value
            }
        }

        Console.WriteLine("Maximum: " + maximum); // Display the maximum array value
        Console.WriteLine("Minimum: " + minimum); // Display the minimum array value

        // Searching an element

        int searchValue = 30; // Store the value that must be searched
        int foundIndex = Array.IndexOf(numbers, searchValue); // Find the index of the search value

        if (foundIndex != -1) // Check whether the value exists in the array
        {
            Console.WriteLine(searchValue + " found at index " + foundIndex); // Display the index of the found value
        }
        else // Execute when the value does not exist
        {
            Console.WriteLine(searchValue + " was not found"); // Display the value-not-found message
        }

        // Sorting an array

        int[] unsortedNumbers = { 50, 10, 40, 20, 30 }; // Declare an unsorted integer array

        Array.Sort(unsortedNumbers); // Sort the array in ascending order

        Console.WriteLine("\nSorted array:"); // Display the sorted-array heading

        foreach (int number in unsortedNumbers) // Visit every element of the sorted array
        {
            Console.Write(number + " "); // Display the current number on the same line
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Reversing an array

        Array.Reverse(unsortedNumbers); // Reverse the elements of the sorted array

        Console.WriteLine("\nReversed array:"); // Display the reversed-array heading

        foreach (int number in unsortedNumbers) // Visit every element of the reversed array
        {
            Console.Write(number + " "); // Display the current number on the same line
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Copying an array

        int[] copiedNumbers = new int[numbers.Length]; // Create a new array having the same size

        Array.Copy(numbers, copiedNumbers, numbers.Length); // Copy all elements into the new array

        Console.WriteLine("\nCopied array:"); // Display the copied-array heading

        foreach (int number in copiedNumbers) // Visit every element of the copied array
        {
            Console.Write(number + " "); // Display the copied number
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Clearing array elements

        int[] clearExample = { 10, 20, 30, 40, 50 }; // Declare an array for the clear example

        Array.Clear(clearExample, 1, 2); // Replace two elements starting from index 1 with their default value

        Console.WriteLine("\nArray after clearing elements:"); // Display the clearing heading

        foreach (int number in clearExample) // Visit every element of the cleared array
        {
            Console.Write(number + " "); // Display the current element
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Resizing an array

        int[] resizeNumbers = { 10, 20, 30 }; // Declare an array having three elements

        Array.Resize(ref resizeNumbers, 5); // Resize the array from three elements to five elements

        resizeNumbers[3] = 40; // Store 40 in the newly created position
        resizeNumbers[4] = 50; // Store 50 in the newly created position

        Console.WriteLine("\nResized array:"); // Display the resized-array heading

        foreach (int number in resizeNumbers) // Visit every element of the resized array
        {
            Console.Write(number + " "); // Display the current number
        }

        Console.WriteLine(); // Move the cursor to the next line

        // Two-dimensional array

        int[,] matrix = // Declare a two-dimensional integer array
        {
            { 10, 20, 30 }, // Store values in the first row
            { 40, 50, 60 } // Store values in the second row
        };

        int totalRows = matrix.GetLength(0); // Get the total number of rows
        int totalColumns = matrix.GetLength(1); // Get the total number of columns

        Console.WriteLine("\nTwo-dimensional array:"); // Display the two-dimensional-array heading

        for (int row = 0; row < totalRows; row++) // Repeat once for every row
        {
            for (int column = 0; column < totalColumns; column++) // Repeat once for every column
            {
                Console.Write(matrix[row, column] + " "); // Display the current matrix element
            }

            Console.WriteLine(); // Move to the next line after displaying one row
        }

        // Jagged array

        int[][] jaggedArray = new int[3][]; // Create a jagged array having three inner arrays

        jaggedArray[0] = new int[] { 10, 20 }; // Create the first inner array with two elements
        jaggedArray[1] = new int[] { 30, 40, 50 }; // Create the second inner array with three elements
        jaggedArray[2] = new int[] { 60, 70, 80, 90 }; // Create the third inner array with four elements

        Console.WriteLine("\nJagged array:"); // Display the jagged-array heading

        for (int row = 0; row < jaggedArray.Length; row++) // Repeat once for every inner array
        {
            for (int column = 0; column < jaggedArray[row].Length; column++) // Repeat once for every element of the current inner array
            {
                Console.Write(jaggedArray[row][column] + " "); // Display the current jagged-array element
            }

            Console.WriteLine(); // Move to the next line after displaying one inner array
        }

        // Passing an array to a method

        Console.WriteLine("\nElements displayed by method:"); // Display the method-example heading

        DisplayArray(numbers); // Pass the numbers array to the DisplayArray method

        // Returning an array from a method

        int[] generatedNumbers = CreateArray(5); // Call the method and store the returned array

        Console.WriteLine("\nArray returned by method:"); // Display the returned-array heading

        foreach (int number in generatedNumbers) // Visit every element of the returned array
        {
            Console.Write(number + " "); // Display the current returned value
        }

        Console.WriteLine(); // Move the cursor to the next line
    }

    // Method accepting an array

    static void DisplayArray(int[] values) // Define a method that accepts an integer array
    {
        foreach (int value in values) // Visit every element of the received array
        {
            Console.WriteLine(value); // Display the current array element
        }
    }

    // Method returning an array

    static int[] CreateArray(int size) // Define a method that creates and returns an array
    {
        int[] result = new int[size]; // Create an integer array of the specified size

        for (int index = 0; index < result.Length; index++) // Repeat once for every array position
        {
            result[index] = (index + 1) * 10; // Store multiples of 10 in the array
        }

        return result; // Return the created array
    }
}