using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositorio.Entities
{
    [Table("USUARIO")]
    public class users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idusuario")]
        public int Id { get; set; }
        [Required]
        public string prinombre { get; set; }
        [Required]
        public string segnombre { get; set; }
        [Required]
        public string priapellido { get; set; }
        [Required]
        public string segapellido { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int idrol { get; set; }

        public int idgnero { get; set; }
        public string tipodocide { get; set; }
        [Required]
        public string nrodocide { get; set; }
        [Required]


    }

}