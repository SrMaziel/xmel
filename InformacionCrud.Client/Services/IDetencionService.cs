using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IDetencionService
    {
        Task<List<DetencionesDTO>> Lista();
    }
}
