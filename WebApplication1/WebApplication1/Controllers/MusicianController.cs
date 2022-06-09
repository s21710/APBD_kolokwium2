using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        _Context context;

        public MusicianController(_Context context)
        {
            this.context = context;
        }


        [HttpGet("{IdMusician}")]
        public async Task<IActionResult> MusicianInActionList(int IdMusician)
        {
            if(!context.Musicians.Where(e=> e.IdMusician == IdMusician).Any())
            {
                return BadRequest("nie ma muzyka o danym id w bazie");
            }

            MusicianDTO author = await context.Musicians.Include(e => e.Musician_Track)
                                                                                 .ThenInclude(e => e.Track_Navi)
                                                                                  .Where(e => e.IdMusician == IdMusician)
                                                                                   .Select(e => new MusicianDTO
                                                                                   {
                                                                                       IdMusician = e.IdMusician,
                                                                                       FirstName = e.FirstName,
                                                                                       LastName = e.LastName,
                                                                                       Musician_Track = e.Musician_Track.Select(e => new TrackDTO {
                                                                                           IdTrack = e.Track_Navi.IdTrack,
                                                                                           TrackName = e.Track_Navi.TrackName,
                                                                                           Duration = e.Track_Navi.Duration,
                                                                                           IdMusicAlbum = e.Track_Navi.IdMusicAlbum
                                                                                       }).OrderBy(e => e.Duration).ToList()
                                                                                   }).SingleAsync();

            return Ok(author);
        }
    }
}
