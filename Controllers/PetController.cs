using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
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
    public async Task<IActionResult> Save([FromForm] PetDto dto)
    {
        await _PetRepository.Save(dto);
        return Ok("Pet Cadastrado");
    }

    [HttpGet("listarAll")]
    public  IActionResult GetAllAbrigo(int? Abrigo_id = null)
    {
        var abrigo = _PetRepository.GetAllPet(Abrigo_id);

        return Ok(abrigo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdAbrigo(int id)
    {
        var abrigo = await _PetRepository.GetIdPet(id);
        return Ok(abrigo);
    }

    [HttpPost("atualizar/{id}")]
    public async Task<IActionResult> UpdateAbrigo([FromBody] PetDto dto, int id)
    {
        await _PetRepository.UpdatePet(dto, id);
        return NoContent();
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteTutor([FromBody] AbrigoLoginDto dto,int id)
    {
        await _PetRepository.Delete(id,dto);
        return NoContent();
    }

  

 
}
