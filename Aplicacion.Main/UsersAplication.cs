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
        private readonly IDataAplication _dataAplication;
        public UserAplication(IUsersRepository _UserRepository, ILoginRepository _LoginRepository, IDataRepository _DataRepository, IDataAplication dataAplication)
        {
            _usersRepository = _UserRepository;
            _loginRepository = _LoginRepository;
            _dataRepository = _DataRepository;
            _dataAplication = dataAplication;
        }
        
        public async Task<ResponseDto<UsuariosDto?>> GetAllDataUser(string email)
        {
            var data = new ResponseDto<UsuariosDto?> { Data = new UsuariosDto() };
            try
            {
                email = await _dataAplication.EncriptAsync(email);
                bool existe = await _loginRepository.GetExistUser(email);
                if (!existe)
                {
                    data.IsSuccess = existe;
                    data.Response = "400";
                    data.Message = "No existe el usuario.";
                    return data;
                }
                
                var user = await _usersRepository.GetAllDataUser(email);

                user.PrimerNombre = await _dataAplication.DecriptAsync(user.PrimerNombre);
                user.SegundoNombre = await _dataAplication.DecriptAsync(user.SegundoNombre);
                user.PrimerApellido = await _dataAplication.DecriptAsync(user.PrimerApellido);
                user.SegundoApellido = await _dataAplication.DecriptAsync(user.SegundoApellido);
                user.NumeroDocumento = await _dataAplication.DecriptAsync(user.NumeroDocumento);
                user.Telefono = await _dataAplication.DecriptAsync(user.Telefono);
                user.Correo = await _dataAplication.DecriptAsync(user.Correo);
                user.Contraseña = await _dataAplication.DecriptAsync(user.Contraseña);

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Datos Correctos.";
                data.Data = user;                
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
                usuarioActualizado.PrimerNombre = await _dataAplication.EncriptAsync(usuarioActualizado.PrimerNombre);
                usuarioActualizado.SegundoNombre = await _dataAplication.EncriptAsync(usuarioActualizado.SegundoNombre);
                usuarioActualizado.PrimerApellido = await _dataAplication.EncriptAsync(usuarioActualizado.PrimerApellido);
                usuarioActualizado.SegundoApellido = await _dataAplication.EncriptAsync(usuarioActualizado.SegundoApellido);
                usuarioActualizado.Telefono = await _dataAplication.EncriptAsync(usuarioActualizado.Telefono);
                usuarioActualizado.Correo = await _dataAplication.EncriptAsync(usuarioActualizado.Correo);

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
                foreach (var usuario in usuarios)
                {
                    usuario.PrimerNombre = await _dataAplication.DecriptAsync(usuario.PrimerNombre);
                    usuario.SegundoNombre = await _dataAplication.DecriptAsync(usuario.SegundoNombre);
                    usuario.PrimerApellido = await _dataAplication.DecriptAsync(usuario.PrimerApellido);
                    usuario.SegundoApellido = await _dataAplication.DecriptAsync(usuario.SegundoApellido);
                    usuario.NumeroDocumento = await _dataAplication.DecriptAsync(usuario.NumeroDocumento);
                    usuario.Telefono = await _dataAplication.DecriptAsync(usuario.Telefono);
                    usuario.Correo = await _dataAplication.DecriptAsync(usuario.Correo);
                    usuario.Contraseña = await _dataAplication.DecriptAsync(usuario.Contraseña);
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
                usuarioNuevo.PrimerNombre = await _dataAplication.EncriptAsync(usuarioNuevo.PrimerNombre);
                usuarioNuevo.SegundoNombre = await _dataAplication.EncriptAsync(usuarioNuevo.SegundoNombre);
                usuarioNuevo.PrimerApellido = await _dataAplication.EncriptAsync(usuarioNuevo.PrimerApellido);
                usuarioNuevo.SegundoApellido = await _dataAplication.EncriptAsync(usuarioNuevo.SegundoApellido);
                usuarioNuevo.NumeroDocumento = await _dataAplication.EncriptAsync(usuarioNuevo.NumeroDocumento);
                usuarioNuevo.Telefono = await _dataAplication.EncriptAsync(usuarioNuevo.Telefono);
                usuarioNuevo.Correo = await _dataAplication.EncriptAsync(usuarioNuevo.Correo);
                usuarioNuevo.Contraseña = await _dataAplication.EncriptAsync(usuarioNuevo.Contraseña);

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
                contraseña = await _dataAplication.EncriptAsync(contraseña);
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
                nuevaContraseña = await _dataAplication.EncriptAsync(nuevaContraseña);
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