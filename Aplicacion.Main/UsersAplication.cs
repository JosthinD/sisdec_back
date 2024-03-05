using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;
using Repositorio.Repositorio;

namespace Aplicacion.Main
{
    public class UserAplication : IUsersAplication
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IDataRepository _dataRepository;
        public UserAplication(IUsersRepository _UserRepository, ILoginRepository _LoginRepository, IDataRepository _DataRepository)
        {
            _usersRepository = _UserRepository;
            _loginRepository = _LoginRepository;
            _dataRepository = _DataRepository;
        }
        
        public async Task<ResponseDto<UsuariosDto?>> GetAllDataUser(string email)
        {
            var data = new ResponseDto<UsuariosDto?> { Data = new UsuariosDto() };
            try
            {
                bool existe = await _loginRepository.GetExistUser(email);
                if (!existe)
                {
                    data.IsSuccess = existe;
                    data.Response = "400";
                    data.Message = "No existe el usuario.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Datos Correctos.";
                data.Data = await _usersRepository.GetAllDataUser(email);
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> UpdateUserData(UpdateUserDataDto usuarioActualizado)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var status = await _usersRepository.UpdateUserData(usuarioActualizado);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Usuario no existe, no se actualizaron datos.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs { 
                                IdAccion = 5,
                                Descripcion =string.Format("Se realizo actualización de datos del usuario con ID = {0}", usuarioActualizado.IdUser) 
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Actualizacion Completada.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<UsuariosDto>>> GetAllUsers()
        {
            var data = new ResponseDto<List<UsuariosDto>> { Data = new List<UsuariosDto>() };
            try
            {
                var usuarios = await _usersRepository.GetAllUsers();
                if (!usuarios.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problema no se puede consultar los datos de los usuarios.";
                    return data;
                }                
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Todos los usuarios.";
                data.Data = usuarios;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> CreateNewUser(Usuarios usuarioNuevo)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                bool existe = await _loginRepository.GetExistUser(usuarioNuevo.Correo);
                if (existe)
                {
                    data.IsSuccess = !existe;
                    data.Response = "400";
                    data.Message = "Usuario ya creado, no se agregraron los datos.";
                    return data;
                }
                var status = await _usersRepository.CreateNewUser(usuarioNuevo);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Problema al agregar usuario.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs
                    {
                        IdAccion = 1,
                        Descripcion = string.Format("Se Agrego nuevo usuario con numero de identificación {0}", usuarioNuevo.NumeroDocumento)
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Usuario Agregado.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> VerifyPasswordForUser(int userId, string contraseña)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var status = await _usersRepository.VerifyPasswordForUser(userId, contraseña);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "200";
                    data.Message = "Problema no coincide la contraseña.";
                    return data;
                }               
                data.IsSuccess = status;
                data.Response = "200";
                data.Message = "Contraseña correcta.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> UpdateUserPassword(int userId, string nuevaContraseña)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var status = await _usersRepository.UpdateUserPassword(userId, nuevaContraseña);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Usuario no existe, no se actualizo contraseña.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs
                    {
                        IdAccion = 5,
                        Descripcion = string.Format("Se realizo actualización de contraseña del usuario con ID = {0}", userId)
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Actualizacion Completada.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> UpdateUserState(int userId, int nuevoEstadoId)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var status = await _usersRepository.UpdateUserState(userId, nuevoEstadoId);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Usuario no existe, no se actualizo estado.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs
                    {
                        IdAccion = 5,
                        Descripcion = string.Format("Se realizo actualización de estado al usuario con ID = {0}", userId)
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Actualizacion Completada.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<bool>> UpdateUserRole(int userId, int nuevoRolId)
        {
            var data = new ResponseDto<bool> { Data = false };
            try
            {
                var status = await _usersRepository.UpdateUserRole(userId, nuevoRolId);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "Usuario no existe, no se actualizo rol.";
                    return data;
                }
                var log = await _dataRepository.AddNewLog(
                    new Logs
                    {
                        IdAccion = 5,
                        Descripcion = string.Format("Se realizo actualización de rol al usuario con ID = {0}", userId)
                    });
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Actualizacion Completada.";
                data.Data = status;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: " + ex.Message;
                data.Response = "500";
                return data;
            }
        }
    }
}