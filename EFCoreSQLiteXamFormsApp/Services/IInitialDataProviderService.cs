using System.Threading.Tasks;

namespace EFCoreSQLiteXamFormsApp.Services
{
    public interface IInitialDataProviderService
    {
        Task AddInitialData();
        string GetPatientId(int length);
    }
}
