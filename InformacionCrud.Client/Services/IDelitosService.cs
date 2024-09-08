using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IDelitosService
    {
        Task<List<DelitosDTO>> Lista();
    }
}
