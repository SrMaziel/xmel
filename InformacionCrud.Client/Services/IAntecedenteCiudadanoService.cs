using InformacionCrud.Shared;

namespace InformacionCrud.Client.Services
{
    public interface IAntecedenteCiudadanoService
    {
        Task<List<AntecentesciudadanoDTO>> Lista();

        Task<List<AntecentesciudadanoDTO>> Busqueda(string data);

        Task<AntecentesciudadanoDTO> Buscar(int id);

        Task<string> Guardar(AntecentesciudadanoDTO antecentesciudadano);

        Task<string> Editar(AntecentesciudadanoDTO antecentesciudadano, int id);

        Task<string> Eliminar(int id);
    }
}
