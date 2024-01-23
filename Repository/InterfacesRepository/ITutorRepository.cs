using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Models;

namespace Adopt_Pet.Api.Repository.InterfacesRepository;

public interface ITutorRepository
{
     Task Save(TutorDto dto);
    Task<TutorModel> GetIdTutor(string id);
}
