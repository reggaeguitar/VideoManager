using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VideoManager.Models;

namespace VideoServices
{
    public class VideoRepository : IVideoRepository
    {
        public ICollection<Video> LoadAllVideos()
        {
            var path = @"C:\p\golfData3.json";
            var fileContents = File.ReadAllText(path);
            var videos = JsonConvert.DeserializeObject<List<Video>>(fileContents);
            return videos;
        }
    }
}
