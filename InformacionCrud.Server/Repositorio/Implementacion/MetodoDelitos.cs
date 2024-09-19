using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;


namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoDelitos : IMetodoDelitos
    {
        private readonly InformacionpublicaContext _context;

        public MetodoDelitos(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Delito>> ListarDelitos()
        {
            List<Delito> delitos = await _context.Delitos
                                                            .Include(TP => TP.TiposdelitosNavigation)
                                                            
                                                            .ToListAsync();

            return delitos;
        }
        public async Task<Delito> BuscarDelitos(int ID)
        {
            return await _context.Delitos.FindAsync(ID);
        }

        public async Task<Delito> CrearDelitos(Delito delito)
        {
            try
            {
                await _context.Delitos.AddAsync(delito);
                await _context.SaveChangesAsync();

                return delito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Delito> EditarDelitos(Delito delito)
        {
            try
            {
                _context.Delitos.Update(delito);
                await _context.SaveChangesAsync();

                return delito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarDelitos(Delito delito)
        {
            try
            {
                _context.Delitos.Remove(delito);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
