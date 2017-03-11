using System;

namespace VideoManager.EntityFramework
{
    public class VideoManagerContextFactory : IVideoManagerContextFactory
    {
        public IVideoManagerContext Create(string connStrName)
        {
            return new VideoManagerContext(connStrName);
        }
    }
}
