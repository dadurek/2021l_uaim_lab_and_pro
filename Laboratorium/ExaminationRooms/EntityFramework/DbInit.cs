namespace ExaminationRooms.Web.EntityFramework
{
    public class DbInit
    {
        public static void Initialize(ExaminationRoomContext examinationRoomContext)
        {
            examinationRoomContext.Database.EnsureCreated();
        }
    }
}