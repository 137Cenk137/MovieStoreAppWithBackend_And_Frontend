using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
         builder.HasKey(a => a.Id);

         builder.HasOne( d => d.Director)
                .WithOne( a => a.Movie)
                .HasForeignKey<Director>(a => a.MovieId);
         
    }
}
