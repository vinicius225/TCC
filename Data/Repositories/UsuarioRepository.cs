
using Data.Entities;
using Data.Repositories.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;

namespace Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Usuario> GetAllUsuarioPerfil()
        {
            return _appDbContext.Usuario.Include(a => a.Perfil).ToList();
        }

        public Usuario GetUsuarioPerfil(int id)
        {
            return _appDbContext.Usuario.Include(a => a.Perfil).Where(b=> b.id == id).FirstOrDefault();

        }
    }
}
