using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
