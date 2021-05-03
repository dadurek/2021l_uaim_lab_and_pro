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

  using System.Net.Http;
  using ZsutPw.Patterns.WindowsApplication.Logic.Model.Data;

  public class NetworkClient : IMatchData
  {
    private readonly ServiceClient serviceClient;

    public NetworkClient( string serviceHost, int servicePort )
    {
        this.serviceClient = new ServiceClient( serviceHost, servicePort );
    }

        public MatchData[] GetMatchSelection()
        {
            string callUri = "examination-rooms-selection";
            var roomsSelectionDict = this.serviceClient.CallWebService<Dictionary<string, string>>(HttpMethod.Get, callUri);
            MatchData[] rooms = new MatchData[roomsSelectionDict.Count];
            int i = 0;
            foreach (string doctorName in roomsSelectionDict.Keys)
            {
                rooms[i] = new MatchData(doctorName, roomsSelectionDict[doctorName]);
                i++;
            }
            return rooms;
        }
    }
}
