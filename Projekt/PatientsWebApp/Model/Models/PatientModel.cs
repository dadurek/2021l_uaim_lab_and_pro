namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Service;

    public partial class Model : IModel
    {
        private PatientData _patientId = new PatientData();

        private PatientData _patientPesel = new PatientData();

        private string _searchTextDeleteId;

        private string _searchTextDeletePesel;

        private string _searchTextId;

        private string _searchTextPesel;

        private PatientData _selectedPatient = new PatientData();

        private PatientData _newPatient = new PatientData
        {
            Conditions = new List<ConditionData>()
        };

        private ConditionData _newCondition = new ConditionData();

        private ObservableCollection<ConditionData> _newConditionList = new ObservableCollection<ConditionData>();

        private ConditionData _conditionDelete = new ConditionData();
        

        public string SearchTextPatientId
        {
            get => _searchTextId;
            set
            {
                _searchTextId = value;
                RaisePropertyChanged("SearchTextId");
            }
        }

        public string SearchTextPatientPesel
        {
            get => _searchTextPesel;
            set
            {
                _searchTextPesel = value;
                RaisePropertyChanged("SearchTextPesel");
            }
        }

        public string SearchTextDeletePatientId
        {
            get => _searchTextDeleteId;
            set
            {
                _searchTextDeleteId = value;
                RaisePropertyChanged("SearchTextDeleteId");
            }
        }

        public string SearchTextDeletePatientPesel
        {
            get => _searchTextDeletePesel;
            set
            {
                _searchTextDeletePesel = value;
                RaisePropertyChanged("SearchTextDeletePesel");
            }
        }


        public PatientData PatientId
        {
            get => _patientId;
            private set
            {
                _patientId = value;
                RaisePropertyChanged("PatientId");
            }
        }


        public PatientData PatientPesel
        {
            get => _patientPesel;
            private set
            {
                _patientPesel = value;
                RaisePropertyChanged("PatientPesel");
            }
        }

        public PatientData SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                RaisePropertyChanged("SelectedPatient");
            }
        }

        public PatientData NewPatient
        {
            get => _newPatient;
            set
            {
                _newPatient = value;
                RaisePropertyChanged("NewPatient");
            }
        }

        public List<string> Sexes
        {
            get => Enum.GetNames(typeof(SexData)).ToList();
        }

        public ConditionData NewCondition
        {
            get => _newCondition;
            set
            {
                _newCondition = value;
                RaisePropertyChanged("NewCondition");
            }
        }

        public ObservableCollection<ConditionData> NewConditionList
        {
            get => _newConditionList;
            set
            {
                _newConditionList = value;
                RaisePropertyChanged("NewConditionList");
            }
        }

        public ConditionData ConditionDelete
        {
            get => _conditionDelete;
            set
            {
                _conditionDelete = value;
                RaisePropertyChanged("ConditionDelete");
            }
        }

        public void LoadPatientById()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    var id = int.Parse(SearchTextPatientId);
                    var patient = networkClient.GetPatientById(id);
                    PatientId = patient.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void LoadPatientByPesel()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    var patient = networkClient.GetPatientByPesel(SearchTextPatientPesel);
                    PatientPesel = patient.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void AddPatient()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    NewPatient.Conditions = NewConditionList.ToList();
                    networkClient.AddPatient(NewPatient);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void AddConditionToNewPatient()
        {
            var t = Task.Run(() =>
            {
                List<ConditionData> xd = NewConditionList.ToList<ConditionData>();
                xd.Add(new ConditionData
                {
                    Type = NewCondition.Type, DiagnosisDate = NewCondition.DiagnosisDate
                });
                NewConditionList = new ObservableCollection<ConditionData>(xd);
            });
            t.Wait();
        }

        public void DeleteConditionFromNewConditionList()
        {
            var t = Task.Run(() =>
            {
                List<ConditionData> xd = NewConditionList.ToList<ConditionData>();
                var index = xd.ToList().FindIndex(x =>
                    x.Type == ConditionDelete.Type && x.DiagnosisDate.Date == ConditionDelete.DiagnosisDate.Date);
                xd.RemoveAt(index);
                NewConditionList = new ObservableCollection<ConditionData>(xd);
            });
        }

        public void DeletePatientById()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    networkClient.DeletePatientById(int.Parse(SearchTextDeletePatientId));
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void DeletePatientByPesel()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    networkClient.DeletePatientByPesel(SearchTextDeletePatientPesel);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }
    }
}