using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoAntecedenteCiudadano
    {
        Task<List<Antecedentesciudadano>> ListarAntecedenteCiudadano();

        Task<List<Antecedentesciudadano>> ListarAntecedentesPorBusqueda(string datos);

        Task<Antecedentesciudadano> BuscarAntecedenteCiudadano(int ID);

        Task<Antecedentesciudadano> CrearAntecedenteCiudadano(Antecedentesciudadano antecedentesciudadano);

        Task<Antecedentesciudadano> EditarAntecedenteCiudadano(Antecedentesciudadano antecedentesciudadano);

        Task BorrarAntecedenteCiudadano(Antecedentesciudadano antecedentesciudadano);
    }
}
