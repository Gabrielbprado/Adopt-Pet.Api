using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers.Abrigo;
[ApiController]
[Route("api/[controller]")]
public class AbrigoController : ControllerBase
{
    private readonly IAbrigoRepository _abrigoRepository;

    public AbrigoController(IAbrigoRepository abrigorepository)
    {
        _abrigoRepository = abrigorepository;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Save([FromBody] AbrigoDto dto)
    {
        await _abrigoRepository.Save(dto);
        return Ok("Abrigo Cadastrado");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdAbrigo(string id)
    {
        var abrigo = await _abrigoRepository.GetIdAbrigo(id);
        return Ok(abrigo);
    }

    [HttpPost("atualizar/{id}")]
    public async Task<IActionResult> UpdateAbrigo([FromBody] AbrigoDto dto, string id)
    {
        await _abrigoRepository.UpdateAbrigo(dto, id);
        return NoContent();
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteTutor(string id)
    {
        await _abrigoRepository.Delete(id);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AbrigoLoginDto dto)
    {
       var token = await _abrigoRepository.Login(dto);
        return Ok(token);
       
    }

 
}
