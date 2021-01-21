using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using EFCoreSQLiteXamFormsApp.Models;
using EFCoreSQLiteXamFormsApp.Services;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.ViewModels
{
    public class PatientDetailViewModel: BaseViewModel
    {
        protected ILocalDataBaseService<Patient> PatientsService => DependencyService.Get<ILocalDataBaseService<Patient>>();
        protected ILocalDataBaseService<Doctor> DoctorsService => DependencyService.Get<ILocalDataBaseService<Doctor>>(); 

        readonly int id;

        public ICommand DeletePatientCommand { get; private set; }
        public ICommand UpdatePatientDataCommand { get; private set; }
        public ICommand EditPatientDataCommand { get; private set; }

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

        bool _isEditable;
        public bool IsEditable
        {
            get { return _isEditable; }
            set { SetProperty(ref _isEditable, value); }
        }

        public PatientDetailViewModel(int id)
        {
            this.id = id;
            DeletePatientCommand = new Command(async () => await OnDeletePatient());
            UpdatePatientDataCommand = new Command(async () => await OnUpdatePatient());
            EditPatientDataCommand = new Command(OnEditPatientData);
        }

        public override async Task InitAsync()
        {
            await ExecuteAsync(async () =>
            {
                Patient = await PatientsService.GetByIdAsync(id);
                Doctors = new ObservableCollection<Doctor>(await DoctorsService.GetAllAsync());
                DoctorSelected = Patient.Doctor;
            });
        }

        async Task OnDeletePatient()
        {
            await ExecuteAsync(async () =>
            {
                await PatientsService.DeleteAsync(Patient.Id);
                await Navigation.PopAsync();
            });
        }

        async Task OnUpdatePatient()
        {
            await ExecuteAsync(async () =>
            {
                Patient.DoctorId = DoctorSelected.Id;
                await PatientsService.UpdateAsync(Patient);
                await Navigation.PopAsync();
            });
        }

        void OnEditPatientData()
        {
            IsEditable = !IsEditable;
            DoctorSelected = Patient.Doctor;
        }
    }
}
