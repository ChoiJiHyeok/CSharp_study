using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace CSharpStudy
{
    public class Product
    {
        public string name { get; set; }

        public string category { get; set; } = "Food";

        public int orderIndex { get; set; } = 0;
        public int price { get; set; }
        public int inventoryCount { get; set;}

        
        public BindingSource bindingDataSource => bindingSource;

        private readonly BindingSource bindingSource = new BindingSource();

        public List<Product> productInfomations => products;

        private readonly List<Product> products = new List<Product>();

        private ConcurrentDictionary<Product, DataTable> productDic = new ConcurrentDictionary<Product, DataTable>();///
        

        public bool TryAdd(string categoryName, string productName)
        {
            Product product = new Product()
            {
                orderIndex = products.Count,
                name = productName,
                category = categoryName
            };
            bindingSource.Add(product);
            return true;
        }
    }
}
