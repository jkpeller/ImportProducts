using System;

namespace ImportProducts
{
    public static class DBService
    {
        public static bool Save(SoftwareProduct softwareProduct)
        {
            if(softwareProduct.Products.Count > 0)
            {
                foreach(Product p in softwareProduct.Products)
                {
                    Import(p);
                }
                return true;
            }
            return false;
        }

        private static void Import(Product p)
        {
            Console.WriteLine($"Importing: Name: {p.Name}; Categories: {string.Join(',', p.Categories)}; Twitter: {p.Twitter}");
        }
    }
}