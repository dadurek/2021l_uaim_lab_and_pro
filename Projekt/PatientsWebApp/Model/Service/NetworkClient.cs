namespace Model.Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Configuration;
    using Data;
    using Utilities;

    public class NetworkClient : INetworkClient
    {
        private readonly ServiceClient _serviceClient;

        public NetworkClient(ServiceConfiguration configuration)
        {
            _serviceClient = new ServiceClient(configuration.BackendUrl);
        }

        public void AddPatient(PatientData patient)
        {
            var callUri = "patient";
            _ = _serviceClient.CallWebServiceAsync<PatientData>(callUri, patient);
        }

        public void DeletePatientById(int id)
        {
            var callUri = $"patient/{id}";
            _ = _serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Delete, callUri);
        }

        public void DeletePatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            _ = _serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Delete, callUri);
        }

        public Task<List<DoctorData>> GetAllDoctors()
        {
            const string callUri = "doctors";
            var allDoctors = _serviceClient.CallWebServiceAsync<List<DoctorData>>(HttpMethod.Get, callUri);
            return allDoctors;
        }

        public Task<DoctorData> GetBestDoctor(int id)
        {
            var callUri = $"patient/{id}/best-doctor";
            var doctor = _serviceClient.CallWebServiceAsync<DoctorData>(HttpMethod.Get, callUri);
            return doctor;
        }

        public Task<PatientData> GetPatientById(int id)
        {
            var callUri = $"patient/{id}";
            var patient = _serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Get, callUri);
            return patient;
        }

        public Task<PatientData> GetPatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            var patient = _serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Get, callUri);
            return patient;
        }
    }
}