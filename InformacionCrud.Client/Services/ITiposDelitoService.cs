using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface ITiposDelitoService
    {
        Task<List<TiposdelitoDTO>> Lista();
       
        Task<TiposdelitoDTO> Buscar(int id);

        Task<string> Guardar(TiposdelitoDTO tiposdelito);

        Task<string> Editar(TiposdelitoDTO tiposdelito, int id);

        Task<string> Eliminar(int id);

    }
}
