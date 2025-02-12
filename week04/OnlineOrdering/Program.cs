using System;

class Program
{
    static void Main()
    {

        Customer customer = new Customer("Inocente Perez", "123 Main St, New York, NY");


        Order order = new Order(customer);


        order.AddProduct(new Product("Laptop", 850.99, 1));
        order.AddProduct(new Product("Mouse", 25.50, 2));
        order.AddProduct(new Product("Keyboard", 45.75, 1));


        order.ShowOrderDetails();
    }
}