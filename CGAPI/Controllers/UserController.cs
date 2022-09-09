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
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private CGDBContext _db;
        private JwtAuthenticationManager _jwtAuthenticationManager;

        public UserController(CGDBContext db, JwtAuthenticationManager jwtAuthenticationManager, IUserService userService)
        {
            _userService = userService;
            _db = db;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] CreateUserVM user)
        {
            _db.CGUsers.Add(new CGUser 
            { 
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            });

            _db.SaveChanges();
            return Ok();
        }



        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult AuthUser([FromBody] LoginUser user)
        {
            var dbUser = _db.CGUsers.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (dbUser == null)
            {
                return Unauthorized();
            }
            var token = _jwtAuthenticationManager.Authenticate(dbUser);
        

            return Ok(token);
        }

        [Authorize]
        [HttpGet("test123")]
        public IActionResult Test()
        {
            return Ok(_userService.CurrentUserId);
        }

    }
}
