using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sensitivewords_Business.Entities;
namespace Sensitivewords_Repository.Data.Config
{
    public class NewWordEntityConfiguration : IEntityTypeConfiguration<Newwords>
    {
        public void Configure(EntityTypeBuilder<Newwords> builder)
        {

            builder.ToTable("NewWords");

            builder.HasKey(w => w.Id);

            builder.Property(wd => wd.Name)
                    .HasColumnName("Name")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(250);
        }
    }
}
