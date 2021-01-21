using System.Collections.Generic;

namespace EFCoreSQLiteXamFormsApp.Models
{
    public class Doctor: BaseModel
    {
        public string CompleteName { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
