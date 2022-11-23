using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IEspecialidadeRepository : IRepositoryBase<Especialidade>
    {
        List<Medico> GetMedicosPorBuscaEspecialidade(string busca);
    }
}
