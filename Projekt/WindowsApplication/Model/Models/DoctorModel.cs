namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dto;
    using IModel;
    using Service;
    using Utilities;

    public class DoctorModel : PropertyContainerBase, IDoctorModel
    {
        private List<DoctorDto> _doctorList = new List<DoctorDto>();


        private DoctorDto _doctorBest = new DoctorDto();

        private string _searchTextBestDoctor;

        private DoctorDto _selectedDoctor = new DoctorDto();

        public DoctorModel(IEventDispatcher dispatch) : base(dispatch)
        {
        }

        public string SearchTextBestDoctor
        {
            get => _searchTextBestDoctor;
            set
            {
                _searchTextBestDoctor = value;
                RaisePropertyChanged("SearchTextBestDoctor");
            }
        }

        public List<DoctorDto> DoctorList
        {
            get => _doctorList;
            private set
            {
                _doctorList = value;
                RaisePropertyChanged("DoctorList");
            }
        }

        public DoctorDto DoctorBest
        {
            get => _doctorBest;
            private set
            {
                _doctorBest = value;
                RaisePropertyChanged("DoctorBest");
            }
        }

        public DoctorDto SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                RaisePropertyChanged("SelectedDoctor");
            }
        }


        public void LoadDoctorList()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    var matchList = networkClient.GetAllDoctors();
                    DoctorList = matchList.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void GetBestDoctor()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    var bestDoctor = networkClient.GetBestDoctor(int.Parse(SearchTextBestDoctor));
                    DoctorBest = bestDoctor.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }
    }
}