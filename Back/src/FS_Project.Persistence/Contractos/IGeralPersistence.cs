using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS_Project.Domain;

namespace FS_Project.Persistence.Contractos
{
    public interface IGeralPersistence
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}