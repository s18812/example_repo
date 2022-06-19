using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qwe.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(100).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.Property(e => e.IdMusicLabel).IsRequired();

                e.ToTable("Album");

                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(100).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdMusicAlbum).IsRequired();

                e.ToTable("Track");

                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Cascade);
            });
            //
            modelBuilder.Entity<MusicianTrack>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.IdTrack).IsRequired();
                e.Property(e => e.IdMusician).IsRequired();

                e.ToTable("MusicianTrack");

                e.HasOne(e => e.Musician)
                .WithMany(e => e.MusiciansTrack)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(e => e.Track)
               .WithMany(e => e.MusiciansTrack)
               .HasForeignKey(e => e.IdTrack)
               .OnDelete(DeleteBehavior.Cascade);
            });
            //
            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                
                e.ToTable("MusicLabel");
            });

            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(100).IsRequired();

                e.ToTable("Musician");
            });

        }
    }
}
