using Microsoft.EntityFrameworkCore;

namespace TIC.Data
{
    public abstract class DataContextBase
    {
        protected DataContextBase()
        {
        }

        public DbSet<QueryHistory> QueryHistory { get; set; }

    }
}