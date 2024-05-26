using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.ActorOperations.Command.UpdateActor;


public class UpdateActorCommand
{
    private readonly MovieStoreDBContext _context;

   
    public UpdateActorModel Model { get; set; }
    public int UpdateId { get; set; }

    public UpdateActorCommand(MovieStoreDBContext context) => _context = context;


    public void Handle()
    {
       
        var updateActor = _context.Actors.Include(x => x.Movies).SingleOrDefault(a => a.Id == UpdateId);
        if (updateActor is null)
        {throw new InvalidOperationException("could not find"); }


        updateActor.SurName = Model.SurName != default ? Model.SurName :updateActor.SurName;
        updateActor.Name = Model.Name != default ? Model.Name : updateActor.Name;
      
        updateActor.Movies.Clear();
        for (int i = 0; i < Model.MovieIds.Count;i ++)
        {   
            updateActor.Movies.Add(new MovieActor { MovieId = Model.MovieIds[i] ,ActorId = UpdateId});
            //deleteMovies[i].MovieId = Model.MovieIds[i] != default ? Model.MovieIds[i] : deleteMovies[i].MovieId;
        }


        /*updateActor.Movies.Clear();
        foreach (var movieId in Model.MovieIds)
        {
            var movie = _context.Movies.AsNoTracking().SingleOrDefault(m => m.Id == movieId);
            if (movie is null)
                throw new InvalidOperationException("Movie not found.");

            updateActor.Movies.Add(new MovieActor
            {
                Movie = movie,
                Actor = updateActor
            });
        }*/
        

        
       
        _context.SaveChanges();
        
    }
}

public class UpdateActorModel
{
    public string? Name { get; set;}
    public string? SurName { get; set; }
     public List<int> MovieIds { get; set;}
}

