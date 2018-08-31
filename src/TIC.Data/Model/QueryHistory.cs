using BBWM.Core.Data;

namespace TIC.Data
{
    public class QueryHistory: Entity
    {
        public string url { get; set; }
        public string body { get; set; }
    }
}