using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.AdocaoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
using AutoMapper;

namespace Adopt_Pet.Api.Profiles;

public class AdocaoProfile : Profile
{
    public AdocaoProfile()
    {
        CreateMap<AdocaoDto, AdocaoModel>();
        CreateMap<AdocaoModel, ReadAdocaoDto>();
    }
}
