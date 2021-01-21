using System;
using System.IO;
using EFCoreSQLiteXamFormsApp.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace EFCoreSQLiteXamFormsApp.Droid.Services
{
    public class DatabaseService : IDatabaseService
    {
        public string GetDbPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                DbConstants.DB_NAME);
        }
    }
}
