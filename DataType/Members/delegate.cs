#nullable enable

/*
Delegate syntax:
[access_modifier] delegate ReturnType DelegateName(ParameterList);

Generic delegate:
delegate TResult Transformer<in TInput, out TResult>(TInput value);

Delegate assignment:
DelegateType d1 = MethodName;
DelegateType d2 = new DelegateType(MethodName);
DelegateType d3 = delegate(parameters) { };
DelegateType d4 = (parameters) => expression;

Delegate invocation:
result = delegateVariable(arguments);
result = delegateVariable.Invoke(arguments);
delegateVariable?.Invoke(arguments);

Multicast operations:
delegateVariable += anotherDelegate;
delegateVariable -= anotherDelegate;

Common built-in delegates:
Action                 // No return value
Action<T>              // Parameters but no return value
Func<TResult>          // Returns a value
Func<T, TResult>       // Parameters and a return value
Predicate<T>           // Takes T and returns bool
Comparison<T>          // Takes two T values and returns int
Converter<TIn, TOut>   // Converts one type to another

A delegate is a type-safe reference to one or more compatible methods.
Delegates can reference static methods, instance methods, local functions,
anonymous methods and lambda expressions.
Delegate parameters and return types must be compatible with the target method.
ref, in and out parameter modifiers must match exactly.
Delegates are immutable; combining or removing creates another delegate value.
Multicast delegates invoke methods in registration order.
A non-void multicast delegate returns the result of its final method.
An unhandled exception stops the remaining multicast invocation.
Delegate equality compares the delegate type, target, method and invocation list.
Delegates are reference types based on System.MulticastDelegate.
Events use delegates internally but restrict direct invocation to the publisher.
*/


using System; // Import basic .NET types
using System.Threading.Tasks; // Import Task


namespace DelegateDemonstration;

// Supporting reference types
internal class Animal
{
    public string Name { get; } // Store the animal name

    public Animal(string name)
    {
        Name = name; // Assign the animal name
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}"; // Return readable text
    }
}

internal sealed class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }
}


// Instance-method target

internal sealed class Printer
{
    private readonly string _name; // Store the printer name

    public Printer(string name)
    {
        _name = name; // Assign the printer name
    }

    public void Print(string message)
    {
        Console.WriteLine($"{_name}: {message}"); // Display the message
    }
}



// Delegate declarations

public delegate void MessageHandler(string message); // Declare a void delegate

public delegate int Calculation(int first, int second); // Declare a returning delegate

public delegate void RefEditor(ref int value); // Declare a delegate with ref

public delegate void OutFactory(out int value); // Declare a delegate with out

public delegate int InReader(in int value); // Declare a delegate with in

public delegate ref int RefSelector(int index); // Declare a delegate with ref return

public delegate void OptionalReporter(string message = "Default message",params int[] codes); // Declare optional and params parameters

public delegate TResult Transformer<in TInput, out TResult>(TInput input); // Declare a variant generic delegate

// Program
internal static class Program
{
    
    private static readonly int[] Values = { 10, 20, 30 }; // Store values for ref return

