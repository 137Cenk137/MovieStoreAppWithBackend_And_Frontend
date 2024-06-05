using AutoMapper;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector;

public class UpdateDirectorCommand
{
    private readonly MovieStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public UpdateDirectorModel Model { get; set; } 
    public int UpdateId { get; set; }

    public UpdateDirectorCommand(MovieStoreDBContext dbContext,IMapper mapper)      
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }

    public void Handle()
    {
        var director = _dbContext.Directors.Find(UpdateId);

        if (director is null)
        {
            throw new InvalidOperationException("could not find");

        }

        director.Name = Model.Name  != default ? Model.Name : director.Name;
        director.SurName = Model.SurName != default ? Model.SurName : director.SurName;
        director.MovieId = Model.MovieId != default ? Model.MovieId : director.MovieId; 

        _dbContext.SaveChanges();
        
    }
}

public class UpdateDirectorModel
{
    public string? Name { get; set;}
    public string? SurName { get; set; }
    public int MovieId { get; set; }


}