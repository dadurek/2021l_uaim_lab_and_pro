namespace Model.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;

    public interface INetworkClient
    {
        Task<List<DoctorData>> GetAllDoctors();

        Task<PatientData> GetPatientById(int id);

        Task<PatientData> GetPatientByPesel(string pesel);

        Task<DoctorData> GetBestDoctor(int id);

        void AddPatient(PatientData patient);

        void DeletePatientById(int id);

        void DeletePatientByPesel(string pesel);
    }
}