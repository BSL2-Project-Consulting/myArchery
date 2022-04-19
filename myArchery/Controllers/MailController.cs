using Microsoft.AspNetCore.Mvc;
using myArchery.Services;

namespace myArchery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly IMailService mailService;
        private Logger<MailController> _logger;

        public MailController(IMailService mailService, Logger<MailController> logger)
        {
            this.mailService = mailService;
            _logger = logger;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
