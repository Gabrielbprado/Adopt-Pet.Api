using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IAbrigoRepository : IBaseRepository<AbrigoDto,ReadAbrigoDto, UpdateAbrigoDto,AbrigoModel>
{
    Task<bool> Delete(AbrigoLoginDto dto,int id);
    Task<bool> Save(AbrigoDto dto);
    Task<string> Login(AbrigoLoginDto dto);
    bool IsValidCnpj(string cnpj);
    public string HashPassword(string password);
}
