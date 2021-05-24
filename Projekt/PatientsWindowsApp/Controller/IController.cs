namespace Controller
{
    using System.ComponentModel;
    using System.Windows.Input;
    using Model.IModel;

    public interface IController : INotifyPropertyChanged
    {
        IDoctorModel DoctorModel { get; }

        IPatientModel PatientModel { get; }

        ICommand ShowHomeCommand { get; }

        ICommand ShowDoctorsCommand { get; }

        ICommand ShowPatientIdCommand { get; }

        ICommand ShowPatientPeselCommand { get; }

        ICommand ShowBestDoctorCommand { get; }

        ICommand ShowAddPatientCommand { get; }

        ICommand ShowDeletePatientIdCommand { get; }

        ICommand ShowDeletePatientPeselCommand { get; }

        ICommand AddConditionToNewPatientCommand { get; }

        ICommand DeleteConditionFromNewConditionListCommand { get; }
    }
}