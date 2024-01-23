using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos
{
    public class ReadTutorDto
    {
    
        public string Username { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
