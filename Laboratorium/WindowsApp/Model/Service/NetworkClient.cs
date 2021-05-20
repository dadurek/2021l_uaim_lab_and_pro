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
    using System.Net.Http;
    using Data;
    using Utilities;

    public class NetworkClient : IMatchData
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public MatchData[] GetMatchSelection()
        {
            const string callUri = "examination-rooms-selection";

            var matchData = serviceClient.CallWebService<MatchData[]>(HttpMethod.Get, callUri);

            return matchData;
        }
    }
}