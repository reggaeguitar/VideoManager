namespace VideoManager.EntityFramework
{
    using System;
    using System.Data.Entity;

    public partial class VideoManagerContext : DbContext, IDisposable, IVideoManagerContext
    {
        public VideoManagerContext(string connStrName)
            : base("name=" + connStrName)
        { }        

        public virtual IDbSet<Actor> Actor { get; set; }
        public virtual IDbSet<Tag> Tag { get; set; }
        public virtual IDbSet<Video> Video { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Video)
                .WithMany(e => e.Actor)
                .Map(m => m.ToTable("ActorVideo").MapLeftKey("ActorId").MapRightKey("VideoId"));

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Video)
                .WithMany(e => e.Tag)
                .Map(m => m.ToTable("TagVideo").MapLeftKey("TagId").MapRightKey("VideoId"));
        }
    }
}
