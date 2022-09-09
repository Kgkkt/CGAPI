using CGAPI.VModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private CGDBContext _db;

        public GameController(CGDBContext db)
        {
            _db = db;
        }

        [HttpPost("getGameElements")]
        public async Task<IActionResult> GetGameElements(GetGameElementsVM gameElementVM)
        {

            var allIds = await _db.CG_GameElements.
                Where(x => x.CG_PlaylistId == gameElementVM.PlayListId && !gameElementVM.CurrentGameElementIds.Contains(x.Id))
                .Select(x => x.Id).ToListAsync();

            var dandIds = allIds.OrderBy(x => Guid.NewGuid()).Take(gameElementVM.Count).AsEnumerable();

            var element = await _db.CG_GameElements
                .Where(x => dandIds.Contains(x.Id))                
                .Select(x => new GetGameElementsResultVM
                {
                    Img = x.CG_Image.Img.Decompress(),
                    SoundCorrectAnswerId = x.CG_SoundCorrectAnswerId,
                    SoundWrongAnswerId = x.CG_SoundWrongAnswerId,
                    SoundQuestId = x.CG_SoundQuestionId
                }).ToListAsync();

            return Ok(element);
        }

        [HttpGet("getSound")]
        public async Task<IActionResult> GetSound(int id)
        {
            var sound = ( await _db.CG_Sounds.FirstOrDefaultAsync(x => x.Id == id))?.Sound.Decompress();
            return Ok(sound);
        }
    }
}
