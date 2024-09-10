using InformacionCrud.Server.Models;

namespace InformacionCrud.Server.Repositorio.Interface
{
	public interface IMetodoVictima
	{

		Task<List<Victima>> ListarVictima();

		Task<Victima> BuscarVictima(int ID);

		Task<Victima> CrearVictima(Victima victima);

		Task<Victima> EditarVictima(Victima victima);

		Task BorrarVictima(Victima victima);


	}



}

