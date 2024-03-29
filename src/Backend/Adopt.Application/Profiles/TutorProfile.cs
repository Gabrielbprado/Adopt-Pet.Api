﻿using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;
using AutoMapper;

namespace Adopt_Pet.Api.Profiles;

public class TutorProfile : Profile
{
    public TutorProfile()
    {
        CreateMap<TutorDto, TutorModel>();
        CreateMap<TutorModel,ReadTutorDto >();
    }
}
