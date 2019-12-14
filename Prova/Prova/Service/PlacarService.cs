using Microsoft.EntityFrameworkCore;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Service
{
    public class PlacarService
    {
        //public Placar Placar { get; set; }
        List<Placar> melhores = new List<Placar>();
        private readonly ProvaContext _context;

        public PlacarService(ProvaContext context)
        {
            _context = context;
        }
        
    }
}
