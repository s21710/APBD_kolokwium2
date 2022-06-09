using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class MusicianDTO
    {

        public int IdMusician { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }


        public ICollection<TrackDTO> Musician_Track { get; set; }
    }
}
