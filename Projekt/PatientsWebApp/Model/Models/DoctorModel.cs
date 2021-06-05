namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using Service;
    using Utilities;

    public partial class Model
    {
        private List<DoctorData> _doctorList = new List<DoctorData>();


        private DoctorData _doctorBest = new DoctorData();

        private string _searchTextBestDoctor;

        private DoctorData _selectedDoctor = new DoctorData();
        

        public string SearchTextBestDoctor
        {
            get => _searchTextBestDoctor;
            set
            {
                _searchTextBestDoctor = value;
                RaisePropertyChanged("SearchTextBestDoctor");
            }
        }

        public List<DoctorData> DoctorList
        {
            get => _doctorList;
            private set
            {
                _doctorList = value;
                RaisePropertyChanged("DoctorList");
            }
        }

        public DoctorData DoctorBest
        {
            get => _doctorBest;
            private set
            {
                _doctorBest = value;
                RaisePropertyChanged("DoctorBest");
            }
        }

        public DoctorData SelectedDoctor
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
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
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
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
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