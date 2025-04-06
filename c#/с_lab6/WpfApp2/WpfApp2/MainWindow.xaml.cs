using System.Collections.Generic;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private ProductCollection products = new ProductCollection();

        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
            DisplayProducts();
        }

        private void LoadProducts()
        {
            products.Add(new Product("Ноутбук", 25000, 1500));
            products.Add(new Product("Смартфон", 15000, 300));
            products.Add(new Product("Телевізор", 30000, 10000));
            products.Add(new Product("Планшет", 18000, 600));
            products.Add(new Product("Планшет", 2000, 450));
        }

        private void DisplayProducts()
        {
            ProductList.Items.Clear();
            foreach (var product in products)
            {
                ProductList.Items.Add(product);
            }
        }

        private void SortByPrice(object sender, RoutedEventArgs e)
        {
            List<Product> sortedList = new List<Product>(products);
            sortedList.Sort();
            ProductList.Items.Clear();
            foreach (var product in sortedList)
            {
                ProductList.Items.Add(product);
            }
        }

        private void SortBySize(object sender, RoutedEventArgs e)
        {
            List<Product> sortedList = new List<Product>(products);
            sortedList.Sort(new ProductComparer("Size"));
            ProductList.Items.Clear();
            foreach (var product in sortedList)
            {
                ProductList.Items.Add(product);
            }
        }
    }
}