using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoTipoDocumento
    {
        Task<List<Tipodocumento>> ListarTipoDocumento();
    }
}
