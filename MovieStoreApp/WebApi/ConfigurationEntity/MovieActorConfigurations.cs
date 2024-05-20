
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MovieActorConfigurations : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.HasKey(x => new{x.MovieId,x.ActorId});

        builder.HasOne(ma => ma.Actor)
                .WithMany(ma => ma.Movies)
                .HasForeignKey(ma => ma.ActorId);

        builder.HasOne(ma => ma.Movie)
                .WithMany(ma => ma.Actors)
                .HasForeignKey(ma => ma.MovieId);

        

            
    }
}