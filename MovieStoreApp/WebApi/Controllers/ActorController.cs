using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.ActorOperations.Command.CreateActor;
using WebApi.Applications.ActorOperations.Command.DeleteActor;
using WebApi.Applications.ActorOperations.Command.UpdateActor;
using WebApi.Applications.ActorOperations.Queries;
using WebApi.Applications.MovieOperations.Queries.GetMovie;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorController : ControllerBase
{
   private readonly MovieStoreDBContext _dbContext;
   private readonly IMapper  _mapper;

   public ActorController(MovieStoreDBContext dbContext,IMapper mapper)
   {
        _dbContext = dbContext;
        _mapper = mapper;
   }
   [HttpGet]
   public ActionResult Get()
   {
    GetActorQuery  query = new(_dbContext, _mapper);
    var result = query.Handle();
    return Ok(result);
   }

   [HttpPost]
   public ActionResult Post([FromBody] CreateActorModel Model)
   {
        CreateActorCommand  command= new CreateActorCommand(_dbContext, _mapper);
        command.Model =  Model;
        command.Handle();

        return Ok();
   }

   [HttpDelete("{id}")]
   public ActionResult Delete(int id)
   {
     DeleteActorCommand command = new(_dbContext){DeleteId = id};
     command.Handle();

     return Ok();

   }

   [HttpPut("{id}")]
   public ActionResult Put(int id,[FromBody] UpdateActorModel actor)
   {
     UpdateActorCommand command = new(_dbContext);
     command.Model = actor;
     command.UpdateId = id;
     command.Handle();
     return Ok();
   }
}
