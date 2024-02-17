using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers.Abrigo;
[ApiController]
[Route("api/[controller]/v1")]
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

    [HttpGet("listarAll")]
    public  async Task<IActionResult> GetAllAbrigo()
    {
        var abrigo =  await _abrigoRepository.GetAll();
        return Ok(abrigo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdAbrigo(int id)
    {
        var abrigo = await _abrigoRepository.GetId(id);
        return Ok(abrigo);
    }

    [HttpPost("atualizar/{id}")]
    public async Task<IActionResult> UpdateAbrigo([FromBody] UpdateAbrigoDto dto, int id)
    {
        await _abrigoRepository.Update(dto, id);
        return NoContent();
    }

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteTutor(int id)
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
