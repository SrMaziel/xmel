using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IVictimaService
    {
        Task<List<VictimaDTO>> Lista();

        Task<VictimaDTO> Buscar(int id);

        Task<string> Guardar(VictimaDTO victima);

        Task<string> Editar(VictimaDTO victima, int id);

        Task<string> Eliminar(int id);
    }
}
