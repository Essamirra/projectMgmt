namespace projman_client
{
    public class DataProviderFactory
    {
        private static IDataProvider _provider = new DataProvider();

        public static IDataProvider getDataProvider()
        {
            return _provider;
        }
    }
}