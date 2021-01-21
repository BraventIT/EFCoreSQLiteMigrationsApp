using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreSQLiteXamFormsApp.Models;
using Xamarin.Forms;

namespace EFCoreSQLiteXamFormsApp.Services
{
    public class InitialDataProviderService: IInitialDataProviderService
    {
        protected ILocalDataBaseService<Patient> PatientsService => DependencyService.Get<ILocalDataBaseService<Patient>>();
        protected ILocalDataBaseService<Doctor> DoctorsService => DependencyService.Get<ILocalDataBaseService<Doctor>>();

        public async Task AddInitialData()
        {
            var pacients = await PatientsService.GetAllAsync();
            if (pacients != null && pacients.Count > 0) return;

            var doctor1 = new Doctor { CompleteName = "Jesús Vicente Civit" };
            doctor1 = await DoctorsService.AddAsync(doctor1);

            var doctor2 = new Doctor { CompleteName = "Sonia Esther Solano" };
            doctor2 = await DoctorsService.AddAsync(doctor2);

            var doctor3 = new Doctor { CompleteName = "Eduardo Andrés Alcalde" };
            doctor3 = await DoctorsService.AddAsync(doctor3);

            List<Patient> patientsToAdd = new List<Patient>();
            patientsToAdd.Add(new Patient() { PatientId = GetPatientId(10), Name = "Manuel", Surname = "Raul Madrona", Age = 22, DoctorId = doctor1.Id, });
            patientsToAdd.Add(new Patient() { PatientId = GetPatientId(10), Name = "Susana", Surname= "Vidal Lobato", Age = 57, DoctorId = doctor1.Id, });
            patientsToAdd.Add(new Patient() { PatientId = GetPatientId(10), Name = "Juana", Surname= "SantaCruz Sánchez", Age = 65, DoctorId = doctor2.Id, });
            patientsToAdd.Add(new Patient() { PatientId = GetPatientId(10), Name = "Laura", Surname= "Galisteo Dios", Age = 75, DoctorId = doctor2.Id, });
            patientsToAdd.Add(new Patient() { PatientId = GetPatientId(10), Name = "Ivan", Surname= "Benito Rioja", Age = 17, DoctorId = doctor3.Id, });
            patientsToAdd.Add(new Patient() { PatientId = GetPatientId(10), Name = "María Rosa", Surname= "Cobo Pedreira", Age = 38, DoctorId = doctor3.Id, });

            await PatientsService.AddRangeAsync(patientsToAdd);
        }

        private static readonly Random random = new Random();
        public string GetPatientId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    
}
