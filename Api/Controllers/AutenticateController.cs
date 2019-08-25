using Entity.Request;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/Autenticate")]
    [ApiController]
    public class AutenticateController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public AutenticateController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        [Route("GetAutenticate")]
        public async Task<IActionResult> UserAppFindById([FromBody] Login login)
        {
            try
            {
                var aut = await _loginServices.AsyncAutenticateUser(login);
                return Ok(aut);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}