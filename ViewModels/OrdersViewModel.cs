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
        public ObservableCollection<Orders> CompletedOrders { get; set; }
        public ObservableCollection<Orders> CurrentOrders { get; set; }
        public ObservableCollection<OrderDetails> OrderDetails { get; set; }
        public Orders SelectedOrder { get; set; }

        public OrdersViewModel(Customers customer)
        {
            Customer = customer;
            PopulateOrders();
        }

        public void PopulateOrders()
        {
            List<Orders> orders = repository.GetCompletedOrdersByCustomer(Customer.CustomerId);
            List<Orders> currentOrders = repository.GetCurrentOrderByCustomer(Customer.CustomerId);

            orders.Sort((a, b) => {
                if (a.RequiredDate != null && b.RequiredDate != null)
                {
                    return DateTime.Compare((DateTime)a.RequiredDate, (DateTime)b.RequiredDate);
                }
                else return 1;
            });
            currentOrders.Sort((a, b) => {
                if (a.RequiredDate != null && b.RequiredDate != null)
                {
                    return DateTime.Compare((DateTime)a.RequiredDate, (DateTime)b.RequiredDate);
                }
                else return 1;
            });

            CompletedOrders = new ObservableCollection<Orders>(orders);
            CurrentOrders = new ObservableCollection<Orders>(currentOrders);
        }
    }
}