    private static async Task Main()
    {
        // Method-group, explicit, lambda and anonymous assignments
        Calculation methodGroupDelegate = Add; // Assign a method group
        Calculation explicitDelegate = new Calculation(Multiply); // Explicitly construct a delegate
        Calculation lambdaDelegate = (left, right) => left - right; // Assign a lambda expression
        Calculation anonymousDelegate =
            delegate(int left, int right) // Assign an anonymous method
            {
                return left / right; // Return the division result
            };

        // Delegate invocation
        Console.WriteLine(methodGroupDelegate(10, 5)); // Use call syntax
        Console.WriteLine(explicitDelegate.Invoke(10, 5)); // Use Invoke
        Console.WriteLine(lambdaDelegate(10, 5)); // Invoke the lambda
        Console.WriteLine(anonymousDelegate(10, 5)); // Invoke the anonymous method


        // Nullable delegate and null-safe invocation
        Calculation? nullableDelegate = null; // Declare a nullable delegate
        nullableDelegate?.Invoke(1, 2); // Skip invocation when null
        nullableDelegate = Add; // Assign a method
        int nullableResult = nullableDelegate?.Invoke(4, 5) ?? 0; // Invoke or use fallback
        Console.WriteLine(nullableResult); // Display the result


        // Instance-method delegate
        Printer firstPrinter = new Printer("First printer"); // Create a target object
        Printer secondPrinter =new Printer("Second printer"); // Create another target object
        
        MessageHandler instanceDelegate =firstPrinter.Print; // Reference an instance method
        instanceDelegate("Instance method delegate"); // Invoke the method


        // Multicast delegate

        MessageHandler notifications = ShowFirst; // Add the first method

        notifications += ShowSecond; // Add the second method

        notifications += firstPrinter.Print; // Add an instance method

        notifications("Multicast invocation"); // Invoke all methods in order


        // Invocation-list inspection

        Delegate[] invocationList =
            notifications.GetInvocationList(); // Get registered delegates

        foreach (Delegate handler in invocationList)
        {
            string target =
                handler.Target?.GetType().Name
                ?? "Static method"; // Get the target description

            Console.WriteLine(
                $"{handler.Method.Name} -> {target}"); // Display method details
        }


        // Removing a multicast method

        notifications -= ShowSecond; // Remove the second method

        notifications("After removal"); // Invoke the remaining methods


        // Delegate.Combine and Delegate.Remove

        MessageHandler firstHandler = ShowFirst; // Store the first delegate

        MessageHandler secondHandler = ShowSecond; // Store the second delegate

        MessageHandler combinedHandler =
            (MessageHandler)Delegate.Combine(
                firstHandler,
                secondHandler); // Combine delegates

        Console.WriteLine(
            combinedHandler.GetInvocationList().Length); // Display count

        MessageHandler? reducedHandler =
            (MessageHandler?)Delegate.Remove(
                combinedHandler,
                secondHandler); // Remove one delegate

        reducedHandler?.Invoke("Delegate.Remove result"); // Invoke the result


        // Returning multicast delegate

        Calculation resultHandlers = Add; // Add the first returning method

        resultHandlers += Multiply; // Add the second returning method

        int finalResult =
            resultHandlers(4, 5); // Receive the last method's result

        Console.WriteLine(
            $"Final multicast result: {finalResult}"); // Display the result


        // Delegate equality

        Calculation firstAdd = Add; // Reference Add

        Calculation secondAdd = Add; // Reference the same method

        Calculation multiply = Multiply; // Reference another method

        Console.WriteLine(firstAdd == secondAdd); // Compare equal delegates

        Console.WriteLine(firstAdd != multiply); // Compare different delegates

        MessageHandler firstInstanceA =
            firstPrinter.Print; // Same target and method

        MessageHandler firstInstanceB =
            firstPrinter.Print; // Same target and method

        MessageHandler secondInstance =
            secondPrinter.Print; // Different target

        Console.WriteLine(
            firstInstanceA == firstInstanceB); // Display true

        Console.WriteLine(
            firstInstanceA == secondInstance); // Display false


        // Method and target inspection

        Console.WriteLine(
            $"Method: {firstAdd.Method.Name}"); // Display method information

        Console.WriteLine(
            $"Target: {firstAdd.Target ?? "null for static method"}"); // Display static target

        Console.WriteLine(
            $"Instance target: {firstInstanceA.Target?.GetType().Name}"); // Display instance target


        // DynamicInvoke

        object? dynamicResult =
            firstAdd.DynamicInvoke(7, 8); // Invoke with runtime arguments

        Console.WriteLine(
            $"DynamicInvoke: {dynamicResult}"); // Display the result


        // Built-in Action delegate

        Action<string> log =
            Console.WriteLine; // Store a void method

        log("Action delegate"); // Invoke Action


        // Built-in Func delegate

        Func<int, int, int> sum =
            Add; // Store a returning method

        Console.WriteLine(sum(3, 6)); // Invoke Func


        // Built-in Predicate delegate

        Predicate<int> isPositive =
            value => value > 0; // Return a Boolean value

        Console.WriteLine(isPositive(10)); // Invoke Predicate


        // Built-in Comparison delegate

        Comparison<string> compareLength =
            (left, right) =>
                left.Length.CompareTo(
                    right.Length); // Compare two strings

        string[] words = { "three", "a", "twelve" }; // Create values

        Array.Sort(words, compareLength); // Pass the delegate

        Console.WriteLine(
            string.Join(", ", words)); // Display sorted values


        // Built-in Converter delegate

        Converter<string, int> textLength =
            text => text.Length; // Convert text to its length

        Console.WriteLine(
            textLength("Delegate")); // Invoke Converter


        // Predicate passed to another method

        int[] numbers = { -5, -1, 0, 8, 10 }; // Create values

        int positiveNumber =
            Array.Find(numbers, isPositive); // Find a matching value

        Console.WriteLine(positiveNumber); // Display the result


        // Delegate passed as a method argument

        int appliedResult =
            Apply(6, 7, Multiply); // Pass a delegate as an argument

        Console.WriteLine(appliedResult); // Display the result


        // Delegate returned from a method

        Calculation selectedOperation =
            SelectOperation(
                useAddition: true); // Receive a delegate

        Console.WriteLine(
            selectedOperation(2, 3)); // Invoke the returned delegate


        // Delegate with ref parameter

        RefEditor editor =
            DoubleValue; // Assign a ref-compatible method

        int editableValue = 10; // Initialize the variable

        editor(ref editableValue); // Modify the original variable

        Console.WriteLine(editableValue); // Display the modified value


        // Delegate with out parameter

        OutFactory factory =
            CreateValue; // Assign an out-compatible method

        factory(out int createdValue); // Create an output variable

        Console.WriteLine(createdValue); // Display the assigned value


        // Delegate with in parameter

        InReader reader =
            ReadValue; // Assign an in-compatible method

        int readableValue = 30; // Initialize the variable

        Console.WriteLine(
            reader(in readableValue)); // Pass a readonly reference


        // Delegate with ref return

        RefSelector selector =
            SelectValue; // Assign a ref-returning method

        ref int selectedValue =
            ref selector(1); // Receive a reference alias

        selectedValue = 200; // Modify the original element

        Console.WriteLine(Values[1]); // Display the modified element


        // Optional and params parameters

        OptionalReporter reporter =
            Report; // Assign the reporting method

        reporter(); // Use the default message

        reporter(
            "Warning",
            101,
            102,
            103); // Pass multiple params values

        reporter(
            message: "Named arguments",
            codes: new[] { 201, 202 }); // Use named arguments


        // Capturing lambda

        int capturedFactor = 3; // Declare a captured variable

        Func<int, int> capturingLambda =
            value => value * capturedFactor; // Capture the variable

        capturedFactor = 4; // Change the captured variable

        Console.WriteLine(
            capturingLambda(5)); // Use the latest captured value


        // Static lambda

        Func<int, int> staticLambda =
            static value => value * 2; // Prevent variable capture

        Console.WriteLine(staticLambda(5)); // Invoke the static lambda


        // Anonymous method without parameter list

        Action<int, double> ignoredParameters =
            delegate
            {
                Console.WriteLine(
                    "Parameters were intentionally ignored."); // Ignore parameters
            };

        ignoredParameters(10, 2.5); // Supply required arguments


        // Local-function delegate

        int AddOffset(int value)
        {
            return value + 10; // Return the adjusted value
        }

        Func<int, int> localFunctionDelegate =
            AddOffset; // Reference the local function

        Console.WriteLine(
            localFunctionDelegate(5)); // Invoke the local function


        // Covariant return compatibility

        Func<Animal> covariantMethodDelegate =
            CreateDog; // Method returns a more-derived type

        Animal createdAnimal =
            covariantMethodDelegate(); // Receive it as the base type

        Console.WriteLine(createdAnimal); // Display the result


        // Contravariant parameter compatibility

        Action<Dog> contravariantMethodDelegate =
            PrintAnimal; // Method accepts a less-derived type

        contravariantMethodDelegate(
            new Dog("Rocky")); // Supply a derived object


        // Generic delegate variance

        Transformer<object, Dog> objectToDog =
            ConvertToDog; // Accept object and return Dog

        Transformer<string, Animal> stringToAnimal =
            objectToDog; // Apply input and output variance

        Animal convertedAnimal =
            stringToAnimal("Bruno"); // Invoke the converted delegate

        Console.WriteLine(convertedAnimal); // Display the result


        // Asynchronous delegate

        Func<int, Task<int>> asynchronousDelegate =
            DoubleAsync; // Reference an asynchronous method

        int asynchronousResult =
            await asynchronousDelegate(25); // Await delegate invocation

        Console.WriteLine(asynchronousResult); // Display the result
    }


