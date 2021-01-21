namespace EFCoreSQLiteXamFormsApp.Models
{
    public class Patient: BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string EmailAddress { get; set; }
        public string PatientId { get; set; }

        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
    
}
