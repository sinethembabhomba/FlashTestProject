using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sensitivewords_Business.Entities;

namespace Sensitivewords_Repository.Data.Config
{
    public class WordEntityConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
         
            builder.ToTable("Words");

            builder.HasKey(w => w.Id);

            builder.Property(wd => wd.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(250);
        }
      
    }
}
