using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MusicLabel
    {
        [Key]
        public int idMusicLabel { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        public virtual ICollection<Album> Albums { get; set; }
    }
}
