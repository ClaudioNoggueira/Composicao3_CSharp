using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    class Order {
        public DateTime Moment { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() {

        }

        public Order(DateTime moment, Client client, OrderStatus status) {
            Moment = moment;
            Client = client;
            Status = status;
        }

        public void AddItem(OrderItem ordemItem) {
            Items.Add(ordemItem);
        }

        public void RemoveItem(OrderItem orderItem) {
            Items.Remove(orderItem);
        }

        public double Total() {
            double total = 0;
            foreach (OrderItem item in Items) {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY");
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status.ToString());
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items) {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: R$ " + Total().ToString("F2"));
            return sb.ToString();
        }



    }
    /*
     * 
            Order order = new Order {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            string txt = OrderStatus.PendingPayment.ToString();

            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");

            Console.WriteLine(txt);
            Console.WriteLine(os);
     */


}
