using System.Collections.Generic;
using VideoManager.Models;

namespace VideoServices
{
    public interface IVideoRepository
    {
        ICollection<Video> LoadAllVideos();
    }
}
