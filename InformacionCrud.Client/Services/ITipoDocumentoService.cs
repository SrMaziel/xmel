using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface ITipoDocumentoService
    {
        Task<List<TipodocumentoDTO>> Lista();
    }
}
