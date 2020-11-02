using Model;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ViewModels
{
    public class OrdersViewModel
    {
        Repository repository = new Repository();
        Customers Customer { get; set; }
        public ObservableCollection<Orders> AllOrders { get; set; }

        public OrdersViewModel(Customers customer)
        {
            Customer = customer;
            PopulateOrders();
        }

        public void PopulateOrders()
        {
            AllOrders = new ObservableCollection<Orders>(repository.GetOrdersByCustomer(Customer.CustomerId));
        }
    }
}
