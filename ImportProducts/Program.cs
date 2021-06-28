using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ImportProducts
{
    public class Program
    {

        public static void Main(string[] args)
        {
            ProcessArguments(args);

            Console.WriteLine("Program exiting...");
            Console.WriteLine(System.AppContext.BaseDirectory);
        }

        static void ProcessArguments(string[] args)
        {
            SoftwareProduct softwareProduct = null;
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid Arguments");
            }
            else
            {
                var command = args[0];
                switch (command)
                {
                    case "capterra":
                    case "softwareadvice":
                        if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                        {
                            Console.WriteLine($"importing {command} products...");
                            string path = args[1];
                            softwareProduct = FileService.LoadFromFile(path);
                        }
                        break;
                    //case "getapp":
                    //    if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                    //    {
                    //        Console.WriteLine($"importing {command} products...");
                    //        string urlPath = args[1];
                    //        LoadFromURL(urlPath);
                    //    }
                    //    break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

                if(softwareProduct != null)
                {
                    DBService.Save(softwareProduct);
                }
            }
        }
    }
}
