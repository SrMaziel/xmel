using InformacionCrud.Server.Models;
using InformacionCrud.Server.Repositorio.Interface;
using Microsoft.EntityFrameworkCore;

namespace InformacionCrud.Server.Repositorio.Implementacion
{
    public class MetodoInfraccionesCiudadano : IMetodoInfraccionesCiudadano
    {
        private readonly InformacionpublicaContext _context;

        public MetodoInfraccionesCiudadano(InformacionpublicaContext context)
        {
            _context = context;
        }

        public async Task<List<Infraccionesciudadano>> ListarInfracciones()
        {
            List<Infraccionesciudadano> infraccionesciudadano = await _context.Infraccionesciudadanos
                                                            .Include(c => c.CiudadanoNavigation)
                                                            .Include(i => i.InfraccionesNavigation)
                                                            .ToListAsync();

            return infraccionesciudadano;
        }

        public async Task<Infraccionesciudadano> BuscarInfracciones(int ID)
        {
            return await _context.Infraccionesciudadanos.FindAsync(ID);
        }

        public async Task<Infraccionesciudadano> CrearInfracciones(Infraccionesciudadano infraccionesciudadano)
        {
            try
            {
                await _context.Infraccionesciudadanos.AddAsync(infraccionesciudadano);
                await _context.SaveChangesAsync();

                return infraccionesciudadano;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Infraccionesciudadano> EditarInfracciones(Infraccionesciudadano infraccionesciudadano)
        {
            try
            {
                _context.Infraccionesciudadanos.Update(infraccionesciudadano);
                await _context.SaveChangesAsync();

                return infraccionesciudadano;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarInfracciones(Infraccionesciudadano infraccionesciudadano)
        {
            try
            {
                _context.Infraccionesciudadanos.Remove(infraccionesciudadano);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
