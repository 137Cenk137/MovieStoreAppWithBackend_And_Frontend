
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.MovieOperations.Queries.GetMovie;

public class GetMovieQuery
{
    private readonly MovieStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetMovieQuery(MovieStoreDBContext dbContext, IMapper mapper)     
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }

    public List<GetMovieViewModels> Handle()
    {
        var movies = _dbContext.Movies.Include(x => x.Genre).AsNoTracking().ToList();

        var result = _mapper.Map<List<GetMovieViewModels>>(movies);

        return result;

    }
}



public class GetMovieViewModels
{
    public string? Name { get; set; }
    public float Price { get; set; }
    public string? Description { get; set; }
    public string? PublishDate { get; set; }

    public string? Genre{ get; set; }
}


