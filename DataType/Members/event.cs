#nullable enable

/*
Event declaration:

public event EventHandler? EventName;
public event EventHandler<CustomEventArgs>? EventName;
public event CustomDelegate? EventName;
public static event EventHandler? EventName;

Interface event:

event EventHandler? EventName;

Custom event accessors:

public event EventHandler EventName
{
    add { backingDelegate += value; }
    remove { backingDelegate -= value; }
}

Subscription:
publisher.EventName += HandlerMethod;

Unsubscription:
publisher.EventName -= HandlerMethod;

Publishing:
EventName?.Invoke(this, EventArgs.Empty);
EventName?.Invoke(this, new CustomEventArgs(...));

The publisher declares and raises the event.
Subscribers attach compatible event-handler methods.
An event can have multiple subscribers.
Handlers are called synchronously in subscription order.
Outside the declaring type, an event can normally be used only with += and -=.
Only the declaring type can directly invoke or assign its event.
Store a lambda in a variable when it must later be unsubscribed.
The standard event pattern uses object? sender and EventArgs.
*/


using System;


namespace EventDemonstration;


// Custom event arguments

public sealed class OrderEventArgs : EventArgs
{
    public int OrderId { get; } // Store the order ID

    public decimal Amount { get; } // Store the order amount

    public OrderEventArgs(int orderId, decimal amount)
    {
        OrderId = orderId; // Assign the order ID

        Amount = amount; // Assign the order amount
    }
}


// Custom event delegate

public delegate void ProgressChangedHandler(int percentage); // Define a custom event-handler signature


// Interface event

public interface IOrderPublisher
{
    event EventHandler<OrderEventArgs>? OrderPlaced; // Declare an event contract
}


// Event publisher

public class OrderService : IOrderPublisher
{
    public event EventHandler? Started; // Declare an event without custom data

    public event EventHandler<OrderEventArgs>? OrderPlaced; // Declare an event with custom data

    public event ProgressChangedHandler? ProgressChanged; // Declare an event using a custom delegate


    // Custom event accessors

    private EventHandler? _completedHandlers; // Store handlers manually

    public event EventHandler Completed
    {
        add
        {
            _completedHandlers += value; // Add the subscribing handler

            Console.WriteLine("Completed handler subscribed."); // Show the add accessor
        }

        remove
        {
            _completedHandlers -= value; // Remove the subscribing handler

            Console.WriteLine("Completed handler unsubscribed."); // Show the remove accessor
        }
    }


    // Publishing methods

    protected virtual void OnStarted()
    {
        Started?.Invoke(this, EventArgs.Empty); // Raise the event safely
    }

    protected virtual void OnProgressChanged(int percentage)
    {
        ProgressChanged?.Invoke(percentage); // Raise the custom delegate event
    }

    protected virtual void OnOrderPlaced(OrderEventArgs arguments)
    {
        OrderPlaced?.Invoke(this, arguments); // Raise the event with custom arguments
    }

    protected virtual void OnCompleted()
    {
        _completedHandlers?.Invoke(this, EventArgs.Empty); // Invoke the backing delegate
    }


    // Publisher operation

    public void PlaceOrder(int orderId, decimal amount)
    {
        OnStarted(); // Publish the Started event

        OnProgressChanged(25); // Publish progress information

        OnProgressChanged(75); // Publish updated progress information

        OnOrderPlaced(new OrderEventArgs(orderId, amount)); // Publish order information

        OnProgressChanged(100); // Publish completion progress

        OnCompleted(); // Publish the Completed event
    }
}


// Program and subscribers

internal static class Program
{
    public static event EventHandler? ApplicationEnded; // Declare a static event

    private static void Main()
    {
        OrderService service = new OrderService(); // Create the publisher


        // Method subscriptions

        service.Started += HandleStarted; // Subscribe a method

        service.OrderPlaced += HandleOrderPlaced; // Subscribe the first order handler

        service.OrderPlaced += AuditOrder; // Subscribe another handler to the same event

        service.ProgressChanged += ShowProgress; // Subscribe to the custom delegate event


        // Lambda subscription

        EventHandler<OrderEventArgs> messageHandler =
            (sender, arguments) =>
                Console.WriteLine(
                    $"Lambda handler: order {arguments.OrderId} received."); // Store a removable lambda

        service.OrderPlaced += messageHandler; // Subscribe the lambda


        // Interface event subscription

        IOrderPublisher publisher = service; // Access the publisher through its interface

        EventHandler<OrderEventArgs> interfaceHandler =
            (sender, arguments) =>
                Console.WriteLine(
                    $"Interface handler: amount {arguments.Amount:C}."); // Create an interface handler

        publisher.OrderPlaced += interfaceHandler; // Subscribe through the interface


        // Custom-accessor event subscription

        EventHandler completedHandler = HandleCompleted; // Store the handler

        service.Completed += completedHandler; // Call the custom add accessor


        // Static event subscription

        ApplicationEnded += HandleApplicationEnded; // Subscribe to the static event


        // First event publication

        service.PlaceOrder(101, 2500M); // Cause the publisher to raise its events


        // Event unsubscription

        service.Started -= HandleStarted; // Remove the Started handler

        service.OrderPlaced -= AuditOrder; // Remove one multicast handler

        service.OrderPlaced -= messageHandler; // Remove the stored lambda

        publisher.OrderPlaced -= interfaceHandler; // Remove the interface subscription

        service.ProgressChanged -= ShowProgress; // Remove the progress handler

        service.Completed -= completedHandler; // Call the custom remove accessor


        // Publication after unsubscription

        Console.WriteLine("\nAfter unsubscription:"); // Separate the output

        service.PlaceOrder(102, 5000M); // Only remaining subscribers are notified


        // Static event publication

        OnApplicationEnded(); // Raise the static event

        ApplicationEnded -= HandleApplicationEnded; // Remove the static handler
    }


    // Standard EventHandler

    private static void HandleStarted(object? sender, EventArgs arguments)
    {
        Console.WriteLine("Order processing started."); // Handle the event
    }


    // EventHandler with custom EventArgs

    private static void HandleOrderPlaced(
        object? sender,
        OrderEventArgs arguments)
    {
        Console.WriteLine(
            $"Order {arguments.OrderId}: {arguments.Amount:C}"); // Read event data
    }


    // Second subscriber for the same event

    private static void AuditOrder(
        object? sender,
        OrderEventArgs arguments)
    {
        Console.WriteLine(
            $"Audit entry created for order {arguments.OrderId}."); // Handle the same event
    }


    // Custom delegate handler

    private static void ShowProgress(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%"); // Handle progress information
    }


    // Custom-accessor event handler

    private static void HandleCompleted(object? sender, EventArgs arguments)
    {
        Console.WriteLine("Order processing completed."); // Handle completion
    }


    // Static event publisher method

    private static void OnApplicationEnded()
    {
        ApplicationEnded?.Invoke(null, EventArgs.Empty); // Raise the static event
    }


    // Static event handler

    private static void HandleApplicationEnded(
        object? sender,
        EventArgs arguments)
    {
        Console.WriteLine("Application ended."); // Handle the static event
    }
}