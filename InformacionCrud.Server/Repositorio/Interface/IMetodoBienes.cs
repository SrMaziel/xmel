using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoBienes
    {
        Task<List<Biene>> ListarBienes();
        Task<Biene> BuscarBienes(int ID);

        Task<Biene> CrearBienes(Biene biene);

        Task<Biene> EditarBienes(Biene biene);

        Task BorrarBienes(Biene biene);
    }
}
