using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS_Project.Domain;

namespace FS_Project.Persistence.Contractos
{
    public interface IEventoPersistence
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}