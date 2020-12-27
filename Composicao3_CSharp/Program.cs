using Entities;
using Entities.Enums;
using System;

namespace Composicao3_CSharp {
    class Program {
        static void Main(string[] args) {
            string data = DateTime.Now.ToLongDateString();
            Console.WriteLine(data + "\n\n");

            Console.WriteLine("Enter client data:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("\nEnter order data:");
            DateTime moment = DateTime.Parse(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("\nHow many items to this order? ");
            int itemsQtd = int.Parse(Console.ReadLine());

            Order order = new Order(moment, client, status);

            for (int i = 1; i <= itemsQtd; i++) {
                Console.WriteLine("\nEnter " + i + "º item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int productQtd = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);

                OrderItem orderItem = new OrderItem(productQtd, productPrice, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine("\n" + order);
        }
    }
}
