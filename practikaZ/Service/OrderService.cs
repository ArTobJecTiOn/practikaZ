using Microsoft.EntityFrameworkCore;
using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class OrderService
    {
        public static void CreateOrder(int userId, int quantity, string description)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now),
                    OrderStatus = "На рассмотрении",
                    Quantity = quantity,
                    Description = description
                };

                context.Orders.Add(order);
                context.SaveChanges();


            }
        }
        public static List<Order> GetOrders(int userID)
        {
            using (MyDbContext context = new MyDbContext())
            {
                return context.Orders
                    .Where(o => o.UserId == userID)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            }
        }
        public static List<Order> GetAllOrders()
        {
            using (var context = new MyDbContext())
            {
                return context.Orders
                    .Include(o => o.User)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            }
        }
        public static void UpdateOrderStatus(int orderId, string newStatus)
        {
            using (var context = new MyDbContext())
            {
                var order = context.Orders.Find(orderId);
                if (order != null)
                {
                    order.OrderStatus = newStatus;
                    context.SaveChanges();
                }
            }
        }
    }
}
