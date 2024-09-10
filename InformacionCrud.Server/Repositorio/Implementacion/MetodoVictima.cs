using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
	public class MetodoVictima : IMetodoVictima
	
	{
		private readonly InformacionpublicaContext _context;

		public MetodoVictima(InformacionpublicaContext context)
		{
			_context = context;
		}

		public async Task<List<Victima>> ListarVictima()
		{
			List<Victima> victima = await _context.Victimas
													.Include(c => c.CiudadanoNavigation)
													
													.ToListAsync();

			return victima;
		}

		public async Task<Victima> BuscarVictima(int ID)
		{
			return await _context.Victimas.FindAsync(ID);
		}

		public async Task<Victima> CrearVictima(Victima victima)
		{
			try
			{
				await _context.Victimas.AddAsync(victima);
				await _context.SaveChangesAsync();

				return victima;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Victima> EditarVictima(Victima victima)
		{
			try
			{
				_context.Victimas.Update(victima);
				await _context.SaveChangesAsync();

				return victima;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task BorrarVictima(Victima victima)
		{ 
			try
			{
				_context.Victimas.Remove(victima);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

