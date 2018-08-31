using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;

namespace TIC.Parser
{
    public class Parser
    {
        public IEnumerable<string> Titles { get; private set; }

        public async Task<IEnumerable<string>> Start()
        {
            var config = Configuration.Default.WithDefaultLoader(); // Setup the configuration to support document loading
            var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes"; // Load the names of all The Big Bang Theory episodes from Wikipedia
            var document = await BrowsingContext.New(config).OpenAsync(address); // Asynchronously get the document in a new context using the configuration
            var cellSelector = "tr.vevent td:nth-child(3)"; // This CSS selector gets the desired content
            var cells = document.QuerySelectorAll(cellSelector); // Perform the query to get all cells with the content
            return cells.Select(m => m.TextContent); // We are only interested in the text - select it with LINQ
        }
    }
}