namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Dto;
    using IModel;
    using Service;
    using Utilities;

    public class PatientModel : PropertyContainerBase, IPatientModel
    {
        private PatientDto _patientId = new PatientDto();

        private PatientDto _patientPesel = new PatientDto();

        private string _searchTextDeleteId;

        private string _searchTextDeletePesel;

        private string _searchTextId;

        private string _searchTextPesel;

        private PatientDto _selectedPatient = new PatientDto();

        private PatientDto _newPatient = new PatientDto
        {
            Conditions = new List<ConditionDto>()
        };

        private ConditionDto _newCondition = new ConditionDto();

        private ObservableCollection<ConditionDto> _newConditionList = new ObservableCollection<ConditionDto>();

        private ConditionDto _conditionDelete = new ConditionDto();

        public PatientModel(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string SearchTextId
        {
            get => _searchTextId;
            set
            {
                _searchTextId = value;
                RaisePropertyChanged("SearchTextId");
            }
        }

        public string SearchTextPesel
        {
            get => _searchTextPesel;
            set
            {
                _searchTextPesel = value;
                RaisePropertyChanged("SearchTextPesel");
            }
        }

        public string SearchTextDeleteId
        {
            get => _searchTextDeleteId;
            set
            {
                _searchTextDeleteId = value;
                RaisePropertyChanged("SearchTextDeleteId");
            }
        }

        public string SearchTextDeletePesel
        {
            get => _searchTextDeletePesel;
            set
            {
                _searchTextDeletePesel = value;
                RaisePropertyChanged("SearchTextDeletePesel");
            }
        }


        public PatientDto PatientId
        {
            get => _patientId;
            private set
            {
                _patientId = value;
                RaisePropertyChanged("PatientId");
            }
        }


        public PatientDto PatientPesel
        {
            get => _patientPesel;
            private set
            {
                _patientPesel = value;
                RaisePropertyChanged("PatientPesel");
            }
        }

        public PatientDto SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                RaisePropertyChanged("SelectedPatient");
            }
        }

        public PatientDto NewPatient
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
            get => Enum.GetNames(typeof(SexDto)).ToList();
        }

        public ConditionDto NewCondition
        {
            get => _newCondition;
            set
            {
                _newCondition = value;
                RaisePropertyChanged("NewCondition");
            }
        }

        public ObservableCollection<ConditionDto> NewConditionList
        {
            get => _newConditionList;
            set
            {
                _newConditionList = value;
                RaisePropertyChanged("NewConditionList");
            }
        }

        public ConditionDto ConditionDelete
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
                    var id = int.Parse(SearchTextId);
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
                    var patient = networkClient.GetPatientByPesel(SearchTextPesel);
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
                List<ConditionDto> xd = NewConditionList.ToList<ConditionDto>();
                xd.Add(new ConditionDto
                {
                    Type = NewCondition.Type, DiagnosisDate = NewCondition.DiagnosisDate
                });
                NewConditionList = new ObservableCollection<ConditionDto>(xd);
            });
            t.Wait();
        }

        public void DeleteConditionFromNewConditionList()
        {
            var t = Task.Run(() =>
            {
                List<ConditionDto> xd = NewConditionList.ToList<ConditionDto>();
                var index = xd.ToList().FindIndex(x =>
                    x.Type == ConditionDelete.Type && x.DiagnosisDate.Date == ConditionDelete.DiagnosisDate.Date);
                xd.RemoveAt(index);
                NewConditionList = new ObservableCollection<ConditionDto>(xd);
            });
        }

        public void DeletePatientById()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient();
                try
                {
                    networkClient.DeletePatientById(int.Parse(SearchTextDeleteId));
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
                    networkClient.DeletePatientByPesel(SearchTextDeletePesel);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }
    }
}