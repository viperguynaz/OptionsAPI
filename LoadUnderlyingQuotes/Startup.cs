using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OptionsData;
using System.Reflection.Metadata;

namespace LoadUnderlyingQuotes;
public class Startup
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EquityQuote> QQQ_Historic { get; set; }
        public DbSet<OptionIngest> QQQ_Option_Historic { get; set; }
    }
}


