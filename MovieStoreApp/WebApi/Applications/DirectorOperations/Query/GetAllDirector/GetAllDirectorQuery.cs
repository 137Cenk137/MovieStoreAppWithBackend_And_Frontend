using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.DirectorOperations.Query.GetAllDirector;


public class GetAllDirectorQuery
{
    private readonly MovieStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetAllDirectorQuery(MovieStoreDBContext dbContext,IMapper mapper)    
    {
            _dbContext = dbContext;
                _mapper = mapper;

    }

    public List<GetAllDirectorViewModel> Handle()
    {
        var Directors = _dbContext.Directors.Include(x => x.Movie).AsNoTracking().ToList();
        if(Directors is null)
        {
            throw new InvalidOperationException("there is no data");
        }
        var result = _mapper.Map<List<GetAllDirectorViewModel>>(Directors);

        return result;

    }
}

public class GetAllDirectorViewModel
{
    public string? Name { get; set;}
    public string? SurName { get; set; }
    public string MovieName { get; set; }
}