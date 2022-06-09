using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTO
{
    public class TrackDTO
    {
        public int IdTrack { get; set; }
        public String TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
    }
}
