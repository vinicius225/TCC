using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class UnidadeDTO : IDTO<UnidadeSaude>
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string telefone { get; set; }


        public void Get(UnidadeSaude obj)
        {
            this.id = obj.id;
            this.nome = obj.nome;
            this.cnpj = obj.cnpj;
            this.endereco = obj.endereco;
            this.numero = obj.numero;
            this.telefone = obj.telefone;
        }

        public void Set(UnidadeSaude obj)
        {
            obj.id = this.id;
            obj.nome = this.nome;
            obj.cnpj = this.cnpj;
            obj.endereco = this.endereco;
            obj.numero = this.numero;
            obj.telefone = this.telefone;

        }
    }
}
