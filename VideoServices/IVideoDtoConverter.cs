using VideoManager.EntityFramework;
using VideoManagerDomain;

namespace VideoServices
{
    public interface IVideoDtoConverter
    {
        Video VideoDtoToVideo(VideoDto videoDto);
        VideoDto VideoToVideoDto(Video video);
    }
}