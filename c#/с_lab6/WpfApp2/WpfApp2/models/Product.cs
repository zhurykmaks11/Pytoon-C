using System;
using System.Collections;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }

        public Product(string name, double price, double size)
        {
            Name = name;
            Price = price;
            Size = size;
        }

        // Реалізація IComparable - сортування за ціною
        public int CompareTo(Product other)
        {
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Name}: {Price} грн, {Size} см³";
        }
    }

    // Реалізація IEnumerable для колекції товарів
    public class ProductCollection : IEnumerable<Product>
    {
        private List<Product> products = new List<Product>();

        public void Add(Product product)
        {
            products.Add(product);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}