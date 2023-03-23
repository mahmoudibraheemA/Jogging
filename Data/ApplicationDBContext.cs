using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Jogging> Joggings { get; set; }
    }
}
