/*
Namespace syntax:

Block-scoped:
namespace NamespaceName
{
}

File-scoped:
namespace NamespaceName;

A namespace organizes related types and prevents naming conflicts.
Namespaces can be nested, reopened and written using dotted names.
Multiple block-scoped namespaces can exist in the same source file.
Types declared outside every namespace belong to the global namespace.
The global:: operator starts name lookup from the global namespace.
Using directives import namespaces but do not copy their types.
Using directives can create aliases or import static members.
*/

global using System; // Import System for all files in the project

using FirstClass = FirstNamespace.Sample; // Create an alias for a type

using static System.Console; // Import static Console members

namespace FirstNamespace // Declare a block-scoped namespace
{
    public class Sample // Declare a type inside FirstNamespace
    {
        public static void Show() // Declare a simple method
        {
            WriteLine("FirstNamespace.Sample"); // Display the full type location
        }
    }
}

namespace FirstNamespace // Reopen the same namespace
{
    public class AnotherSample // Add another type to FirstNamespace
    {
    }
}

namespace SecondNamespace // Declare another namespace in the same file
{
    public class Sample // Same class name is allowed in another namespace
    {
        public static void Show() // Declare a simple method
        {
            WriteLine("SecondNamespace.Sample"); // Display the full type location
        }
    }
}

namespace ParentNamespace // Declare a parent namespace
{
    namespace ChildNamespace // Declare a nested namespace
    {
        public class NestedType // Belongs to ParentNamespace.ChildNamespace
        {
        }
    }
}

namespace Company.Application.Services // Declare a namespace using a dotted name
{
    public class Service // Belongs to Company.Application.Services
    {
    }
}

namespace MainApplication // Declare the application namespace
{
    using SecondNamespace; // Import a namespace inside another namespace

    internal class Program // Declare the main class
    {
        static void Main() // Start the program
        {
            FirstClass.Show(); // Use the type alias

            Sample.Show(); // Use SecondNamespace.Sample through using

            FirstNamespace.Sample.Show(); // Use the fully qualified type name

            global::FirstNamespace.Sample.Show(); // Start lookup from the global namespace

            Type firstType = typeof(FirstNamespace.Sample); // Access a type in FirstNamespace

            Type secondType = typeof(SecondNamespace.Sample); // Access the same type name in another namespace

            Type nestedType = typeof(ParentNamespace.ChildNamespace.NestedType); // Access a nested namespace

            Type dottedType = typeof(Company.Application.Services.Service); // Access a dotted namespace

            Type globalType = typeof(GlobalType); // Access a type from the global namespace

            WriteLine(firstType.FullName); // Display the first fully qualified name

            WriteLine(secondType.FullName); // Display the second fully qualified name

            WriteLine(nestedType.FullName); // Display the nested type name

            WriteLine(dottedType.FullName); // Display the dotted namespace type name

            WriteLine(globalType.Namespace ?? "Global namespace"); // Show that GlobalType has no namespace
        }
    }
}

public class GlobalType // Declare a type outside every namespace
{
}

/*
public namespace InvalidNamespace
{
}

Wrong:
A namespace cannot have an access modifier.
*/

/*
[Serializable]
namespace InvalidNamespace
{
}

Wrong:
Attributes cannot be applied directly to a namespace.
*/

/*
class OuterClass
{
    namespace InnerNamespace
    {
    }
}

Wrong:
A namespace cannot be declared inside a class or another type.
*/

/*
namespace InvalidUsingPosition
{
    public class Sample
    {
    }

    using System.Collections.Generic;
}

Wrong:
Using directives inside a namespace must appear before type declarations.
*/

/*
FirstNamespace objectName;

Wrong:
A namespace is not a type, so an object cannot be created from it.
*/

/*
using FirstNamespace;
using SecondNamespace;

Sample.Show();

Wrong:
Sample becomes ambiguous because both imported namespaces contain
a type named Sample. Use a fully qualified name or an alias.
*/