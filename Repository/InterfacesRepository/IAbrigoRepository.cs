using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IAbrigoRepository : IBaseRepository<AbrigoDto,ReadAbrigoDto, UpdateAbrigoDto,AbrigoModel>
{
    Task Delete(AbrigoLoginDto dto,int id);
    Task Save(AbrigoDto dto);
    Task<string> Login(AbrigoLoginDto dto);
}
