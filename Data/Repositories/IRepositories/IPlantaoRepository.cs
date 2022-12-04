using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IPlantaoRepository : IRepositoryBase<Plantao>
    {
        IEnumerable<Plantao> GetPlantao(int id);
    }
}
