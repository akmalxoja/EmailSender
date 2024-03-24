using EmailSender.Application.Services.EmailService;
using EmailSender.Domain.Entites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm] EmailModel model)
        {
            

            await _emailService.SendEmailAsync(model);

            return Ok("Muvoffaqiyatli email yuborildi");
        }
    }
}
