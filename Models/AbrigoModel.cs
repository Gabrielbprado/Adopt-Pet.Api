using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Models
{
    public class AbrigoModel 
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string State { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]

        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        public string CNPJ { get; set; } = null!;


    }
}
