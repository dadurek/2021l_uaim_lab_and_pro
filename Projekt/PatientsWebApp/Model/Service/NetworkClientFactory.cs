namespace Model.Service
{
    public static class NetworkClientFactory
    {
        public static INetworkClient GetNetworkClient()
        {
#if DEBUG
            return new FakeNetworkClient();
#else
            const string serviceHost = "patients-app";
            const int servicePort = 80;
            return new NetworkClient(serviceHost, servicePort);
#endif
        }
    }
}