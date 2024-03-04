using Aplicacion.DTO;
using Repositorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    internal interface IUpusersAplications
    {
        Task<ResponseDto<users?>> PostAllDataUser(string prinombre, string segnombre, string priapellido, string segapellido, string telefono, string correo, string username, string password);
    }
}
