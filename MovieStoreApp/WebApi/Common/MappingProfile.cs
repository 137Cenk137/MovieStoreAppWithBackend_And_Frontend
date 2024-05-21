using AutoMapper;
using WebApi.Applications.MovieOperations.Queries.GetMovie;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    { //source     target
        CreateMap<Movie,GetMovieViewModels>()
                                .ForMember(dest => dest.Genre ,opt => opt.MapFrom(src => src.Genre.GenreName));

        CreateMap<CreateMovieModel,Movie>();
    }
}