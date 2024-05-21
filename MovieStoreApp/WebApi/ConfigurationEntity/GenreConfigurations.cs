
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GenreConfigurations : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
         builder.HasKey(a => a.Id);

         builder.HasOne(a => a.Customer)
                    .WithMany(a => a.Genres)
                    .HasForeignKey(a => a.CustomerId);

        

        
    }
}


