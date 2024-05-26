using AutoMapper;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre;


public class CreateGenreCommand 
{
    private readonly MovieStoreDBContext _dbContext;

    private readonly IMapper _mapper;
    private readonly CreateGenreModel _model;
    public CreateGenreCommand(MovieStoreDBContext dbContext,IMapper mapper,CreateGenreModel model)     
    {
            _dbContext = dbContext;
            _mapper = mapper;
            _model = model;
    }

    public void Handle()
    {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.GenreName == _model.GenreName);
        if (genre is not null)
        {throw new InvalidOperationException("object has already been");}

        var newVaule = _mapper.Map<Genre>(_model);
        _dbContext.Genres.Add(newVaule);
        _dbContext.SaveChanges();
        
    }
}

public class CreateGenreModel
{
    public string? GenreName { get; set;}
    public int CustomerId { get; set;}
}