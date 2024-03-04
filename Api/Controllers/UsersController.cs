using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Main;
using Aplicacion.DTO;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersAplication _usersAplication;

        public UsersController(IUsersAplication usersAplication)
        {
            _usersAplication = usersAplication;
        }

        [HttpGet("GetAllDataUser")]
        public async Task<IActionResult> GetAllDataUser(string email)
        {
            var result = await _usersAplication.GetAllDataUser(email);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("PutDataUser")]
        public async Task<IActionResult> PutDataUser([FromBody] UpdateUserDataDto usuarioActualizado)
        {
            var result = await _usersAplication.UpdateUserData(usuarioActualizado);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
