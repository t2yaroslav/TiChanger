using System;

namespace TIC.ParserStart
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}