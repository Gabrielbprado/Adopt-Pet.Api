using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.AdocaoDtos;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IAdocaoRepository
{
     Task Adopte(AdocaoDto dto);
    Task Delete(int id, AbrigoLoginDto dto);
}
