using AutoMapper;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie;

public class UpdateMovieCommand
{
    private readonly MovieStoreDBContext _dbContext;
    
    public int UpdateId { get; set; }
    public UpdateMovieModel Model { get; set; }
    public UpdateMovieCommand(MovieStoreDBContext context)
    {
            _dbContext = context;
            

    }

    public void Handle()
    {
        var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == UpdateId );
        if (movie is  null)
        {
            throw new InvalidOperationException("could not been find update Book");
        }

        //book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        //book.Title = Model.Title != default ? Model .Title : book.Title;
        movie.Price = Model.Price != default ? Model.Price : movie.Price;
        movie.Name = Model.Name != default ? Model.Name : movie.Name;
        movie.Description = Model.Description != default ? Model.Description : movie.Description;
        movie.PublishDate = Model.PublishDate != default ? Model.PublishDate : movie.PublishDate;

        _dbContext.SaveChanges();
    }
}

public class UpdateMovieModel
{
    public string  Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public DateTime PublishDate { get; set; }

}
