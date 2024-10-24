using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerEnClaseSemana4_TomasLopez.Models;

    public class LigaProContext : DbContext
    {
        public LigaProContext (DbContextOptions<LigaProContext> options)
            : base(options)
        {
        }

        public DbSet<TallerEnClaseSemana4_TomasLopez.Models.Jugador> Jugador { get; set; } = default!;

public DbSet<TallerEnClaseSemana4_TomasLopez.Models.Equipos> Equipos { get; set; } = default!;

public DbSet<TallerEnClaseSemana4_TomasLopez.Models.Estadio> Estadio { get; set; } = default!;
    }
