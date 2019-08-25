using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/UserApp")]
    [ApiController]
    public class UserAppController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserAppController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Consulta el usuario por id
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns>UserApp</returns>
        [HttpGet]
        [Route("UserAppFindById")]
        public async Task<IActionResult> UserAppFindById([FromQuery] Guid id)
        {
            try
            {
                var user = await _userServices.UsertFinById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}