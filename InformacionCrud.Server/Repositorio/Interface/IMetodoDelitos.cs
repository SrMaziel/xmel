using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoDelitos
    {
        Task<List<Delito>> ListarDelitos();
    }
}
