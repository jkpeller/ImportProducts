using System;
using System.Collections.Generic;

namespace ImportProducts
{
    public class SoftwareProduct
    {
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string[] Categories { get; set; }

        public string Twitter { get; set; }

        public string Name { get; set; }
    }
}
