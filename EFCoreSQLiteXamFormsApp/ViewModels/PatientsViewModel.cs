using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using EFCoreSQLiteXamFormsApp.Models;
using EFCoreSQLiteXamFormsApp.Services;
using EFCoreSQLiteXamFormsApp.Views;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.ViewModels
{
    public class PatientsViewModel: BaseViewModel
    {
        protected ILocalDataBaseService<Patient> PatientsService => DependencyService.Get<ILocalDataBaseService<Patient>>();
        protected ILocalDataBaseService<Doctor> DoctorsService => DependencyService.Get<ILocalDataBaseService<Doctor>>();
        protected IInitialDataProviderService InitialDataProviderService => DependencyService.Get<IInitialDataProviderService>(); 

        public ICommand PatientSelectedCommand { get; private set; }
        public ICommand AddNewPatientCommand { get; private set; }


        ObservableCollection<PatientItemViewModel> _patients;
        public ObservableCollection<PatientItemViewModel> Patients
        {
            get { return _patients; }
            set { SetProperty(ref _patients, value); }
        }

        PatientItemViewModel _patientSelected;
        public PatientItemViewModel PatientSelected
        {
            get { return _patientSelected; }
            set { _ = SetProperty(ref _patientSelected, value); }
        }

        public PatientsViewModel()
        {
            AddNewPatientCommand = new Command(async () => await OnAddNewPatient());
            PatientSelectedCommand = new Command(async () => await OnPatientSelected());
        }

        public override async Task InitAsync()
        {
            await ExecuteAsync(async () =>
            {
                await InitialDataProviderService.AddInitialData();
                await LoadPatients();
            });
        }

        async Task OnPatientSelected()
        {
            await ExecuteAsync(async () =>
            {
                await Navigation.PushAsync(new PatientDetailView(PatientSelected.Id));
            });
        }

        async Task OnAddNewPatient()
        {
            await ExecuteAsync(async () =>
            {
                await Navigation.PushAsync(new AddPatientView());
            });
        }

        async Task LoadPatients()
        {
            var patients = await PatientsService.GetAllAsync();

            Patients = new ObservableCollection<PatientItemViewModel>(patients?.Select(p => new PatientItemViewModel(p)));
        }
    }
}
