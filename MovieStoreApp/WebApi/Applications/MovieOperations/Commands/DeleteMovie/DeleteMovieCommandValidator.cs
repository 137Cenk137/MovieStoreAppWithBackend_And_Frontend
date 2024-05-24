using System.Data;
using FluentValidation;

namespace WebApi.Applications.MovieOperations.Commands.DeleteMovie;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator(int lengthofcontext)
    {
        RuleFor(command => command.DelteId).NotEmpty().GreaterThan(0).LessThan(lengthofcontext+1);
    }
}