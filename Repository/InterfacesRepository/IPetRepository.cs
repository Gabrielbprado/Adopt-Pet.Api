using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IPetRepository
{
     Task Save(PetDto dto);
    Task<ReadPetDto> GetIdPet(int id);
    Task UpdatePet(PetDto dto, int id);
    Task Delete(int id,AbrigoLoginDto dto);
    IEnumerable<ReadPetDto> GetAllPet(int? Abrigo_id = null);
}
