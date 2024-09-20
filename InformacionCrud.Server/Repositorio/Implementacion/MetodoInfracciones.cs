using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoInfracciones : IMetodoInfracciones
    {
         private readonly InformacionpublicaContext _context;

        public MetodoInfracciones(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Infraccione>> ListarInfracciones()
        {
            List<Infraccione> infracciones = await _context.Infracciones
                                                            .ToListAsync();

            return infracciones;
        }

        public async Task<Infraccione> BuscarInfracciones(int ID)
        {
            return await _context.Infracciones.FindAsync(ID);
        }

        public async Task<Infraccione> CrearInfracciones(Infraccione infraccione)
        {
            try
            {
                await _context.Infracciones.AddAsync(infraccione);
                await _context.SaveChangesAsync();

                return infraccione;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Infraccione> EditarInfracciones(Infraccione infraccione)
        {
            try
            {
                _context.Infracciones.Update(infraccione);
                await _context.SaveChangesAsync();

                return infraccione;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarInfracciones(Infraccione infraccione)
        {
            try
            {
                _context.Infracciones.Remove(infraccione);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

