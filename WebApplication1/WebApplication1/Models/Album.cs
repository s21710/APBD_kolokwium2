using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Album
    {
        public int Id_Album { get; set; }
        public String AlbumName{ get; set; }
        public DateTime PublishDate { get; set; }
        public int Id_MusicLabel { get; set; }
        public virtual MusicLabel MusicLabelNavi { get; set; }

    }
}
