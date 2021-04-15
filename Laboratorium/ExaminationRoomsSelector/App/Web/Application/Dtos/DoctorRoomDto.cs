namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    public class DoctorRoomDto
    {
        public DoctorDto doctor { get; set; }
        public ExaminationRoomDto room { get; set; }

        public DoctorRoomDto(DoctorDto doctor, ExaminationRoomDto room)
        {
            this.doctor = doctor;
            this.room = room;
        }
    }
}