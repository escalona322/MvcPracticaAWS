using Microsoft.EntityFrameworkCore;
using MvcPracticaAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPracticaAWS.Data
{
    public class ChampionsContext : DbContext
    {
        public ChampionsContext(DbContextOptions<ChampionsContext> options)
         : base(options) { }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
    }
}
