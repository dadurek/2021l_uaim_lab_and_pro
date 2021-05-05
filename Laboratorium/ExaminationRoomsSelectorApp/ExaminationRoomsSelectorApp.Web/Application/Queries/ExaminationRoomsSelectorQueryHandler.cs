namespace ExaminationRoomsSelectorApp.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;
    using Utils;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IDoctorsServiceClient _doctorsServiceClient;
        private readonly IExaminationRoomsServiceClient _examinationRoomsServiceClient;


        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient,
            IDoctorsServiceClient doctorsServiceClient)
        {
            _examinationRoomsServiceClient = examinationRoomsServiceClient;
            _doctorsServiceClient = doctorsServiceClient;
        }

        public ExaminationRoomsSelectorQueryHandler()
        {
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            _doctorsServiceClient.AddDoctor(doctorDto);
        }

        public void AddRoom(ExaminationRoomDto examinationRoomDto)
        {
            _examinationRoomsServiceClient.AddRoom(examinationRoomDto);
        }

        public async Task<List<DoctorRoomDto>> GetExaminationRoomsSelectionAsync()
        {
            var doctors = (await _doctorsServiceClient.GetAllDoctorsAsync()).ToList();
            var rooms = (await _examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).ToList();

            var bestMatch = new ExaminationRoomsSelector().MatchDoctorsWithRooms(doctors, rooms);

            return await Task.FromResult(bestMatch);
        }
    }
}