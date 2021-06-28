using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ImportProducts
{
    public static class FileService
    {
        public static SoftwareProduct LoadFromFile(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath);
            string strContents = reader.ReadToEnd();

            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".yaml":
                case ".yml":
                    return ReadYAML(strContents);
                case ".json":
                    return ReadJSON(strContents);
                default:
                    Console.WriteLine("Unrecognized filetype");
                    break;
            }
            return null;
        }

        public static SoftwareProduct ReadJSON(string contents)
        {
            Console.WriteLine(contents);
            SoftwareProductJson softwareProductsJson = JsonConvert.DeserializeObject<SoftwareProductJson>(contents);
            if (softwareProductsJson != null && softwareProductsJson.Products.Length > 0)
            {
                Console.WriteLine(softwareProductsJson.Products[0].Title);
                return ConvertFromJsonFormat(softwareProductsJson);
            }
            return null;
        }

        public static SoftwareProduct ReadYAML(string contents)
        {
            Console.WriteLine(contents);
            var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            List<SoftwareProductsYaml> yamlList = deserializer.Deserialize<List<SoftwareProductsYaml>>(contents);
            if (yamlList != null && yamlList.Count > 0)
            {
                return ConvertFromYamlFormat(yamlList);
            }
            return null;
        }

        private static SoftwareProduct ConvertFromJsonFormat(SoftwareProductJson softwareProductsJson)
        {
            SoftwareProduct softwareProduct = new SoftwareProduct();
            List<Product> products = new List<Product>();
            foreach (ProductJson pj in softwareProductsJson.Products)
            {
                Product product = new Product
                {
                    Name = pj.Title,
                    Categories = pj.Categories,
                    Twitter = pj.Twitter
                };

                products.Add(product);
            }

            softwareProduct.Products = products;
            return softwareProduct;
        }

        private static SoftwareProduct ConvertFromYamlFormat(List<SoftwareProductsYaml> yamlList)
        {
            SoftwareProduct softwareProduct = new SoftwareProduct();
            List<Product> products = new List<Product>();
            foreach (SoftwareProductsYaml spy in yamlList)
            {
                Console.WriteLine(spy.Name);
                Product product = new Product
                {
                    Name = spy.Name,
                    Categories = spy.Tags.Split(','),
                    Twitter = spy.Twitter
                };

                products.Add(product);
            }

            softwareProduct.Products = products;
            return softwareProduct;
        }
    }
}
