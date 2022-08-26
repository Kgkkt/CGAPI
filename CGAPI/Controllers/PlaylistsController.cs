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
        private readonly UserService _userService;
        private readonly CGDBContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PlaylistsController(IWebHostEnvironment webHostEnvironment, CGDBContext db, UserService userService)
        {
            _userService = userService;

            _db = db;
            _webHostEnvironment = webHostEnvironment;
            
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
                CG_Playlist = new CG_Playlist { CGUserId = _userService.CurrentUserId, Name = "test", Type = GLOB.PlayListTypes.Public },
                CG_SoundAnswer = new CG_Sound { Sound = FileManager.GetBytes(myGameElement.Answer) },
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

        [HttpGet("getSound")]
        public IActionResult GetSound(int id)
        {
            var arr = _db.CG_Sounds.First().Sound.Decompress();       
            return Ok(arr);
        }


        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok(561324);
        }


    }
}
