using EFCoreSQLiteXamFormsApp.ViewModels;

namespace EFCoreSQLiteXamFormsApp.Views
{
    public partial class AddPatientView : BaseView
    {
        AddPatientViewModel ViewModel => BindingContext as AddPatientViewModel;

        public AddPatientView()
        {
            InitializeComponent();
            BindingContext = new AddPatientViewModel();
            ViewModel.Navigation = Navigation;
        }
    }
}
