using System.Data;
using System.IO.Compression;
using FluentValidation;

namespace WebApi.Applications.ActorOperations.Command.CreateActor;

public class CreateActorValidator : AbstractValidator<CreateActorCommand>
{
    public CreateActorValidator()
    {
        RuleFor( x => x.Model.Name).NotEmpty().MinimumLength(4);
        RuleFor(x => x.Model.SurName).NotEmpty().MinimumLength(4);
        RuleFor(x => x.Model.ints).NotNull();
        RuleFor(x => x.Model.ints).ForEach(x => x.GreaterThan(0));
    }
}