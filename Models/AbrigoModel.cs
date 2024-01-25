using Microsoft.AspNetCore.Identity;

namespace Adopt_Pet.Api.Models
{
    public class AbrigoModel : IdentityUser
    {
        public string City { get; set; } = null!;

        public string State { get; set; } = null!;
        public string CNPJ { get; set; } = null!;
        public AbrigoModel() : base() { }
     
    }
}
