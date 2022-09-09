using CGAPI.Common;
using CGAPI.Sevices;
using CGAPI.VModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly CGDBContext _db;
  
        public PlaylistsController( CGDBContext db, IUserService userService)
        {
            _userService = userService;

            _db = db;
      
            
        }

        //[HttpGet("getAllPlaylists")]
        //public IActionResult GetAllPlaylists(int userId)
        //{
        //    var playlists = _db.CG_Playlists.Where(x => x.CGUserId == userId).Select(x => new PlaylistVM 
        //    { 
        //        Id = x.Id,
        //        Name = x.Name
        //    }).ToList();
        //    return Ok(playlists);
        //}
        //[HttpGet("getAllPlaylists")]
        //public IActionResult GetAllPlaylists(PlaylistVM playlist)
        //{
        //    //var playlists = _db.CG_Playlists.Where(x => x.CGUserId == userId).Select(x => new PlaylistVM
        //    //{
        //    //    Id = x.Id,
        //    //    Name = x.Name
        //    //}).ToList();
        //    return Ok();
        //}

        [Authorize]
        [HttpPost("setGameElement")]
        [Consumes("multipart/form-data")]
        public IActionResult SetGameElement([FromForm] MyGameElement myGameElement)
        {

            _db.CG_GameElements.Add(new CG_GameElement
            {
                CG_Image = new CG_Image { Img = FileManager.GetBytes(myGameElement.Img) },
                CG_Playlist = new CG_Playlist { CGUserId = /*_userService.CurrentUserId*/1, Name = "test", Type = GLOB.PlayListTypes.Public },
                CG_SoundWrongAnswer = new CG_Sound { Sound = FileManager.GetBytes(myGameElement.WrongAnswer) },
                CG_SoundCorrectAnswer = new CG_Sound { Sound = FileManager.GetBytes(myGameElement.CorrectAnswer) },
                CG_SoundQuestion = new CG_Sound { Sound = FileManager.GetBytes(myGameElement.Quest) },
            });

            _db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult PostTest(List<IFormFile> file)
        {

            var f = file.FirstOrDefault();
            if (f != null)
            {
                using (var ms = new MemoryStream())
                {
                    f.CopyTo(ms);
                    var fileBytes = ms.ToArray().Compress();


                    _db.CG_Sounds.Add(new CG_Sound
                    {
                        Sound = fileBytes
                    }) ;
                    _db.SaveChanges();                
                }
            }

           
            return Ok();
        }

      


    }
}
