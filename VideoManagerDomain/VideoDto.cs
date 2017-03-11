using System;
using System.Collections.Generic;

namespace VideoManagerDomain
{ 
    [Serializable]
    public class VideoDto
    {
        public ICollection<ActorDto> Actors { get; private set; }
        public DateTime DateAdded { get; private set; }
        public int VideoId { get; internal set; }
        //public File Image { get; private set; }
        public DateTime? LastVisited { get; private set; }
        public int Points { get; private set; }
        public string Title { get; private set; }
        public ICollection<TagDto> Tags { get; private set; }
        public string Url { get; private set; }
        public int VisitCount { get; private set; }

        public VideoDto(
            ICollection<ActorDto> actors,
            DateTime dateAdded,
            int videoId,
            DateTime? lastVisited,
            int points,
            string title,
            ICollection<TagDto> tags,
            string url,
            int visitCount)
        {
            Actors = actors;
            DateAdded = dateAdded;
            VideoId = videoId;
            LastVisited = lastVisited;
            Points = points;
            Title = title;
            Tags = tags;
            Url = url;
            VisitCount = visitCount;
        }
        
        public void IncrementVisitCount()
        {
            ++this.VisitCount;
        }    
    }
}