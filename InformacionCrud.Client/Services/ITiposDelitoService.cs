using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface ITiposDelitoService
    {
        Task<List<TiposdelitoDTO>> Lista();
    }
}