    // Calculation target methods

    private static int Add(int first, int second)
    {
        return first + second; // Return the sum
    }

    private static int Multiply(int first, int second)
    {
        return first * second; // Return the product
    }


    // Message target methods

    private static void ShowFirst(string message)
    {
        Console.WriteLine($"First: {message}"); // Display the first message
    }

    private static void ShowSecond(string message)
    {
        Console.WriteLine($"Second: {message}"); // Display the second message
    }


    // Method accepting a delegate

    private static int Apply(
        int first,
        int second,
        Calculation operation)
    {
        return operation(first, second); // Invoke the supplied delegate
    }


    // Method returning a delegate

    private static Calculation SelectOperation(bool useAddition)
    {
        return useAddition
            ? Add
            : Multiply; // Return the selected method
    }


    // ref, out and in target methods

    private static void DoubleValue(ref int value)
    {
        value *= 2; // Modify the original variable
    }

    private static void CreateValue(out int value)
    {
        value = 100; // Assign the output variable
    }

    private static int ReadValue(in int value)
    {
        return value; // Read the input value
    }


    // Ref-returning target method

    private static ref int SelectValue(int index)
    {
        return ref Values[index]; // Return an element by reference
    }


    // Optional and params target method

    private static void Report(
        string message,
        params int[] codes)
    {
        Console.WriteLine(
            $"{message}: [{string.Join(", ", codes)}]"); // Display the report
    }


    // Variance target methods

    private static Dog CreateDog()
    {
        return new Dog("Max"); // Return a derived object
    }

    private static void PrintAnimal(Animal animal)
    {
        Console.WriteLine(animal); // Accept and display a base object
    }

    private static Dog ConvertToDog(object value)
    {
        return new Dog(
            value.ToString() ?? "Dog"); // Convert the object to Dog
    }


    // Asynchronous target method

    private static async Task<int> DoubleAsync(int value)
    {
        await Task.Delay(10); // Perform asynchronous work

        return value * 2; // Return the result
    }
}