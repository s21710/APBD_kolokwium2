using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class _Context : DbContext

    {
        public _Context()
        {

        }

        public _Context(DbContextOptions<_Context> options) : base(options)
        {

        }

        public virtual DbSet<Track> Tracks { get; set; } 
        public virtual DbSet<Musician> Musicians { get; set; } 
        public virtual DbSet<Musician_Track> Musician_Tracks { get; set; } 
        public virtual DbSet<MusicLabel> MusicLabels { get; set; } 
        public virtual DbSet<Album> Albums { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s21710;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician_Track>(opt =>
            {
                opt.HasKey(e => new { e.Id_Track, e.Id_Musician });

                opt.Property(e => e.Id_Musician).IsRequired();
                opt.HasOne(e => e.MusicianNavi).WithMany(e => e.Musician_Track).HasForeignKey(e => e.Id_Musician);

                opt.Property(e => e.Id_Track).IsRequired();
                opt.HasOne(e => e.Track_Navi).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.Id_Track);
            });

            modelBuilder.Entity<Album>(opt =>
            {
                opt.HasKey(e => e.Id_Album);
                opt.Property(e => e.Id_Album).ValueGeneratedOnAdd();

                opt.Property(e => e.Id_MusicLabel).IsRequired();
                opt.HasOne(e => e.MusicLabelNavi).WithMany(e => e.Albums).HasForeignKey(e => e.Id_Album);

            });

            modelBuilder.Entity<Musician>(opt =>
            {
                opt.HasData(
                        new Musician { IdMusician = 1, FirstName = "Piotr", LastName = "Piskorski", Nickname="hutka"}
                );
            });
            modelBuilder.Entity<MusicLabel>(opt =>
            {
                opt.HasData(
                        new MusicLabel { idMusicLabel = 1, Name = "SoundCloud"}
                );
            });
            modelBuilder.Entity<Track>(opt =>
            {
                opt.HasData(
                        new Track { IdTrack = 1, TrackName = "hotel insomnia" , Duration = 2 , IdMusicAlbum = 2}
                );
            });
            modelBuilder.Entity<Musician_Track>(opt =>
            {
                opt.HasData(
                        new Musician_Track { Id_Musician = 1, Id_Track= 1 }
                );
            });
            modelBuilder.Entity<Album>(opt =>
            {
                opt.HasData(
                        new  Album{Id_Album = 1 ,AlbumName = "superalbum", PublishDate= new DateTime(2022, 06, 09, 0, 0, 0), Id_MusicLabel = 1 }
                );
            });
        }
    }
}
