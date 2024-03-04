using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;

namespace Aplicacion.Main
{
    public class UpusersAplication : IUpusersAplication
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ILoginRepository _loginRepository;
        public UpusersAplication(IUsersRepository _UserRepository, ILoginRepository _LoginRepository)
        {
            _usersRepository = _UserRepository;
            _loginRepository = _LoginRepository;
        }

        public async Task<ResponseDto<users?>> GetAllDataUser(string email)
        {
            var data = new ResponseDto<users?> { Data = new users() };
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
    }
}
