namespace Model.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;

    public class FakeNetworkClient : INetworkClient
    {
        public Task<List<DoctorData>> GetAllDoctors()
        {
            return Task.FromResult(
                new List<DoctorData>
                {
                    new DoctorData
                    {
                        Id = 1, Name = "Marcin", Pesel = "123", Sex = "Male",
                        Specializations = new List<SpecializationData>
                        {
                            new SpecializationData
                            {
                                Type = 1, CertificationDate = new DateTime(2020, 1, 1)
                            }
                        }
                    },
                    new DoctorData
                    {
                        Id = 1, Name = "Maciej", Pesel = "123", Sex = "Male",
                        Specializations = new List<SpecializationData>
                        {
                            new SpecializationData
                            {
                                Type = 1, CertificationDate = new DateTime(2020, 1, 1)
                            }
                        }
                    }
                }
            );
        }

        public Task<PatientData> GetPatientById(int id)
        {
            return Task.FromResult(new PatientData
            {
                Id = id, Name = "Marcin", Pesel = "123", Sex = "Male",
                Conditions = new List<ConditionData>
                {
                    new ConditionData
                    {
                        Type = 1, DiagnosisDate = new DateTime(2020, 1, 1)
                    }
                }
            });
        }

        public Task<PatientData> GetPatientByPesel(string pesel)
        {
            return Task.FromResult(new PatientData
            {
                Id = 1337, Name = "Maciej", Pesel = pesel, Sex = "Female",
                Conditions = new List<ConditionData>
                {
                    new ConditionData
                    {
                        Type = 1, DiagnosisDate = new DateTime(2020, 1, 1)
                    }
                }
            });
        }

        public Task<DoctorData> GetBestDoctor(int id)
        {
            return Task.FromResult(
                new DoctorData
                {
                    Id = 1, Name = "Marcin", Pesel = "123", Sex = "Male",
                    Specializations = new List<SpecializationData>
                    {
                        new SpecializationData
                        {
                            Type = 1, CertificationDate = new DateTime(2020, 1, 1)
                        }
                    }
                });
        }

        public void AddPatient(PatientData patient)
        {
            throw new NotImplementedException();
        }

        public void DeletePatientById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePatientByPesel(string pesel)
        {
            throw new NotImplementedException();
        }
    }
}