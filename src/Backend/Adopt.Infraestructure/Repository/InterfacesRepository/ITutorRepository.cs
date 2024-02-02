using Adopt_Pet.Api.Data.Dtos.TutorDtos;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface ITutorRepository
{
     Task Save(TutorDto dto);
    Task<ReadTutorDto> GetIdTutor(string id);
    Task UpdateTutor(TutorDto dto,string id);
    Task Delete(string id);
    Task<string> Login(TutorLoginDto dto);
}
