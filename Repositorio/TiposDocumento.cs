using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entities
{
    [Table("TIPOSDOCUMENTO")]
    public class TiposDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? TipoDocumento { get; set; }
        [Required]
        [StringLength(5)]
        public string? Abreviacion { get; set; }
    }
}
