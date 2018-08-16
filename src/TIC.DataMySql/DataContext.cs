using System;
using Microsoft.EntityFrameworkCore;

namespace TIC.DataMySql
{
    public class DataContext : DataContextBase
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}