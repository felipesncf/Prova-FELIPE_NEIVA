using Microsoft.EntityFrameworkCore;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Service
{
    public class JogadorService
    {
        private readonly ProvaContext _context;

        public JogadorService(ProvaContext context)
        {
            _context = context;
        }
        public async Task<List<Jogador>> FindAllAsync()
        {
            return await _context.Jogador.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
