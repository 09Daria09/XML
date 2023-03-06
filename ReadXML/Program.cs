using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace ReadXML
{
    internal class Program
    {
        public class Order
        {
            public int Id { get; set; }
            public string Customer { get; set; }
            public List<Product> Products { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("C:/Users/Lenovo/source/repos/XML/XML/Order.xml");

            IEnumerable<XElement> orderElements = doc.Descendants("Order");
            List<Order> orders = new List<Order>();

            foreach (XElement orderElement in orderElements)
            {
                Order order = new Order
                {
                    Id = Convert.ToInt32(orderElement.Attribute("Id").Value),
                    Customer = orderElement.Attribute("Customer").Value,
                    Products = new List<Product>()
                };

                IEnumerable<XElement> productElements = orderElement.Descendants("Product");
                foreach (XElement productElement in productElements)
                {
                    Product product = new Product
                    {
                        Id = Convert.ToInt32(productElement.Attribute("Id").Value),
                        Name = productElement.Attribute("Name").Value,
                        Price = Convert.ToDecimal(productElement.Attribute("Price").Value)
                    };

                    order.Products.Add(product);
                }

                orders.Add(order);

            }

            foreach (Order ord in orders)
            {
                Console.WriteLine($"Order {ord.Id} {ord.Customer}:");
                foreach (Product product in ord.Products)
                {
                    Console.WriteLine($"\t{product.Name} - {product.Price} грн");
                }
                Console.WriteLine();
            }
        }
    }
}

