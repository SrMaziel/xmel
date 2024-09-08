using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IDenunciaService
    {
        Task<List<DenunciaDTO>> Lista();

        Task<DenunciaDTO> Buscar(int id);

        Task<string> Guardar(DenunciaDTO denuncia);

        Task<string> Editar(DenunciaDTO denuncia, int id);

        Task<string> Eliminar(int id);
    }
}
