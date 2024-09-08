using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface INacionalidadService
    {
        Task<List<NacionalidadDTO>> Lista();
    }
}
