using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IAbrigoRepository
{
     Task Save(AbrigoDto dto);
    Task<ReadAbrigoDto> GetIdAbrigo(int id);
    Task UpdateAbrigo(AbrigoDto dto, int id);
    Task Delete(int id);
    Task<string> Login(AbrigoLoginDto dto);
    IEnumerable<ReadAbrigoDto> GetAllAbrigo();
}
