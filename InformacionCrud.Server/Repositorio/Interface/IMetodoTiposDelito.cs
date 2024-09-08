using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoTiposDelito
    {
        Task<List<Tiposdelito>> ListarTiposDelitos();
    }
}
