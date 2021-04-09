using BlueBankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueBankAPI.DataAccess
{
    public class BlueBankContext : DbContext
    {
        public BlueBankContext(DbContextOptions<BlueBankContext> options) : base(options)
        {

        }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<Persona> Persona { get; set; }
    }
}
