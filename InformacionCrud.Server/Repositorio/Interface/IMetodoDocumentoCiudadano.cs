using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoDocumentoCiudadano
    {
        Task<List<Documentosciudadano>> ListarDocumentos();

        Task<Documentosciudadano> BuscarDocumentos(int ID);

        Task<Documentosciudadano> CrearDocumentos(Documentosciudadano documentosciudadano);

        Task<Documentosciudadano> EditarDocumentos(Documentosciudadano documentosciudadano);

        Task BorrarDocumentos(Documentosciudadano documentosciudadano);
    }
}
