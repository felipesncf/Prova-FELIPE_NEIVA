using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class PlacarFormsViewModel
    {
        public Placar Placar { get; set; }
        public ICollection<Jogador> Jogadores { get; set; }
    }
}
