using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adopt_Pet.Api.Models;

public class PetModel
{
    [Key]
    [Required]
    public int id { get; set; }
    [Required]
    public int Abrigo_id { get; set; }
    [Required]
    public string name { get; set; } = null!;
    [Required]
    public string description { get; set; } = null!;
    [Required]
    public bool adopted { get; set; }
    [Required]
    public string age { get; set; } = null!;
    [Required]
    public string address { get; set; } = null!;
    [NotMapped]
    public IFormFile PhotoFile { get; set; } = null!;
    public virtual AbrigoModel AbrigoModel { get; set; } = null!;
    public virtual AdocaoModel AdocaoModel { get; set; } = null!;


}
