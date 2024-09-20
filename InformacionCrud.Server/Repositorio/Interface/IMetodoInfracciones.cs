using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoInfracciones
    {
        Task<List<Infraccione>> ListarInfracciones();

        Task<Infraccione> BuscarInfracciones(int ID);

        Task<Infraccione> CrearInfracciones(Infraccione infraccione);

        Task<Infraccione> EditarInfracciones(Infraccione infraccione);

        Task BorrarInfracciones(Infraccione infraccione);
    }
}
