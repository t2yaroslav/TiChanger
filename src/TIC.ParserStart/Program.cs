using System;
using System.Net;
using TIC.ApiClient;
using TIC.ApiClient.Model;

namespace TIC.ParserStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new Rest();

            var filter = new ExchangersListFilter()
            {
                Filter = new Filter(),
                StartFrom = 0
            };

            var exchangers = restClient.GetExchangerList(filter);
        }
    }
}