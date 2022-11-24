using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UsuarioDTO : IDTO<Usuario>
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public char sexo { get; set; }
        public int id_perfil  { get; set; }

        public void Get(Usuario obj)
        {
            this.id = obj.id;
            this.nome = obj.nome;
            this.senha = obj.senha;
            this.sexo = obj.sexo;
            this.id_perfil = obj.id_perfil; 
            this.email = obj.email;
        }

        public void Set(Usuario obj)
        {
            obj.id = this.id;
            obj.nome = this.nome;
            obj.id_perfil = this.id_perfil;
            obj.senha = this.senha;
            obj.sexo = this.sexo;
            obj.email = this.email;
        }
    }
}
