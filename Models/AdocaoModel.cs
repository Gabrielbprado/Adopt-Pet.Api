using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adopt_Pet.Api.Models
{
    public class AdocaoModel 
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public int pet_id { get; set; }
        [Required]
        public string tutor_id { get; set; } = null!;
        public DateTime Date { get; set; }
        public virtual PetModel PetModel { get; set; } = null!;
        public virtual TutorModel TutorModel { get; set; } = null!;


    }
}
