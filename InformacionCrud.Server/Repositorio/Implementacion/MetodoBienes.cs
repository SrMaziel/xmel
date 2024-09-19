using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoBienes : IMetodoBienes
    {
        private readonly InformacionpublicaContext _context;

        public MetodoBienes(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Biene>> ListarBienes()
        {
            List<Biene> bienes = await _context.Bienes
                                                          
                                                            .ToListAsync();

            return bienes;
        }

        public async Task<Biene> BuscarBienes(int ID)
        {
            return await _context.Bienes.FindAsync(ID);
        }

        public async Task<Biene> CrearBienes(Biene biene)
        {
            try
            {
                await _context.Bienes.AddAsync(biene);
                await _context.SaveChangesAsync();

                return biene;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Biene> EditarBienes(Biene biene)
        {
            try
            {
                _context.Bienes.Update(biene);
                await _context.SaveChangesAsync();

                return biene;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarBienes(Biene biene)
        {
            try
            {
                _context.Bienes.Remove(biene);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
