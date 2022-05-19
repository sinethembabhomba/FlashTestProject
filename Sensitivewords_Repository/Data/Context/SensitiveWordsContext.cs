using Microsoft.EntityFrameworkCore;
using Sensitivewords_Business.Entities;
using System.Reflection;

namespace Sensitivewords_Repository.Data.Context
{
    public class SensitiveWordsContext : DbContext
    {
        public SensitiveWordsContext()
        {
        }

        public SensitiveWordsContext(DbContextOptions<SensitiveWordsContext> options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Newwords> Newwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
