using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    public static class ProductManager
    {
        public static IReadOnlyList<Product> productList => reports;
        private static readonly List<Product> reports = new List<Product>();

    }

}
