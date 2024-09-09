using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoInfracciones
    {
        Task<List<Infraccione>> ListarInfracciones();
    }
}
