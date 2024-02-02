using Microsoft.AspNetCore.Identity;

namespace Adopt_Pet.Api.Models
{
    public class TutorModel : IdentityUser
    {
        public string City { get; set; } = null!;

        public string State { get; set; } = null!;
        public virtual AdocaoModel AdocaoModel { get; set; }

        public TutorModel() : base() { }
     
    }
}
