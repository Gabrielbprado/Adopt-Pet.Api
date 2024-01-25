using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.TutorDtos
{
    public class TutorLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
