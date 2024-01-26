using adopt_pet.api.data.dtos.abrigodtos;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.PetDtos;

public class ReadPetDto
{


    public string name { get; set; } = null!;
 
    public string description { get; set; } = null!;
  
    public bool adopted { get; set; }
 
    public string age { get; set; } = null!;
 
    public string address { get; set; } = null!;

    public string image { get; set; } = null!;
    public ReadAbrigoDto ReadAbrigoDto { get; set; } =  null!;
}
