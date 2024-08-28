namespace BibliotecaMobile.Helpers
{
    public static class Conectividade
    {
        public static bool GetConnectivity()
        {
            bool isConnected = false;
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType == NetworkAccess.Internet)
            {
                isConnected = true;
            }

            return isConnected;
        }
    }
}
