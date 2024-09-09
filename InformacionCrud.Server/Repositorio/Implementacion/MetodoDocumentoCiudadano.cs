using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoDocumentoCiudadano : IMetodoDocumentoCiudadano
    {
        private readonly InformacionpublicaContext _context;

        public MetodoDocumentoCiudadano(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Documentosciudadano>> ListarDocumentos()
        {
            List<Documentosciudadano> documentosciudadanos = await _context.Documentosciudadanos                                                          
                                                            .Include(td => td.TipodocumentoNavigation)
                                                            .Include(c => c.CiudadanoNavigation)
                                                            .ToListAsync();

            return documentosciudadanos;
        }

        public async Task<Documentosciudadano> BuscarDocumentos(int ID)
        {
            return await _context.Documentosciudadanos.FindAsync(ID);
        }

        public async Task<Documentosciudadano> CrearDocumentos(Documentosciudadano documentosciudadanos)
        {
            try
            {
                await _context.Documentosciudadanos.AddAsync(documentosciudadanos);
                await _context.SaveChangesAsync();

                return documentosciudadanos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Documentosciudadano> EditarDocumentos(Documentosciudadano documentosciudadanos)
        {
            try
            {
                _context.Documentosciudadanos.Update(documentosciudadanos);
                await _context.SaveChangesAsync();

                return documentosciudadanos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarDocumentos(Documentosciudadano documentosciudadanos)
        {
            try
            {
                _context.Documentosciudadanos.Remove(documentosciudadanos);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
