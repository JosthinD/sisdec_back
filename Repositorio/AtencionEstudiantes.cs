using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entities
{
    public class AtencionEstudiantes
    {
        public int Id { get; set; }
        public string? Programa { get; set; }
        public string? Director { get; set; }
        public string? Modulo { get; set; }
        public string? Fecha { get; set; }
        public string? Hora { get; set; }
        public string? Semestre { get; set; }
        public string? Grupo { get; set; }
        public string? Jornada { get; set; }
        public string? Motivo { get; set; }
        public string? Observaciones { get; set; }
        public string? AprobacionEstudiante { get; set; }
        public int IdUsuario { get; set; }
    }
}
