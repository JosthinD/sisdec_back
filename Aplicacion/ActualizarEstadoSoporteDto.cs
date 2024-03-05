using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO
{
    public class ActualizarEstadoSoporteDto
    {
        public int SoporteId { get; set; }
        public int NuevoEstadoId { get; set; }
    }
}
