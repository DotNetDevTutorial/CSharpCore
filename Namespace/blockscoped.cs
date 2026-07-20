/*
Syntax:

namespace NamespaceName
{
    // Types and nested namespaces
}

A block-scoped namespace uses opening and closing braces.
Its scope ends at the closing brace.
Multiple block-scoped namespaces can exist in one file.
The same namespace can be reopened in another block.
Namespaces can be nested or written using dotted names.
Types outside every namespace belong to the global namespace.
*/

using System; // Import System for the complete file

/*
namespace Company.Application;

Wrong:
A file-scoped namespace cannot be mixed with block-scoped namespaces.
*/

/*
public namespace InvalidNamespace
{
}

Wrong:
A namespace cannot have an access modifier.
*/

namespace Company.Models // Declare the first block-scoped namespace
{
    public class Employee // Declare a class inside Company.Models
    {
        public string Name { get; set; } = string.Empty; // Store the employee name
    }
}

namespace Company.Models // Reopen the same namespace
{
    public class Department // Add another class to Company.Models
    {
        public string Name { get; set; } = string.Empty; // Store the department name
    }
}

namespace Company // Declare the parent namespace
{
    namespace Services // Declare a nested namespace
    {
        using Company.Models; // Import a namespace before type declarations

        public class EmployeeService // Declare a class inside Company.Services
        {
            public void Display(Employee employee) // Receive an Employee object
            {
                Console.WriteLine(employee.Name); // Display the employee name
            }
        }

        /*
        public class Sample
        {
        }

        using System.Collections.Generic;

        Wrong:
        A using directive inside a namespace must appear before type declarations.
        */
    }
}

namespace Company.Utilities.Helpers // Declare a namespace using a dotted name
{
    public static class NamespaceChecker // Declare a helper class
    {
        public static void Display(Type type) // Receive a type
        {
            Console.WriteLine($"Type: {type.Name}"); // Display the type name
            Console.WriteLine($"Namespace: {type.Namespace}"); // Display its namespace
            Console.WriteLine(); // Print an empty line
        }
    }
}

namespace Company.Application // Declare another namespace in the same file
{
    using Company.Models; // Import Company.Models
    using Company.Services; // Import Company.Services
    using Company.Utilities.Helpers; // Import the helper namespace

    internal class Program // Declare the main class
    {
        static void Main(string[] args) // Start the program
        {
            Employee employee = new Employee(); // Create an Employee object
            employee.Name = "Saad"; // Assign the employee name

            Department department = new Department(); // Create a Department object
            department.Name = "Data Engineering"; // Assign the department name

            EmployeeService service = new EmployeeService(); // Create the service
            service.Display(employee); // Display the employee name

            Console.WriteLine(department.Name); // Display the department name
            Console.WriteLine(); // Print an empty line

            NamespaceChecker.Display(typeof(Employee)); // Display Company.Models
            NamespaceChecker.Display(typeof(EmployeeService)); // Display Company.Services
            NamespaceChecker.Display(typeof(Program)); // Display Company.Application

            GlobalMessage.Display(); // Call a class from the global namespace
        }
    }

    /*
    public class OuterClass
    {
        namespace InnerNamespace
        {
        }
    }

    Wrong:
    A namespace cannot be declared inside a class.
    */
}

internal static class GlobalMessage // Declare a type outside every namespace
{
    public static void Display() // Declare a display method
    {
        Console.WriteLine("This class belongs to the global namespace."); // Display a message
        Console.WriteLine(typeof(GlobalMessage).Namespace ?? "Global namespace"); // Display its namespace
    }
}