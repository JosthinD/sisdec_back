using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO
{
    public class NewSoporteDto
    {
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
    }
}
