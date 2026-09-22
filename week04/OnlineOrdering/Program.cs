/*
 * ============================================================================
 *  ONLINE ORDERING  -  CSE 210  -  Week 04
 * ============================================================================
 *
 *  CORE REQUIREMENTS
 *    - Product: name, product ID, price, quantity, and the total cost of
 *      that line item (price * quantity).
 *    - Address: street, city, state, country; can report whether it is in
 *      the USA and can render itself as a full multi-line address.
 *    - Customer: a name and an Address; asks its Address whether it's in
 *      the USA rather than inspecting the country itself.
 *    - Order: a Customer and a list of Products. Computes the total cost
 *      (every product's cost plus $5 USA / $35 international shipping)
 *      and can render a packing label (product name + ID per item) and a
 *      shipping label (customer name + full address).
 *    - The program builds 2 orders (one USA customer, one international),
 *      each with 3 products, and prints both labels and totals for both.
 *      No user input.
 * ============================================================================
 */

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA customer
        Address address1 = new Address("123 Main Street", "Provo", "Utah", "USA");
        Customer customer1 = new Customer("Kenneth Ighogboja", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L001", 850.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "M002", 25.00, 2));
        order1.AddProduct(new Product("Keyboard", "K003", 45.00, 1));

        // Order 2 - international customer
        Address address2 = new Address("45 Independence Avenue", "Accra", "Greater Accra", "Ghana");
        Customer customer2 = new Customer("Daniel Mensah", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Smartphone", "S004", 600.00, 1));
        order2.AddProduct(new Product("Phone Case", "C005", 20.00, 2));
        order2.AddProduct(new Product("USB Cable", "U006", 15.00, 3));

        List<Order> orders = new List<Order> { order1, order2 };
        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"ORDER {orderNumber}");
            Console.WriteLine("========================================");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
            Console.WriteLine();

            orderNumber++;
        }
    }
}
