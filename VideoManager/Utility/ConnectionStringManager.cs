namespace VideoManager.Utility
{
    public class ConnectionStringManager : IConnectionStringManager
    {
        public string GetConnStrName()
        {
            return "VideoManagerContext";
        }
    }
}