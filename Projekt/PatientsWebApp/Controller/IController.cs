namespace Controller
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Model.Models;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        Task GetAllDoctors();

        Task GetPatientId();

        Task GetPatientPesel();

        Task GetBestDoctor();

        Task AddPatient();

        Task DeletePatientId();

        Task DeletePatientPesel();

        Task AddConditionToNewConditionList();

        Task DeleteConditionFromNewConditionList();
    }
}