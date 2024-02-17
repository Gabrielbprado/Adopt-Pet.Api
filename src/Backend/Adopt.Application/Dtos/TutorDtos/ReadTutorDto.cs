using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.TutorDtos
{
    public class ReadTutorDto
    {

        public string Username { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;


        public string Email { get; set; } = null!;


        public string PhoneNumber { get; set; } = null!;
        public byte[] databytes { get; set; } = null!;
    }
}
