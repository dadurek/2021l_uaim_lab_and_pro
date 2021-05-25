namespace Model.Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Data;
    using Utilities;

    public class NetworkClient : INetworkClient
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public void AddPatient(PatientData patient)
        {
            var callUri = "patient";
            _ = serviceClient.CallWebServiceAsync<PatientData>(callUri, patient);
        }

        public void DeletePatientById(int id)
        {
            var callUri = $"patient/{id}";
            _ = serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Delete, callUri);
        }

        public void DeletePatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            _ = serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Delete, callUri);
        }

        public Task<List<DoctorData>> GetAllDoctors()
        {
            const string callUri = "doctors";
            var allDoctors = serviceClient.CallWebServiceAsync<List<DoctorData>>(HttpMethod.Get, callUri);
            return allDoctors;
        }

        public Task<DoctorData> GetBestDoctor(int id)
        {
            var callUri = $"patient/{id}/best-doctor";
            var doctor = serviceClient.CallWebServiceAsync<DoctorData>(HttpMethod.Get, callUri);
            return doctor;
        }

        public Task<PatientData> GetPatientById(int id)
        {
            var callUri = $"patient/{id}";
            var patient = serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Get, callUri);
            return patient;
        }

        public Task<PatientData> GetPatientByPesel(string pesel)
        {
            var callUri = $"patient/pesel/{pesel}";
            var patient = serviceClient.CallWebServiceAsync<PatientData>(HttpMethod.Get, callUri);
            return patient;
        }
    }
}