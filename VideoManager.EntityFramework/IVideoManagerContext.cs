using System;
using System.Data.Entity;

namespace VideoManager.EntityFramework
{
    public interface IVideoManagerContext : IDisposable
    {
        IDbSet<Actor> Actor { get; set; }
        IDbSet<Tag> Tag { get; set; }
        IDbSet<Video> Video { get; set; }
        Database Database { get; }
        int SaveChanges();
        void SetModified(object entity);
    }
}
