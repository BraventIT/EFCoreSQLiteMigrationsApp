using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using EFCoreSQLiteXamFormsApp.Models;
using EFCoreSQLiteXamFormsApp.Services;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.ViewModels
{
    public class AddPatientViewModel: BaseViewModel
    {
        protected ILocalDataBaseService<Patient> PatientsService => DependencyService.Get<ILocalDataBaseService<Patient>>();
        protected ILocalDataBaseService<Doctor> DoctorsService => DependencyService.Get<ILocalDataBaseService<Doctor>>(); 
        protected IInitialDataProviderService InitialDataProviderService => DependencyService.Get<IInitialDataProviderService>();

        public ICommand AddNewPatientCommand { get; private set; }

        Patient _patient;
        public Patient Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }

        ObservableCollection<Doctor> _doctors;
        public ObservableCollection<Doctor> Doctors
        {
            get { return _doctors; }
            set { SetProperty(ref _doctors, value); }
        }

        Doctor _doctorSelected;
        public Doctor DoctorSelected
        {
            get { return _doctorSelected; }
            set { SetProperty(ref _doctorSelected, value); }
        }

        public AddPatientViewModel()
        {
            AddNewPatientCommand = new Command(async() => await OnAddNewPatient());
        }

        public override async Task InitAsync()
        {
            await ExecuteAsync(async () =>
            {
                Patient = new Patient();
                Doctors = new ObservableCollection<Doctor>(await DoctorsService.GetAllAsync());
                DoctorSelected = Patient.Doctor;
            });
        }

        async Task OnAddNewPatient()
        {
            await ExecuteAsync(async () =>
            {
                Patient.PatientId = InitialDataProviderService.GetPatientId(10);
                Patient.DoctorId = DoctorSelected.Id;
                await PatientsService.AddAsync(Patient);
                await Navigation.PopAsync();
            });
        }
    }
}
