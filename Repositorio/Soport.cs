using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorio.Entities
{
    [Table("SOPORTE")]
    public class soport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idcaso")]
        public int idcaso { get; set; }
        [Required]
        public string Asunto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Nrodocint { get; set; }
        [Required]
        public string Nomyape { get; set; }
        

    }

}
