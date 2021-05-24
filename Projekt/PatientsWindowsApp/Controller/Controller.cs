namespace Controller
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Model.IModel;
    using Utilities;

    public class Controller : PropertyContainerBase, IController
    {
        public Controller(IEventDispatcher dispatcher, IDoctorModel doctorModel, IPatientModel patientModel) :
            base(dispatcher)
        {
            DoctorModel = doctorModel;

            PatientModel = patientModel;

            ShowHomeCommand = new ControllerCommand(ShowHome);

            ShowDoctorsCommand = new ControllerCommand(ShowDoctors);

            ShowPatientIdCommand = new ControllerCommand(ShowPatientId);

            ShowBestDoctorCommand = new ControllerCommand(ShowBestDoctor);

            ShowAddPatientCommand = new ControllerCommand(ShowAddPatient);

            ShowPatientPeselCommand = new ControllerCommand(ShowPatientPesel);

            ShowDeletePatientIdCommand = new ControllerCommand(ShowDeletePatientId);

            ShowDeletePatientPeselCommand = new ControllerCommand(ShowDeletePatientPesel);

            AddConditionToNewPatientCommand = new ControllerCommand(AddConditionToNewPatient);

            DeleteConditionFromNewConditionListCommand = new ControllerCommand(DeleteConditionFromNewConditionList);
        }

        public IDoctorModel DoctorModel { get; }

        public IPatientModel PatientModel { get; }

        public ICommand ShowHomeCommand { get; }

        public ICommand ShowDoctorsCommand { get; }

        public ICommand ShowBestDoctorCommand { get; }

        public ICommand ShowAddPatientCommand { get; }

        public ICommand ShowPatientIdCommand { get; }

        public ICommand ShowPatientPeselCommand { get; }

        public ICommand ShowDeletePatientIdCommand { get; }

        public ICommand ShowDeletePatientPeselCommand { get; }

        public ICommand AddConditionToNewPatientCommand { get; }

        public ICommand DeleteConditionFromNewConditionListCommand { get; }

        private void ShowHome()
        {
        }

        private void ShowDoctors()
        {
            Task.Run(() => DoctorModel.LoadDoctorList());
        }

        private void ShowPatientId()
        {
            Task.Run(() => PatientModel.LoadPatientById());
        }

        private void ShowPatientPesel()
        {
            Task.Run(() => PatientModel.LoadPatientByPesel());
        }

        private void ShowBestDoctor()
        {
            Task.Run(() => DoctorModel.GetBestDoctor());
        }

        private void ShowAddPatient()
        {
            Task.Run(() => PatientModel.AddPatient());
        }

        private void ShowDeletePatientId()
        {
            Task.Run(() => PatientModel.DeletePatientById());
        }

        private void ShowDeletePatientPesel()
        {
            Task.Run(() => PatientModel.DeletePatientByPesel());
        }

        private void AddConditionToNewPatient()
        {
            Task.Run(() => PatientModel.AddConditionToNewPatient());
        }

        private void DeleteConditionFromNewConditionList()
        {
            Task.Run(() => PatientModel.DeleteConditionFromNewConditionList());
        }
    }
}