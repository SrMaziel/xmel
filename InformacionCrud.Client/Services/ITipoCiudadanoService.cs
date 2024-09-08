using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface ITipoCiudadanoService
    {
        Task<List<TiposciudadanoDTO>> Lista();
    }
}
