using System.Security.Cryptography;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: if not size is given to the queue then it is set to 10 automatlically 
        // Expected Result:  the newCs will have a maximun of 10 in capacity
        Console.WriteLine("Test 1");
        var newCs = new CustomerService(-1);

        // Defect(s) Found: no defects found because it will automatically set the max queue to 10 

        Console.WriteLine("=================");

        // Test 2 
        // Scenario: adding more customers that the zise of the queue 
        // Expected Result: a message isdisplayed that shows an alert that not more customers cna be added 
        Console.WriteLine("Test 2");
        newCs = new CustomerService(3);
        newCs.AddNewCustomer();
        newCs.AddNewCustomer();
        newCs.AddNewCustomer();
        newCs.AddNewCustomer();

        // Defect(s) Found: by adding the last customer an error mesage will be displayed

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Expected Result: append a list of ccustomers should be retuned in the order intorduced 
        // Scenario: adding 4 customer should returnd fom the first to the last 
        Console.WriteLine("Test 2");   
        newCs = new CustomerService(4);
        newCs.AddNewCustomer();        
        newCs.AddNewCustomer();        
        newCs.AddNewCustomer();                
        newCs.AddNewCustomer();  
        Console.WriteLine(newCs._queue);

        // Defect(s) Found:       

    }    
    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {

        if (_queue.Count == 0)
        {
            Console.WriteLine("There is not customer in the list to serve");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}