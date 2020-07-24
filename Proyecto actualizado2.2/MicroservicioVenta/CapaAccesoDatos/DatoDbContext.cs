using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CapaDeDominio.Entity;
namespace CapaAccesoDatos
{
    public class DatoDbContext : DbContext
    {
  
        public DbSet<DestinoVenta> DestinoVentas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }
        public DbSet<TipoEstado> TipoEstados { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaReclamo> VentasReclamos { get; set; }
        
        public DatoDbContext(DbContextOptions<DatoDbContext> options):base(options)
        {

        }
       

    }
}
