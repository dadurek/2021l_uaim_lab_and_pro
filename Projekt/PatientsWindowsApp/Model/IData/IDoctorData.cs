namespace Model.IData
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Dto;

    public interface IDoctorData : INotifyPropertyChanged
    {
        List<DoctorDto> DoctorList { get; }

        DoctorDto DoctorBest { get; }

        DoctorDto SelectedDoctor { get; set; }

        string SearchTextBestDoctor { get; set; }
    }
}