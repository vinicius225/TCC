
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
