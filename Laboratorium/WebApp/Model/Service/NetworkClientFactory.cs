namespace Model.Service
{
    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient()
        {
#if DEBUG
            /* AT
            const string serviceHost = "localhost";
            const int servicePort = 8081;
      
            return new NetworkClient( serviceHost, servicePort );
            */
            return new FakeNetworkClient();

#else
            const string serviceHost = "roomselector-app";
            const int servicePort = 80;

            return new NetworkClient( serviceHost, servicePort );

#endif
        }
    }
}