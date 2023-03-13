using Microsoft.EntityFrameworkCore;

namespace TradingPlatform.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
       
        public DbSet<Stock> Stocks { get; set; }
    }
}
