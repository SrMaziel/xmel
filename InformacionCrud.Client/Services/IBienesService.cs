using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IBienesService
    {
        Task<List<BienesDTO>> Lista();

        Task<BienesDTO> Buscar(int id);

        Task<string> Guardar(BienesDTO bienes);

        Task<string> Editar(BienesDTO bienes, int id);

        Task<string> Eliminar(int id);
    }
}
