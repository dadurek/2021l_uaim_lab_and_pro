namespace Model.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dto;

    public interface INetworkClient
    {
        Task<List<DoctorDto>> GetAllDoctors();

        Task<PatientDto> GetPatientById(int id);

        Task<PatientDto> GetPatientByPesel(string pesel);

        Task<DoctorDto> GetBestDoctor(int id);

        void AddPatient(PatientDto patient);

        void DeletePatientById(int id);

        void DeletePatientByPesel(string pesel);
    }
}