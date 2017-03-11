using System;
using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public class VideoDtoConverter : IVideoDtoConverter
    {
        public Video VideoDtoToVideo(VideoDto videoDto)
        {
            throw new NotImplementedException();
        }

        public VideoDto VideoToVideoDto(Video video)
        {
            throw new NotImplementedException();
        }
    }
}
