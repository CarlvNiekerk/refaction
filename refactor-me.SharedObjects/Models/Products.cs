using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.SharedObjects.Models
{
    public class Products
    {
        public IList<Product> Items { get; private set; }

        public Products(IList<Product> items)
        {
            Items = items;
        }

        public Products(Product product)
        {
            Items = new List<Product> { product };
        }
    }
}
