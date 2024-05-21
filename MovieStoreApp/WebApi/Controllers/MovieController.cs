using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.MovieOperations.Commands.DeleteMovie;
using WebApi.Applications.MovieOperations.Queries.GetMovie;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieStoreDBContext _dbContext;
    private readonly IMapper _mapper;

    public MovieController(MovieStoreDBContext dbContext, IMapper mapper)
    {
            _dbContext = dbContext;
            _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        GetMovieQuery query = new GetMovieQuery(_dbContext, _mapper);
        var result = query.Handle();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] Movie model)
    {
        CreateMovieCommand command =new CreateMovieCommand(_dbContext, _mapper);
        command.Model = model;
        command.Handle();

        return Ok();
    } 

    [HttpDelete]
    public IActionResult DeleteMovie(int id)
    {
        DeleteMovieCommand command =new DeleteMovieCommand(_dbContext);
        command.DelteId = id;
        command.Handle();
        return Ok();
    }

}
