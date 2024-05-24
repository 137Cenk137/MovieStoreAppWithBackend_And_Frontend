using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.CreateMovie;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(command => command.Model).NotEmpty();
        RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);
        RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        RuleFor(commaand => commaand.Model.Description).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
        RuleFor(command => command.Model.OrderId).NotEmpty().GreaterThan(0);

    }
}