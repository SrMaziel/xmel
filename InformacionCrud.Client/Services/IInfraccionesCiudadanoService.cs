using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IInfraccionesCiudadanoService
    {
        Task<List<InfraccionesCiudadanoDTO>> Lista();

        Task<InfraccionesCiudadanoDTO> Buscar(int id);

        Task<string> Guardar(InfraccionesCiudadanoDTO infraccionesciudadano);

        Task<string> Editar(InfraccionesCiudadanoDTO infraccionesciudadano, int id);

        Task<string> Eliminar(int id);
    }
}
