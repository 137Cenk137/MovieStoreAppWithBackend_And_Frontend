using FluentValidation;

namespace WebApi.Applications.ActorOperations.Command.DeleteActor;

 
public class DeletelctorValidator: AbstractValidator<DeleteActorCommand>
{
    public DeletelctorValidator()
    {
        RuleFor(x => x.DeleteId).NotEmpty().GreaterThan(0);
       
    }
}