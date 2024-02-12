using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<IActionResult> Save([FromForm] TutorDto dto)
    {
        await _tutorRepository.Save(dto);
        return Ok("Tutor Cadastrado");
    }

    [HttpGet("tutor/{username}")]
    public async Task<IActionResult> GetTutor(string username)
    {
        var tutor = await _tutorRepository.GetTutor(username);
        return Ok(tutor);
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

    [HttpPatch("uploadPhoto/{id}")]
    public async Task<IActionResult> UploadPhoto(string id, IFormFile file)
    {
        await _tutorRepository.UploadPhoto(id, file);
        return NoContent();
    }

}
