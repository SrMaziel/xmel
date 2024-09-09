using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IFronteraSalvadoreñaService
    {
        Task<List<FronterasalvadoreñaDTO>> Lista();
    }
}
