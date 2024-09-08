using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoDetenciones
    {
        Task<List<Detencione>> ListarDetenciones();
    }
}
