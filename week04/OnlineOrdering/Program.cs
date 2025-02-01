using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Address address1 = new Address("123 Pine Street", "Kingston", "New York", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Product product1 = new Product("Lego Technic Porsche 911 RSR", 42096, 192.00, 1);
        Product product2 = new Product("Lego Technic Peugeot 9X8 24H", 42156, 139.00, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Address address2 = new Address("456 Oak Ave", "Newlands", "Cape Town", "South Africa");
        Customer customer2 = new Customer("Jane Smith", address2);

        Product product3 = new Product("Lego Technic BMW M1000 RR", 42130, 193.00, 2);
        Product product4 = new Product("Lego Technic McLaren P1", 42172, 455.00, 1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1:\n");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("Order 2:\n");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}