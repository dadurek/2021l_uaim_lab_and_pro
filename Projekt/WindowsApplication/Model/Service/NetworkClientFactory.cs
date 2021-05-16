namespace Model.Service
{
    public static class NetworkClientFactory
    {
        public static INetworkClient GetNetworkClient()
        {
#if DEBUG
            //return new FakeNetworkClient();
            const string serviceHost = "localhost";
            const int servicePort = 42070;
            return new NetworkClient(serviceHost, servicePort);
#else
            const string serviceHost = "localhost";
            const int servicePort = 42070;
            return new NetworkClient(serviceHost, servicePort);
#endif
        }
    }
}