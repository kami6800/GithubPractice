﻿using Model;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels;

namespace GithubPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository = new Repository();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            Customers customer = repository.GetCustomer(username);
            if (customer != null)
            {
                OrdersWindow ordersWindow = new OrdersWindow(customer);
                this.Close();
                ordersWindow.Show();
            }
            else
            {
                ErrorLabel.Content = "User doesn't exist";
            }
        }
    }
}
