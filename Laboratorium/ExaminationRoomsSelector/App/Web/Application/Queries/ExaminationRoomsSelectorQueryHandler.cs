namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;

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

            var bestMatch = MatchDoctorsWithRooms(doctors, rooms);

            return await Task.FromResult(bestMatch);
        }

        //simple greedy algorithm that match best room for each doctor
        public static List<DoctorRoomDto> MatchDoctorsWithRooms(List<DoctorDto> doctorsDto,
            List<ExaminationRoomDto> examinationRoomsDto)
        {
            var doctors = doctorsDto ?? throw new ArgumentNullException(nameof(doctorsDto));
            var rooms = examinationRoomsDto ?? throw new ArgumentNullException(nameof(examinationRoomsDto));

            var list = new List<DoctorRoomDto>();
            
            foreach (var doctor in doctors)
            {
                var bestRoom = rooms.First();
                var rank = GetRank(doctor, bestRoom);
                
                foreach (var room in rooms)
                {
                    var x = GetRank(doctor, room);
                    if (x <= rank) continue;
                    rank = x;
                    bestRoom = room;
                }

                if (GetRank(doctor, bestRoom) == 0)
                    return list;

                list.Add(new DoctorRoomDto(doctor, bestRoom));
                rooms.Remove(bestRoom);
            }

            return list;
        }

        //Get rank, iterating over the loop is faster than using Intersect
        private static int GetRank(DoctorDto doctorDto, ExaminationRoomDto examinationRoomDto)
        {
            var count = 0;
            foreach (var s in doctorDto.Specializations)
            {
                foreach (var c in examinationRoomDto.Certifications)
                {
                    if (s == c)
                        count++;
                }
            }

            return count;
            // return doctorDto.Specializations.Intersect(examinationRoomDto.Certifications).Count(); //slower option
        }
    }
}