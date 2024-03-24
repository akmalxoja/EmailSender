using EmailSender.Application.Services.AuthService;
using EmailSender.Domain.Entites.Models.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.API.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IAuthService _authService;

        public IdentityController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var result = _authService.GenerateToken(user);
            return Ok(result);
        }

    }
}
