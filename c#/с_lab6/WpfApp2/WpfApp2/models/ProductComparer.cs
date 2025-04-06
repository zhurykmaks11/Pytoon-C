using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public class ProductComparer : IComparer<Product>
    {
        private string _criteria;

        public ProductComparer(string criteria)
        {
            _criteria = criteria;
        }

        public int Compare(Product x, Product y)
        {
            if (_criteria == "Price")
                return x.Price.CompareTo(y.Price);
            if (_criteria == "Size")
                return x.Size.CompareTo(y.Size);
            return 0;
        }
    }
}