using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class HViewModel
    {
        public Placar Placar { get; set; }
        public ICollection<Placar> Placares { get; set; }
    }
}
