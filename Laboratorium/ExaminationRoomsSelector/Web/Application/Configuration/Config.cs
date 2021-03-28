namespace ExaminationRoomsSelector.Web.Web.Application
{
    using Microsoft.Extensions.Configuration;

    public class Config
    {
        public static  string DOCTOR_URL;
        public static  string ROOM_URL;

        public static void Init(IConfiguration Configuration)
        {
            DOCTOR_URL = Configuration.GetValue<string>("UrlConnection:DoctorUrl");
            ROOM_URL = Configuration.GetValue<string>("UrlConnection:RoomUrl");
        }
    }
}