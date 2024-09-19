using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoTiposDelito
    {
        Task<List<Tiposdelito>> ListarTiposdelitos();

        Task<Tiposdelito> BuscarTiposdelitos(int ID);

        Task<Tiposdelito> CrearTiposdelitos(Tiposdelito tiposdelito);

        Task<Tiposdelito> EditarTiposdelitos(Tiposdelito tiposdelito);

        Task BorrarTiposdelitos(Tiposdelito tiposdelito);
    }
}
