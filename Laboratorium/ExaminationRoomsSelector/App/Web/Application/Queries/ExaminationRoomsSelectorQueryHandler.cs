namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServiceClients;
    using Dtos;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IDoctorsServiceClient _doctorsServiceClient;
        private readonly IExaminationRoomsServiceClient _examinationRoomsServiceClient;
        private List<DoctorDto> _doctorList = new();
        private List<ExaminationRoomDto> _roomList = new();
        

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient,
            IDoctorsServiceClient doctorsServiceClient)
        {
            _examinationRoomsServiceClient = examinationRoomsServiceClient;
            _doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<List<DoctorRoomDto>> GetExaminationRoomsSelectionAsync()
        {
            _doctorList = (await _doctorsServiceClient.GetAllDoctorsAsync()).ToList();
            _roomList = (await _examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).ToList();

            await MakeList();

            return await MatchDoctorsWithRooms();
        }

        public void AddDoctor(DoctorDto doctorDto)
        {
            _doctorsServiceClient.AddDoctor(doctorDto);
        }
        
        public void AddRoom(ExaminationRoomDto examinationRoomDto)
        {
            _examinationRoomsServiceClient.AddRoom(examinationRoomDto);
        }

        //simple greedy algorithm that mark as best doctor and room when they have most of all groups common specializations
        private Task<List<DoctorRoomDto>> MatchDoctorsWithRooms()
        {
            var l = new List<DoctorRoomDto>();

            while (_doctorList.Any() && _roomList.Any())
            {
                var bestDoctor = _doctorList[0];
                var bestRoom = _roomList[0];
                var rank = GetRank(bestDoctor, bestRoom);

                foreach (var doctor in _doctorList)
                {
                    foreach (var room in _roomList)
                    {
                        var x = GetRank(doctor, room);
                        if (x > rank)
                        {
                            rank = x;
                            bestDoctor = doctor;
                            bestRoom = room;
                        }
                    }
                }
                if (GetRank(bestDoctor, bestRoom) == 0) //edge case, if common specialization of doctor and room is 0, break
                    break;
                
                l.Add(new DoctorRoomDto(bestDoctor, bestRoom));
                _doctorList.Remove(bestDoctor);
                _roomList.Remove(bestRoom);
            }
            return Task.FromResult(l);
        }

        //return number of specialization that are same
        protected virtual int GetRank(DoctorDto d, ExaminationRoomDto e)
        {
            return d.Specializations.ToList().Intersect(e.Certifications.ToList()).Count();
        }


        //remake list od doctors and rooms that they contain only specializations witch are common part of all rooms and all doctors
        private async Task MakeList()
        {
            var commonSetOfDisease = GetCommonSet();
            
            foreach (var doctor in _doctorList)
                if (doctor.Specializations.Any(n => commonSetOfDisease.Contains(n)))
                {
                    var list = doctor.Specializations.ToList().Intersect(commonSetOfDisease).ToList();
                    doctor.Specializations = list;
                }

            for (var i = 0; i < _roomList.Count; i++)
            {
                var room = _roomList[i];
                if (room.Certifications.Any(n => commonSetOfDisease.Contains(n)))
                {
                    var list = room.Certifications.ToList().Intersect(commonSetOfDisease).ToList();
                    room.Certifications = list;
                }
                if (!room.Certifications.Any())
                {
                    _roomList.Remove(room);
                    i++;
                }
            }
        }

        //Get all specializations that are common part of all rooms and all doctors
        private List<int>  GetCommonSet()
        {
            var commonDoctors = new List<int>();
            var commonRooms = new List<int>();
            var hashSet = new HashSet<int>();

            foreach (var n in _doctorList)
                commonDoctors.AddRange(n.Specializations.Where(x => hashSet.Add(x)));

            hashSet.Clear(); //clear next itteration

            foreach (var n in _roomList)
                commonRooms.AddRange(n.Certifications.Where(x => hashSet.Add(x)));

            return commonDoctors.Intersect(commonRooms).ToList();
        }
    }
}