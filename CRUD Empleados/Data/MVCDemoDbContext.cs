using CRUD_Empleados.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Empleados.Data
{
    // La clase MVCDemoDbContext hereda de DbContext (EntityFramework)
    public class MVCDemoDbContext : DbContext
    {
        // Constructor
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        // Propiedades que acceden a la db (DbSet se mapea a partir de la clase Empleado)
        public DbSet<Empleado> Empleados { get; set; }
    }
}
