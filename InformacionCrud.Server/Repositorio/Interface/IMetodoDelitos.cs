using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoDelitos
    {
        Task<List<Delito>> ListarDelitos();
        Task<Delito> BuscarDelitos(int ID);

        Task<Delito> CrearDelitos(Delito delito);

        Task<Delito> EditarDelitos(Delito delito);

        Task BorrarDelitos(Delito delito);
    }
}
