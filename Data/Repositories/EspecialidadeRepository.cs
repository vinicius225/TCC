﻿using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EspecialidadeRepository : RepositoryBase<Especialidade>, IEspecialidadeRepository
    {
        readonly AppDbContext _appDbContext;
        public EspecialidadeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public List<Medico> GetMedicosPorBuscaEspecialidade(string? busca)
        {
            var result = _appDbContext.Medico.Where(a => a.nome.ToLower().Contains(busca.ToLower())).ToList();
            var medido_espec = _appDbContext.Especialidade.Where(b=> b.nome.ToLower().Contains(busca.ToLower())).Select(n=>( n.Medico).ToList());
            var busca_espec = _appDbContext.BuscaEspecialidade.Where(b=> b.descricao.ToLower().Contains(busca.ToLower())).Select(n=>( n.Especialidade.Medico).ToList());



            foreach (var medido in medido_espec)
            {
                result.AddRange(medido);
            }
            foreach (var busca_temp in busca_espec)
            {
                result.AddRange(busca_temp);
            }

            return result;
        }
    }
}
