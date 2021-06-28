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
                return;
            }
            else
            {
                var command = args[0];
                switch (command)
                {
                    case "capterra":
                    case "softwareadvice":
                        if(args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                        {
                            Console.WriteLine($"importing {command} products...");
                            string path = args[1];
                            LoadFromFile(path);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }

            Console.WriteLine("Program exiting...");
            Console.WriteLine(System.AppContext.BaseDirectory);
        }

        static void LoadFromFile(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath);
            string strContents = reader.ReadToEnd();

            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".yaml":
                case ".yml":
                    ReadYAML(strContents);
                    break;
                case ".json":
                    ReadJSON(strContents);
                    break;
                default:
                    Console.WriteLine("Unrecognized filetype");
                    break;
            }
        }

        static void ReadJSON(string contents)
        {
            Console.WriteLine(contents);
            SoftwareProductJson softwareProducts = JsonConvert.DeserializeObject<SoftwareProductJson>(contents);
            if(softwareProducts != null && softwareProducts.Products.Length > 0)
            {
                Console.WriteLine(softwareProducts.Products[0].Title);
            }
        }

        static void ReadYAML(string contents)
        {
            Console.WriteLine(contents);
            var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            List<SoftwareProductsYaml> yamlList = deserializer.Deserialize<List<SoftwareProductsYaml>>(contents);
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
