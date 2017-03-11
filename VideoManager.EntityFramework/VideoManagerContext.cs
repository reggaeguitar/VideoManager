namespace VideoManager.EntityFramework
{
    using System.Data.Entity;

    public partial class VideoManagerContext : DbContext
    {
        public VideoManagerContext()
            : base("name=VideoManagerContext")
        { }        

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Video> Video { get; set; }

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
