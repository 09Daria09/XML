using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем список заказов
            List<Order> orders = new List<Order>()
            {
                new Order(1, "Павел", new List<Product>() { new Product(1, "Молоко", 30.0), new Product(2, "Хлеб", 20.0) }),
                new Order(2, "Валентина", new List<Product>() { new Product(3, "Огурцы", 30.0) }),
                new Order(2, "Николай", new List<Product>() { new Product(3, "Помидоры", 60.50) }),
                new Order(1, "Светлана", new List<Product>() { new Product(1, "Конфеты", 68.90), new Product(2, "Сок", 45.0) })
            };

            // Создаем XML-файл и записываем в него информацию о заказах
            XmlTextWriter writer = new XmlTextWriter("../../Order.xml", Encoding.UTF8);
            writer.WriteStartElement("Orders");
            writer.Formatting = Formatting.Indented; //Форматирует отступы в дочерних элементах в соответствии с параметрами настройки IndentChar и Indentation
            writer.IndentChar = '\t'; // Возвращает или задает знак для отступа
            writer.Indentation = 1; // Возвращает или задает количество записываемых IndentChars для каждого уровня в иерархии


            foreach (Order order in orders)
            {
                writer.WriteStartElement("Order");
                writer.WriteAttributeString("Id", order.Id.ToString());
                writer.WriteAttributeString("Customer", order.Customer);

                foreach (Product product in order.Products)
                {
                    writer.WriteStartElement("Product");
                    writer.WriteAttributeString("Id", product.Id.ToString());
                    writer.WriteAttributeString("Name", product.Name);
                    writer.WriteAttributeString("Price", product.Price.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();

            Console.WriteLine("Данные сохранены в XML-файл");
            Console.ReadKey();
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
    class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<Product> Products { get; set; }

        public Order(int id, string customer, List<Product> products)
        {
            Id = id;
            Customer = customer;
            Products = products;
        }
    }
}

