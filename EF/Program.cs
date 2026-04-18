using EF_task.Data;
using EF_task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EF_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //add data to product table
            //add data to order table
            ApplicationDBContext dBContext = new ApplicationDBContext();
            Product product1 = new Product() { Name = "Laptop", Description = "Gaming Laptop", Price = 1200 };
            Product product2 = new Product { Name = "iPhone 15", Description = "Apple Smartphone 128GB", Price = 999.99 };
            Order order1 = new Order { Address = "Nablus", CreatedAt = DateTime.Now };
            Order order2 = new Order { Address = "Jericho", CreatedAt = new DateTime(2026, 04, 15) };
            Order order3 = new Order { Address = "Ramallah", CreatedAt = DateTime.Now.AddDays(-2) };
            //dBContext.Products.Add(product1);
            //dBContext.Products.Add(product2);
            //dBContext.Orders.Add(order1);
            //dBContext.Orders.Add(order2);
            //dBContext.Orders.Add(order3);
            dBContext.Products.AddRange(new List<Product> {product1, product2 });

            dBContext.Orders.AddRange(new List<Order> { order1, order2, order3 });
            dBContext.SaveChanges();

            //get all products
            var products = dBContext.Products.ToList();
            foreach (var p in products)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Description: {p.Description}, Price: {p.Price}");
            }
            //get all orders
            var orders = dBContext.Orders.ToList();
            foreach (var o in orders)
            {
                Console.WriteLine($"Id: {o.Id}, Address: {o.Address}, CreatedAt: {o.CreatedAt}");
            }

            //update product name
            product1.Name = "Gaming Laptop";
            //update order created at
            order1.CreatedAt = new DateTime(2026, 05, 10);

            dBContext.SaveChanges();

            //remove product with id 2

            dBContext.Products.Remove(product2);
            //remove order with id 3
            dBContext.Orders.Remove(order3);

            dBContext.SaveChanges();
        }
    }
}
