using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IPetRepository : IBaseRepository<PetDto,ReadPetDto, UpdatePetDto,PetModel>
{
     Task<bool> Save(PetDto model);
    Task<bool> Update(UpdatePetDto dto,int id, AbrigoLoginDto dtoAbrigo);
    Task<bool> Delete(int id, AbrigoLoginDto dto);
    Task<IEnumerable<ReadPetDto>> GetAll(int? Abrigo_id = null);

}
