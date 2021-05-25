namespace Model.IData
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Data;

    public interface IPatientData : INotifyPropertyChanged
    {
        string SearchTextPatientId { get; set; }

        string SearchTextPatientPesel { get; set; }

        string SearchTextDeletePatientId { get; set; }

        string SearchTextDeletePatientPesel { get; set; }

        PatientData PatientId { get; }

        PatientData PatientPesel { get; }

        PatientData SelectedPatient { get; set; }

        PatientData NewPatient { get; set; }

        List<string> Sexes { get; }

        ConditionData NewCondition { get; set; }

        ObservableCollection<ConditionData> NewConditionList { get; set; }

        ConditionData ConditionDelete { get; set; }
    }
}