﻿using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TutorController : ControllerBase
{
    private readonly ITutorRepository _tutorRepository;

    public TutorController(ITutorRepository tutorRepository)
    {
        _tutorRepository = tutorRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Save(TutorDto dto)
    {
        await _tutorRepository.Save(dto);
        return Ok("Tutor Cadastrado");
    }

    [HttpGet]
    public async Task<IActionResult> GetIdTutor(string id)
    {
        var tutor = await _tutorRepository.GetIdTutor(id);
        return Ok(tutor);
    }
}