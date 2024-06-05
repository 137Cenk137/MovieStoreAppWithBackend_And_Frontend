using AutoMapper;
using WebApi.Common;

namespace WebApi.Applications.DirectorOperations.Commands.CreateDirector;

public class CreateDirectorCommand : IBaseCommand
{

    private readonly MovieStoreDBContext _context;

    private readonly IMapper _mapper;
    public CreateDirectorModel Model { get; set; }

    public CreateDirectorCommand(MovieStoreDBContext context, IMapper mapper)
    {
            _context = context;
            _mapper = mapper;
    }

    public void Handle()
    {
        var director = _context.Directors.SingleOrDefault(d => d.Name == Model.Name && d.SurName == Model.SurName);
        if (director is not null)
        {throw new InvalidOperationException($"{Model.Name} {Model.SurName} has already exist");}
        var result = _mapper.Map<Director>(Model);
        result.Id = _context.baseEntities.Count();
        _context.Directors.Add(result);
        _context.SaveChanges();

    }
}

public class CreateDirectorModel
{
    public string? Name { get; set;}
    public string? SurName { get; set; }
    public int MovieId { get; set; }
}
