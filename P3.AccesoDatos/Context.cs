using Microsoft.EntityFrameworkCore;
using P3.Abstracciones.Modelos.ModelosAD;

namespace P3.AccesoDatos
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<VehiculoAD> Vehiculos { get; set; }
    }
}
