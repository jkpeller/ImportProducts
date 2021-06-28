using System;
using System.Collections.Generic;
using ImportProducts;
using Xunit;

namespace ImportProductsTests
{
    public class ImportProductsTests
    {
        readonly string resourcesPath = "../../../../ImportProductsTests/Resources";

        [Fact]
        public void Test1()
        {
            Console.WriteLine("Test1");
            Assert.True(true);
        }

        [Fact]
        public void TestFileService_LoadFromFile_InvalidPath()
        {
            Console.WriteLine("Test2");
            SoftwareProduct softwareProduct = FileService.LoadFromFile("");
            Assert.Null(softwareProduct);
        }

        [Fact]
        public void TestFileService_LoadFromFile_ValidYamlPath()
        {
            Console.WriteLine("Test3");
            SoftwareProduct softwareProduct = FileService.LoadFromFile($"{resourcesPath}/capterra.yaml");
            Assert.NotEmpty(softwareProduct.Products);
        }

        [Fact]
        public void TestFileService_LoadFromFile_ValidJsonPath()
        {
            Console.WriteLine("Test4");
            SoftwareProduct softwareProduct = FileService.LoadFromFile($"{resourcesPath}/softwareadvice.json");
            Assert.NotEmpty(softwareProduct.Products);
        }

        [Fact]
        public void TestDBService_Import_ValidProduct()
        {
            Console.WriteLine("Test5");
            SoftwareProduct softwareProduct = new SoftwareProduct
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "ProductName1",
                        Categories = new string[] { "cat1", "cat2" },
                        Twitter = "@twitter"
                    },
                    new Product
                    {
                        Name = "ProductName2",
                        Categories = new string[] { "cat3", "cat4" },
                        Twitter = "@twitter"
                    }
                }
            };

            bool result = DBService.Save(softwareProduct);
            Assert.True(result);
        }
    }
}
