using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Main;
using Aplicacion.DTO;
using Repositorio.Entities;
using Swashbuckle.AspNetCore.Annotations;

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
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _usersAplication.GetAllUsers();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("CreateNewUser")]
        [SwaggerOperation(Summary = "Crear un nuevo usuario", Description = "Crea un nuevo usuario en el sistema. " +
            "El atributo Id no debe ser proporcionado en el cuerpo de la solicitud ya que es generado automáticamente.")]
        public async Task<IActionResult> CreateNewUser([FromBody] Usuarios usuariosNuevo)
        {
            var result = await _usersAplication.CreateNewUser(usuariosNuevo);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("VerifyPasswordForUser")]
        public async Task<IActionResult> VerifyPasswordForUser(int userId, string contraseña)
        {
            var result = await _usersAplication.VerifyPasswordForUser(userId,contraseña);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("UpdateUserPassword")]
        public async Task<IActionResult> UpdateUserPassword(int userId, string contraseña)
        {
            var result = await _usersAplication.UpdateUserPassword(userId, contraseña);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("UpdateUserState")]
        public async Task<IActionResult> UpdateUserState(int userId, int nuevoEstadoId)
        {
            var result = await _usersAplication.UpdateUserState(userId, nuevoEstadoId);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPut("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(int userId, int nuevoRolId)
        {
            var result = await _usersAplication.UpdateUserRole(userId, nuevoRolId);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
