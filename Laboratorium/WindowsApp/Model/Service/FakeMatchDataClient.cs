//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace Model.Service
{
    using System.Collections.Generic;
    using Data;

    public class FakeMatchDataClient : IMatchData
    {
        private static readonly MatchData[] matchDataList =
        {
            new MatchData
            {
                doctor = new DoctorData
                {
                    FirstName = "Marcin", LastName = "Dadura", Sex = "male", Specializations = new List<int>
                    {
                        1, 2, 4
                    }
                },
                room = new ExaminationRoomData
                {
                    Number = "69b", Certifications = new List<int>
                    {
                        1, 2, 4
                    }
                }
            },
            new MatchData
            {
                doctor = new DoctorData
                {
                    FirstName = "Maciej", LastName = "Włodarczyk", Sex = "female", Specializations = new List<int>
                    {
                        1, 2, 3
                    }
                },
                room = new ExaminationRoomData
                {
                    Number = "69b", Certifications = new List<int>
                    {
                        1, 2, 5
                    }
                }
            }
        };


        public MatchData[] GetMatchSelection()
        {
            return matchDataList;
        }
    }
}