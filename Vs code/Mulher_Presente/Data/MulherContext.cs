using Microsoft.EntityFrameworkCore;
using Mulher_Presente.Models;

namespace Mulher_Presente.Data
{
    public class MulherContext : DbContext
    {
        
        public MulherContext(DbContextOptions<MulherContext> opt): base (opt)
        {

        }

        public DbSet<Vitima> Vitima {get;set;}
        public DbSet<Parceiros> Parceiros {get;set;}


    }
}