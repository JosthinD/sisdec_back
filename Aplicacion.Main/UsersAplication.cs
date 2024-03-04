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
    }
}