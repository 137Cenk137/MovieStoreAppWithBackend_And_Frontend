
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieOrderConfigurations : IEntityTypeConfiguration<MovieOrder>
{
    public void Configure(EntityTypeBuilder<MovieOrder> builder)
    {
        builder.HasKey(x => new { x.MovieId,x.CustomerId});

        builder.HasOne(mo => mo.Customer)
            .WithMany(mo => mo.Movies)
            .HasForeignKey(x => x.CustomerId);

        builder.HasOne(mo => mo.Movie)
            .WithMany(mo => mo.Customers)
            .HasForeignKey(x => x.MovieId);
    }
}