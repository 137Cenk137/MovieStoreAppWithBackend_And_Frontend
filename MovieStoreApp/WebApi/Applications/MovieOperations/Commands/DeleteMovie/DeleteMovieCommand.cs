namespace WebApi.Applications.MovieOperations.Commands.DeleteMovie;

public class DeleteMovieCommand
{
    private readonly MovieStoreDBContext _dbContext;

    public DeleteMovieCommand(MovieStoreDBContext dbContext) => _dbContext = dbContext;

    public int DelteId { get; set; }

    public void Handle()
    {
        var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == DelteId);
        if (movie is null)
        {throw new InvalidOperationException("No data to delete was found");}
        _dbContext.Movies.Remove(movie);
        _dbContext.SaveChanges();
    }
}