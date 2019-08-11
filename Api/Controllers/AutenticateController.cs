using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;

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
        public IActionResult UserAppFindById([FromBody] Login login)
        {
            try
            {
                var aut = _loginServices.AutenticateUser(login);
                return Ok(aut);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}