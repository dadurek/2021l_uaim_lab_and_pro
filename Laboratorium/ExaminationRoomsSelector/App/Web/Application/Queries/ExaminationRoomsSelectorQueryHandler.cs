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

        public List<DoctorRoomDto> MatchDoctorsWithRooms(List<DoctorDto> doctorsDto,
            List<ExaminationRoomDto> examinationRoomsDto)
        {
            var doctors = doctorsDto ?? throw new ArgumentNullException(nameof(doctorsDto));
            var rooms = examinationRoomsDto ?? throw new ArgumentNullException(nameof(examinationRoomsDto));

            (doctors, rooms) = RemakeLists(doctors, rooms);

            var list = new List<DoctorRoomDto>();

            while (doctors.Any() && rooms.Any())
            {
                var bestDoctor = doctors[0];
                var bestRoom = rooms[0];
                var rank = GetRank(bestDoctor, bestRoom);

                foreach (var doctor in doctors)
                {
                    foreach (var room in rooms)
                    {
                        var x = GetRank(doctor, room);
                        if (x <= rank) continue;
                        rank = x;
                        bestDoctor = doctor;
                        bestRoom = room;
                    }
                }

                if (GetRank(bestDoctor, bestRoom) == 0
                ) //edge case, if common specialization of doctor and room is 0, break
                    break;

                list.Add(new DoctorRoomDto(bestDoctor, bestRoom));
                doctors.Remove(bestDoctor);
                rooms.Remove(bestRoom);
            }

            return list;
        }

        //return number of specialization that are same
        protected virtual int GetRank(DoctorDto d, ExaminationRoomDto e)
        {
            return d.Specializations.ToList().Intersect(e.Certifications.ToList()).Count();
        }


        //remake list od doctors and rooms that they contain only specializations witch are common part of all rooms and all doctors
        private (List<DoctorDto> doctors, List<ExaminationRoomDto> rooms) RemakeLists(List<DoctorDto> doctors,
            List<ExaminationRoomDto> rooms)
        {
            var commonSetOfDisease = GetCommonSet(doctors, rooms);

            foreach (var doctor in doctors)
                if (doctor.Specializations.Any(n => commonSetOfDisease.Contains(n)))
                {
                    var list = doctor.Specializations.ToList().Intersect(commonSetOfDisease).ToList();
                    doctor.Specializations = list;
                }

            for (var i = 0; i < rooms.Count; i++)
            {
                var room = rooms[i];
                if (room.Certifications.Any(n => commonSetOfDisease.Contains(n)))
                {
                    var list = room.Certifications.ToList().Intersect(commonSetOfDisease).ToList();
                    room.Certifications = list;
                }

                if (room.Certifications.Any()) continue;
                rooms.Remove(room);
                i++;
            }

            return (doctors, rooms);
        }

        //Get all specializations that are common part of all rooms and all doctors
        private List<int> GetCommonSet(List<DoctorDto> doctors, List<ExaminationRoomDto> rooms)
        {
            var commonDoctors = new List<int>();
            var commonRooms = new List<int>();
            var hashSet = new HashSet<int>();

            foreach (var n in doctors)
                commonDoctors.AddRange(n.Specializations.Where(x => hashSet.Add(x)));

            hashSet.Clear(); //clear next itteration

            foreach (var n in rooms)
                commonRooms.AddRange(n.Certifications.Where(x => hashSet.Add(x)));

            return commonDoctors.Intersect(commonRooms).ToList();
        }
    }
}