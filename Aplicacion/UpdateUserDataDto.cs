using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO
{
    public class UpdateUserDataDto
    {
        public int IdUser { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdGenero { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
