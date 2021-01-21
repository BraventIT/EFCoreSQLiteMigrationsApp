using EFCoreSQLiteXamFormsApp.ViewModels;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.Views
{
    public partial class PatientDetailView : BaseView
    {
        PatientDetailViewModel ViewModel => BindingContext as PatientDetailViewModel;

        public PatientDetailView(int id)
        {
            InitializeComponent();
            BindingContext = new PatientDetailViewModel(id);
            ViewModel.Navigation = Navigation;
        }

        void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if(!ViewModel.IsEditable)
            {
                (sender as ToolbarItem).IconImageSource = "save.png";
                ViewModel.EditPatientDataCommand.Execute(null);
            }
            else
            {
                ViewModel.UpdatePatientDataCommand.Execute(null);
            }
        }
    }
}
