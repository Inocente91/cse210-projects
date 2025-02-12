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


class Product
{
    public string name;
    public double price;
    public int quantity;

    public Product(string name, double price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return price * quantity;
    }
}


class Customer
{
    public string name;
    public string address;

    public Customer(string name, string address)
    {
        this.name = name;
        this.address = address;
    }
}