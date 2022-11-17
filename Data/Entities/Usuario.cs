using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("usuario")]
    public class Usuario : IEntityBase
    {
        public string nome { get; set; }
        public string email { get; set; }
        public char sexo { get; set; }
        public string senha { get; set; }
        public int id_perfil { get; set; }

        [ForeignKey("id_perfil")]
        public virtual Perfil? Perfil { get; set; }
    }
}
