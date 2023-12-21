using dnd_manager_webapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dnd_manager_webapp.Data
{
    public class PartyDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public PartyDbContext(DbContextOptions<PartyDbContext> opt)
            :base(opt)
        {
                
        }
    }
}
