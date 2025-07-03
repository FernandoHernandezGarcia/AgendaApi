using AgendaApi.Models;
using AgendaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data
{
    /// <summary>
    /// Contexto principal de la base de datos AgendaDb.
    /// Administra el acceso a entidades como Reuniones.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Representa el conjunto de reuniones en la base de datos.
        /// </summary>
        public DbSet<Reunion> Reuniones { get; set; }
    }
}