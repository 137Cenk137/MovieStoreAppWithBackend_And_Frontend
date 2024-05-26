using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.GenreOperations.Queries.GetAllGenre;

public class GetAllGenreQuery
{
    private readonly MovieStoreDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllGenreQuery(MovieStoreDBContext dbContext,IMapper mapper)
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }

    public List<GetAllGenreViewModel> Handle()
    {
        var genres = _dbContext.Genres.AsNoTracking().ToList();
        if (genres is null)
        {
            throw new InvalidOperationException("there is no data");
        }

        var result = _mapper.Map<List<GetAllGenreViewModel>>(genres);

        return result;
    }
}

public class GetAllGenreViewModel
{
    public string? GenreName { get; set;}
}