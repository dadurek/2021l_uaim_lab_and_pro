namespace Model.Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Dto;
    using Utilities;

    public class NetworkClient : INetworkClient
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public void AddPatient(PatientDto patient)
        {
            var callUri = "patient";
            _ = serviceClient.CallWebServiceAsync<PatientDto>(callUri, patient);
        }

        public void DeletePatientById(int id)
        {
            var callUri = $"patient/{id}";
            _ = serviceClient.CallWebServiceAsync<PatientDto>(HttpMethod.Delete, callUri);
        }

        public void DeletePatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            _ = serviceClient.CallWebServiceAsync<PatientDto>(HttpMethod.Delete, callUri);
        }

        public Task<List<DoctorDto>> GetAllDoctors()
        {
            const string callUri = "doctors";
            var allDoctors = serviceClient.CallWebServiceAsync<List<DoctorDto>>(HttpMethod.Get, callUri);
            return allDoctors;
        }

        public Task<DoctorDto> GetBestDoctor(int id)
        {
            var callUri = $"patient/{id}/best-doctor";
            var doctor = serviceClient.CallWebServiceAsync<DoctorDto>(HttpMethod.Get, callUri);
            return doctor;
        }

        public Task<PatientDto> GetPatientById(int id)
        {
            var callUri = $"patient/{id}";
            var patient = serviceClient.CallWebServiceAsync<PatientDto>(HttpMethod.Get, callUri);
            return patient;
        }

        public Task<PatientDto> GetPatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            var patient = serviceClient.CallWebServiceAsync<PatientDto>(HttpMethod.Get, callUri);
            return patient;
        }
    }
}