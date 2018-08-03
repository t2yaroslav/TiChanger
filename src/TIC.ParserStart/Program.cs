﻿using System;
using TIC.ApiClient;

namespace TIC.ParserStart
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello!");
            var parser = new Parser.Parser();
            var list = parser.Start().Result;

            Console.WriteLine("");
            Console.WriteLine("Get list of wiki:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            */
            
            
            Console.WriteLine("REST client!");
            var restClient = new Rest();
            var repo = restClient.Go().Result;

            Console.WriteLine("");
            Console.WriteLine(repo.name);
            Console.ReadKey();
        }
    }
}