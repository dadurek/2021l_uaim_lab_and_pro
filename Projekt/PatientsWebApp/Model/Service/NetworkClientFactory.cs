namespace Model.Service
{
    using Configuration;

    public static class NetworkClientFactory
    {
        public static INetworkClient GetNetworkClient(ServiceConfiguration configuration)
        {
#if DEBUG
            return new NetworkClient(configuration);
            //return new FakeNetworkClient();
#else
            return new NetworkClient(configuration);
#endif
        }
    }
}