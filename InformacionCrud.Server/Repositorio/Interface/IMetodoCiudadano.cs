using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoCiudadano
    {
        Task<List<Ciudadano>> ListarCiudadanos();

        Task<Ciudadano> BuscarCiudadano(int ID);
        
        Task<Ciudadano> CrearCiudadano(Ciudadano ciudadano);

        Task<Ciudadano> EditarCiudadano(Ciudadano ciudadano);

        Task BorrarCiudadano(Ciudadano ciudadano);
    }
}
