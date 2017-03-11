using System;
using System.Collections.Generic;

namespace VideoManager.Models
{
    [Serializable]
    public class Video
    {
        public ICollection<string> Actors { get; private set; }
        public DateTime DateAdded { get; private set; }
        public int Id { get; private set; }
        //public File Image { get; private set; }
        public DateTime LastVisited { get; private set; }
        public int Points { get; private set; }
        public string Title { get; private set; }
        public ICollection<string> Tags { get; private set; }
        public string Url { get; private set; }
        public int VisitCount { get; private set; }

        public Video(
            ICollection<string> actors,
            DateTime dateAdded,
            int id,
            DateTime lastVisited,
            int points,
            string title,
            ICollection<string> tags,
            string url,
            int visitCount)
        {
            Actors = actors;
            DateAdded = dateAdded;
            Id = id;
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