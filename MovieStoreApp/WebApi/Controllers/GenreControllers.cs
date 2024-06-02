using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.GenreOperations.Commands.CreateGenre;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.Applications.GenreOperations.Queries.GetAllGenre;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreControllers : ControllerBase
{
   private readonly MovieStoreDBContext _dbContext;
   private readonly IMapper _mapper;

   public GenreControllers(MovieStoreDBContext dbContext,IMapper mapper)
   {
        _dbContext = dbContext;
            _mapper = mapper;

   }

   [HttpGet]
   public ActionResult<List<GetAllGenreViewModel>> GetAll()
   {
        GetAllGenreQuery query =new(_dbContext,_mapper);
        var result= query.Handle();

        return Ok(result);

   }
   [HttpPost]
   public ActionResult Post([FromBody] CreateGenreModel model )
   {
    CreateGenreCommand command = new CreateGenreCommand(_dbContext,_mapper,model);
    command.Handle();
    return Ok();

   }
   [HttpDelete("{id}")]
   public ActionResult Delete(int id)
   {
        DeleteGenreCommand command =new DeleteGenreCommand(_dbContext,id);
        command.Handle();
        
        return Ok();

   }
}
