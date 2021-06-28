using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ImportProducts
{
    class Program
    {

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Invalid Arguments");
                //return;
            }
            else
            {
                var command = args[0];
                switch (command)
                {
                    case "capterra":
                        Console.WriteLine("importing capterra products...");
                        LoadFromYAML("/Users/jpellerin@ibm.com/Documents/software engineer/coding/feed-products/capterra.yaml");
                        break;
                    case "softwareadvice":
                        Console.WriteLine("importing softwareadvice products...");
                        LoadFromJSON("/Users/jpellerin@ibm.com/Documents/software engineer/coding/feed-products/softwareadvice.json");
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }


            Console.WriteLine("Program exiting...");
            Console.WriteLine(System.AppContext.BaseDirectory);
        }

        static void LoadFromJSON(string filename)
        {
            using StreamReader r = new StreamReader(filename);
            string json = r.ReadToEnd();
            Console.WriteLine(json);
            SoftwareProducts softwareProducts = JsonConvert.DeserializeObject<SoftwareProducts>(json);
            if(softwareProducts != null && softwareProducts.Products.Length > 0)
            {
                Console.WriteLine(softwareProducts.Products[0].Title);
            }
        }

        static void LoadFromYAML(string filename)
        {
            using StreamReader r = new StreamReader(filename);
            string yaml = r.ReadToEnd();
            Console.WriteLine(yaml);
            var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            List<SoftwareProductsYaml> yamlList = deserializer.Deserialize<List<SoftwareProductsYaml>>(yaml);
            //SoftwareProducts softwareProducts = JsonConvert.DeserializeObject<SoftwareProducts>(yaml);
            if (yamlList != null && yamlList.Count > 0)
            {
                foreach(SoftwareProductsYaml spy in yamlList)
                {
                    Console.WriteLine(spy.Name);
                }
            }
        }
    }
}
