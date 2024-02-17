using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.PetDtos;

public class PetDto
{
    [Required]
    public int abrigo_id { get; set; }
    [Required]
    public string name { get; set; } = null!;
    [Required]
    public string description { get; set; } = null!;
    [Required]
    public string age { get; set; } = null!;
    [Required]
    public string address { get; set; } = null!;
    [Required]
    public IFormFile PhotoFile { get; set; } = null!;
 
}
