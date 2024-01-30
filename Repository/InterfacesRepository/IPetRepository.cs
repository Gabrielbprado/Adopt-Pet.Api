using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface IPetRepository : IBaseRepository<PetDto,ReadPetDto, UpdatePetDto,PetModel>
{
     Task Save(PetDto model);
    Task Update(UpdatePetDto dto,int id, AbrigoLoginDto dtoAbrigo);
    Task Delete(int id, AbrigoLoginDto dto);
    IEnumerable<ReadPetDto> GetAll(int? Abrigo_id = null);

}
