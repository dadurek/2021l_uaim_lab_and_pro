namespace ZsutPw.Patterns.WindowsApplication.Logic.Model.Data
{
   public class MatchData
    {
        public MatchData()
        {

        }

        public MatchData(string doctorName, string roomNumber)
        {
            DoctorName = doctorName;
            RoomNumber = roomNumber;
        }
        public string DoctorName { get; set; }
        public string RoomNumber { get; set; }
    }
}

