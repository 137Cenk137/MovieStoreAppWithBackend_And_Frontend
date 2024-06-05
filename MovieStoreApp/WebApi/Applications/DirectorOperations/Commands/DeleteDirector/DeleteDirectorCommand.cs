using AutoMapper;
using WebApi.Common;

namespace WebApi.Applications.DirectorOperations.Commands.DeleteDirector;

public class DeleteDirectorCommand 
{
    private readonly MovieStoreDBContext _dbContext;
   
    public int DeleteId { get; set; }

    public DeleteDirectorCommand(MovieStoreDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.SingleOrDefault(d => d.Id == DeleteId);
        if (director is null)
        {
            throw new InvalidOperationException("data could not find");
        
        }

        _dbContext.Directors.Remove(director);
        _dbContext.SaveChanges();
    }
}