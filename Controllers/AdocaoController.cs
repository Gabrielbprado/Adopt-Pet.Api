using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.AdocaoDtos;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Controllers;
[ApiController]
[Route("api/[controller]/v1")]
public class AdocaoController : ControllerBase
{
    private readonly IAdocaoRepository _adocaoRepository;

    public AdocaoController(IAdocaoRepository adocaoRepository)
    {
        _adocaoRepository = adocaoRepository;
    }

    [HttpPost("adotar")]
    public async Task<IActionResult> Save([FromBody] AdocaoDto dto)
    {
        await _adocaoRepository.Adopte(dto);
        return Ok("Tutor Cadastrado");
    }

    

    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> DeleteAdocao([FromBody] AbrigoLoginDto dto,int id)
    {
        await _adocaoRepository.Delete(id,dto);
        return NoContent();
    }

 

 
}
