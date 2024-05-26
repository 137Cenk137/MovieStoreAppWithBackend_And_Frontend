namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre;

public class DeleteGenreCommand 
{
    private readonly MovieStoreDBContext _dbContext;

    private readonly int _DeleteId;

    public DeleteGenreCommand(MovieStoreDBContext dbContext, int deleteId)
    {
            _dbContext = dbContext;
            _DeleteId = deleteId;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == _DeleteId);
        if  (genre is null)
        {throw new InvalidOperationException("object could not found");}

        _dbContext.Genres.Remove(genre);
        _dbContext.SaveChanges();
        
    }
    
}
