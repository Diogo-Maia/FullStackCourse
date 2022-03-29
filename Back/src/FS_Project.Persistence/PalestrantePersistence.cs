using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS_Project.Domain;
using FS_Project.Persistence.Contextos;
using FS_Project.Persistence.Contractos;
using Microsoft.EntityFrameworkCore;

namespace FS_Project.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProEventosContext _context;

        public PalestrantePersistence(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if(includeEventos)
                query = query.Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);


            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if(includeEventos)
                query = query.Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);


            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if(includeEventos)
                query = query.Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);


            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}