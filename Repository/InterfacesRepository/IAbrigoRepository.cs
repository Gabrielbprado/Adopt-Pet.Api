using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IAbrigoRepository
{
     Task Save(AbrigoDto dto);
    Task<ReadAbrigoDto> GetIdAbrigo(string id);
    Task UpdateAbrigo(AbrigoDto dto,string id);
    Task Delete(string id);
    Task<string> Login(AbrigoLoginDto dto);
    Task<IEnumerable<ReadAbrigoDto>> GetAllAbrigo();
}
