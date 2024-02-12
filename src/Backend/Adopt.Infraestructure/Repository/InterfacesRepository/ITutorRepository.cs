﻿using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface ITutorRepository
{
     Task Save(TutorDto dto);
    Task<ReadTutorDto> GetIdTutor(string id);
    Task UpdateTutor(TutorDto dto,string id);
    Task Delete(string id);
    Task<string> Login(TutorLoginDto dto);
    Task<ReadTutorDto> GetTutor(string username);
     Task<string> UploadPhoto(string id, IFormFile file);

}
