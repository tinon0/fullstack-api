using Microsoft.EntityFrameworkCore;
using Practica_Final.Models;

namespace Practica_Final.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            
        }
        public DbSet<Escuadron> Escuadrones { get; set; }
        public DbSet<Soldado> Soldados { get; set; }
        public DbSet<TipoEscuadron> TipoEscuadrones { get; set; }
        public DbSet<SoldadoXEscuadron> SoladosXEscuadrones { get; set; }
    }
}
