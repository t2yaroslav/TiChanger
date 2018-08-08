﻿using System;
using System.Net;
using TIC.ApiClient;
using TIC.ApiClient.Model;

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

            var restClient = new Rest();

            var filter = new ExchangersListFilter()
            {
                Filter = new Filter(),
                StartFrom = 0
            };

            var exchangers = restClient.GetExchangerList(filter);
            /*
            Console.WriteLine("REST client!");
            var restClient = new Rest();
            var repo = restClient.Go().Result;
            
            Console.WriteLine("");
            Console.WriteLine(repo.Collection.ItemsCount);
            Console.ReadKey();
            */
        }
    }
}