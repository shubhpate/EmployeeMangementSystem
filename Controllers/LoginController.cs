using Employee_Management_System.Model;
using Employee_Management_System.Repository;
using Employee_Management_System.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Management_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IAuthenticateService _auth;
        public LoginController(IAuthenticateService auth)
        {
         _auth = auth;
         
        }

       [HttpPost]
        public IActionResult loginAuth([FromBody] LoginEntity login)
        {
            var authenticatedUser = _auth.AuthenticateData(login.Username, login.Password);
            if (authenticatedUser == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            var token = _auth.GenerateToken(authenticatedUser);
            return Ok(new { token });
        }


    }
}
