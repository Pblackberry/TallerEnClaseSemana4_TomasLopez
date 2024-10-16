using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerEnClaseSemana4_TomasLopez.Models;

    public class EquiposContext : DbContext
    {
        public EquiposContext (DbContextOptions<EquiposContext> options)
            : base(options)
        {
        }

        public DbSet<TallerEnClaseSemana4_TomasLopez.Models.Equipos> Equipos { get; set; } = default!;
    }
