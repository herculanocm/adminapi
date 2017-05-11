using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Perfis")]
    public class Perfil
    {
        [Key]
        public string Role { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}