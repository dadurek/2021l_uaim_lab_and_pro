namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    public class DoctorRoomDto
    {
        private DoctorDto doctor { get; set; }
        private ExaminationRoomDto room { get; set; }

        public DoctorRoomDto(DoctorDto doctor, ExaminationRoomDto room)
        {
            this.doctor = doctor;
            this.room = room;
        }
    }
}