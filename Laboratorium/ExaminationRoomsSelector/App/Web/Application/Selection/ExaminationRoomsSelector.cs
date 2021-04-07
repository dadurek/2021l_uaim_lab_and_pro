// namespace ExaminationRoomsSelector.Web.Web.Application.Selection
// {
//     using System;
//     using System.Collections.Generic;
//     using System.Linq;
//     using global::ExaminationRoomsSelector.Web.Application.Dtos;
//
//     public class ExaminationRoomsSelector : IExaminationRoomsSelector
//     {
//         private readonly List<DoctorDto> doctors;
//         private readonly List<ExaminationRoomDto> rooms;
//
//         public ExaminationRoomsSelector(IEnumerable<DoctorDto> doctorDtos, IEnumerable<ExaminationRoomDto> examinationRoomDtos)
//         {
//             doctors = doctorDtos?.ToList() ?? throw new ArgumentNullException(nameof(doctorDtos));
//             rooms = examinationRoomDtos?.ToList() ?? throw new ArgumentNullException(nameof(examinationRoomDtos));
//         }
//         
//
//         //simple greedy algorithm that mark as best doctor and room when they have most of all groups common specializations
//         public List<DoctorRoomDto> MatchDoctorsWithRooms()
//         {
//             RemakeLists();
//
//             var list = new List<DoctorRoomDto>();
//
//             while (doctors.Any() && rooms.Any())
//             {
//                 var bestDoctor = doctors[0];
//                 var bestRoom = rooms[0];
//                 var rank = GetRank(bestDoctor, bestRoom);
//
//                 foreach (var doctor in doctors)
//                 {
//                     foreach (var room in rooms)
//                     {
//                         var x = GetRank(doctor, room);
//                         if (x <= rank) continue;
//                         rank = x;
//                         bestDoctor = doctor;
//                         bestRoom = room;
//                     }
//                 }
//
//                 if (GetRank(bestDoctor, bestRoom) == 0
//                 ) //edge case, if common specialization of doctor and room is 0, break
//                     break;
//
//                 list.Add(new DoctorRoomDto(bestDoctor, bestRoom));
//                 doctors.Remove(bestDoctor);
//                 rooms.Remove(bestRoom);
//             }
//
//             return list;
//         }
//
//         //return number of specialization that are same
//         protected virtual int GetRank(DoctorDto d, ExaminationRoomDto e)
//         {
//             return d.Specializations.ToList().Intersect(e.Certifications.ToList()).Count();
//         }
//
//
//         //remake list od doctors and rooms that they contain only specializations witch are common part of all rooms and all doctors
//         private void RemakeLists()
//         {
//             var commonSetOfDisease = GetCommonSet();
//
//             foreach (var doctor in doctors)
//                 if (doctor.Specializations.Any(n => commonSetOfDisease.Contains(n)))
//                 {
//                     var list = doctor.Specializations.ToList().Intersect(commonSetOfDisease).ToList();
//                     doctor.Specializations = list;
//                 }
//
//             for (var i = 0; i < rooms.Count; i++)
//             {
//                 var room = rooms[i];
//                 if (room.Certifications.Any(n => commonSetOfDisease.Contains(n)))
//                 {
//                     var list = room.Certifications.ToList().Intersect(commonSetOfDisease).ToList();
//                     room.Certifications = list;
//                 }
//
//                 if (room.Certifications.Any()) continue;
//                 rooms.Remove(room);
//                 i++;
//             }
//         }
//
//         //Get all specializations that are common part of all rooms and all doctors
//         private List<int> GetCommonSet()
//         {
//             var commonDoctors = new List<int>();
//             var commonRooms = new List<int>();
//             var hashSet = new HashSet<int>();
//
//             foreach (var n in doctors)
//                 commonDoctors.AddRange(n.Specializations.Where(x => hashSet.Add(x)));
//
//             hashSet.Clear(); //clear next itteration
//
//             foreach (var n in rooms)
//                 commonRooms.AddRange(n.Certifications.Where(x => hashSet.Add(x)));
//
//             return commonDoctors.Intersect(commonRooms).ToList();
//         }
//     }
// }

