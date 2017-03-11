using System.Collections.Generic;
using VideoManagerDomain;

namespace VideoServices
{
    public interface IVideoRepository
    {
        void CreateVideo(string connStrName, VideoDto videoDto);
        ICollection<VideoDto> LoadAllVideos(string connStrName);
        VideoDto LoadVideo(string connStrName, int videoId);
        void EditVideo(string connStrName, VideoDto videoDto);
        void DeleteVideo(string connStrName, int videoId);
        void IncrementVisitCount(string connStrName, int videoId);
    }
}
