namespace ExaminationRoomsSelector.Web.Web.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::ExaminationRoomsSelector.Web.Application.Dtos;

    public class ExaminationRoomsSelector
    {
        


        //simple greedy algorithm that match best room for each doctor
        public List<DoctorRoomDto> MatchDoctorsWithRooms(List<DoctorDto> doctorsDto, List<ExaminationRoomDto> examinationRoomsDto)
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
        private int GetRank(DoctorDto doctorDto, ExaminationRoomDto examinationRoomDto)
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
        }
    }
}