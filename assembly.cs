/*
Syntax:
Assembly assemblyObject = Assembly.GetExecutingAssembly();

The System.Reflection.Assembly class is used to obtain information
about the currently running assembly, referenced assemblies, modules,
types, classes, methods, properties, and assembly version.
*/

using System; // Import basic C# classes
using System.Reflection; // Import classes used for assembly and reflection


namespace AssemblyDemo // Declare the namespace
{
    class Calculator // Declare a sample class inside the assembly
    {
        public int Add(int firstNumber, int secondNumber) // Declare a public method
        {
            return firstNumber + secondNumber; // Return the sum of two numbers
        }

        public int Subtract(int firstNumber, int secondNumber) // Declare another public method
        {
            return firstNumber - secondNumber; // Return the difference between two numbers
        }
    }

    class Program // Declare the main program class
    {
        static void Main() // Declare the program entry point
        {
            // Get the currently executing assembly

            Assembly currentAssembly = Assembly.GetExecutingAssembly(); // Get the assembly containing this program

            Console.WriteLine("Current Assembly Information"); // Display a section label
            Console.WriteLine($"Assembly Name: {currentAssembly.GetName().Name}"); // Display the assembly name
            Console.WriteLine($"Full Name: {currentAssembly.FullName}"); // Display the complete assembly identity
            Console.WriteLine($"Version: {currentAssembly.GetName().Version}"); // Display the assembly version
            Console.WriteLine($"Location: {currentAssembly.Location}"); // Display the physical location of the assembly file
            Console.WriteLine($"Entry Point: {currentAssembly.EntryPoint?.Name}"); // Display the program entry-point method
            Console.WriteLine(); // Print an empty line

            // Display assembly modules

            Console.WriteLine("Modules Available in the Assembly"); // Display a section label

            Module[] modules = currentAssembly.GetModules(); // Get all modules contained in the assembly

            foreach (Module module in modules) // Visit every module in the assembly
            {
                Console.WriteLine($"Module Name: {module.Name}"); // Display the module name
                Console.WriteLine($"Module ID: {module.ModuleVersionId}"); // Display the unique module identifier
            }

            Console.WriteLine(); // Print an empty line

            // Display referenced assemblies

            Console.WriteLine("Referenced Assemblies"); // Display a section label

            AssemblyName[] referencedAssemblies = currentAssembly.GetReferencedAssemblies(); // Get assemblies referenced by this program

            foreach (AssemblyName assemblyName in referencedAssemblies) // Visit every referenced assembly
            {
                Console.WriteLine($"Name: {assemblyName.Name}"); // Display the referenced assembly name
                Console.WriteLine($"Version: {assemblyName.Version}"); // Display the referenced assembly version
                Console.WriteLine(); // Print an empty line
            }

            // Display all types declared in the current assembly

            Console.WriteLine("Types Available in the Assembly"); // Display a section label

            Type[] availableTypes = currentAssembly.GetTypes(); // Get all classes and other types declared in the assembly

            foreach (Type type in availableTypes) // Visit every type in the assembly
            {
                Console.WriteLine($"Type Name: {type.Name}"); // Display the short type name
                Console.WriteLine($"Full Type Name: {type.FullName}"); // Display the complete type name
                Console.WriteLine($"Is Class: {type.IsClass}"); // Check whether the type is a class
                Console.WriteLine($"Is Public: {type.IsPublic}"); // Check whether the type is public

                // Display methods declared inside the type

                MethodInfo[] methods = type.GetMethods( // Get the methods declared directly in the current type
                    BindingFlags.Public | // Include public methods
                    BindingFlags.NonPublic | // Include non-public methods
                    BindingFlags.Instance | // Include instance methods
                    BindingFlags.Static | // Include static methods
                    BindingFlags.DeclaredOnly); // Exclude inherited methods

                foreach (MethodInfo method in methods) // Visit every method declared in the type
                {
                    Console.WriteLine($"Method: {method.Name}"); // Display the method name
                    Console.WriteLine($"Return Type: {method.ReturnType.Name}"); // Display the method return type
                }

                Console.WriteLine(); // Print an empty line
            }

            // Get assembly information using a known type

            Assembly calculatorAssembly = typeof(Calculator).Assembly; // Get the assembly containing the Calculator class

            Console.WriteLine("Assembly Obtained Using typeof"); // Display a section label
            Console.WriteLine($"Calculator Assembly: {calculatorAssembly.GetName().Name}"); // Display the Calculator class assembly name
            Console.WriteLine(); // Print an empty line

            // Create an object dynamically using assembly information

            string calculatorTypeName = typeof(Calculator).FullName!; // Store the complete name of the Calculator class
            object? calculatorObject = currentAssembly.CreateInstance(calculatorTypeName); // Create a Calculator object dynamically

            if (calculatorObject != null) // Check whether the object was created successfully
            {
                Type calculatorType = calculatorObject.GetType(); // Get the runtime type of the created object
                MethodInfo? addMethod = calculatorType.GetMethod("Add"); // Find the Add method inside Calculator

                object? result = addMethod?.Invoke( // Call the Add method dynamically
                    calculatorObject, // Pass the Calculator object
                    new object[] { 20, 10 }); // Pass the method arguments

                Console.WriteLine("Dynamic Object and Method Invocation"); // Display a section label
                Console.WriteLine($"20 + 10 = {result}"); // Display the dynamically calculated result
            }
            else // Execute when the object could not be created
            {
                Console.WriteLine("Calculator object could not be created."); // Display an error message
            }
        }
    }
}