﻿using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface ITutorRepository
{
     Task Save(AbrigoDto dto);
    Task<ReadTutorDto> GetIdTutor(string id);
    Task UpdateTutor(AbrigoDto dto,string id);
    Task Delete(string id);
    Task<string> Login(TutorLoginDto dto);
}
