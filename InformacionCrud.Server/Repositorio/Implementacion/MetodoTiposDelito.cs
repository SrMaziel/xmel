using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoTiposDelito : IMetodoTiposDelito
    {
        private readonly InformacionpublicaContext _context;

        public MetodoTiposDelito(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Tiposdelito>> ListarTiposdelitos()
        {
            List<Tiposdelito> tiposdelitos = await _context.Tiposdelitos
                                                         
                                                            .ToListAsync();

            return tiposdelitos;
        }

        public async Task<Tiposdelito> BuscarTiposdelitos(int ID)
        {
            return await _context.Tiposdelitos.FindAsync(ID);
        }

        public async Task<Tiposdelito> CrearTiposdelitos(Tiposdelito tiposdelito)
        {
            try
            {
                await _context.Tiposdelitos.AddAsync(tiposdelito);
                await _context.SaveChangesAsync();

                return tiposdelito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tiposdelito> EditarTiposdelitos(Tiposdelito tiposdelito)
        {
            try
            {
                _context.Tiposdelitos.Update(tiposdelito);
                await _context.SaveChangesAsync();

                return tiposdelito;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarTiposdelitos(Tiposdelito tiposdelito)
        {
            try
            {
                _context.Tiposdelitos.Remove(tiposdelito);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

