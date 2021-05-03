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

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;
  using Logic.Model.Data;

  public class FakeMatchDataClient : IMatchData
  {

      private static readonly MatchData[] matchDataList = new MatchData[]
    {
        new MatchData( ) { DoctorName = "Marcin", RoomNumber = "99"},
        new MatchData( ) { DoctorName = "Maciej", RoomNumber = "88"}
    };


    public MatchData[] GetMatchSelection()
    {
        return FakeMatchDataClient.matchDataList;
    }
  }
}
