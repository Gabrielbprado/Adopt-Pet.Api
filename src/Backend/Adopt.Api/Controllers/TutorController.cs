using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers;
[ApiController]
[Route("api/[controller]/v1")]
public class TutorController : ControllerBase
{
    private readonly ITutorRepository _tutorRepository;

    public TutorController(ITutorRepository tutorRepository)
    {
        _tutorRepository = tutorRepository;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Save([FromBody] TutorDto dto)
    {
        await _tutorRepository.Save(dto);
        return Ok("Tutor Cadastrado");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdTutor(string id)
    {
        var tutor = await _tutorRepository.GetIdTutor(id);
        return Ok(tutor);
    }

    [HttpPost("atualizar/{id}")]
    public async Task<IActionResult> UpdateTutor([FromBody] TutorDto dto, string id)
    {
        await _tutorRepository.UpdateTutor(dto, id);
        return NoContent();
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteTutor(string id)
    {
        await _tutorRepository.Delete(id);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] TutorLoginDto dto)
    {
       var token = await _tutorRepository.Login(dto);
        return Ok(token);
     
    }

 
}
