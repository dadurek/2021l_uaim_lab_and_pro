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
    public static class NetworkClientFactory
    {
        public static IMatchData GetNetworkClient()
        {
#if DEBUG
            return new FakeMatchDataClient();
#else
            const string serviceHost = "localhost";
            const int servicePort = 44328;
            return new NetworkClient(serviceHost, servicePort);
#endif
        }
    }
}