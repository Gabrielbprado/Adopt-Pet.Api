using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
using AutoMapper;

namespace Adopt_Pet.Api.Profiles;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<PetDto, PetModel>();
        CreateMap<PetModel, List<ReadPetDto>>();
        CreateMap<PetModel, ReadPetDto>().ForMember(dto => dto.ReadAbrigoDto, opt => opt.MapFrom(pet => pet.AbrigoModel));
        CreateMap<ReadPetDto, PetModel>();
        CreateMap<PetModel, PetDto>();
        CreateMap<UpdatePetDto, ReadPetDto>();
        CreateMap<ReadPetDto, UpdatePetDto>();
        CreateMap<PetModel, UpdatePetDto>();
        CreateMap<UpdatePetDto,PetModel>();
    }
}
