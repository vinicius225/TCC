using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IMedicoRepository : IRepositoryBase<Medico>
    {
        List<Medico> GetAllMedicoEspecialidade();
        Medico GetMedicoEspecialidade(int id);
    }
}
