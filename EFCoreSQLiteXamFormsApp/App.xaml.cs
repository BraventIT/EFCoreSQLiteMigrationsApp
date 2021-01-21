using EFCoreSQLiteXamFormsApp.Models;
using EFCoreSQLiteXamFormsApp.Services;
using EFCoreSQLiteXamFormsApp.Views;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage( new PatientsView());
            (Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex("#CED345");
            (Current.MainPage as NavigationPage).BarTextColor = Color.White;

            DependencyService.Register<ILocalDataBaseService<Patient>, LocalDataBaseService<Patient>>();
            DependencyService.Register<ILocalDataBaseService<Doctor>, LocalDataBaseService<Doctor>>();
            DependencyService.Register<IInitialDataProviderService, InitialDataProviderService>();
            DependencyService.Register<IDbContext, DataBaseContext>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
