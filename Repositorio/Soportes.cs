using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entities
{
    [Table("SOPORTES")]
    public class Soportes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Asunto { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int IdEstado { get; set; }
    }
}
