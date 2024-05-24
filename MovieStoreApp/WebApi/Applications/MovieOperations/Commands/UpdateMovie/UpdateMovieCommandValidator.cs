using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.UpdateMovie;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator(MovieStoreDBContext context)
    {
        RuleFor(command => command.UpdateId).NotEmpty().GreaterThan(0).LessThan(context.Movies.Count()+1);
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(command => command.Model.Description).NotEmpty().MinimumLength(4);
           
    }
}