using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IDelitosService
    {
        Task<List<DelitosDTO>> Lista();
        Task<DelitosDTO> Buscar(int id);

        Task<string> Guardar(DelitosDTO delitos);

        Task<string> Editar(DelitosDTO delitos, int id);

        Task<string> Eliminar(int id);
    }
}
