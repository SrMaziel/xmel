using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
    public interface IMetodoArrestopolicial
    {
        Task<List<Arrestopolicial>> ListarArresto();
        
        Task<Arrestopolicial> BuscarArresto(int ID);

        Task<Arrestopolicial> CrearArresto(Arrestopolicial arrestopolicial);

        Task<Arrestopolicial> EditarArresto(Arrestopolicial arrestopolicial);

        Task BorrarArresto(Arrestopolicial arrestopolicial);
    }
}
