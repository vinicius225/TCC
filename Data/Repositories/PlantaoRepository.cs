
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class PlantaoRepository : RepositoryBase<Plantao>, IPlantaoRepository
    {
        private readonly AppDbContext _appDbContext;
        public PlantaoRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public IEnumerable<Plantao> GetPlantao(int id)
        {
            var plantao = _appDbContext.Plantaos.Where(a=> a.id== id).ToList();
            foreach(var item in plantao)
            {
                item.Medicos = _appDbContext.Medico.Where(b=> b.id == item.id).FirstOrDefault();
                
            }
            return plantao;
        }
    }
}
