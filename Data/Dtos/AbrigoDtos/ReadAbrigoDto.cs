using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Data.Dtos.AbrigoDtos
{
    public class ReadAbrigoDto
    {

        public string Username { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;


        public string Email { get; set; } = null!;


        public int PhoneNumber { get; set; }
        public int CNPJ { get; set; }
    }
}
