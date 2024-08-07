using Microsoft.EntityFrameworkCore;
using Practica_Final.Context;
using Practica_Final.Models;

namespace Practica_Final.Repositories.Impl
{
    public class ArmyRepository : IArmyRepository
    {
        private readonly ContextDB _context;
        public ArmyRepository(ContextDB _context)
        {
            this._context = _context;
        }
        public async Task<List<Escuadron>> GetEscuadrones()
        {
            var escuadrones = await _context.Escuadrones.Include(e => e.TipoEscuadron).ToListAsync();
            return escuadrones;
        }

        public async Task<List<Soldado>> GetSoldados(Guid idEsc)
        {
            var soldadosEnEscuadron = _context.SoladosXEscuadrones.Where(sxe => sxe.Id.Equals(idEsc)).Select(sxe => sxe.IdSoldado);

            var soldadosNoEnEscuadron = await _context.Soldados.Where(x => !soldadosEnEscuadron.Contains(x.Id)).ToListAsync();
            
            return soldadosNoEnEscuadron;
        }

        //public async Task<Soldado> PostSoldado(string nom, string ape, float alt, float peso, string loc)
        //{
        //    var soldado = new Soldado();

        //    soldado.Id = Guid.NewGuid();
        //    soldado.Nombre = nom;
        //    soldado.Apellido = ape;
        //    soldado.Altura = alt;
        //    soldado.Peso = peso;
        //    soldado.InicioActividades = DateTime.Now;
        //    soldado.Localidad = loc;

        //    _context.Soldados.Add(soldado);
        //    await _context.SaveChangesAsync();

        //    return soldado;
        //}
        //
        //public async Task<SoldadoXEscuadron> PostSoldadoxEscuadron(Guid idSol, Guid idEsc, string act)
        //{
        //    var soldadoxEscuadron = new SoldadoXEscuadron();
        //    soldadoxEscuadron.Id = Guid.NewGuid();
        //    soldadoxEscuadron.IdSoldado = idSol;
        //    soldadoxEscuadron.IdEscuadron = idEsc;
        //    soldadoxEscuadron.Actividad = act;
        //    soldadoxEscuadron.FechaCreacion = DateTime.Now;

        //    _context.SoladosXEscuadrones.Add(soldadoxEscuadron);
        //    await _context.SaveChangesAsync();

        //    return soldadoxEscuadron;
        //}
        public async Task<string> GetNombreSoldado(Guid idSoldado)
        {
            var soldado = await _context.Soldados.Where(s => s.Id.Equals(idSoldado)).FirstOrDefaultAsync();
            return soldado.Nombre;
        }
        public async Task<string> GetNombreEscuadron(Guid idEscuadron)
        {
            var escuadron = await _context.Escuadrones.Where(s => s.Id.Equals(idEscuadron)).FirstOrDefaultAsync();
            return escuadron.Nombre;
        }

        public async Task<SoldadoXEscuadron> PostSoldadoxEscuadron(SoldadoXEscuadron soldadoXEscuadron)
        {
            _context.SoladosXEscuadrones.Add(soldadoXEscuadron);
            await _context.SaveChangesAsync();
            return soldadoXEscuadron;
        }

        public async Task<Soldado> PostSoldado(Soldado soldado)
        {
            _context.Soldados.Add(soldado);
            await _context.SaveChangesAsync();
            return soldado;
        }
    }
}
