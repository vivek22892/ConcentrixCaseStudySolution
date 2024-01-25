using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Concentrix.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
       
        private readonly ILogger<LoginController> _logger;
        private readonly IAuthenticateService _authService;

        public LoginController(ILogger<LoginController> logger, IAuthenticateService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost(Name = "Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody] Login login)
        {
            _logger.LogDebug("Authenticate user");
            try
            {
                JwtToken response = _authService.AuthenticateUser(new User());
                return Ok(response);
            }
            catch (Exception ex)
            {
               return BadRequest("Failed Authenticate" + ex.Message);
            }
        }
    }
}
