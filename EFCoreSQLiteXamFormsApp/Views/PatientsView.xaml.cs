using EFCoreSQLiteXamFormsApp.ViewModels;

namespace EFCoreSQLiteXamFormsApp.Views
{
    public partial class PatientsView : BaseView
    {
        PatientsViewModel ViewModel => BindingContext as PatientsViewModel;

        public PatientsView()
        {
            InitializeComponent();
            BindingContext = new PatientsViewModel();
            ViewModel.Navigation = Navigation;
        }

    }
}
