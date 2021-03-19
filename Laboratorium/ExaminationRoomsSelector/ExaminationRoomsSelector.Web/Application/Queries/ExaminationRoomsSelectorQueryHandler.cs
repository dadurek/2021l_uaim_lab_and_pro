namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using System.Collections.Generic;
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using ExaminationRoomsSelector.Web.Application.DataServiceClients;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IExaminationRoomsServiceClient examinationRoomsServiceClient;
        private readonly IDoctorsServiceClient doctorsServiceClient;
        private List<DoctorDto> doctorList;
        private List<ExaminationRoomDto> roomList;
        private readonly List<int> commonSetOfDisease;

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient, IDoctorsServiceClient doctorsServiceClient)
        {
            this.examinationRoomsServiceClient = examinationRoomsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
            doctorList = new List<DoctorDto>();
            roomList = new List<ExaminationRoomDto>();
            commonSetOfDisease = new List<int>();
        }
        
        public async Task<int> GetExaminationRoomsSelectionAsync()
        {
            doctorList = (await doctorsServiceClient.GetAllDoctorsAsync()).ToList();
            roomList = (await examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).ToList();

            await GetCommonSet();
            await MakeList();
            

            return 5;
        }
        

        private async Task MakeList()
        {
            foreach (var doctor in doctorList)
            {
                if (doctor.Specializations.Any(n => commonSetOfDisease.Contains(n)))
                {
                    var list = (doctor.Specializations.ToList()).Intersect(commonSetOfDisease).ToList();
                    doctor.Specializations = list;
                }
            }
            foreach (var room in roomList)
            {
                if (room.Certifications.Any(n => commonSetOfDisease.Contains(n)))
                {
                    var list = (room.Certifications.ToList()).Intersect(commonSetOfDisease).ToList();
                    room.Certifications = list;
                }
                //TODO remove rooms with no certifications
                // if (!room.Certifications.Any())
                // {
                //     roomList.Remove(room);
                // }
            }
        }
        

        private async Task GetCommonSet()
        {
            commonSetOfDisease.Clear();
            
            var commonDoctors = new List<int>();
            var commonRooms = new List<int>();
            var hashSet = new HashSet<int>();
            
            foreach (var n in doctorList)
                commonDoctors.AddRange(n.Specializations.Where(x => hashSet.Add(x)));

            hashSet.Clear();
            
            foreach (var n in roomList)
                commonRooms.AddRange(n.Certifications.Where(x => hashSet.Add(x)));
            
            foreach (var x in commonDoctors.Intersect(commonRooms))
                    commonSetOfDisease.Add(x);
        }
    }
}
