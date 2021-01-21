using System.IO;
using EFCoreSQLiteXamFormsApp.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreSQLiteXamFormsApp.Migrations
{
    public class DesignTimeDataBaseContext : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            string database = $"{Directory.GetCurrentDirectory()}\\{DbConstants.DB_NAME}";
            return new DataBaseContext(database);
        }
    }
}
