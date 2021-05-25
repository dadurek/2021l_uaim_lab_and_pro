namespace Controller
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Model.Models;
    using Utilities;

    public class Controller : PropertyContainerBase, IController
    {
        public Controller(IEventDispatcher dispatcher, IModel model) :
            base(dispatcher)
        {
            Model = model;

        }

        public IModel Model { get; }

        public async Task GetAllDoctors()
        {
            await Task.Run(() => Model.LoadDoctorList());
        }

        public async Task GetPatientId()
        {
            await Task.Run(() => Model.LoadPatientById());
        }

        public async Task GetPatientPesel()
        {
            await Task.Run(() => Model.LoadPatientByPesel());
        }

        public async Task GetBestDoctor()
        {
            await Task.Run(() => Model.GetBestDoctor());
        }

        public async Task AddPatient()
        {
            await Task.Run(() => Model.AddPatient());
        }

        public async Task DeletePatientId()
        {
            await Task.Run(() => Model.DeletePatientById());
        }

        public async Task DeletePatientPesel()
        {
            await Task.Run(() => Model.DeletePatientByPesel());
        }

        public async Task AddConditionToNewConditionList()
        {
            await Task.Run(() => Model.AddConditionToNewPatient());
        }

        public async Task DeleteConditionFromNewConditionList()
        {
            await Task.Run(() => Model.DeleteConditionFromNewConditionList());
        }
    }
}