using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IDocumentoCiudadanoService
    {
        Task<List<DocumentoCiudadanoDTO>> Lista();

        Task<DocumentoCiudadanoDTO> Buscar(int id);

        Task<string> Guardar(DocumentoCiudadanoDTO documentociudadano);

        Task<string> Editar(DocumentoCiudadanoDTO documentociudadano, int id);

        Task<string> Eliminar(int id);
    }
}
