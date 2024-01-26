using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.AdocaoDtos;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IAdocaoRepository
{
     Task Adopte(AdocaoDto dto);
    Task Delete(int id, AbrigoLoginDto dto);
}
