using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prova.Models;
using Prova.Service;

namespace Prova.Controllers
{
    public class PlacarsController : Controller
    {
        private readonly ProvaContext _context;
        private readonly JogadorService _jogadorService;
        private readonly PlacarService _placarService;

        public PlacarsController(ProvaContext context, JogadorService jogadorService, PlacarService placarService)
        {
            _context = context;
            _jogadorService = jogadorService;
            _placarService = placarService;
        }

        // GET: Placars
        public async Task<IActionResult> Index()
        {
            var provaContext = _context.Placar.Include(p => p.Jogador);
            return View(await provaContext.ToListAsync());
        }

        // GET: Placars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar
                .Include(p => p.Jogador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // GET: Placars/Create
        public async Task< IActionResult> Create()
        {
            //ViewData["JogadorId"] = new SelectList(_context.Jogador, "Id", "Id");
            var jogadores = await _jogadorService.FindAllAsync();
            var viewModel = new PlacarFormsViewModel { Jogadores = jogadores };
            return View(viewModel);
        }

        // POST: Placars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JogadorId,Total,Data")] Placar placar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "Id", "Id", placar.JogadorId);
            return View(placar);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var placar = await _context.Placar.FindAsync(id);
            var jogadores = _context.Jogador.OrderBy(x => x.Id).ToList();
            if (placar == null)
            {
                return NotFound();
            }
            var vm = new PlacarFormsViewModel { Jogadores = jogadores, Placar = placar };
            return View(vm);
        }

        // POST: Placars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,pontos,jogadorId,data")] Placar placar)
        {
            if (id != placar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacarExists(placar.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(placar);
        }

        // GET: Placars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placar = await _context.Placar
                .Include(p => p.Jogador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (placar == null)
            {
                return NotFound();
            }

            return View(placar);
        }

        // POST: Placars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placar = await _context.Placar.FindAsync(id);
            _context.Placar.Remove(placar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacarExists(int id)
        {
            return _context.Placar.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Melhores(int? id)
        {
            var provaContext = _context.Placar.Include(p => p.Jogador).OrderByDescending(p => p.Total).Take(10);
            
            return View(await provaContext.ToListAsync());
        }
    }
}
