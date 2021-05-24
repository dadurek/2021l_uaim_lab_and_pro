namespace Model.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dto;

    public class FakeNetworkClient : INetworkClient
    {
        public Task<List<DoctorDto>> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> GetPatientById(int id)
        {
            return Task.FromResult(new PatientDto
            {
                Id = id, Name = "Marcin", Pesel = "123", Sex = "male",
                Conditions = new List<ConditionDto>
                {
                    new ConditionDto
                    {
                        Type = 1, DiagnosisDate = new DateTime(2020, 1, 1)
                    }
                }
            });
        }

        public Task<PatientDto> GetPatientByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorDto> GetBestDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public void AddPatient(PatientDto patient)
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