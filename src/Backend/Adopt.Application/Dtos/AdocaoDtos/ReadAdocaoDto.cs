using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;

namespace Adopt_Pet.Api.Data.Dtos.AdocaoDtos
{
    public class ReadAdocaoDto
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public ReadPetDto ReadPetDto { get; set; } = null!;
        public ReadTutorDto ReadTutorDto { get; set; } = null!;
    }
}
