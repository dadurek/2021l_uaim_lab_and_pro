namespace Model.IData
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Dto;

    public interface IPatientData : INotifyPropertyChanged
    {
        string SearchTextId { get; set; }

        string SearchTextPesel { get; set; }

        string SearchTextDeleteId { get; set; }

        string SearchTextDeletePesel { get; set; }

        PatientDto PatientId { get; }

        PatientDto PatientPesel { get; }

        PatientDto SelectedPatient { get; set; }

        PatientDto NewPatient { get; set; }

        List<string> Sexes { get; }

        ConditionDto NewCondition { get; set; }

        ObservableCollection<ConditionDto> NewConditionList { get; set; }

        ConditionDto ConditionDelete { get; set; }
    }
}