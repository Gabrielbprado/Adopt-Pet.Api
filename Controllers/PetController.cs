using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers.Abrigo;
[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetRepository _PetRepository;

    public PetController(IPetRepository Petrepository)
    {
        _PetRepository = Petrepository;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Save([FromBody] PetDto dto)
    {
        await _PetRepository.Save(dto);
        return Ok("Pet Cadastrado");
    }

    [HttpGet("listarAll")]
    public  IActionResult GetAllAbrigo()
    {
        var abrigo = _PetRepository.GetAllPet();
        return Ok(abrigo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdAbrigo(string id)
    {
        var abrigo = await _PetRepository.GetIdPet(id);
        return Ok(abrigo);
    }

    [HttpPost("atualizar/{id}")]
    public async Task<IActionResult> UpdateAbrigo([FromBody] PetDto dto, string id)
    {
        await _PetRepository.UpdatePet(dto, id);
        return NoContent();
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteTutor(string id)
    {
        await _PetRepository.Delete(id);
        return NoContent();
    }

  

 
}
