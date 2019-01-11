using Microsoft.EntityFrameworkCore;

namespace OBTestApi.DbModels
{
    public class OBDbContext : DbContext
    {
        public virtual DbSet<Patient> Patient { get; set; }

        public OBDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
