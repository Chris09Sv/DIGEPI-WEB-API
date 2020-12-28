using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DGP.Data
{
    public class DGPContext : DbContext
    {
        public DGPContext (DbContextOptions<DGPContext> options)
            : base(options)
        {
        }


        public DbSet<TMuestras> TMuestras { get; set; }
        public DbSet<Laboratorios> TLaboratorios { get; set; }
        public DbSet<Manejo> TManejo { get; set; }
        public DbSet<Provincias> TProvincias { get; set; }
    }
}
