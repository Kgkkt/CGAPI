using CGAPI.VModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CGAPI.Sevices
{
    public class UserService : IUserService
    {


        public int CurrentUserId { get; private set; }

        

        public UserService(IHttpContextAccessor iHttpContextAccessor)
        {            
            var user = iHttpContextAccessor.HttpContext?.User;

            if (user != null && user.FindFirstValue("Id") != null)
            {               
                var isParsed = int.TryParse( user.FindFirst("Id").Value, out int currentUserId);

                if (isParsed)
                {
                    CurrentUserId = currentUserId;
                }
            }

        }
    }
}
