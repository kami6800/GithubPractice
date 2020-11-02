using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels;

namespace GithubPractice
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        Customers Customer { get; set; }
        public OrdersWindow(Customers customer)
        {
            InitializeComponent();
            Customer = customer;
            DataContext = new OrdersViewModel(customer);
        }
    }
}
