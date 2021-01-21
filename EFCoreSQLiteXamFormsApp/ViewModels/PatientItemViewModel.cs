using System;
using EFCoreSQLiteXamFormsApp.Models;

namespace EFCoreSQLiteXamFormsApp.ViewModels
{
    public class PatientItemViewModel: BaseViewModel
    {
        public PatientItemViewModel(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            PatientId = patient.PatientId;
        }

        public int Id { get; set; }

        string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string PatientId { get; set; }
    }
}
