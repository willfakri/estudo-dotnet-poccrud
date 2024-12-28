using Microsoft.EntityFrameworkCore;
using PocCrud.Models;

namespace PocCrud.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

    }
}