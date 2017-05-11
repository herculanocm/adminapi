using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Sessoes")]
    public class Sessao
    {
        [Key]
        public string Chave { get; set; }
        public string LoginUsuario { get; set; }
        public Nullable<System.DateTime> Inicio { get; set; }
        public Nullable<System.DateTime> Fim { get; set; }

        [ForeignKey("Usuario")]
        public string Login { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}