
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class EspecialidadeDTO : IDTO<Especialidade>
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }

        public void Get(Especialidade obj)
        {
            this.id = obj.id;
            this.nome = obj.nome;
            this.descricao = obj.descricao;
        }

        public void Set(Especialidade obj)
        {
            obj.id = this.id;
            obj.nome = this.nome;
            obj.descricao = this.descricao;
          //  obj.editado = DateTime.Now.ToLocalTime();
        }
    }
}
