using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.SharedObjects.Models
{
    public class ProductOptions
    {
        public IList<ProductOption> Items { get; private set; }

        public ProductOptions()
        {

        }

        public ProductOptions(IList<ProductOption> items)
        {
            Items = items;
        }
    }
}
