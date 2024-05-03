using Cientifica.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Cientifica.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Investigador>Investigadores { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<RecursosE>RecursosEs { get; set; }
        public DbSet<ProyectoDeInvestigacion> ProyectoDeInvestigaciones { get; set; }

        public DbSet<Participacion> Participaciones { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }

        public DbSet<ActividadesDeInvestigacion> ActividadesDeInvestigaciones { get; set; }
    }
}
