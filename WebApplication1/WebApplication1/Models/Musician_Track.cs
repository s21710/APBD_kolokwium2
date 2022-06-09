using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Musician_Track
    {
        public int Id_Musician { get; set; }
        public virtual Musician MusicianNavi{ get; set; }
        public int Id_Track { get; set; }
        public virtual Track Track_Navi { get; set; }
    }
}
