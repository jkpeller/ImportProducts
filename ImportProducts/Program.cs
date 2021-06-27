using System;

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

            var command = args[0];
            switch(command)
            {
                case "capterra":
                    Console.WriteLine("importing capterra products...");
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
            Console.WriteLine("Program exiting...");
        }
    }
}
