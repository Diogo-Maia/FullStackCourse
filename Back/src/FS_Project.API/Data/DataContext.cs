using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS_Project.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FS_Project.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options){}
        
        public DbSet<Evento> Eventos { get; set; }
    }
}