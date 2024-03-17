using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entities
{
    public class PlanAccionAcademico
    {
        public int Id { get; set; }
        public string? Programa { get; set; }
        public string? Fecha { get; set; }
        public string? Director { get; set; }
        public string? FechaDos { get; set; }
        public string? Actividad { get; set; }
        public string? Descripcion { get; set; }
        public string? Duracion { get; set; }
        public string? Lugar { get; set; }
        public string? HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public string? Responsable { get; set; }
        public string? Participantes { get; set; }
        public string? Evidencias { get; set; }
        public int IdUsuario { get; set; }
    }
}
