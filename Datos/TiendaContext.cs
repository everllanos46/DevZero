using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class TiendaContext : DbContext
    {

        public TiendaContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Producto> productos {get; set;}
        public DbSet<Proveedor> proveedores {get; set;}
        public DbSet<Detalle> detalles{get;set;}
        public DbSet<Usuario> usuarios{get; set;}
        public DbSet<Interesado> interesados{get; set;}
        public DbSet<Factura> facturas {get; set;}
        public DbSet<FacturaCompra>  facturaCompras{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
            .HasOne<Proveedor>().WithMany()
            .HasForeignKey(p => p.IdProveedor);
        }

    }
}
