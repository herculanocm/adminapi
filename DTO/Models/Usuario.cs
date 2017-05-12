using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Perfil> Perfis { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}