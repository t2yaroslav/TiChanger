using System;
using System.Collections.Generic;
using System.Net;
using TIC.ApiClient;
using TIC.ApiClient.Model;

namespace TIC.ParserStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var restClient = new ApiClient.ApiClient();

            var filter = new ExchangersListFilter()
            {
                startFrom = 0
            };

            var exchangers = restClient.GetExchangerList(filter);

            filter.startFrom = 20;

            var exchangers2 = restClient.GetExchangerList(filter);
        }
    }
}