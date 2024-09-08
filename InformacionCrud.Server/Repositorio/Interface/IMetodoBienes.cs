using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoBienes
    {
        Task<List<Biene>> ListarBienes();
    }
}
