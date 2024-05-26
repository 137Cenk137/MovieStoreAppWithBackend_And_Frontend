using System.Data;
using FluentValidation;

namespace WebApi.Applications.ActorOperations.Command.UpdateActor;

public class UpdateActorValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorValidator(
    )
    {
        RuleFor(x => x.UpdateId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Model.SurName).NotEmpty().MinimumLength(4);
        RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
        RuleFor(x =>x.Model.MovieIds).ForEach(x => x.GreaterThan(0)); 
    }
}