using HNGxVideoStreaming.Models;
using Microsoft.EntityFrameworkCore;

namespace HNGxVideoStreaming.Data
{
    public class VideoSteamApiDbContext : DbContext
    {
        public VideoSteamApiDbContext(DbContextOptions<VideoSteamApiDbContext> options) : base(options)
        {
        }

        public DbSet<UploadContext> UploadContexts { get; set; }
        public DbSet<TranscribeData> TranscribeDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadContext>()
                .HasMany(p => p.TranscribedData)
                .WithOne(x => x.UploadContext)
                .HasForeignKey(x => x.UploadKeyId);

        }
    }
}
