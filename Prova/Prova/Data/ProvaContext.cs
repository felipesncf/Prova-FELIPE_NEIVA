using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prova.Models;

namespace Prova.Models
{
    public class ProvaContext : DbContext
    {
        public ProvaContext (DbContextOptions<ProvaContext> options)
            : base(options)
        {
        }

        public DbSet<Prova.Models.Jogador> Jogador { get; set; }

        public DbSet<Prova.Models.Placar> Placar { get; set; }
    }
}
