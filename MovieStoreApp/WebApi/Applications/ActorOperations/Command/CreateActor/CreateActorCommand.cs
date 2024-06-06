using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApi.Applications.ActorOperations.Command.CreateActor;

public class CreateActorCommand
{
    private readonly MovieStoreDBContext _context;
    private readonly IMapper _mapper;

    public CreateActorModel Model { get; set; }

    public CreateActorCommand(MovieStoreDBContext context, IMapper mapper)
    {
            _context = context;
            _mapper = mapper;
    }

    public void Handle()
    {

        /*actor = new Actor
            {
                Name = Model.Name,
                SurName = Model.SurName,
                Movies = new List<MovieActor>()
            };

            foreach (var movieId in Model.MovieIds)
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == movieId);
                if (movie is null)
                    throw new InvalidOperationException("Movie not found.");

                actor.Movies.Add(new MovieActor
                {
                    Movie = movie,
                    Actor = actor
                });
            }*/

        var actor2 = _context.Actors.SingleOrDefault(x => x.Name == Model.Name);
        if (actor2 is not null)
        { throw new InvalidOperationException("this actor has already existed");}

         //var newActor = _mapper.Map<Actor>(Model);


           var  actor = new Actor
            {
                Id = _context.baseEntities.Count(),
                Name = Model.Name,
                SurName = Model.SurName,
                Movies = new List<MovieActor>()
            };

            foreach (var movieId in Model.ints)
            {
                var movie = _context.Movies.SingleOrDefault(m => m.Id == movieId);
                if (movie is null)
                    throw new InvalidOperationException("Movie not found.");

                actor.Movies.Add(new MovieActor
                {
                   MovieId = movieId,
                   Actor = actor
                });
            }
            
        _context.Actors.Add(actor);

        _context.SaveChanges();

    }
}

public class CreateActorModel
{
    public string? Name { get; set;}
    public string? SurName { get; set; }

    public List<int> ints{ get; set; }
    //public ICollection<MovieActor> Movies { get; set; } = new List<MovieActor>();

    
}
