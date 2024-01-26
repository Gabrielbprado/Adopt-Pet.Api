using Adopt_Pet.Api.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.AdocaoDtos
{
    public class AdocaoDto
    {
    

       
        public int pet_id { get; set; }
     
        public string tutor_id { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
