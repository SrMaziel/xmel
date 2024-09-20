using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IPenaImpuestaService
    {
        Task<List<PenaimpuestaDTO>> Lista();

        Task<PenaimpuestaDTO> Buscar(int id);

        Task<string> Guardar(PenaimpuestaDTO penaimpuesta);

        Task<string> Editar(PenaimpuestaDTO penaimpuesta, int id);

        Task<string> Eliminar(int id);
    }
}
