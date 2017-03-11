using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VideoManager.Models;

namespace VideoServices
{
    public class VideoRepository : IVideoRepository
    {
        const string Path = @"C:\p\golfData.json";

        public void DeleteVideo(int videoId)
        {
            throw new NotImplementedException();
        }

        public void IncrementVisitCount(int videoId)
        {
            var videos = LoadAllVideos();
            var vid = videos.Single(x => x.Id == videoId);
            vid.IncrementVisitCount();
            WriteVideos(videos.ToList());
        }        

        public ICollection<Video> LoadAllVideos()
        {
            var fileContents = File.ReadAllText(Path);
            var videos = JsonConvert.DeserializeObject<List<Video>>(fileContents);
            return videos;
        }

        private void WriteVideos(List<Video> videos)
        {
            var json = JsonConvert.SerializeObject(videos);
            File.WriteAllText(Path, json);
        }
    }
}
