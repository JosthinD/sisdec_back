using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entities
{
    public class PracticaPorAsignatura
    {
        public int Id { get; set; }
        public string? Programa { get; set; }
        public string? Director { get; set; }
        public string? Semestre { get; set; }
        public string? NombrePractica { get; set; }
        public string? NumeroPractica { get; set; }
        public string? Lugar { get; set; }
        public string? Horas { get; set; }
        public string? Observaciones { get; set; }
        public string? Introduccion { get; set; }
        public string? ObjetivoGeneral { get; set; }
        public string? ObjetivosEspecificos { get; set; }
        public string? EvidenciasActividades { get; set; }
        public string? ObjetosUsados { get; set; }
        public string? ResultadoAprendizaje { get; set; }
        public string? EvaluacionPractica { get; set; }
        public int IdUsuario { get; set; }
    }
}
