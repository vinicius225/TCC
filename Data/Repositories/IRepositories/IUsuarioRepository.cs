using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        List<Usuario> GetAllUsuarioPerfil();
        Usuario GetUsuarioPerfil(int id);
    }
}
