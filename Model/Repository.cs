using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Repository
    {
        NorthwindContext context = new NorthwindContext();
        public Customers GetCustomer (string id)
        {
            return context.Customers.Find(id);
        }

        public List<Orders> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public List<Orders> GetOrdersByCustomer(string customerId)
        {
            return context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
