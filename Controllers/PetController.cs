using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers.Abrigo;
[ApiController]
[Route("api/[controller]/v1")]
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
        var abrigo = _PetRepository.GetAll(Abrigo_id);

        return Ok(abrigo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdAbrigo(int id)
    {
        var abrigo =  _PetRepository.GetId(id);
        return Ok(abrigo);
    }

    [HttpPost("atualizar/{id}")]
    public async Task<IActionResult> UpdateAbrigo([FromForm] UpdatePetDto dto, int id, [FromForm] AbrigoLoginDto abrigo)
    {
        await _PetRepository.Update(dto, id, abrigo);
        return NoContent();
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteTutor([FromBody] AbrigoLoginDto dto,int id)
    {
        await _PetRepository.Delete(id,dto);
        return NoContent();
    }

  

 
}
