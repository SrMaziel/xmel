using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoInfraccionesCiudadano
    {
        Task<List<Infraccionesciudadano>> ListarInfracciones();

        Task<Infraccionesciudadano> BuscarInfracciones(int ID);

        Task<Infraccionesciudadano> CrearInfracciones(Infraccionesciudadano infraccionesciudadano);

        Task<Infraccionesciudadano> EditarInfracciones(Infraccionesciudadano infraccionesciudadano);

        Task BorrarInfracciones(Infraccionesciudadano infraccionesciudadano);
    }
}

