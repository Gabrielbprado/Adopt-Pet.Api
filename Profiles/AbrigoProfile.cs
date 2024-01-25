using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using AutoMapper;

namespace Adopt_Pet.Api.Profiles;

public class AbrigoProfile : Profile
{
    public AbrigoProfile()
    {
        CreateMap<AbrigoDto, AbrigoModel>();
        CreateMap<AbrigoModel,ReadAbrigoDto >();
    }
}
