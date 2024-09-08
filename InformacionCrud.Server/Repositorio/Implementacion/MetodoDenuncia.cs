using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoDenuncia : IMetodoDenuncia
    {
        private readonly InformacionpublicaContext _context;

        public MetodoDenuncia(InformacionpublicaContext context)
        {
            _context = context;
        }
        public async Task<List<Denuncium>> ListarDenuncia()
        {
            List<Denuncium> denuncia = await _context.Denuncia.ToListAsync();


            return denuncia;
        }

        public async Task<Denuncium> BuscarDenuncia(int ID)
        {
            return await _context.Denuncia.FindAsync(ID);
        }

        public async Task<Denuncium> CrearDenuncia(Denuncium denuncium)
        {
            try
            {
                await _context.Denuncia.AddAsync(denuncium);
                await _context.SaveChangesAsync();

                return denuncium;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Denuncium> EditarDenuncia(Denuncium denuncium)
        {
            try
            {
                _context.Denuncia.Update(denuncium);
                await _context.SaveChangesAsync();

                return denuncium;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarDenuncia(Denuncium denuncium)
        {
            try
            {
                _context.Denuncia.Remove(denuncium);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
