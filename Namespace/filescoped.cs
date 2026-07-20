/*
Syntax:
namespace NamespaceName;

A file-scoped namespace ends with a semicolon and does not use braces.
It applies to every type declared after it until the end of the file.
Only one file-scoped namespace is allowed in a source file.
It cannot be mixed with a block-scoped namespace or top-level statements.
It must appear before all type declarations.
It can use a dotted namespace name.
It requires C# 10 or later.
*/

global using System; // Correct: global using appears before normal using directives

using System.Collections.Generic; // Correct: using can appear before the namespace

/*
Console.WriteLine("Hello");

namespace Company.Application;

Wrong:
Top-level statements cannot be used with a file-scoped namespace.
*/

/*
public class BeforeNamespace
{
}

namespace Company.Application;

Wrong:
A type cannot appear before a file-scoped namespace.
*/

/*
public namespace Company.Application;

Wrong:
A namespace cannot have an access modifier.
*/

/*
namespace Company.Application

Wrong:
A file-scoped namespace must end with a semicolon.
*/

namespace Company.Application.FileScopedDemo; // Correct: dotted file-scoped namespace

using static System.Console; // Correct: using can appear after the namespace but before types

/*
namespace AnotherNamespace;

Wrong:
Only one file-scoped namespace is allowed in one source file.
*/

/*
namespace AnotherNamespace
{
    public class Sample
    {
    }
}

Wrong:
A block-scoped namespace cannot be mixed with a file-scoped namespace.
*/

public interface IService // Belongs to Company.Application.FileScopedDemo
{
    void Run(); // Declare a method
}

public class Service : IService // Belongs to Company.Application.FileScopedDemo
{
    public void Run() // Implement the interface method
    {
        WriteLine("Service is running."); // Display a message
    }
}

public struct SampleStruct // Belongs to Company.Application.FileScopedDemo
{
}

public enum SampleEnum // Belongs to Company.Application.FileScopedDemo
{
    Value
}

public record SampleRecord; // Belongs to Company.Application.FileScopedDemo

public delegate void SampleDelegate(); // Belongs to Company.Application.FileScopedDemo

internal class Program // Belongs to Company.Application.FileScopedDemo
{
    static void Main() // Start the program
    {
        IService service = new Service(); // Create an object
        service.Run(); // Call the method

        List<Type> types = new List<Type> // Store different type declarations
        {
            typeof(IService), // Add the interface
            typeof(Service), // Add the class
            typeof(SampleStruct), // Add the struct
            typeof(SampleEnum), // Add the enum
            typeof(SampleRecord), // Add the record
            typeof(SampleDelegate), // Add the delegate
            typeof(Program) // Add the Program class
        };

        foreach (Type type in types) // Visit every type
        {
            WriteLine($"{type.Name} -> {type.Namespace}"); // Show the namespace
        }
    }
}

/*
using System.Text;

Wrong:
A using directive after the file-scoped namespace must appear
before all type declarations.
*/

/*
global using System.Linq;

Wrong:
A global using directive cannot appear inside a file-scoped namespace.
*/

/*
namespace ChildNamespace;

Wrong:
Another namespace cannot be declared after a file-scoped namespace.
*/

/*
public class OuterClass
{
    namespace InnerNamespace;
}

Wrong:
A namespace cannot be declared inside a class.
*/

/*
public class OutsideNamespace
{
}

Wrong assumption:
This class would still belong to Company.Application.FileScopedDemo
because the namespace continues until the end of the file.
*/

/*
}

Wrong:
A file-scoped namespace does not have a closing brace.
*/