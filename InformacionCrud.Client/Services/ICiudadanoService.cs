using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface ICiudadanoService
    {
        Task<List<CiudadanoDTO>> Lista();

        Task<CiudadanoDTO> Buscar(int id);

        Task<string> Guardar(CiudadanoDTO ciudadano);

        Task<string> Editar(CiudadanoDTO ciudadano, int id);

        Task<string> Eliminar(int id);
    }
}
