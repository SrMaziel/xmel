using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IArrestopolicialService
    {
        Task<List<ArrestopolicialoDTO>> Lista();

        Task<ArrestopolicialoDTO> Buscar(int id);

        Task<string> Guardar(ArrestopolicialoDTO arrestopolicialo);

        Task<string> Editar(ArrestopolicialoDTO arrestopolicialo, int id);

        Task<string> Eliminar(int id);
    }
}
