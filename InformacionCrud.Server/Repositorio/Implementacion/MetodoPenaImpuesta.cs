using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoPenaImpuesta : IMetodoPenaImpuesta
    {
        private readonly InformacionpublicaContext _context;

        public MetodoPenaImpuesta(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Penaimpuestum>> ListarPenaimpuesta()
        {
            List<Penaimpuestum> penaimpuesta = await _context.Penaimpuesta
                                                            .Include(d => d.DelitosNavigation)
                                                            .Include(td => td.TiposdelitosNavigation)

                                                            .ToListAsync();

            return penaimpuesta;
        }

        public async Task<Penaimpuestum> BuscarPenaimpuesta(int ID)
        {
            return await _context.Penaimpuesta.FindAsync(ID);
        }

        public async Task<Penaimpuestum> CrearPenaimpuesta(Penaimpuestum penaimpuestum)
        {
            try
            {
                await _context.Penaimpuesta.AddAsync(penaimpuestum);
                await _context.SaveChangesAsync();

                return penaimpuestum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Penaimpuestum> EditarPenaimpuesta(Penaimpuestum penaimpuestum)
        {
            try
            {
                _context.Penaimpuesta.Update(penaimpuestum);
                await _context.SaveChangesAsync();

                return penaimpuestum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarPenaimpuesta(Penaimpuestum penaimpuestum)
        {
            try
            {
                _context.Penaimpuesta.Remove(penaimpuestum);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
    
