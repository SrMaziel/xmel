using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IInfraccionesService
    {
        Task<List<InfraccionesDTO>> Lista();

        Task<InfraccionesDTO> Buscar(int id);

        Task<string> Guardar(InfraccionesDTO infracciones);

        Task<string> Editar(InfraccionesDTO infracciones, int id);

        Task<string> Eliminar(int id);
    }
}
