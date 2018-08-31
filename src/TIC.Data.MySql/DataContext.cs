using Microsoft.EntityFrameworkCore;

namespace TIC.Data.MySql
{
    // for migrations:
    // from bbwt.web project: 
    // create - dotnet ef migrations add <MigrationName> -p ../bbwt.data.mysql -s ./ -c DataContext
    // update - dotnet ef database update -p ../bbwt.data.mysql -s ./ -c DataContext

    // migration rollback
    // revert - dotnet ef database update <PreviousMigrationName> -p ../bbwt.data.mysql -s ./ -c DataContext
    // remove - dotnet ef migrations remove -p ../bbwt.data.mysql -s ./ -c DataContext

    public interface IDataContext
    {
    }

    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}