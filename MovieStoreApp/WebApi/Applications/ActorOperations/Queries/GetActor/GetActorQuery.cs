using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.ActorOperations.Queries;

public class GetActorQuery
{
    private readonly MovieStoreDBContext _dbContext;

    private readonly IMapper _mapper;

    public GetActorQuery(MovieStoreDBContext dbContext, IMapper mapper)     
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }

    public List<GetActorQueryViewModel> Handle()
    {
        var actors = _dbContext.Actors.AsNoTracking().ToList();
        if (actors is null)
        {throw new InvalidOperationException("No data");}
        
        var result = _mapper.Map<List<GetActorQueryViewModel>>(actors);

        return result;
        
    }
}

public class GetActorQueryViewModel
{
    public string? Name { get; set;}
    public string? SurName { get; set; }
}
