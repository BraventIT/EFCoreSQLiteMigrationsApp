using System;
using System.IO;
using EFCoreSQLiteXamFormsApp.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace EFCoreSQLiteXamFormsApp.iOS.Services
{
    public class DatabaseService: IDatabaseService
    {
        public string GetDbPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                DbConstants.DB_NAME);
        }
    }
}
