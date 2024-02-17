

namespace adopt_pet.api.data.dtos.abrigodtos
{
    public class ReadAbrigoDto
    {
        public int id { get; set; }
        public string username { get; set; } = null!;

        public string city { get; set; } = null!;

        public string state { get; set; } = null!;


        public string email { get; set; } = null!;


        public string phonenumber { get; set; } = null!;
        public string CNPJ { get; set; } = null!;
    }
}
