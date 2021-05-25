namespace Model.IData
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Data;

    public interface IDoctorData : INotifyPropertyChanged
    {
        List<DoctorData> DoctorList { get; }

        DoctorData DoctorBest { get; }

        DoctorData SelectedDoctor { get; set; }

        string SearchTextBestDoctor { get; set; }
    }
}