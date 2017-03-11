﻿using System.Collections.Generic;
using VideoManager.Models;

namespace VideoServices
{
    public interface IVideoRepository
    {
        ICollection<Video> LoadAllVideos();
        void IncrementVisitCount(int videoId);
        void DeleteVideo(int videoId);
    }
}
