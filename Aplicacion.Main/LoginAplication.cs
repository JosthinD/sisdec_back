using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Repositorio.Entities;
using Repositorio.Interfaces;
using Repositorio.Repositorio;

namespace Aplicacion.Main
{
    public class LoginAplication : ILoginAplication
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IDataAplication _dataAplication;
        public LoginAplication(ILoginRepository _LoginRepository, IDataAplication dataAplication)
        {
            _loginRepository = _LoginRepository;
            _dataAplication = dataAplication;
        }

        public async Task<ResponseDto<DataLogin>> GetLogin(string email, string password)
        {
            var data = new ResponseDto<DataLogin> { Data = new DataLogin() };
            try
            {
                string? emailEncript = await _dataAplication.EncriptAsync(email);
                string? passwordEncript = await _dataAplication.EncriptAsync(password);

                bool existe = await _loginRepository.GetExistUser(emailEncript);
                if (!existe)
                {
                    data.IsSuccess = existe;
                    data.Response = "400";
                    data.Message = "No existe el usuario.";
                    return data;
                }
                var status = await _loginRepository.GetCoincidenciaPassword(emailEncript, passwordEncript);
                if (!status)
                {
                    data.IsSuccess = status;
                    data.Response = "400";
                    data.Message = "No coincide la contraseña con el usuario.";
                    return data;
                }
                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Datos Correctos.";
                data.Data.Rol = await _loginRepository.GetRol(emailEncript);
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