using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entities
{
    [Table("LOGS")]
    public class Logs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? IdAccion { get; set; }
        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }
        [Required]
        public DateTime? DateLog { get; set; }
    }
}
