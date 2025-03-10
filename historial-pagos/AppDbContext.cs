using historial_pagos.Models;
using Microsoft.EntityFrameworkCore;

namespace historial_pagos
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Pago> Pago
        {
            get; set;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
