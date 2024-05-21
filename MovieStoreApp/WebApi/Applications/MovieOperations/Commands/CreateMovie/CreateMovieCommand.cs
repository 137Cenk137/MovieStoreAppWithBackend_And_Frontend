using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CreateMovieCommand
{
    private readonly MovieStoreDBContext _dbContext;
    private readonly IMapper _mapper;
    public Movie Model { get; set; }


    public CreateMovieCommand(MovieStoreDBContext dbContext, IMapper mapper)
    {
            _dbContext = dbContext;
                _mapper = mapper;
    }

    public void Handle()
    {
        var movie = _dbContext.Movies.AsNoTracking().SingleOrDefault(x => x.Name.ToLower() == Model.Name.ToLower());
        if (movie is not null)
        {throw new InvalidOperationException("Movie name has already existed");}


        

        _dbContext.Movies.Add(Model);

        _dbContext.SaveChanges();
        
    }


    
}

public class CreateMovieModel
{
    public string Name { get; set; }
    public float Price { get; set; }
    public DateTime PublishDate { get; set; }
    public string? Description { get; set; }

}


