using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(20)]
        public String TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public int IdMusicAlbum { get; set; }

        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
