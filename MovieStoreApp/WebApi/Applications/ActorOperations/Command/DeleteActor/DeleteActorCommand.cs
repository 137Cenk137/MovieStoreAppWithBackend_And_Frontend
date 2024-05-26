
namespace WebApi.Applications.ActorOperations.Command.DeleteActor;

public class DeleteActorCommand 
{
    private readonly MovieStoreDBContext _dbContext;

    public int DeleteId { get; set; }

    public DeleteActorCommand(MovieStoreDBContext dbContext) => _dbContext = dbContext;

    public void Handle()
    {
        var deleteActor = _dbContext.Actors.Find(DeleteId);

        if (deleteActor is null)
        {
            throw new InvalidOperationException("object that will delete could not find ");
        }

        _dbContext.Actors.Remove(deleteActor);
        _dbContext.SaveChanges();
    }
}