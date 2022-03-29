using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS_Project.Domain;

namespace FS_Project.Persistence.Contractos
{
    public interface IPalestrantePersistence
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false);
    }
}