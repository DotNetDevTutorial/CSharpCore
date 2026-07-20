/*
using NamespaceName;                         // Import a namespace
global using NamespaceName;                  // Import a namespace for all project files
using Alias = NamespaceName;                 // Create a namespace alias
using Alias = NamespaceName.TypeName;        // Create a type alias
using static NamespaceName.TypeName;         // Import static members
Alias::TypeName                              // Access a type through an alias
global::NamespaceName.TypeName               // Start lookup from the global namespace
using (resource) { }                         // Dispose resource after the block
using ResourceType resource = expression;    // Dispose resource at the end of the scope
*/

global using System; // Import System for all project files

using System.Collections.Generic; // Import collection types

using Text = System.Text; // Create an alias for a namespace

using Builder = System.Text.StringBuilder; // Create an alias for a type

using static System.Console; // Import static Console members

namespace UsingDemonstration
{
    using System.IO; // Import a namespace only inside this namespace

    internal class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>(); // Use an imported namespace type

            numbers.Add(10); // Add a value to the list

            Builder firstText = new Builder(); // Use the type alias

            firstText.Append("Type alias"); // Add text to the builder

            Text::StringBuilder secondText = new Text::StringBuilder(); // Use :: with a namespace alias

            secondText.Append("Namespace alias"); // Add text to the builder

            WriteLine(firstText); // Use WriteLine imported by using static

            WriteLine(secondText); // Display the second builder

            global::System.Console.WriteLine(numbers[0]); // Access System from the global namespace

            using (StringReader reader = new StringReader("Using statement")) // Create a block-scoped resource
            {
                WriteLine(reader.ReadToEnd()); // Read data from the resource
            } // Dispose reader after this block

            using StringReader secondReader = new StringReader("Using declaration"); // Create a scope-level resource

            WriteLine(secondReader.ReadToEnd()); // Read data from the resource
        } // Dispose secondReader at the end of Main
    }
}