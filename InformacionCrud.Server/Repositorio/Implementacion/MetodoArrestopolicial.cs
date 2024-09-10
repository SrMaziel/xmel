using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoArrestopolicial : IMetodoArrestopolicial
    {
        private readonly InformacionpublicaContext _context;

        public MetodoArrestopolicial(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Arrestopolicial>> ListarArresto()
        {
            return await _context.Arrestopolicials
                                 .Include(c => c.CiudadanoNavigation)
                                 .Include(tp => tp.TipociudadanoNavigation)
                                 .Include(D => D.DelitosNavigation)
                                
                                 .Include(d=> d.DetencionesNavigation)
                                 .ToListAsync();
        }

        public async Task<Arrestopolicial> BuscarArresto(int ID)
        {
            return await _context.Arrestopolicials.FindAsync(ID);
        }

        public async Task<Arrestopolicial> CrearArresto(Arrestopolicial arrestopolicial)
        {
            try
            {
                await _context.Arrestopolicials.AddAsync(arrestopolicial);
                await _context.SaveChangesAsync();
                return arrestopolicial;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Arrestopolicial> EditarArresto(Arrestopolicial arrestopolicial)
        {
            try
            {
                _context.Arrestopolicials.Update(arrestopolicial);
                await _context.SaveChangesAsync();
                return arrestopolicial;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarArresto(Arrestopolicial arrestopolicial)
        {
            try
            {
                _context.Arrestopolicials.Remove(arrestopolicial);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

