using Microsoft.EntityFrameworkCore;


namespace Mulher_Presente.Data
{
    public class VitimaUserContext : DbContext
    {
        public VitimaUserContext(DbContextOptions<VitimaUserContext> opt) : base(opt)
        {

        }
            public DbSet<Models.VitimaUser> VitimaUser { set; get; }

            public DbSet<Models.ParceirosUser> ParceirosUser { set; get; }
    }
    
}

 
           
    
