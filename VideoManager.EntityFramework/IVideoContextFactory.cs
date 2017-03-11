namespace VideoManager.EntityFramework
{
    public interface IVideoManagerContextFactory
    {
        IVideoManagerContext Create(string connStrName);
    }
}