using Aplicacion.DTO;
using Aplicacion.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Repositorio.Entities;
using Repositorio.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Aplicacion.Main
{
    public class DataAplication : IDataAplication
    {
        private readonly IDataRepository _dataRepository;
        private readonly IConfiguration _configuration;
        public DataAplication(IDataRepository _DataRepository, IConfiguration configuration)
        {
            _dataRepository = _DataRepository;
            _configuration = configuration;
        }
              
        public async Task<ResponseDto<List<Roles?>>> GetAllRoles()
        {
            var data = new ResponseDto<List<Roles>?> { Data = new List<Roles>() };
            try
            {
                var roles = await _dataRepository.GetAllRoles();
                if (!roles.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de roles a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Roles";
                data.Data = roles;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Roles" + ex.Message;
                data.Response = "500";
                return data;
            }
        }

        public async Task<ResponseDto<List<Generos?>>> GetAllGenres()
        {
            var data = new ResponseDto<List<Generos>?> { Data = new List<Generos>() };
            try
            {
                var generos = await _dataRepository.GetAllGenres();
                if (!generos.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de generos a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Roles";
                data.Data = generos;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de generos" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<TiposDocumento?>>> GetAllDocumentTypes()
        {
            var data = new ResponseDto<List<TiposDocumento>?> { Data = new List<TiposDocumento>() };
            try
            {
                var tipos = await _dataRepository.GetAllDocumentTypes();
                if (!tipos.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de tipos de documentos a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Tipos de Documentos";
                data.Data = tipos;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de tipos de documentos" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Estados?>>> GetAllStates()
        {
            var data = new ResponseDto<List<Estados>?> { Data = new List<Estados>() };
            try
            {
                var estados = await _dataRepository.GetAllStates();
                if (!estados.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de estados a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Estados";
                data.Data = estados;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de estados" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Logs?>>> GetAllLogs()
        {
            var data = new ResponseDto<List<Logs>?> { Data = new List<Logs>() };
            try
            {
                var logs = await _dataRepository.GetAllLogs();
                if (!logs.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "400";
                    data.Message = "Problemas en la consulta de logs a la base de datos.";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Logs";
                data.Data = logs;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Logs" + ex.Message;
                data.Response = "500";
                return data;
            }
        }
        public async Task<ResponseDto<List<Logs?>>> GetLogsByActionIdAndDate(int? idAccion, DateTime? fecha)
        {
            var data = new ResponseDto<List<Logs>?> { Data = new List<Logs>() };
            try
            {
                var logs = await _dataRepository.GetLogsByActionIdAndDate(idAccion,fecha);
                if (!logs.Any())
                {
                    data.IsSuccess = false;
                    data.Response = "200";
                    data.Message = "No hay datos con esos filtros";
                    return data;
                }

                data.IsSuccess = true;
                data.Response = "200";
                data.Message = "Logs";
                data.Data = logs;
                return data;
            }
            catch (Exception ex)
            {
                data.IsSuccess = false;
                data.Message = "Error: En consulta de Logs" + ex.Message;
                data.Response = "500";
                return data;
            }
        }

        public async Task<string> EncriptAsync(string data)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_configuration["Encrypt:Key"]);
            aesAlg.IV = Encoding.UTF8.GetBytes(_configuration["Encrypt:IV"]);

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            await swEncrypt.WriteAsync(data);
            swEncrypt.Flush(); // Asegurarse de que los datos se escriben completamente
            csEncrypt.FlushFinalBlock(); // Asegurarse de que los datos se cifran completamente
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        public async Task<string> DecriptAsync(string data)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_configuration["Encrypt:Key"]);
            aesAlg.IV = Encoding.UTF8.GetBytes(_configuration["Encrypt:IV"]);

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using var msDecrypt = new MemoryStream(Convert.FromBase64String(data));
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return await srDecrypt.ReadToEndAsync();
        }
    }
}