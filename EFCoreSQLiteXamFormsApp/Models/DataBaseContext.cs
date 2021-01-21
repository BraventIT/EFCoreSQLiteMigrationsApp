using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.Models
{
    public class DataBaseContext: DbContext, IDbContext
    {
        private IDatabaseService DataBaseService => DependencyService.Get<IDatabaseService>();
        private string _dbPathMigrations;

        public DataBaseContext()
        {
        }

        public DataBaseContext(string dbPath)
        {
            _dbPathMigrations = dbPath;
        }

        DataBaseContext _dbContext;
        DataBaseContext IDbContext.DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DataBaseContext();
                    _dbContext.Database.MigrateAsync();
                }
                return _dbContext;
            }
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = string.IsNullOrWhiteSpace(_dbPathMigrations)
                ? DataBaseService.GetDbPath()
                : _dbPathMigrations;
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
